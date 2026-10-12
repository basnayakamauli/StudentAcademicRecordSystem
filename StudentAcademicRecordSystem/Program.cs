namespace StudentAcademicRecordSystem
{
    // Main class used to start the application.
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Set up the Windows Forms application.
            ApplicationConfiguration.Initialize();

            // Start the application and open the main form.
            Application.Run(new Form1());
        }
    }
}
