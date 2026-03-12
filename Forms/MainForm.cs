using System;
using System.Drawing;
using System.Windows.Forms;
using ElectronicJournal.Data;
using ElectronicJournal.Business;

namespace ElectronicJournal.Forms
{
    public partial class MainForm : Form
    {
        private DataAccess dataAccess;
        private GradeCalculator gradeCalculator;

        public MainForm()
        {
            InitializeComponent();

            dataAccess = RepositoryFactory.CreateDataAccess();
            gradeCalculator = new GradeCalculator();

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Електронний журнал";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(500, 400);
            this.BackColor = Color.FromArgb(240, 242, 245);

            Button btnStudents = new Button
            {
                Text = "Студенти",
                Size = new Size(200, 60),
                Location = new Point(150, 50),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnStudents.Click += BtnStudents_Click;
            this.Controls.Add(btnStudents);

            Button btnSubjects = new Button
            {
                Text = "Предмети",
                Size = new Size(200, 60),
                Location = new Point(150, 120),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSubjects.Click += BtnSubjects_Click;
            this.Controls.Add(btnSubjects);

            Button btnGrades = new Button
            {
                Text = "Оцінки",
                Size = new Size(200, 60),
                Location = new Point(150, 190),
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnGrades.Click += BtnGrades_Click;
            this.Controls.Add(btnGrades);

            Button btnAttendance = new Button
            {
                Text = "Відвідування",
                Size = new Size(200, 60),
                Location = new Point(150, 260),
                BackColor = Color.FromArgb(23, 162, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnAttendance.Click += BtnAttendance_Click;
            this.Controls.Add(btnAttendance);
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm(dataAccess, gradeCalculator);
            studentForm.ShowDialog();
        }

        private void BtnSubjects_Click(object sender, EventArgs e)
        {
            SubjectForm subjectForm = new SubjectForm(dataAccess);
            subjectForm.ShowDialog();
        }

        private void BtnGrades_Click(object sender, EventArgs e)
        {
            GradeForm gradeForm = new GradeForm(dataAccess, gradeCalculator);
            gradeForm.ShowDialog();
        }

        private void BtnAttendance_Click(object sender, EventArgs e)
        {
            AttendanceForm attendanceForm = new AttendanceForm(dataAccess);
            attendanceForm.ShowDialog();
        }
    }
}