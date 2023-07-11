using CourseReportEmailer.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseReportEmailer.Commands
{
    public class EnrollmentDetailReportCommand
    {
        private string _connectionString;
        public EnrollmentDetailReportCommand(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public IList<EnrollmentDetailReportModel> GetList() 
        {
            List<EnrollmentDetailReportModel> list = new List<EnrollmentDetailReportModel>();
            var sql = "EnrollmentReport_GetList";
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                list = connection.Query<EnrollmentDetailReportModel>(sql).ToList();
            }

            return list;
        }
    }
}
