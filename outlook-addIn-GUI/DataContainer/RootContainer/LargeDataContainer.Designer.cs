namespace OAGUI.DataControl
{
    partial class LargeDataContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LargeDataContainer));
            this.downBtn = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.upBtn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.fieldName = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
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
            this.downBtn.TabIndex = 1;
            this.downBtn.UseVisualStyleBackColor = true;
            this.downBtn.Click += new System.EventHandler(this.btnDown_Click);
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
            // upBtn
            // 
            this.upBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upBtn.FlatAppearance.BorderSize = 0;
            this.upBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upBtn.ImageIndex = 1;
            this.upBtn.ImageList = this.imageList1;
            this.upBtn.Location = new System.Drawing.Point(0, 0);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(41, 25);
            this.upBtn.TabIndex = 2;
            this.upBtn.UseVisualStyleBackColor = true;
            this.upBtn.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ImageIndex = 4;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(30, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(11, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnShow);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(170, 54);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(22, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.fieldName);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer2.Panel2.Controls.Add(this.downBtn);
            this.splitContainer2.Panel2.Controls.Add(this.upBtn);
            this.splitContainer2.Size = new System.Drawing.Size(148, 25);
            this.splitContainer2.SplitterDistance = 103;
            this.splitContainer2.TabIndex = 0;
            // 
            // fieldName
            // 
            this.fieldName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldName.Location = new System.Drawing.Point(0, 0);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(103, 25);
            this.fieldName.TabIndex = 0;
            this.fieldName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnShow
            // 
            this.btnShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.ImageIndex = 2;
            this.btnShow.ImageList = this.imageList1;
            this.btnShow.Location = new System.Drawing.Point(0, 0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(24, 25);
            this.btnShow.TabIndex = 1;
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // DataContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "DataContainer";
            this.Size = new System.Drawing.Size(170, 54);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.SplitContainer splitContainer2;
        protected System.Windows.Forms.Button downBtn;
        protected System.Windows.Forms.Button upBtn;
        protected System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label fieldName;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnShow;


    }
}
