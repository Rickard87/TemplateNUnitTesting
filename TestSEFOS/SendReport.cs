using System.Text;

namespace TestSEFOS
{
    [SetUpFixture] // This attribute is used to indicate setup/teardown for the entire assembly
    public class SendReport
    {
        private readonly string reportPath = @"C:\ReportTest\";
        private readonly string fileName = "report.txt";
        private StringWriter consoleOutput; // To capture console output

        [OneTimeSetUp] // Runs once before any tests are executed
        public void RunBeforeAnyTests()
        {
            // Create the directory if it doesn't exist
            Directory.CreateDirectory(reportPath);

            // Redirect console output to capture test messages
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        [OneTimeTearDown] // Runs once after all tests have been executed
        public void RunAfterAllTests()
        {
            //Generating the report after all tests are finished

            // Get the captured console output
            string capturedOutput = consoleOutput.ToString();

            // Sample report content
            string reportContent = GenerateTestReport(capturedOutput);

            // Write the report to the file
            WriteReportToFile(reportContent);

            // Restore the original console output (optional)
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
            consoleOutput.Dispose();
        }

        private string GenerateTestReport(string capturedOutput)
        {
            // Generate report content with the captured console output
            var sb = new StringBuilder();
            sb.AppendLine($"SEFOS Test Execution Report");
            sb.AppendLine($"Date: {DateTime.Now}");
            sb.AppendLine();
            sb.AppendLine("=== Captured Console Output ===");
            sb.AppendLine(capturedOutput);
            sb.AppendLine("===============================");

            return sb.ToString();
        }

        private void WriteReportToFile(string reportContent)
        {
            try
            {
                // Ensure two new lines before the new report
                string newReport = reportContent + Environment.NewLine + Environment.NewLine;

                // Read the current content if the file exists
                string existingContent = File.Exists(reportPath + fileName) ? File.ReadAllText(reportPath + fileName) : string.Empty;

                // Combine the new report with the existing content (newest report at the top)
                string combinedContent = newReport + existingContent;

                // Write the combined content back to the file
                File.WriteAllText(reportPath + fileName, combinedContent);

                Console.WriteLine($"Report added to: {reportPath + fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write report: {ex.Message}");
            }
        }
    }
}
