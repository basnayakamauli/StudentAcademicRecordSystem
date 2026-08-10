namespace StudentAcademicRecordSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void txtGPA_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtStudentName.Clear();
            txtCourse.Clear();
            txtUnit.Clear();
            txtMarks.Clear();
            txtGPA.Clear();
            txtWAM.Clear();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtMarks.Text, out double mark) &&
                mark >= 0 && mark <= 100)
            {

                double gpa;

                if (mark >= 80)
                    gpa = 4.0;
                else if (mark >= 70)
                    gpa = 3.0;
                else if (mark >= 60)
                    gpa = 2.0;
                else if (mark >= 50)
                    gpa = 1.0;
                else
                    gpa = 0.0;

                txtGPA.Text = gpa.ToString("0.0");
                txtWAM.Text = mark.ToString("0.0");
            }
            else
            {
                MessageBox.Show(
                      "Please enter a valid mark between 0 and 100.",
                      "Invalid Mark",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning
                );
            }
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) ||
                string.IsNullOrWhiteSpace(txtStudentName.Text))
            {
                MessageBox.Show(
                    "Please enter the Student ID and Student Name.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            dgvStudents.Rows.Add(
                txtStudentID.Text,
                txtStudentName.Text,
                txtCourse.Text,
                txtUnit.Text,
                txtMarks.Text,
                txtGPA.Text,
                txtWAM.Text
            );

            MessageBox.Show(
                "Student record added successfully!",
                "Record Added",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}


