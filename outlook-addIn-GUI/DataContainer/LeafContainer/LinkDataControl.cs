using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OAFramework;

namespace OAGUI.DataControl
{
    public class LinkDataControl : LargeLinkDataContainer
    {
        private System.Windows.Forms.LinkLabel linkLabel1;

        public override void UpdateControl()
        {
            FieldText = "";//TypedData.DataField.FieldName;
            LabelValue = TypedData.LinkValue;
        }

        private string LabelValue
        {
            get
            {
                return linkLabel1.Text;
            }
            set
            {
                linkLabel1.Text = value;
                linkLabel1.Links.Add(new LinkLabel.Link() { LinkData = value });
            }
        }

        public override void UpdateDataUnitWithControlValue()
        {
            TypedData.LinkValue = LabelValue;
        }
        
        public override void InitializeComponent()
        {
            base.InitializeComponent();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
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
            this.splitContainer1.Panel2.Controls.Add(this.linkLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(187, 52);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(187, 25);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // LinkDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "LinkDataControl";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}
