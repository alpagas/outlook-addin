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

    public class ComboDataControl : LargeComboDataContainer
    {
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ComboBox comboBox1;

        public override void UpdateControl()
        {
            button1.Visible = (!TypedData.IsStatic);
            FieldText = TypedData.DataField.FieldName;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("");
            comboBox1.Items.AddRange(TypedData.GetValuesForCombo().ToArray());
            SelectedValue = TypedData.SelectedValue;
        }

        private string SelectedValue
        {
            get
            {
                if ((comboBox1.SelectedIndex == -1) || (string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
                    || string.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString())) return null;
                return comboBox1.SelectedItem.ToString();
            }
            set
            {
                if (value == null) comboBox1.SelectedIndex = -1;
                else
                {
                    int i = comboBox1.Items.IndexOf(value);
                    comboBox1.SelectedIndex = i;
                }
            }
        }

        public override void UpdateDataUnitWithControlValue()
        {
            TypedData.SelectedValue = SelectedValue;
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComboDataControl));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
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
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.comboBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.button1);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.splitContainer3.Size = new System.Drawing.Size(170, 25);
            this.splitContainer3.SplitterDistance = 140;
            this.splitContainer3.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.ImageIndex = 5;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ComboDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ComboDataControl";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var comboForm = new CombofieldForm())
            {
                comboForm.InitializeComboField(TypedData.DataField);
                //var currentLocation = this.Location;
                //comboForm.Location = new Point(currentLocation.X, currentLocation.Y + this.Height);

                var button = ((Control)sender);
                var bounds = button.Bounds;
                var point = button.PointToScreen(new Point(button.Right, button.Bottom));
                comboForm.Load += (o, args) =>
                {
                    var form = ((Form)o);
                    form.Location = new Point(point.X - form.Width, point.Y);
                };
                comboForm.ShowDialog(this);
                if (comboForm.AcceptButton.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        var cbToDeleted = TypedData.DataField.ComboValues.ToList().FindAll(x => !comboForm.Values.Contains(x));
                        for (int i = 0; i < cbToDeleted.Count; i++)
                        {
                            OADBManager.Instance.DBContext.Entry(cbToDeleted[i]).State = EntityState.Deleted;
                        }
                        TypedData.DataField.ComboValues = comboForm.Values;
                        OADBManager.Instance.DBContext.SaveChanges();
                        UpdateControl();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
