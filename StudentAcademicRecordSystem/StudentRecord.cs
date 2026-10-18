namespace StudentAcademicRecordSystem
{
    // Represents one academic unit record for a student.
    public class StudentRecord
    {
        // Student details
        public string StudentID { get; set; } = "";
        public string StudentName { get; set; } = "";
        public string Course { get; set; } = "";
        public string Unit { get; set; } = "";

        // Academic result for one unit
        public double Mark { get; set; }
        public double GPA { get; set; }
    }
}


