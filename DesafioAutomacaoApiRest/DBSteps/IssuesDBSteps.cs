using DesafioAutomacaoApiRest.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.DBSteps
{
    class IssuesDBSteps
    {
        public static void InsertNewIssue(string nomeProjeto)
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/InsertNewProject.sql", Encoding.UTF8);
            query = query.Replace("$projectName", nomeProjeto);
            query = query.Replace("$projectDescription", nomeProjeto + " description");
            DBHelpers.ExecuteQuery(query);

            ExtentReportHelpers.AddTestInfo(2, "PARAMETERS: Executa query - " + query);
        }


        public static void InserirMonitorBug01DB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/InsertBugMonitor.sql", Encoding.UTF8);

            DBHelpers.ExecuteQuery(query);

            ExtentReportHelpers.AddTestInfo(2, "PARAMETERS: Executa query - " + query);
        }

        public static void InserirAssinarBugParaUser01DB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/InsertBugAssignToUser.sql", Encoding.UTF8);

            DBHelpers.ExecuteQuery(query);

            ExtentReportHelpers.AddTestInfo(2, "PARAMETERS: Executa query - " + query);
        }
    }
}
