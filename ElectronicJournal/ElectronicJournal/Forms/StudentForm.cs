using System;
using System.Windows.Forms;
using ElectronicJournal.Business;
using ElectronicJournal.Models;

namespace ElectronicJournal.Forms
{
    public partial class StudentForm : Form
    {
        private StudentService _studentService;
        private GradeService _gradeService;
        private BindingSource _studentBindingSource;

        public StudentForm(StudentService sService, GradeService gService)
        {
            InitializeComponent();
            _studentService = sService;
            _gradeService = gService;

            _studentBindingSource = new BindingSource();
            dataGridView1.DataSource = _studentBindingSource;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadStudents();
            SetupDataGridViewColumns();
        }

        private void LoadStudents()
        {
            var students = _studentService.GetAllStudents();
            _studentBindingSource.DataSource = students;
        }

        private void SetupDataGridViewColumns()
        {
            if (dataGridView1.Columns.Count == 0) return;

            dataGridView1.Columns["Id"].HeaderText = "№";
            dataGridView1.Columns["Id"].Width = 50;
            dataGridView1.Columns["FirstName"].HeaderText = "Ім'я";
            dataGridView1.Columns["FirstName"].Width = 100;
            dataGridView1.Columns["LastName"].HeaderText = "Прізвище";
            dataGridView1.Columns["LastName"].Width = 100;
            dataGridView1.Columns["MiddleName"].HeaderText = "По батькові";
            dataGridView1.Columns["MiddleName"].Width = 100;
            dataGridView1.Columns["RecordBookNumber"].HeaderText = "№ заліковки";
            dataGridView1.Columns["RecordBookNumber"].Width = 100;

            if (dataGridView1.Columns.Contains("Email"))
                dataGridView1.Columns["Email"].Visible = false;
            if (dataGridView1.Columns.Contains("Phone"))
                dataGridView1.Columns["Phone"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var student = new Student(txtFirstName.Text, txtLastName.Text)
                {
                    MiddleName = txtMiddleName.Text,
                    RecordBookNumber = txtRecordBook.Text
                };
                _studentService.AddStudent(student);
                LoadStudents();
                ClearFields();
                MessageBox.Show("Студента додано!", "Успіх");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Виберіть студента для видалення.");
                    return;
                }

                var student = dataGridView1.CurrentRow.DataBoundItem as Student;
                if (student == null) return;

                var result = MessageBox.Show($"Видалити студента {student.LastName} {student.FirstName}?", "Підтвердження", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _studentService.DeleteStudent(student.Id);
                    LoadStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtRecordBook.Text = "";
        }
    }
}