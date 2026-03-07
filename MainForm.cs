using System;
using System.Drawing;
using System.Windows.Forms;
using ElectronicJournal.Data;

namespace ElectronicJournal.Forms
{
    public partial class MainForm : Form
    {
        private DataAccess dataAccess;

        public MainForm()
        {
            InitializeComponent();
            dataAccess = new DataAccess("journal.db");
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
                Location = new Point(150, 150),
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
                Location = new Point(150, 220),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSubjects.Click += BtnSubjects_Click;
            this.Controls.Add(btnSubjects);
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm(dataAccess);
            studentForm.ShowDialog();
        }

        private void BtnSubjects_Click(object sender, EventArgs e)
        {
            SubjectForm subjectForm = new SubjectForm(dataAccess);
            subjectForm.ShowDialog();
        }
    }
}