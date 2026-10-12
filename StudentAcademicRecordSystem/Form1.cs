using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StudentAcademicRecordSystem
{
    // Main form that handles the user interface and student record operations.
    public partial class Form1 : Form
    {
        // Store student records while the application is running.
        private readonly List<StudentRecord> records =
            new List<StudentRecord>();

        // Set up the form and student records table.
        public Form1()
        {
            InitializeComponent();

            // Allow all matching rows to be highlighted during a search.
            dgvStudents.MultiSelect = true;

            // Allow scrolling when many records are displayed.
            dgvStudents.ScrollBars = ScrollBars.Both;
        }

        // Designer-linked handlers.
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label1_Click_2(object sender, EventArgs e) { }
        private void label1_Click_3(object sender, EventArgs e) { }
        private void txtGPA_TextChanged(object sender, EventArgs e) { }

        // Calculate the GPA for a unit based on the mark.
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

        // Calculate the student's overall GPA.
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

        // Calculate the student's WAM from recorded marks
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

        // Show the student's current academic status.
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

        // Clear the calculated results from the form.
        private void ClearAcademicResults()
        {
            txtGPA.Clear();
            txtWAM.Clear();

            lblStudentStatus.Text = "-";
            lblStudentStatus.ForeColor =
                SystemColors.ControlText;

            dgvStudents.ClearSelection();
        }

        // Check that the entered mark is between 0 and 100.
        private bool TryGetValidMark(out double mark)
        {
            return double.TryParse(txtMarks.Text, out mark) &&
                   mark >= 0 &&
                   mark <= 100;
        }

        // Preview the GPA for the entered mark.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentID.Text.Trim();
            string studentName = txtStudentName.Text.Trim();
            string course = txtCourse.Text.Trim();

            // Check whether this student already exists.
            StudentRecord? existingStudent = null;

            foreach (StudentRecord record in records)
            {
                if (record.StudentID.Equals(
                    studentId,
                    StringComparison.OrdinalIgnoreCase))
                {
                    existingStudent = record;
                    break;
                }
            }

            // Make sure the saved student details match.
            if (existingStudent != null)
            {
                bool sameName = existingStudent.StudentName.Equals(
                    studentName,
                    StringComparison.OrdinalIgnoreCase);

                bool sameCourse = existingStudent.Course.Equals(
                    course,
                    StringComparison.OrdinalIgnoreCase);

                if (!sameName || !sameCourse)
                {
                    ClearAcademicResults();

                    MessageBox.Show(
                        "This Student ID already exists with different student details. " +
                        "Please use the correct Student Name and Course.",
                        "Student Details Mismatch",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Update the student's current GPA and WAM.
                double overallGPA =
                    CalculateOverallGPA(studentId);

                double currentWAM =
                    CalculateWAM(studentId);

                txtGPA.Text =
                    overallGPA.ToString("0.00");

                txtWAM.Text =
                    currentWAM.ToString("0.00");

                DisplayStudentStatus(currentWAM);
            }
            else
            {
                // Clear previous results when entering a new student.
                ClearAcademicResults();
            }

            // Validate the mark and show the unit GPA.
            if (TryGetValidMark(out double mark))
            {
                double unitGPA = CalculateGPA(mark);

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

        // Add a new unit record for the student.
        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentID.Text.Trim();
            string studentName = txtStudentName.Text.Trim();
            string course = txtCourse.Text.Trim();
            string unit = txtUnit.Text.Trim();

            // Check whether this student already exists.
            StudentRecord? existingStudent = null;

            foreach (StudentRecord record in records)
            {
                if (record.StudentID.Equals(
                    studentId,
                    StringComparison.OrdinalIgnoreCase))
                {
                    existingStudent = record;
                    break;
                }
            }

            // Clear previous results when entering a new student.
            if (existingStudent == null)
            {
                ClearAcademicResults();
            }

            // Check that all required fields are completed.
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

            // Check that the entered mark is valid.
            if (!TryGetValidMark(out double mark))
            {
                MessageBox.Show(
                    "Please enter a valid mark between 0 and 100.",
                    "Invalid Mark",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Make sure an existing Student ID uses the same details.
            if (existingStudent != null)
            {
                bool sameName = existingStudent.StudentName.Equals(
                    studentName,
                    StringComparison.OrdinalIgnoreCase);

                bool sameCourse = existingStudent.Course.Equals(
                    course,
                    StringComparison.OrdinalIgnoreCase);

                if (!sameName || !sameCourse)
                {
                    ClearAcademicResults();

                    MessageBox.Show(
                        "This Student ID already exists with different student details. " +
                        "Please use the same Student Name and Course.",
                        "Student Details Mismatch",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Update the student's saved academic results.
                double existingOverallGPA =
                    CalculateOverallGPA(studentId);

                double existingWAM =
                    CalculateWAM(studentId);

                txtGPA.Text =
                    existingOverallGPA.ToString("0.00");

                txtWAM.Text =
                    existingWAM.ToString("0.00");

                DisplayStudentStatus(existingWAM);
            }

            // Prevent the same unit from being added twice.
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

            // Create the new student unit record.
            StudentRecord newRecord = new StudentRecord
            {
                StudentID = studentId,
                StudentName = studentName,
                Course = course,
                Unit = unit,
                Mark = mark,
                GPA = unitGPA
            };

            // Save the record to the list.
            records.Add(newRecord);

            // Update the student's GPA, WAM and status.
            double overallGPA =
                CalculateOverallGPA(studentId);

            double currentWAM =
                CalculateWAM(studentId);

            txtGPA.Text =
                overallGPA.ToString("0.00");

            txtWAM.Text =
                currentWAM.ToString("0.00");

            DisplayStudentStatus(currentWAM);

            // Display the new record in the table.
            dgvStudents.Rows.Add(
                studentId,
                studentName,
                course,
                unit,
                mark.ToString("0.##"),
                unitGPA.ToString("0.00")
            );

            MessageBox.Show(
                "Student unit record added successfully!",
                "Record Added",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Keep the student details ready for another unit.
            txtUnit.Clear();
            txtMarks.Clear();
            txtUnit.Focus();
        }

        // Search for a student using the Student ID.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentID.Text.Trim();

            // Check that a Student ID has been entered.
            if (string.IsNullOrWhiteSpace(studentId))
            {
                MessageBox.Show(
                    "Please enter a Student ID.",
                    "Missing Student ID",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Find the matching student record.
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

            // Clear the results if the student is not found.
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
                lblStudentStatus.ForeColor =
                    SystemColors.ControlText;

                MessageBox.Show(
                    "Student record not found.",
                    "Student Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // Display the stored student details.
            txtStudentName.Text =
                foundRecord.StudentName;

            txtCourse.Text =
                foundRecord.Course;

            txtUnit.Clear();
            txtMarks.Clear();

            // Calculate and display the student's results.
            double overallGPA =
                CalculateOverallGPA(studentId);

            double currentWAM =
                CalculateWAM(studentId);

            txtGPA.Text =
                overallGPA.ToString("0.00");

            txtWAM.Text =
                currentWAM.ToString("0.00");

            DisplayStudentStatus(currentWAM);

            // Highlight all records belonging to the student.
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

            // Move the table to the first matching record.
            if (firstMatch != null)
            {
                dgvStudents.CurrentCell =
                    firstMatch.Cells[0];

                dgvStudents.FirstDisplayedScrollingRowIndex =
                    firstMatch.Index;
            }

            MessageBox.Show(
                "Student record found.",
                "Search Result",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Clear the form for a new operation.
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
            lblStudentStatus.ForeColor =
                SystemColors.ControlText;

            dgvStudents.ClearSelection();

            txtStudentID.Focus();
        }

        // Designer-linked DataGridView handler.
        private void dgvStudents_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        // Designer-linked label handler.
        private void lblStudentID_Click(
            object sender,
            EventArgs e)
        {
        }

        // Designer-linked status label handler.
        private void lblStatus_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}