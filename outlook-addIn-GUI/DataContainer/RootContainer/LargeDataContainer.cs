using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using OAFramework;
using OAGUI.DataContainer;
using log4net;

namespace OAGUI.DataControl
{
    public partial class LargeDataContainer : DataContainer
    {
        
        public LargeDataContainer()
        {
            InitializeComponent();
        }
        
        private void btnShow_Click(object sender, EventArgs e)
        {
            PanelVisible = !PanelVisible;
        }

        private string fieldtext;
        protected override string FieldText
        {
            get
            {
                return fieldtext;
            }
            set
            {
                fieldtext = value;
                fieldName.Text = fieldtext;

            }
        }

        public override bool EnableUp
        {
            get
            {
                return upBtn.Enabled;
            }
            set
            {
                upBtn.Enabled = value;
                upBtn.ImageIndex = upBtn.Enabled ? 1 : 3;
            }
        }

        public override bool EnableDown
        {
            get
            {
                return downBtn.Enabled;
            }
            set
            {
                downBtn.Enabled = value;
                downBtn.ImageIndex = downBtn.Enabled ? 0 : 2;
            }
        }

        private bool showEditItem;
        public override bool ShowEditItem
        {
            get
            {
                return showEditItem;
            }
            set
            {
                showEditItem = value;
                upBtn.Visible = showEditItem;
                downBtn.Visible = showEditItem;
                btnDelete.Visible = showEditItem;
            }
        }

        public bool PanelVisible
        {
            get
            {
                return splitContainer1.Panel2Collapsed;
            }
            set
            {
                splitContainer1.Panel2Collapsed = value;
                this.btnShow.ImageIndex = (splitContainer1.Panel2Collapsed) ? 3 : 2;
            }
        }

        protected override void btnDown_Click(object sender, EventArgs e)
        {
            base.btnDown_Click(sender, e);
        }

        protected override void btnUp_Click(object sender, EventArgs e)
        {
            base.btnUp_Click(sender, e);
        }

        protected override void btnDelete_Click(object sender, EventArgs e)
        {
            base.btnDelete_Click(sender, e);
        }
    }
}
