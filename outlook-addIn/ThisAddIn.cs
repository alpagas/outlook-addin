using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using log4net;
using OAFramework;
using OAFramework.Configuration;
using OAMail;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace outlook_addIn
{
    public partial class ThisAddIn
    {
        private OAPanel _mailPanel;
        private Office.CustomTaskPane _myCustomTaskPane;
        private Outlook.Explorer _explorerReference;
        private MailSelection rMailSelection;

        private static readonly ILog _logger = LogManager.GetLogger(typeof(ThisAddIn));

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            InitializeDBConnection();
            AddOAMailPanel();
            AddOAMailToolBox();
            LinkSelectionChange();
        }

        private void InitializeDBConnection()
        {
            try
            {
                OADBManager.CreateInstance();
            }
            catch (Exception e)
            {
                _logger.Error("Initialisation fail !" + e);
            }
        }

        private void AddOAMailToolBox()
        {

        }

        private void AddOAMailPanel()
        {
            try
            {
                _mailPanel = new OAPanel();
                _mailPanel.Application = Application;
                _myCustomTaskPane = this.CustomTaskPanes.Add(_mailPanel, "Outlook-Addin");
                _mailPanel.Dock = DockStyle.Fill;
                _myCustomTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionFloating;
                _myCustomTaskPane.Width = 210;
                _myCustomTaskPane.Height = 175;
                _myCustomTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
                _myCustomTaskPane.Visible = true;
            }
            catch (Exception e)
            {
                _logger.Error("Error while creating OAPanel :" + e);
                throw e;
            }
        }

        private void LinkSelectionChange()
        {
            _explorerReference = Application.ActiveExplorer();

            foreach (Outlook.Explorer Exp in Application.Explorers)
            {
                Exp.SelectionChange += new Outlook.ExplorerEvents_10_SelectionChangeEventHandler(ThisAddIn_SelectionChange);
            }
        }

        private Outlook.MailItem lastSelectedMail;
        public Outlook.MailItem LastSelectedMail
        {
            get
            {
                return lastSelectedMail;
            }
            set
            {
                lastSelectedMail = value;
                if (lastSelectedMail != null)
                    _mailPanel.SelectedMail = MailManager.GetMailGroup(lastSelectedMail);
            }
        }


        private void ThisAddIn_SelectionChange()
        {
            if (_myCustomTaskPane.Visible)
            {

                var NewMailSelection = new MailSelection(Application.ActiveExplorer().Selection);
                if ((rMailSelection == null) || (!rMailSelection.Equals(NewMailSelection)))
                {
                    _mailPanel.CleanOAPanel();
                    rMailSelection = NewMailSelection;
                    if (rMailSelection.Count == 1)
                        LastSelectedMail = rMailSelection[0];
                    else
                        LastSelectedMail = null;

                }
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
