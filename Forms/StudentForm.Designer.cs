namespace ElectronicJournal.Forms
{
    partial class StudentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtRecordBook;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtRecordBook = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            System.Windows.Forms.Label lblFirstName = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblLastName = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblMiddleName = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblRecordBook = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            lblFirstName.Text = "Ім'я:";
            lblFirstName.Location = new System.Drawing.Point(30, 32);
            lblFirstName.Size = new System.Drawing.Size(80, 20);

            lblLastName.Text = "Прізвище:";
            lblLastName.Location = new System.Drawing.Point(30, 62);
            lblLastName.Size = new System.Drawing.Size(80, 20);

            lblMiddleName.Text = "По батькові:";
            lblMiddleName.Location = new System.Drawing.Point(30, 92);
            lblMiddleName.Size = new System.Drawing.Size(80, 20);

            lblRecordBook.Text = "№ заліковки:";
            lblRecordBook.Location = new System.Drawing.Point(30, 122);
            lblRecordBook.Size = new System.Drawing.Size(80, 20);

            this.txtFirstName.Location = new System.Drawing.Point(120, 30);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 20);
            this.txtFirstName.TabIndex = 0;

            this.txtLastName.Location = new System.Drawing.Point(120, 60);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 20);
            this.txtLastName.TabIndex = 1;

            this.txtMiddleName.Location = new System.Drawing.Point(120, 90);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(200, 20);
            this.txtMiddleName.TabIndex = 2;

            this.txtRecordBook.Location = new System.Drawing.Point(120, 120);
            this.txtRecordBook.Name = "txtRecordBook";
            this.txtRecordBook.Size = new System.Drawing.Size(200, 20);
            this.txtRecordBook.TabIndex = 3;

            this.btnAdd.Location = new System.Drawing.Point(120, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Location = new System.Drawing.Point(220, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.dataGridView1.Location = new System.Drawing.Point(20, 210);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(560, 250);
            this.dataGridView1.TabIndex = 6;

            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtRecordBook);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(lblRecordBook);
            this.Controls.Add(lblMiddleName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(lblFirstName);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 480);
            this.Name = "StudentForm";
            this.Text = "Студенти";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}