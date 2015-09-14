using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAFramework;

namespace OAGUI.DataControl
{  
    public class CheckDataControl : LargeCheckDataContainer
    {
        private System.Windows.Forms.CheckBox checkBox1;

        public override void UpdateControl()
        {
            FieldText = TypedData.DataField.FieldName;
            CheckValue = TypedData.CheckValue;
        }

        private bool CheckValue
        {
            get
            {
                return checkBox1.Checked;
            }
            set
            {
                checkBox1.Checked = value;
            }
        }

        public override void UpdateDataUnitWithControlValue()
        {
            TypedData.CheckValue = CheckValue;
        }
        
        public override void InitializeComponent()
        {
            base.InitializeComponent();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            this.splitContainer1.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer1.Size = new System.Drawing.Size(187, 52);
            // 
            // checkBox1
            // 
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(187, 25);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Value";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // CheckDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "CheckDataControl";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
