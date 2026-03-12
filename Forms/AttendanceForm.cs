using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ElectronicJournal.Data;
using ElectronicJournal.Models;
using ElectronicJournal.Business;

namespace ElectronicJournal.Forms
{
    public partial class AttendanceForm : Form
    {
        private DataAccess dataAccess;
        private GradeCalculator calculator;
        private List<Student> students;
        private List<Subject> subjects;

        public AttendanceForm(DataAccess da)
        {
            InitializeComponent();
            dataAccess = da;
            calculator = new GradeCalculator();
            LoadData();
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

                dtpDate.Value = DateTime.Now;
                cmbReason.Items.Clear();
                cmbReason.Items.AddRange(new string[] { "Хвороба", "Сімейні обставини", "Інше" });
                cmbReason.SelectedIndex = 0;

                LoadAttendance();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}");
            }
        }

        private void LoadAttendance()
        {
            try
            {
                if (cmbStudent.SelectedValue != null && cmbSubject.SelectedValue != null)
                {
                    int studentId = (int)cmbStudent.SelectedValue;
                    int subjectId = (int)cmbSubject.SelectedValue;

                    var allAttendance = dataAccess.GetAttendanceByStudent(studentId);
                    var filtered = new List<Attendance>();

                    foreach (var a in allAttendance)
                    {
                        if (a.SubjectId == subjectId)
                            filtered.Add(a);
                    }

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = filtered;

                    if (dataGridView1.Columns.Count > 0)
                    {
                        dataGridView1.Columns["Id"].Visible = false;
                        dataGridView1.Columns["StudentId"].Visible = false;
                        dataGridView1.Columns["SubjectId"].Visible = false;
                        dataGridView1.Columns["Date"].HeaderText = "Дата";
                        dataGridView1.Columns["IsPresent"].HeaderText = "Присутній";
                        dataGridView1.Columns["AbsenceReason"].HeaderText = "Причина";
                    }

                    UpdateStats();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження відвідування: {ex.Message}");
            }
        }

        private void UpdateStats()
        {
            try
            {
                if (cmbStudent.SelectedValue != null)
                {
                    int studentId = (int)cmbStudent.SelectedValue;
                    var attendances = dataAccess.GetAttendanceByStudent(studentId);
                    double percentage = calculator.CalculateAttendancePercentage(attendances);
                    lblStats.Text = $"Відвідуваність: {percentage:F1}%";
                }
            }
            catch (Exception ex)
            {
                lblStats.Text = "Відвідуваність: помилка";
            }
        }

        private void btnPresent_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudent.SelectedValue == null || cmbSubject.SelectedValue == null)
                {
                    MessageBox.Show("Виберіть студента та предмет", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var attendance = new Attendance(
                    (int)cmbStudent.SelectedValue,
                    (int)cmbSubject.SelectedValue,
                    dtpDate.Value
                );

                dataAccess.AddAttendance(attendance);
                LoadAttendance();
                MessageBox.Show("Присутність відмічено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAbsent_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudent.SelectedValue == null || cmbSubject.SelectedValue == null)
                {
                    MessageBox.Show("Виберіть студента та предмет", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var attendance = new Attendance(
                    (int)cmbStudent.SelectedValue,
                    (int)cmbSubject.SelectedValue,
                    dtpDate.Value
                );

                attendance.MarkAbsent(cmbReason.Text);
                dataAccess.AddAttendance(attendance);
                LoadAttendance();
                MessageBox.Show("Відсутність зафіксовано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            LoadAttendance();
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttendance();
        }
    }
}