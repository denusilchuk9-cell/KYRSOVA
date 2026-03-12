using System.Windows.Forms;

namespace ElectronicJournal.Forms
{
    partial class GradeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.ComboBox cmbGradeType;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.DateTimePicker dtpDate;
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
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.cmbGradeType = new System.Windows.Forms.ComboBox();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.Location = new System.Drawing.Point(160, 37);
            this.cmbStudent.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(332, 24);
            this.cmbStudent.TabIndex = 17;
            this.cmbStudent.SelectedIndexChanged += new System.EventHandler(this.cmbStudent_SelectedIndexChanged);

            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.Location = new System.Drawing.Point(160, 74);
            this.cmbSubject.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(332, 24);
            this.cmbSubject.TabIndex = 16;
            this.cmbSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSubject_SelectedIndexChanged);

            this.cmbGradeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradeType.Location = new System.Drawing.Point(160, 185);
            this.cmbGradeType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGradeType.Name = "cmbGradeType";
            this.cmbGradeType.Size = new System.Drawing.Size(199, 24);
            this.cmbGradeType.TabIndex = 13;

            this.txtGrade.Location = new System.Drawing.Point(160, 111);
            this.txtGrade.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(132, 22);
            this.txtGrade.TabIndex = 15;

            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(160, 148);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(265, 22);
            this.dtpDate.TabIndex = 14;

            this.btnAdd.Location = new System.Drawing.Point(160, 234);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 37);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Додати";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Location = new System.Drawing.Point(307, 234);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 37);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(43, 369);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(468, 307);
            this.dataGridView1.TabIndex = 10;

            this.lblStudent.Location = new System.Drawing.Point(40, 39);
            this.lblStudent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(107, 25);
            this.lblStudent.TabIndex = 22;
            this.lblStudent.Text = "Студент:";

            this.lblSubject.Location = new System.Drawing.Point(40, 76);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(107, 25);
            this.lblSubject.TabIndex = 21;
            this.lblSubject.Text = "Предмет:";

            this.lblGrade.Location = new System.Drawing.Point(40, 113);
            this.lblGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(107, 25);
            this.lblGrade.TabIndex = 20;
            this.lblGrade.Text = "Оцінка:";

            this.lblDate.Location = new System.Drawing.Point(40, 150);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(107, 25);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Дата:";

            this.lblType.Location = new System.Drawing.Point(40, 187);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(107, 25);
            this.lblType.TabIndex = 18;
            this.lblType.Text = "Тип:";

            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbGradeType);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.cmbStudent);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblStudent);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 722);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GradeForm";
            this.Text = "Оцінки";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblStudent;
        private Label lblSubject;
        private Label lblGrade;
        private Label lblDate;
        private Label lblType;
    }
}