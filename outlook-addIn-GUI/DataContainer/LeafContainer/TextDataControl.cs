using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAFramework;

namespace OAGUI.DataControl
{
    public class TextDataControl : LargeTextDataContainer
    {
        private System.Windows.Forms.TextBox textBox1;

        public override void UpdateControl()
        {
            FieldText = TypedData.DataField.FieldName;
            TextValue = TypedData.TextValue;
        }

        private string TextValue
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        public override void UpdateDataUnitWithControlValue()
        {
            TypedData.TextValue = TextValue;
        }
        
        public override void InitializeComponent()
        {
            base.InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextDataControl));
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
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
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 0;
            // 
            // TextDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "TextDataControl";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
