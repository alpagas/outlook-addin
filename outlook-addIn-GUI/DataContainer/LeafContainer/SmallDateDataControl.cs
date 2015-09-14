using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OAFramework;
using OAFramework.Configuration;

using OAGUI.DataContainer.ComboForm;

namespace OAGUI.DataControl
{

    public class SmallDateDataControl : SmallDateDataContainer
    {
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button button1;
        private DateTimePicker dateTimePicker1;

        private System.ComponentModel.IContainer components;

        public override void UpdateControl()
        {
            FieldText = TypedData.DataField.FieldName;
            DateValue = (TypedData.DateValue == DateTime.MinValue) ? (DateTime.Now) : TypedData.DateValue;
        }

        private DateTime DateValue
        {
            get
            {
                return dateTimePicker1.Value;
            }
            set
            {
                dateTimePicker1.Value = value;
            }
        }

        public override void UpdateDataUnitWithControlValue()
        {
            TypedData.DateValue = DateValue;
        }


        public override void InitializeComponent()
        {
            base.InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmallDateDataControl));
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
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
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.SetChildIndex(this.btnPanel, 0);
            this.panel1.Controls.SetChildIndex(this.dateTimePicker1, 0);
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker1.Location = new System.Drawing.Point(0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // SmallDateDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "SmallDateDataControl";
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


    }
}
