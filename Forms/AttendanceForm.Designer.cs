using System.Windows.Forms;

namespace ElectronicJournal.Forms
{
    partial class AttendanceForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Button btnPresent;
        private System.Windows.Forms.Button btnAbsent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblStats;

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
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.btnPresent = new System.Windows.Forms.Button();
            this.btnAbsent = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblStats = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbStudent
            // 
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.Location = new System.Drawing.Point(160, 37);
            this.cmbStudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(332, 24);
            this.cmbStudent.TabIndex = 17;
            this.cmbStudent.SelectedIndexChanged += new System.EventHandler(this.cmbStudent_SelectedIndexChanged);
            // 
            // cmbSubject
            // 
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.Location = new System.Drawing.Point(160, 74);
            this.cmbSubject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(332, 24);
            this.cmbSubject.TabIndex = 16;
            this.cmbSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSubject_SelectedIndexChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(160, 111);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(265, 22);
            this.dtpDate.TabIndex = 15;
            // 
            // cmbReason
            // 
            this.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReason.Location = new System.Drawing.Point(160, 148);
            this.cmbReason.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(199, 24);
            this.cmbReason.TabIndex = 14;
            // 
            // btnPresent
            // 
            this.btnPresent.Location = new System.Drawing.Point(160, 197);
            this.btnPresent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPresent.Name = "btnPresent";
            this.btnPresent.Size = new System.Drawing.Size(133, 37);
            this.btnPresent.TabIndex = 13;
            this.btnPresent.Text = "Присутній";
            this.btnPresent.Click += new System.EventHandler(this.btnPresent_Click);
            // 
            // btnAbsent
            // 
            this.btnAbsent.Location = new System.Drawing.Point(307, 197);
            this.btnAbsent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAbsent.Name = "btnAbsent";
            this.btnAbsent.Size = new System.Drawing.Size(133, 37);
            this.btnAbsent.TabIndex = 12;
            this.btnAbsent.Text = "Відсутній";
            this.btnAbsent.Click += new System.EventHandler(this.btnAbsent_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(27, 295);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(465, 308);
            this.dataGridView1.TabIndex = 10;
            // 
            // lblStats
            // 
            this.lblStats.Location = new System.Drawing.Point(160, 246);
            this.lblStats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(400, 25);
            this.lblStats.TabIndex = 11;
            this.lblStats.Text = "Відвідуваність: 0%";
            // 
            // lblStudent
            // 
            this.lblStudent.Location = new System.Drawing.Point(40, 39);
            this.lblStudent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(107, 25);
            this.lblStudent.TabIndex = 21;
            this.lblStudent.Text = "Студент:";
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(40, 76);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(107, 25);
            this.lblSubject.TabIndex = 20;
            this.lblSubject.Text = "Предмет:";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(40, 113);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(107, 25);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Дата:";
            // 
            // lblReason
            // 
            this.lblReason.Location = new System.Drawing.Point(40, 150);
            this.lblReason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(107, 25);
            this.lblReason.TabIndex = 18;
            this.lblReason.Text = "Причина:";
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 615);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnAbsent);
            this.Controls.Add(this.btnPresent);
            this.Controls.Add(this.cmbReason);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.cmbStudent);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblStudent);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AttendanceForm";
            this.Text = "Відвідування";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private Label lblStudent;
        private Label lblSubject;
        private Label lblDate;
        private Label lblReason;
    }
}