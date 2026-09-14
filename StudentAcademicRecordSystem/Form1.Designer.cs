namespace StudentAcademicRecordSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            lblStudentID = new Label();
            txtStudentID = new TextBox();
            lblStudentName = new Label();
            txtStudentName = new TextBox();
            lblCourse = new Label();
            txtCourse = new TextBox();
            lblUnit = new Label();
            txtUnit = new TextBox();
            lblMarks = new Label();
            txtMarks = new TextBox();
            lblGPA = new Label();
            txtGPA = new TextBox();
            lblWAM = new Label();
            txtWAM = new TextBox();
            btnAddRecord = new Button();
            btnCalculate = new Button();
            btnClear = new Button();
            dgvStudents = new DataGridView();
            StudentID = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            Course = new DataGridViewTextBoxColumn();
            Unit = new DataGridViewTextBoxColumn();
            Marks = new DataGridViewTextBoxColumn();
            GPA = new DataGridViewTextBoxColumn();
            btnSearch = new Button();
            lblStatus = new Label();
            lblStudentStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 9);
            label2.Name = "label2";
            label2.Size = new Size(552, 32);
            label2.TabIndex = 1;
            label2.Text = "Student Academic Record Management System";
            label2.Click += label2_Click;
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Location = new Point(0, 79);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(100, 25);
            lblStudentID.TabIndex = 2;
            lblStudentID.Text = "Student ID:";
            lblStudentID.Click += lblStudentID_Click;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(198, 79);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(150, 31);
            txtStudentID.TabIndex = 3;
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.Location = new Point(0, 147);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(129, 25);
            lblStudentName.TabIndex = 4;
            lblStudentName.Text = "Student Name:";
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(198, 147);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(150, 31);
            txtStudentName.TabIndex = 5;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(0, 213);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(71, 25);
            lblCourse.TabIndex = 6;
            lblCourse.Text = "Course:";
            lblCourse.Click += label1_Click_1;
            // 
            // txtCourse
            // 
            txtCourse.Location = new Point(198, 210);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(150, 31);
            txtCourse.TabIndex = 7;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(0, 275);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(48, 25);
            lblUnit.TabIndex = 8;
            lblUnit.Text = "Unit:";
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(198, 272);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(150, 31);
            txtUnit.TabIndex = 9;
            // 
            // lblMarks
            // 
            lblMarks.AutoSize = true;
            lblMarks.Location = new Point(0, 343);
            lblMarks.Name = "lblMarks";
            lblMarks.Size = new Size(64, 25);
            lblMarks.TabIndex = 10;
            lblMarks.Text = "Marks:";
            lblMarks.Click += label1_Click_2;
            // 
            // txtMarks
            // 
            txtMarks.Location = new Point(198, 337);
            txtMarks.Name = "txtMarks";
            txtMarks.Size = new Size(150, 31);
            txtMarks.TabIndex = 11;
            // 
            // lblGPA
            // 
            lblGPA.AutoSize = true;
            lblGPA.Location = new Point(0, 430);
            lblGPA.Name = "lblGPA";
            lblGPA.Size = new Size(109, 25);
            lblGPA.TabIndex = 12;
            lblGPA.Text = "Overall GPA:";
            lblGPA.Click += label1_Click_3;
            // 
            // txtGPA
            // 
            txtGPA.Location = new Point(198, 430);
            txtGPA.Name = "txtGPA";
            txtGPA.ReadOnly = true;
            txtGPA.Size = new Size(150, 31);
            txtGPA.TabIndex = 13;
            txtGPA.TextChanged += txtGPA_TextChanged;
            // 
            // lblWAM
            // 
            lblWAM.AutoSize = true;
            lblWAM.Location = new Point(0, 495);
            lblWAM.Name = "lblWAM";
            lblWAM.Size = new Size(123, 25);
            lblWAM.TabIndex = 14;
            lblWAM.Text = "Current WAM:";
            // 
            // txtWAM
            // 
            txtWAM.Location = new Point(198, 495);
            txtWAM.Name = "txtWAM";
            txtWAM.ReadOnly = true;
            txtWAM.Size = new Size(150, 31);
            txtWAM.TabIndex = 15;
            // 
            // btnAddRecord
            // 
            btnAddRecord.Location = new Point(60, 638);
            btnAddRecord.Name = "btnAddRecord";
            btnAddRecord.Size = new Size(120, 34);
            btnAddRecord.TabIndex = 16;
            btnAddRecord.Text = "Add Record";
            btnAddRecord.UseVisualStyleBackColor = true;
            btnAddRecord.Click += btnAddRecord_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(250, 638);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(112, 34);
            btnCalculate.TabIndex = 17;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(701, 638);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 18;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] { StudentID, StudentName, Course, Unit, Marks, GPA });
            dgvStudents.Location = new Point(31, 699);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 62;
            dgvStudents.Size = new Size(926, 348);
            dgvStudents.TabIndex = 19;
            dgvStudents.CellContentClick += dgvStudents_CellContentClick;
            // 
            // StudentID
            // 
            StudentID.HeaderText = "Student ID";
            StudentID.MinimumWidth = 8;
            StudentID.Name = "StudentID";
            StudentID.Width = 150;
            // 
            // StudentName
            // 
            StudentName.HeaderText = "Student Name";
            StudentName.MinimumWidth = 8;
            StudentName.Name = "StudentName";
            StudentName.Width = 150;
            // 
            // Course
            // 
            Course.HeaderText = "Course";
            Course.MinimumWidth = 8;
            Course.Name = "Course";
            Course.Width = 150;
            // 
            // Unit
            // 
            Unit.HeaderText = "Unit";
            Unit.MinimumWidth = 8;
            Unit.Name = "Unit";
            Unit.Width = 150;
            // 
            // Marks
            // 
            Marks.HeaderText = "Marks";
            Marks.MinimumWidth = 8;
            Marks.Name = "Marks";
            Marks.Width = 150;
            // 
            // GPA
            // 
            GPA.HeaderText = "Unit GPA";
            GPA.MinimumWidth = 8;
            GPA.Name = "GPA";
            GPA.Width = 150;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(445, 638);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(162, 34);
            btnSearch.TabIndex = 20;
            btnSearch.Text = "Search Student";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(0, 567);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(130, 25);
            lblStatus.TabIndex = 22;
            lblStatus.Text = "Student Status:";
            lblStatus.Click += lblStatus_Click;
            // 
            // lblStudentStatus
            // 
            lblStudentStatus.AutoSize = true;
            lblStudentStatus.Location = new Point(200, 553);
            lblStudentStatus.Name = "lblStudentStatus";
            lblStudentStatus.Size = new Size(0, 25);
            lblStudentStatus.TabIndex = 23;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 1050);
            Controls.Add(lblStudentStatus);
            Controls.Add(lblStatus);
            Controls.Add(btnSearch);
            Controls.Add(dgvStudents);
            Controls.Add(btnClear);
            Controls.Add(btnCalculate);
            Controls.Add(btnAddRecord);
            Controls.Add(txtWAM);
            Controls.Add(lblWAM);
            Controls.Add(txtGPA);
            Controls.Add(lblGPA);
            Controls.Add(txtMarks);
            Controls.Add(lblMarks);
            Controls.Add(txtUnit);
            Controls.Add(lblUnit);
            Controls.Add(txtCourse);
            Controls.Add(lblCourse);
            Controls.Add(txtStudentName);
            Controls.Add(lblStudentName);
            Controls.Add(txtStudentID);
            Controls.Add(lblStudentID);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Student Academic Record System";
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label lblStudentID;
        private TextBox txtStudentID;
        private Label lblStudentName;
        private TextBox txtStudentName;
        private Label lblCourse;
        private TextBox txtCourse;
        private Label lblUnit;
        private TextBox txtUnit;
        private Label lblMarks;
        private TextBox txtMarks;
        private Label lblGPA;
        private TextBox txtGPA;
        private Label lblWAM;
        private TextBox txtWAM;
        private Button btnAddRecord;
        private Button btnCalculate;
        private Button btnClear;
        private DataGridView dgvStudents;
        private DataGridViewTextBoxColumn StudentID;
        private DataGridViewTextBoxColumn StudentName;
        private DataGridViewTextBoxColumn Course;
        private DataGridViewTextBoxColumn Unit;
        private DataGridViewTextBoxColumn Marks;
        private DataGridViewTextBoxColumn GPA;
        private Button btnSearch;
        private Label lblStatus;
        private Label lblStudentStatus;
    }
}
