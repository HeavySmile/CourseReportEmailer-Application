
using CourseReportEmailer.Commands;
using CourseReportEmailer.Models;
using CourseReportEmailer.Workers;
using Newtonsoft.Json;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace CourseReportEmailer
{
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                EnrollmentDetailReportCommand command = new EnrollmentDetailReportCommand(@"Data Source=localhost;Initial Catalog=CourseReport;Integrated Security=True");
                IList<EnrollmentDetailReportModel> models = command.GetList();

                var reportFileName = "EnrollmentDetailsReport.xlsx";
                EnrollmentDetailReportSpreadSheetCreator enrollmentSheetCreator = new EnrollmentDetailReportSpreadSheetCreator();
                enrollmentSheetCreator.Create(reportFileName, models);

                EnrollmentDetailReportEmailSender emailer = new EnrollmentDetailReportEmailSender();
                emailer.Send(reportFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
            }
        }
    }
}
