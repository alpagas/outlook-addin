using System.Diagnostics;

namespace OAGUI.DataControl
{
    partial class SmallDataContainer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        public virtual void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmallDataContainer));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fieldName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPanel = new System.Windows.Forms.Panel();
            this.upBtn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.downBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.btnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "button_down_9x9.gif");
            this.imageList1.Images.SetKeyName(1, "button_up_9x9.gif");
            this.imageList1.Images.SetKeyName(2, "button_down_dis_9x9.gif");
            this.imageList1.Images.SetKeyName(3, "button_up_dis_9x9.gif");
            this.imageList1.Images.SetKeyName(4, "delete_9x9.png");
            this.imageList1.Images.SetKeyName(5, "edit_9x9.png");
            this.imageList1.Images.SetKeyName(6, "plus_16x16.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fieldName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(248, 25);
            this.splitContainer1.SplitterDistance = 78;
            this.splitContainer1.TabIndex = 0;
            // 
            // fieldName
            // 
            this.fieldName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldName.Location = new System.Drawing.Point(0, 0);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(78, 25);
            this.fieldName.TabIndex = 0;
            this.fieldName.Text = "fieldName";
            this.fieldName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 25);
            this.panel1.TabIndex = 0;
            // 
            // btnPanel
            // 
            this.btnPanel.AutoSize = true;
            this.btnPanel.Controls.Add(this.upBtn);
            this.btnPanel.Controls.Add(this.btnDelete);
            this.btnPanel.Controls.Add(this.downBtn);
            this.btnPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPanel.Location = new System.Drawing.Point(139, 0);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(27, 25);
            this.btnPanel.TabIndex = 0;
            this.btnPanel.Visible = false;
            // 
            // upBtn
            // 
            this.upBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upBtn.FlatAppearance.BorderSize = 0;
            this.upBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upBtn.ImageIndex = 1;
            this.upBtn.ImageList = this.imageList1;
            this.upBtn.Location = new System.Drawing.Point(16, 0);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(0, 25);
            this.upBtn.TabIndex = 5;
            this.upBtn.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ImageIndex = 4;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(16, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(11, 25);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // downBtn
            // 
            this.downBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.downBtn.FlatAppearance.BorderSize = 0;
            this.downBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downBtn.ImageIndex = 0;
            this.downBtn.ImageList = this.imageList1;
            this.downBtn.Location = new System.Drawing.Point(0, 0);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(16, 25);
            this.downBtn.TabIndex = 2;
            this.downBtn.UseVisualStyleBackColor = true;
            // 
            // SmallDataContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SmallDataContainer";
            this.Size = new System.Drawing.Size(248, 25);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.btnPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.SplitContainer splitContainer1;
        protected System.Windows.Forms.Label fieldName;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Panel btnPanel;
        protected System.Windows.Forms.Button downBtn;
        public System.Windows.Forms.Button btnDelete;
        protected System.Windows.Forms.Button upBtn;


    }
}
