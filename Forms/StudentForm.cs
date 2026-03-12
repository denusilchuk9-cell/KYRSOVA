using System;
using System.Drawing;
using System.Windows.Forms;
using ElectronicJournal.Data;
using ElectronicJournal.Models;
using ElectronicJournal.Business;

namespace ElectronicJournal.Forms
{
    public partial class StudentForm : Form
    {
        private DataAccess dataAccess;
        private GradeCalculator gradeCalculator;
        private Label lblStrategyInfo;
        private Button btnSimpleStrategy;
        private Button btnWeightedStrategy;

        public StudentForm(DataAccess da, GradeCalculator gc)
        {
            InitializeComponent();
            dataAccess = da;
            gradeCalculator = gc;
            LoadStudents();
            SetupDataGridViewColumns();
            AddStrategyControls();
        }

        private void AddStrategyControls()
        {
            lblStrategyInfo = new Label
            {
                Text = $"Поточна стратегія: {gradeCalculator.GetStrategyName()}",
                Location = new Point(120, 230),
                Size = new Size(250, 20),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 123, 255)
            };
            this.Controls.Add(lblStrategyInfo);

            btnSimpleStrategy = new Button
            {
                Text = "Проста стратегія",
                Location = new Point(350, 150),
                Size = new Size(150, 30),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            btnSimpleStrategy.Click += BtnSimpleStrategy_Click;
            this.Controls.Add(btnSimpleStrategy);

            btnWeightedStrategy = new Button
            {
                Text = "Зважена стратегія",
                Location = new Point(350, 190),
                Size = new Size(150, 30),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            btnWeightedStrategy.Click += BtnWeightedStrategy_Click;
            this.Controls.Add(btnWeightedStrategy);
        }

        private void BtnSimpleStrategy_Click(object sender, EventArgs e)
        {
            gradeCalculator.SetStrategy(new SimpleAverageStrategy());
            lblStrategyInfo.Text = $"Поточна стратегія: {gradeCalculator.GetStrategyName()}";
            MessageBox.Show("Встановлено просту стратегію розрахунку", "Strategy Pattern");
        }

        private void BtnWeightedStrategy_Click(object sender, EventArgs e)
        {
            gradeCalculator.SetStrategy(new WeightedAverageStrategy());
            lblStrategyInfo.Text = $"Поточна стратегія: {gradeCalculator.GetStrategyName()}";
            MessageBox.Show("Встановлено зважену стратегію розрахунку", "Strategy Pattern");
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

        private void LoadStudents()
        {
            try
            {
                var students = dataAccess.GetAllStudents();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }
    }
}