using System;
using System.Windows.Forms;
using ElectronicJournal.Data;
using ElectronicJournal.Models;

namespace ElectronicJournal.Forms
{
    public partial class SubjectForm : Form
    {
        private DataAccess dataAccess;

        public SubjectForm(DataAccess da)
        {
            InitializeComponent();
            dataAccess = da;
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            try
            {
                var subjects = dataAccess.GetAllSubjects();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = subjects;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["Id"].HeaderText = "№";
                    dataGridView1.Columns["Id"].Width = 50;
                    dataGridView1.Columns["Name"].HeaderText = "Назва предмета";
                    dataGridView1.Columns["Name"].Width = 150;
                    dataGridView1.Columns["TeacherName"].HeaderText = "Викладач";
                    dataGridView1.Columns["TeacherName"].Width = 150;
                    dataGridView1.Columns["Hours"].HeaderText = "Годин";
                    dataGridView1.Columns["Hours"].Width = 80;
                    dataGridView1.Columns["ControlForm"].HeaderText = "Форма контролю";
                    dataGridView1.Columns["ControlForm"].Width = 120;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Введіть назву предмета");
                    return;
                }

                var subject = new Subject(txtName.Text)
                {
                    TeacherName = txtTeacher.Text,
                    Hours = (int)numHours.Value,
                    ControlForm = cmbControl.Text
                };

                dataAccess.AddSubject(subject);
                LoadSubjects();
                ClearFields();
                MessageBox.Show("Предмет додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtTeacher.Text = "";
            numHours.Value = 0;
            cmbControl.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var subject = (Subject)dataGridView1.CurrentRow.DataBoundItem;
                    var result = MessageBox.Show($"Видалити предмет {subject.Name}?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dataAccess.DeleteSubject(subject.Id);
                        LoadSubjects();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }
    }
}