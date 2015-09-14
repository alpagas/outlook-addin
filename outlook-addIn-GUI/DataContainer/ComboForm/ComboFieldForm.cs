using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OAFramework;

namespace OAGUI.DataContainer.ComboForm
{
    public partial class CombofieldForm : Form
    {
        private EFDataField _field;

        private BindingSource bs;
        public BindingSource Source
        {
            get
            {
                return bs;
            }
        }
        
        public CombofieldForm()
        {
            InitializeComponent();
        }

        public DataGridView GridView
        {
            get
            {
                return combovalueGridView;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           AcceptButton.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AcceptButton.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public ICollection<EFFieldComboValue> Values
        {
            get
            {
                return ((ICollection<EFFieldComboValue>)Source.List);
            }
        }

        public void InitializeComboField(EFDataField field)
        {
            _field = field;
            bs = new BindingSource() {AllowNew = true};
            bs.DataSource = field.ComboValues.ToList();
            GridView.DataSource = bs;
            foreach (DataGridViewColumn t in GridView.Columns)
            {
                t.Visible = (t.Name == "ComboValue");
            }
        }

    }
}
