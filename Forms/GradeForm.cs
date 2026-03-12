using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ElectronicJournal.Data;
using ElectronicJournal.Models;
using ElectronicJournal.Business;

namespace ElectronicJournal.Forms
{
    public partial class GradeForm : Form
    {
        private DataAccess dataAccess;
        private GradeCalculator gradeCalculator;
        private List<Student> students;
        private List<Subject> subjects;
        private Label lblAverage;

        public GradeForm(DataAccess da, GradeCalculator gc)
        {
            InitializeComponent();
            dataAccess = da;
            gradeCalculator = gc;
            LoadData();
            AddAverageControls();
            StyleButtons();
            StyleForm();
        }

        private void LoadData()
        {
            try
            {
                students = dataAccess.GetAllStudents();
                subjects = dataAccess.GetAllSubjects();

                cmbStudent.DataSource = null;
                cmbStudent.DataSource = students;
                cmbStudent.DisplayMember = "GetFullName";
                cmbStudent.ValueMember = "Id";

                cmbSubject.DataSource = null;
                cmbSubject.DataSource = subjects;
                cmbSubject.DisplayMember = "Name";
                cmbSubject.ValueMember = "Id";

                cmbGradeType.Items.Clear();
                cmbGradeType.Items.AddRange(new string[] { "Лекція", "Практична", "Модульна", "Іспит" });
                cmbGradeType.SelectedIndex = 0;

                dtpDate.Value = DateTime.Now;

                LoadGrades();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}");
            }
        }

        private void LoadGrades()
        {
            try
            {
                if (cmbStudent.SelectedValue != null && cmbSubject.SelectedValue != null)
                {
                    int studentId = (int)cmbStudent.SelectedValue;
                    int subjectId = (int)cmbSubject.SelectedValue;

                    var grades = dataAccess.GetGradesByStudent(studentId);
                    var filteredGrades = new List<Grade>();

                    foreach (var grade in grades)
                    {
                        if (grade.SubjectId == subjectId)
                            filteredGrades.Add(grade);
                    }

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = filteredGrades;

                    if (dataGridView1.Columns.Count > 0)
                    {
                        dataGridView1.Columns["Id"].Visible = false;
                        dataGridView1.Columns["StudentId"].Visible = false;
                        dataGridView1.Columns["SubjectId"].Visible = false;
                        dataGridView1.Columns["Value"].HeaderText = "Оцінка";
                        dataGridView1.Columns["Date"].HeaderText = "Дата";
                        dataGridView1.Columns["GradeType"].HeaderText = "Тип";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження оцінок: {ex.Message}");
            }
        }

        private void AddAverageControls()
        {
            lblAverage = new Label
            {
                Text = "Середній бал: —",
                Location = new Point(120, 230),
                Size = new Size(250, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 123, 255)
            };
            this.Controls.Add(lblAverage);

            Button btnCalculateAvg = new Button
            {
                Text = "Розрахувати середній",
                Location = new Point(350, 190),
                Size = new Size(150, 30),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            btnCalculateAvg.Click += BtnCalculateAvg_Click;
            this.Controls.Add(btnCalculateAvg);
        }

        private void BtnCalculateAvg_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudent.SelectedValue == null || cmbSubject.SelectedValue == null)
                {
                    MessageBox.Show("Виберіть студента та предмет");
                    return;
                }

                int studentId = (int)cmbStudent.SelectedValue;
                int subjectId = (int)cmbSubject.SelectedValue;

                var grades = dataAccess.GetGradesByStudent(studentId);
                var filteredGrades = new List<Grade>();

                foreach (var grade in grades)
                {
                    if (grade.SubjectId == subjectId)
                        filteredGrades.Add(grade);
                }

                double avg = gradeCalculator.CalculateAverage(filteredGrades);
                string strategyName = gradeCalculator.GetStrategyName();

                lblAverage.Text = $"Середній бал ({strategyName}): {avg:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void StyleButtons()
        {
            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAdd.Cursor = Cursors.Hand;

            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDelete.Cursor = Cursors.Hand;
        }

        private void StyleForm()
        {
            this.BackColor = Color.FromArgb(240, 242, 245);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudent.SelectedValue == null || cmbSubject.SelectedValue == null)
                {
                    MessageBox.Show("Виберіть студента та предмет", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtGrade.Text, out int value) || value < 0 || value > 100)
                {
                    MessageBox.Show("Оцінка має бути числом від 0 до 100", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var grade = new Grade(
                    (int)cmbStudent.SelectedValue,
                    (int)cmbSubject.SelectedValue,
                    value,
                    dtpDate.Value
                )
                {
                    GradeType = cmbGradeType.Text
                };

                dataAccess.AddGrade(grade);
                LoadGrades();
                txtGrade.Text = "";
                MessageBox.Show("Оцінку додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrades();
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrades();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var grade = (Grade)dataGridView1.CurrentRow.DataBoundItem;
                    var result = MessageBox.Show("Видалити оцінку?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dataAccess.DeleteGrade(grade.Id);
                        LoadGrades();
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