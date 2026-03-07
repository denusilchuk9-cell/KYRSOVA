using System;
using System.Drawing;
using System.Windows.Forms;
using ElectronicJournal.Data;
using ElectronicJournal.Models;

namespace ElectronicJournal.Forms
{
    public partial class StudentForm : Form
    {
        private DataAccess dataAccess;

        public StudentForm(DataAccess da)
        {
            InitializeComponent();
            dataAccess = da;
            LoadStudents();
            SetupDataGridViewColumns();
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
        }

        private void LoadStudents()
        {
            var students = dataAccess.GetAllStudents();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
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

                dataAccess.AddStudent(student);
                LoadStudents();
                ClearFields();
                MessageBox.Show("Студента додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtRecordBook.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var student = (Student)dataGridView1.CurrentRow.DataBoundItem;
                var result = MessageBox.Show($"Видалити студента {student.LastName} {student.FirstName}?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dataAccess.DeleteStudent(student.Id);
                    LoadStudents();
                }
            }
        }
    }
}