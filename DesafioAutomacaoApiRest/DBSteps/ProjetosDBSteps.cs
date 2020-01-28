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
        public static void InsertNewProject(string nomeProjeto)
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/InsertNewProject.sql", Encoding.UTF8);
            query = query.Replace("$projectName", nomeProjeto);
            query = query.Replace("$projectDescription", nomeProjeto+" description");
            DBHelpers.ExecuteQuery(query);

            ExtentReportHelpers.AddTestInfo(2, "PARAMETERS: Executa query - " + query);
        }

        public static void DeleteAllProject()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/DeleteAllProjects.sql", Encoding.UTF8);
            DBHelpers.ExecuteQuery(query);
            ExtentReportHelpers.AddTestInfo(2, "PARAMETERS: Executa query - " + query);
        }


        //public static void InserirCargaDeProjetosDB()
        //{
        //    string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/CadastraNovosProjetos.sql", Encoding.UTF8);

        //    DBHelpers.ExecuteQuery(query);

        //    ExtentReportHelpers.AddTestInfo(2, "PARAMETERS: Executa query - " + query);
        //}


        //public static void InicialCargaDeProjetosDB()
        //{
        //    string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/IniciarProjeto01.sql", Encoding.UTF8);

        //    DBHelpers.ExecuteQuery(query);
        //}


    }
}
