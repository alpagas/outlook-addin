using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using OAFramework;
using OAFramework.Configuration;

using OAGUI.DataContainer.ComboForm;

namespace OAGUI.DataControl
{

    public class NumberDataControl : SmallNumberDataContainer
    {
        private System.Windows.Forms.SplitContainer splitContainer3;

        private System.Windows.Forms.Button button1;
        private TextBox textBox1;

        private System.ComponentModel.IContainer components;

        public override void UpdateControl()
        {

            FieldText = TypedData.DataField.FieldName;
            NumberValue = TypedData.NumberValue;

        }

        public override void UpdateDataUnitWithControlValue()
        {
            TypedData.NumberValue = NumberValue;
        }

        private double NumberValue
        {
            get
            {
                double result;
                if (double.TryParse(textBox1.Text, NumberStyles.None, CultureInfo.InvariantCulture, out result))
                {
                    return result;
                }
                return 0;
            }
            set
            {
                double result;
                if (double.TryParse(value.ToString(), NumberStyles.None, CultureInfo.InvariantCulture, out result))
                {
                    textBox1.Text = result.ToString();
                }
                else
                {
                    textBox1.Text = "0";
                }
            }
        }


        public override void InitializeComponent()
        {
            base.InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumberDataControl));
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.btnPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
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
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.SetChildIndex(this.btnPanel, 0);
            this.panel1.Controls.SetChildIndex(this.textBox1, 0);
            // 
            // downBtn
            // 
            this.downBtn.FlatAppearance.BorderSize = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            // 
            // upBtn
            // 
            this.upBtn.FlatAppearance.BorderSize = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.button1);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.splitContainer3.Size = new System.Drawing.Size(166, 25);
            this.splitContainer3.SplitterDistance = 135;
            this.splitContainer3.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating);
            // 
            // NumberDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "NumberDataControl";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.btnPanel.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if ((currenttb.Text == "") || !Regex.IsMatch(currenttb.Text, @"^\d+$"))
            {
                currenttb.BackColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                currenttb.ResetBackColor();
            }
        }
    }
}
