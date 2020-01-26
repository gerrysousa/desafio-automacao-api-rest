using DesafioAutomacaoApiRest.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.DBSteps
{
    class ProjetosDBSteps
    {
        public static void InserirCargaDeProjetosDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/CadastraNovosProjetos.sql", Encoding.UTF8);            

            DBHelpers.ExecuteQuery(query);

            ExtentReportHelpers.AddTestInfo(2, "PARAMETERS: Executa query - " + query);
        }

    }
}
