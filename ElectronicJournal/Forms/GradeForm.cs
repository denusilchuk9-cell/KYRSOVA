using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ElectronicJournal.Business;
using ElectronicJournal.Models;

namespace ElectronicJournal.Forms
{
    public partial class GradeForm : Form
    {
        private GradeService _gradeService;
        private StudentService _studentService;
        private SubjectService _subjectService;
        private Label lblAverage;

        public GradeForm(GradeService gService, StudentService sService, SubjectService subService)
        {
            InitializeComponent();
            _gradeService = gService;
            _studentService = sService;
            _subjectService = subService;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = true;

            CreateAverageLabel();
            LoadData();
        }

        private void CreateAverageLabel()
        {
            lblAverage = new Label();
            lblAverage.Text = "Середній бал: —";
            lblAverage.Location = new Point(120, 265);
            lblAverage.Size = new Size(300, 25);
            lblAverage.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblAverage.ForeColor = Color.FromArgb(0, 123, 255);
            this.Controls.Add(lblAverage);
        }

        private void LoadData()
        {
            try
            {
                var students = _studentService.GetAllStudents();
                var subjects = _subjectService.GetAllSubjects();

                cmbStudent.DataSource = students;
                cmbStudent.DisplayMember = "GetFullName";
                cmbStudent.ValueMember = "Id";

                cmbSubject.DataSource = subjects;
                cmbSubject.DisplayMember = "Name";
                cmbSubject.ValueMember = "Id";

                cmbGradeType.Items.Clear();
                cmbGradeType.Items.AddRange(new string[] { "Лекція", "Практична", "Модульна", "Іспит" });
                cmbGradeType.SelectedIndex = 0;

                dtpDate.Value = DateTime.Now;
                txtGrade.Text = "";

                if (students.Count > 0 && subjects.Count > 0)
                {
                    LoadGrades();
                }
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
                if (cmbStudent.SelectedItem != null && cmbSubject.SelectedItem != null)
                {
                    var student = (Student)cmbStudent.SelectedItem;
                    var subject = (Subject)cmbSubject.SelectedItem;

                    var allGrades = _gradeService.GetGradesByStudent(student.Id);
                    var filtered = allGrades.Where(g => g.SubjectId == subject.Id).ToList();

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = filtered;

                    if (dataGridView1.Columns.Contains("StudentId"))
                        dataGridView1.Columns["StudentId"].Visible = false;
                    if (dataGridView1.Columns.Contains("SubjectId"))
                        dataGridView1.Columns["SubjectId"].Visible = false;
                    if (dataGridView1.Columns.Contains("Id"))
                        dataGridView1.Columns["Id"].HeaderText = "№";
                    if (dataGridView1.Columns.Contains("Value"))
                        dataGridView1.Columns["Value"].HeaderText = "Оцінка";
                    if (dataGridView1.Columns.Contains("Date"))
                    {
                        dataGridView1.Columns["Date"].HeaderText = "Дата";
                        dataGridView1.Columns["Date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    }
                    if (dataGridView1.Columns.Contains("GradeType"))
                        dataGridView1.Columns["GradeType"].HeaderText = "Тип";

                    UpdateAverage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження оцінок: {ex.Message}");
            }
        }

        private void UpdateAverage()
        {
            try
            {
                if (lblAverage == null) return;

                if (cmbStudent.SelectedItem != null && cmbSubject.SelectedItem != null)
                {
                    var student = (Student)cmbStudent.SelectedItem;
                    var subject = (Subject)cmbSubject.SelectedItem;

                    float avg = _gradeService.GetStudentAverage(student.Id, subject.Id);
                    lblAverage.Text = $"Середній бал: {avg:F2}";
                }
            }
            catch
            {
                if (lblAverage != null)
                    lblAverage.Text = "Середній бал: помилка";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudent.SelectedItem == null || cmbSubject.SelectedItem == null)
                {
                    MessageBox.Show("Виберіть студента та предмет");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtGrade.Text))
                {
                    MessageBox.Show("Введіть оцінку");
                    return;
                }

                if (!int.TryParse(txtGrade.Text, out int value) || value < 0 || value > 100)
                {
                    MessageBox.Show("Оцінка має бути числом від 0 до 100");
                    return;
                }

                var student = (Student)cmbStudent.SelectedItem;
                var subject = (Subject)cmbSubject.SelectedItem;

                var grade = new Grade(student.Id, subject.Id, value, dtpDate.Value)
                {
                    GradeType = cmbGradeType.Text
                };

                _gradeService.AddGrade(grade);
                LoadGrades();
                txtGrade.Text = "";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Виберіть оцінку для видалення.");
                    return;
                }

                var grade = dataGridView1.CurrentRow.DataBoundItem as Grade;
                if (grade == null) return;

                var result = MessageBox.Show($"Видалити оцінку {grade.Value}?", "Підтвердження", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _gradeService.DeleteGrade(grade.Id);
                    LoadGrades();
                }
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
    }
}