using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StudentAcademicRecordSystem
{
    public partial class Form1 : Form
    {
        // Stores unit records during the current session.
        private readonly List<StudentRecord> records = new List<StudentRecord>();

        public Form1()
        {
            InitializeComponent();

            dgvStudents.MultiSelect = true;
        }

        // Designer-linked handlers.
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label1_Click_2(object sender, EventArgs e) { }
        private void label1_Click_3(object sender, EventArgs e) { }
        private void txtGPA_TextChanged(object sender, EventArgs e) { }

        // Calculate GPA for one unit.
        private double CalculateGPA(double mark)
        {
            if (mark >= 80)
                return 4.0;
            else if (mark >= 70)
                return 3.0;
            else if (mark >= 60)
                return 2.0;
            else if (mark >= 50)
                return 1.0;
            else
                return 0.0;
        }

        // Calculate overall GPA for one student.
        private double CalculateOverallGPA(string studentId)
        {
            double total = 0;
            int count = 0;

            foreach (StudentRecord record in records)
            {
                if (record.StudentID.Equals(
                    studentId,
                    StringComparison.OrdinalIgnoreCase))
                {
                    total += record.GPA;
                    count++;
                }
            }

            return count == 0 ? 0 : total / count;
        }

        // Calculate WAM for one student.
        private double CalculateWAM(string studentId)
        {
            double total = 0;
            int count = 0;

            foreach (StudentRecord record in records)
            {
                if (record.StudentID.Equals(
                    studentId,
                    StringComparison.OrdinalIgnoreCase))
                {
                    total += record.Mark;
                    count++;
                }
            }

            return count == 0 ? 0 : total / count;
        }

        // Display student status based on WAM.
        private void DisplayStudentStatus(double wam)
        {
            if (wam >= 50)
            {
                lblStudentStatus.Text = "Satisfactory";
                lblStudentStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStudentStatus.Text = "At Risk";
                lblStudentStatus.ForeColor = Color.Red;
            }
        }

        // Check whether the entered mark is valid.
        private bool TryGetValidMark(out double mark)
        {
            return double.TryParse(txtMarks.Text, out mark) &&
                   mark >= 0 &&
                   mark <= 100;
        }

        // Preview GPA for the current mark.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (TryGetValidMark(out double mark))
            {
                double unitGPA = CalculateGPA(mark);

                string studentId = txtStudentID.Text.Trim();
                bool studentExists = false;

                foreach (StudentRecord record in records)
                {
                    if (record.StudentID.Equals(
                        studentId,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        studentExists = true;
                        break;
                    }
                }

                // Clear old aggregate results when previewing
                // a student who has no saved records.
                if (!studentExists)
                {
                    txtGPA.Clear();
                    txtWAM.Clear();

                    lblStudentStatus.Text = "-";
                    lblStudentStatus.ForeColor = SystemColors.ControlText;

                    dgvStudents.ClearSelection();
                }

                MessageBox.Show(
                    $"Unit GPA: {unitGPA:0.00}",
                    "GPA Preview",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Please enter a valid mark between 0 and 100.",
                    "Invalid Mark",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Add a unit record.
        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentID.Text.Trim();
            string studentName = txtStudentName.Text.Trim();
            string course = txtCourse.Text.Trim();
            string unit = txtUnit.Text.Trim();

            // Check required fields.
            if (string.IsNullOrWhiteSpace(studentId) ||
                string.IsNullOrWhiteSpace(studentName) ||
                string.IsNullOrWhiteSpace(course) ||
                string.IsNullOrWhiteSpace(unit))
            {
                MessageBox.Show(
                    "Please complete Student ID, Student Name, Course and Unit.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Check mark.
            if (!TryGetValidMark(out double mark))
            {
                MessageBox.Show(
                    "Please enter a valid mark between 0 and 100.",
                    "Invalid Mark",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Keep the same details for an existing Student ID.
            foreach (StudentRecord existingRecord in records)
            {
                if (existingRecord.StudentID.Equals(
                    studentId,
                    StringComparison.OrdinalIgnoreCase))
                {
                    bool sameName = existingRecord.StudentName.Equals(
                        studentName,
                        StringComparison.OrdinalIgnoreCase);

                    bool sameCourse = existingRecord.Course.Equals(
                        course,
                        StringComparison.OrdinalIgnoreCase);

                    if (!sameName || !sameCourse)
                    {
                        MessageBox.Show(
                            "This Student ID already exists with different student details. " +
                            "Please use the same Student Name and Course.",
                            "Student Details Mismatch",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }
                }
            }

            // Stop duplicate units for the same student.
            foreach (StudentRecord record in records)
            {
                if (record.StudentID.Equals(
                        studentId,
                        StringComparison.OrdinalIgnoreCase) &&
                    record.Unit.Equals(
                        unit,
                        StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "This unit has already been added for this student.",
                        "Duplicate Unit",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            double unitGPA = CalculateGPA(mark);

            StudentRecord newRecord = new StudentRecord
            {
                StudentID = studentId,
                StudentName = studentName,
                Course = course,
                Unit = unit,
                Mark = mark,
                GPA = unitGPA
            };

            // Save the record.
            records.Add(newRecord);

            double overallGPA = CalculateOverallGPA(studentId);
            double currentWAM = CalculateWAM(studentId);

            txtGPA.Text = overallGPA.ToString("0.00");
            txtWAM.Text = currentWAM.ToString("0.00");

            DisplayStudentStatus(currentWAM);

            // Add the unit to the table.
            dgvStudents.Rows.Add(
                studentId,
                studentName,
                course,
                unit,
                mark.ToString("0.00"),
                unitGPA.ToString("0.00")
            );

            MessageBox.Show(
                "Student unit record added successfully!",
                "Record Added",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Keep student details ready for the next unit.
            txtUnit.Clear();
            txtMarks.Clear();
            txtUnit.Focus();
        }

        // Search for a student by ID.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentID.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentId))
            {
                MessageBox.Show(
                    "Please enter a Student ID.",
                    "Missing Student ID",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            StudentRecord? foundRecord = null;

            foreach (StudentRecord record in records)
            {
                if (record.StudentID.Equals(
                    studentId,
                    StringComparison.OrdinalIgnoreCase))
                {
                    foundRecord = record;
                    break;
                }
            }

            if (foundRecord == null)
            {
                dgvStudents.ClearSelection();

                txtStudentName.Clear();
                txtCourse.Clear();
                txtUnit.Clear();
                txtMarks.Clear();
                txtGPA.Clear();
                txtWAM.Clear();

                lblStudentStatus.Text = "-";
                lblStudentStatus.ForeColor = SystemColors.ControlText;

                MessageBox.Show(
                    "Student record not found.",
                    "Student Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            txtStudentName.Text = foundRecord.StudentName;
            txtCourse.Text = foundRecord.Course;
            txtUnit.Clear();
            txtMarks.Clear();

            double overallGPA = CalculateOverallGPA(studentId);
            double currentWAM = CalculateWAM(studentId);

            txtGPA.Text = overallGPA.ToString("0.00");
            txtWAM.Text = currentWAM.ToString("0.00");

            DisplayStudentStatus(currentWAM);

            // Highlight all rows that belong to the searched student.
            dgvStudents.ClearSelection();

            DataGridViewRow? firstMatch = null;

            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string rowStudentId =
                    row.Cells[0].Value?.ToString() ?? "";

                if (rowStudentId.Equals(
                    studentId,
                    StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;

                    if (firstMatch == null)
                    {
                        firstMatch = row;
                    }
                }
            }

            // Move to the first matching row.
            if (firstMatch != null)
            {
                dgvStudents.CurrentCell = firstMatch.Cells[0];
                dgvStudents.FirstDisplayedScrollingRowIndex = firstMatch.Index;
            }

            MessageBox.Show(
                "Student record found.",
                "Search Result",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Clear the form fields.
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtStudentName.Clear();
            txtCourse.Clear();
            txtUnit.Clear();
            txtMarks.Clear();
            txtGPA.Clear();
            txtWAM.Clear();

            lblStudentStatus.Text = "-";
            lblStudentStatus.ForeColor = SystemColors.ControlText;

            dgvStudents.ClearSelection();

            txtStudentID.Focus();
        }

        private void dgvStudents_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void lblStudentID_Click(object sender, EventArgs e)
        {
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
        }
    }
}