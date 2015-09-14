using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OAFramework;

namespace OAGUI.DataControl
{
    public class AmountDataControl : LargeAmountDataContainer
    {
        private ComboBox comboBox1;
        private MaskedTextBox maskedTextBox1;

        public override void UpdateControl()
        {
            FieldText = TypedData.DataField.FieldName;
            AmountValue = TypedData.Amount;
            Currency = TypedData.Ccy;
        }

        private double AmountValue
        {
            get
            {
                return double.Parse(maskedTextBox1.Text);
            }
            set
            {
                double result;
                if(double.TryParse(value.ToString(),NumberStyles.None,CultureInfo.InvariantCulture,out result))
                {
                    maskedTextBox1.Text = result.ToString();
                }
                else
                {
                    maskedTextBox1.Text = "0";
                }
            }
        }

        private string Currency
        {
            get
            {
                return comboBox1.SelectedItem.ToString();
            }
            set
            {
                var idx = comboBox1.Items.IndexOf(value);
                comboBox1.SelectedIndex=idx;
            }
        }

        public override void UpdateDataUnitWithControlValue()
        {
            TypedData.Amount = AmountValue;
            TypedData.Ccy = Currency;
        }
        
        public override void InitializeComponent()
        {
            base.InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmountDataControl));
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            // 
            // downBtn
            // 
            this.downBtn.FlatAppearance.BorderSize = 0;
            // 
            // upBtn
            // 
            this.upBtn.FlatAppearance.BorderSize = 0;
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.maskedTextBox1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "button_down_9x9.gif");
            this.imageList1.Images.SetKeyName(1, "button_up_9x9.gif");
            this.imageList1.Images.SetKeyName(2, "button_down_dis_9x9.gif");
            this.imageList1.Images.SetKeyName(3, "button_up_dis_9x9.gif");
            this.imageList1.Images.SetKeyName(4, "delete_9x9.png");
            this.imageList1.Images.SetKeyName(5, "edit_9x9.png");
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.maskedTextBox1.Location = new System.Drawing.Point(0, 0);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(138, 20);
            this.maskedTextBox1.TabIndex = 0;
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBox1.ValidatingType = typeof(double);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "EUR",
            "USD",
            "GBP",
            "CHF",
            "JPY",
            "HKD"});
            this.comboBox1.Location = new System.Drawing.Point(138, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(32, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // AmountDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "AmountDataControl";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
