using System;
using System.Drawing;
using System.Windows.Forms;
using ElectronicJournal.Business;
using ElectronicJournal.Data;
using ElectronicJournal.Models;

namespace ElectronicJournal.Forms
{
    public class TestForm : Form
    {
        private Button btnTestGrade;
        private Button btnTestAttendance;
        private ListBox listBox;

        public TestForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Тестова форма";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            btnTestGrade = new Button
            {
                Text = "Тест Grade",
                Location = new Point(50, 50),
                Size = new Size(150, 40)
            };
            btnTestGrade.Click += BtnTestGrade_Click;

            btnTestAttendance = new Button
            {
                Text = "Тест Attendance",
                Location = new Point(50, 100),
                Size = new Size(150, 40)
            };
            btnTestAttendance.Click += BtnTestAttendance_Click;

            listBox = new ListBox
            {
                Location = new Point(50, 150),
                Size = new Size(350, 200)
            };

            this.Controls.Add(btnTestGrade);
            this.Controls.Add(btnTestAttendance);
            this.Controls.Add(listBox);
        }

        private void BtnTestGrade_Click(object sender, EventArgs e)
        {
            try
            {
                listBox.Items.Clear();
                listBox.Items.Add("=== ТЕСТ GRADE ===");

                var gradeRepo = new GradeRepository();
                listBox.Items.Add("1. GradeRepository створено");

                var studentRepo = new StudentRepository();
                var student = new Student("Тест", "Тестовий");
                studentRepo.Add(student);
                listBox.Items.Add($"2. Створено студента з ID: {student.Id}");

                var subjectRepo = new SubjectRepository();
                var subject = new Subject("Тестовий предмет");
                subjectRepo.Add(subject);
                listBox.Items.Add($"3. Створено предмет з ID: {subject.Id}");

                var grade = new Grade(student.Id, subject.Id, 85, DateTime.Now);
                grade.GradeType = "Тест";
                listBox.Items.Add("4. Об'єкт Grade створено");

                gradeRepo.Add(grade);
                listBox.Items.Add($"5. Grade додано з ID: {grade.Id}");

                var allGrades = gradeRepo.GetAll();
                listBox.Items.Add($"6. Всього оцінок в репозиторії: {allGrades.Count}");

                var studentGrades = gradeRepo.GetByStudent(student.Id);
                listBox.Items.Add($"7. Оцінок студента: {studentGrades.Count}");

                var avg = gradeRepo.GetAverage(student.Id, subject.Id);
                listBox.Items.Add($"8. Середній бал: {avg}");

                listBox.Items.Add("=== ТЕСТ УСПІШНИЙ ===");
            }
            catch (Exception ex)
            {
                listBox.Items.Add($"!!! ПОМИЛКА: {ex.Message}");
            }
        }

        private void BtnTestAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                listBox.Items.Clear();
                listBox.Items.Add("=== ТЕСТ ATTENDANCE ===");

                var attendanceRepo = new AttendanceRepository();
                listBox.Items.Add("1. AttendanceRepository створено");

                var studentRepo = new StudentRepository();
                var student = new Student("Тест", "Тестовий");
                studentRepo.Add(student);
                listBox.Items.Add($"2. Створено студента з ID: {student.Id}");

                var subjectRepo = new SubjectRepository();
                var subject = new Subject("Тестовий предмет");
                subjectRepo.Add(subject);
                listBox.Items.Add($"3. Створено предмет з ID: {subject.Id}");

                var attendance = new Attendance(student.Id, subject.Id, DateTime.Now);
                listBox.Items.Add("4. Attendance створено");

                attendanceRepo.Add(attendance);
                listBox.Items.Add($"5. Attendance додано з ID: {attendance.Id}");

                var allAttendance = attendanceRepo.GetAll();
                listBox.Items.Add($"6. Всього записів: {allAttendance.Count}");

                var studentAttendance = attendanceRepo.GetByStudent(student.Id);
                listBox.Items.Add($"7. Записів студента: {studentAttendance.Count}");

                listBox.Items.Add("=== ТЕСТ УСПІШНИЙ ===");
            }
            catch (Exception ex)
            {
                listBox.Items.Add($"!!! ПОМИЛКА: {ex.Message}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                btnTestGrade?.Dispose();
                btnTestAttendance?.Dispose();
                listBox?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}