using System.Windows.Forms;

namespace ElectronicJournal.Forms
{
    partial class GradeForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbStudent;
        private ComboBox cmbSubject;
        private ComboBox cmbGradeType;
        private TextBox txtGrade;
        private DateTimePicker dtpDate;
        private Button btnAdd;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private Label lblStudent;
        private Label lblSubject;
        private Label lblGrade;
        private Label lblDate;
        private Label lblType;

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
            this.cmbStudent = new ComboBox();
            this.cmbSubject = new ComboBox();
            this.cmbGradeType = new ComboBox();
            this.txtGrade = new TextBox();
            this.dtpDate = new DateTimePicker();
            this.btnAdd = new Button();
            this.btnDelete = new Button();
            this.dataGridView1 = new DataGridView();
            this.lblStudent = new Label();
            this.lblSubject = new Label();
            this.lblGrade = new Label();
            this.lblDate = new Label();
            this.lblType = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStudent.Location = new System.Drawing.Point(120, 40);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(250, 24);
            this.cmbStudent.TabIndex = 0;
            this.cmbStudent.SelectedIndexChanged += new System.EventHandler(this.cmbStudent_SelectedIndexChanged);

            this.cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSubject.Location = new System.Drawing.Point(120, 75);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(250, 24);
            this.cmbSubject.TabIndex = 1;
            this.cmbSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSubject_SelectedIndexChanged);

            this.cmbGradeType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGradeType.Items.AddRange(new object[] { "Лекція", "Практична", "Модульна", "Іспит" });
            this.cmbGradeType.Location = new System.Drawing.Point(120, 180);
            this.cmbGradeType.Name = "cmbGradeType";
            this.cmbGradeType.Size = new System.Drawing.Size(150, 24);
            this.cmbGradeType.TabIndex = 2;

            this.txtGrade.Location = new System.Drawing.Point(120, 110);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(100, 22);
            this.txtGrade.TabIndex = 3;

            this.dtpDate.Format = DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(120, 145);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 4;

            this.btnAdd.Location = new System.Drawing.Point(120, 220);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Location = new System.Drawing.Point(230, 220);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(20, 270);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(650, 250);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.AllowUserToAddRows = false;

            this.lblStudent.Location = new System.Drawing.Point(20, 43);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(80, 20);
            this.lblStudent.Text = "Студент:";

            this.lblSubject.Location = new System.Drawing.Point(20, 78);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(80, 20);
            this.lblSubject.Text = "Предмет:";

            this.lblGrade.Location = new System.Drawing.Point(20, 113);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(80, 20);
            this.lblGrade.Text = "Оцінка:";

            this.lblDate.Location = new System.Drawing.Point(20, 148);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 20);
            this.lblDate.Text = "Дата:";

            this.lblType.Location = new System.Drawing.Point(20, 183);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 20);
            this.lblType.Text = "Тип:";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 550);
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
            this.Name = "GradeForm";
            this.Text = "Оцінки";
            this.StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}