using System.Windows.Forms;

namespace ElectronicJournal.Forms
{
    partial class SubjectForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTeacher;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.ComboBox cmbControl;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTeacher = new System.Windows.Forms.TextBox();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.cmbControl = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            System.Windows.Forms.Label lblName = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblTeacher = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblHours = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblControl = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            lblName.Text = "Назва:";
            lblName.Location = new System.Drawing.Point(30, 32);
            lblName.Size = new System.Drawing.Size(80, 20);

            lblTeacher.Text = "Викладач:";
            lblTeacher.Location = new System.Drawing.Point(30, 62);
            lblTeacher.Size = new System.Drawing.Size(80, 20);

            lblHours.Text = "Годин:";
            lblHours.Location = new System.Drawing.Point(30, 92);
            lblHours.Size = new System.Drawing.Size(80, 20);

            lblControl.Text = "Форма контролю:";
            lblControl.Location = new System.Drawing.Point(30, 122);
            lblControl.Size = new System.Drawing.Size(80, 20);

            this.txtName.Location = new System.Drawing.Point(120, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 0;

            this.txtTeacher.Location = new System.Drawing.Point(120, 60);
            this.txtTeacher.Name = "txtTeacher";
            this.txtTeacher.Size = new System.Drawing.Size(200, 20);
            this.txtTeacher.TabIndex = 1;

            this.numHours.Location = new System.Drawing.Point(120, 90);
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(100, 20);
            this.numHours.Maximum = 500;
            this.numHours.TabIndex = 2;

            this.cmbControl.Location = new System.Drawing.Point(120, 120);
            this.cmbControl.Name = "cmbControl";
            this.cmbControl.Size = new System.Drawing.Size(150, 20);
            this.cmbControl.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbControl.Items.AddRange(new object[] { "Залік", "Іспит" });
            this.cmbControl.TabIndex = 3;

            this.btnAdd.Location = new System.Drawing.Point(120, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Location = new System.Drawing.Point(220, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.dataGridView1.Location = new System.Drawing.Point(20, 210);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(560, 250);
            this.dataGridView1.TabIndex = 6;

            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbControl);
            this.Controls.Add(this.numHours);
            this.Controls.Add(this.txtTeacher);
            this.Controls.Add(this.txtName);
            this.Controls.Add(lblControl);
            this.Controls.Add(lblHours);
            this.Controls.Add(lblTeacher);
            this.Controls.Add(lblName);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 480);
            this.Name = "SubjectForm";
            this.Text = "Предмети";

            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}