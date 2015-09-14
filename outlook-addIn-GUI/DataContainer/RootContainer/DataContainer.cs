using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OAFramework;
using OAGUI.DataControl;
using log4net;

namespace OAGUI.DataControl
{
    public partial class DataContainer : UserControl
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(LargeDataContainer));

        public event EventHandler UpClick;
        public event EventHandler DownClick;
        public event EventHandler DeleteClick;

        private void OnUpClick()
        {
            if (UpClick != null)
            {
                UpClick(this, EventArgs.Empty);
            }
        }

        private void OnDownClick()
        {
            if (DownClick != null)
            {
                DownClick(this, EventArgs.Empty);
            }
        }

        private void OnDeleteClick()
        {
            if (DeleteClick != null)
            {
                DeleteClick(this, EventArgs.Empty);
            }
        }

        private IDataUnit rData;
        public IDataUnit Data
        {
            get
            {
                return rData;
            }
            set
            {
                rData = value;
                UpdateControl();
            }
        }

        public virtual void UpdateControl()
        {

        }
        
        protected virtual string FieldText { get; set; }
        
        protected virtual void btnDown_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if ((btn != null) && (btn.Enabled))
            {
                OnDownClick();
            }
        }

        protected virtual void btnUp_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if ((btn != null) && (btn.Enabled))
            {
                OnUpClick();
            }
        }

        protected virtual void btnDelete_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if ((btn != null) && (btn.Enabled))
            {
                OnDeleteClick();
            }
        }

        public virtual bool EnableUp { get; set; }
        public virtual bool EnableDown{ get; set; }
        public virtual bool ShowEditItem { get; set; }
        
        public virtual void ResetControlValueIfNeeded()
        {
            if (Data.DataField != null)
            {
                Data = Data.DataField.CreateDataUnit(true);
                UpdateControl();
            }
            else
            {
                Logger.ErrorFormat("We should not go here !!!=> {0}", Data.ControlClassName);
            }
        }

        public virtual void UpdateDataUnitWithControlValue()
        {

        }


        public DataContainer()
        {
            InitializeComponent();
        }
    }
}
