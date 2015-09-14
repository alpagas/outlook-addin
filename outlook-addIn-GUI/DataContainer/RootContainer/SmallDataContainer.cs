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

using log4net;

namespace OAGUI.DataControl
{
    public partial class SmallDataContainer : DataContainer
    {
     
        public SmallDataContainer()
        {
            InitializeComponent();
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
                //btnPanel.Visible = showEditItem;
            }
        }

        protected override void btnDown_Click(object sender, EventArgs e)
        {
          base.btnDown_Click(sender,e);
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
