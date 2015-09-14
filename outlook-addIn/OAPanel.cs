using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using log4net.Util;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using OAFramework;
using OAFramework.User;
using OAGUI;
using OAGUI.DataControl;

namespace OAMail
{
    public partial class OAPanel : UserControl
    {
        public Outlook.Application Application;
        
        private IMail selectedMail;
        public IMail SelectedMail
        {
            get
            {
                return selectedMail;
            }
            set
            {
                selectedMail = value;
                SetDataContainerWithMailChildren();
            }
        }

        private void SetDataContainerWithMailChildren()
        {
            if (selectedMail != null)
            {
                foreach (var dataUnit in selectedMail.DataUnits)
                {
                    var container = GetDataContainerFromFlowPanel(flowLayoutPanelValue, dataUnit);
                    if (container != null)
                    {
                        container.Data = dataUnit;
                    }
                }
            }
        }

        private DataContainer GetDataContainerFromFlowPanel(DataContainerLayoutPanel panel, EFDataUnit dataUnit)
        {
            foreach (var container in panel.Controls.OfType<DataContainer>())
            {
                if (container.Data.DataField.Equals(dataUnit.DataField)) return container;
            }
            return null;
        }

        public OAPanel()
        {
            InitializeComponent();
            MailManager.FillCacheWithAllMailForUser(UserManager.UserGroup);
            InitializePluginPanelWithTemplate();
        }

        private void InitializePluginPanelWithTemplate()
        {
            var template = TemplateManager.GetDefaultTemplatesForUserGroup(UserManager.UserGroup);
            configLabel.Text = string.Format("Template : {0} \n User Group : {1} \n User : {2}", template.ElementName, UserManager.UserGroup.UserGroupName, UserManager.UserName);
            FieldManager.BuildDataContainerFromTemplate(template, flowLayoutPanelValue, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedMail != null)
            {
                MailManager.SaveMail(selectedMail, FieldManager.ExtractDataUnitFromPanel(flowLayoutPanelValue));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        public void CleanOAPanel()
        {
            foreach (var container in flowLayoutPanelValue.Controls.OfType<DataContainer>())
            {
                container.ResetControlValueIfNeeded();
            }
        }
    }
}
