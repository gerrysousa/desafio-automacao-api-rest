using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DesafioAutomacaoApiRest.Pages;
using DesafioAutomacaoApiRest.Requests.Issues;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DesafioAutomacaoApiRest.Requests.Projects;

namespace DesafioAutomacaoApiRest.Tests.DDT
{
    class DataDrivenTests : TestBase
    {
        #region Objetos
        CreateAnIssueRequest createAnIssueRequest = new CreateAnIssueRequest();
        Issue issue = new Issue();
        Category category = new Category();
        Project project = new Project();
        CreateAProjectRequest createAProjectRequest = new CreateAProjectRequest();
        Status status = new Status();
        ViewState viewState = new ViewState();

        #endregion

        #region Data Driven Providers
        public static IEnumerable CadastrarProblemasProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/CadastrarProblemas.csv");
        }

        public static IEnumerable CadastrarProjetosProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/CadastrarProjetos.csv");
        }
        #endregion

       [SetUp]
       public void SetUp1()
       {
          //DBHelpers.ResetBD();
           SetupCenariosHelpers.CadastrarUmProjeto("Projeto 01");
        }

        [Test, TestCaseSource("CadastrarProblemasProvider")]
        public void Test_CadastrarProblemaMinimoInformacoesComSucessoDDT(ArrayList testData)
        {
            #region Parameters
            string statusEsperado = "Created";

            string summary = testData[0].ToString();
            string description = testData[1].ToString();
            string categoryName = testData[2].ToString();
            string projectName = testData[3].ToString();
            #endregion

            #region Acoes
            category.name = categoryName;
            project.name = projectName;

            issue.summary = summary;
            issue.description = description;
            issue.category = category;
            issue.project = project;

            createAnIssueRequest.SetJsonBody(issue);

            IRestResponse<dynamic> response = createAnIssueRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(summary, response.Data.issue.summary.ToString());
                Assert.AreEqual(description, response.Data.issue.description.ToString());

                Assert.AreEqual(categoryName, response.Data.issue.category.name.ToString());
                Assert.AreEqual(projectName, response.Data.issue.project.name.ToString());
                //Etc
            });

            #endregion
        }

        [Test, TestCaseSource("CadastrarProjetosProvider")]
        public void Test_CadastrarUmProjetoComSucessoDDT(ArrayList testData)
        {
            #region Parameters
            string statusEsperado = "Created";

            int projectId = Convert.ToInt32(testData[0]);
            string projectName = testData[1].ToString();
            string projectDescription = testData[2].ToString();
            bool projectEnabled = Convert.ToBoolean(testData[3]);
            string projectFilePath = testData[4].ToString();

            int statusId = Convert.ToInt32(testData[5]);
            string statusName = testData[6].ToString();
            string statusLabel = testData[7].ToString(); ;

            int viewStateId = Convert.ToInt32(testData[8]);
            string viewStateName = testData[9].ToString();
            string viewStateLabel = testData[10].ToString();

            #endregion

            #region Acoes

            status.id = statusId;
            status.name = statusName;
            status.label = statusLabel;

            viewState.id = viewStateId;
            viewState.name = viewStateName;
            viewState.label = viewStateLabel;

            //montando body
            project.id = projectId;
            project.name = projectName;
            project.description = projectDescription;
            project.enabled = projectEnabled;
            project.file_path = projectFilePath;
            project.status = status;
            project.view_state = viewState;

            createAProjectRequest.SetJsonBody(project);

            IRestResponse<dynamic> response = createAProjectRequest.ExecuteRequest();
            #endregion

            #region Asserts
            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(projectName, response.Data.project.name.ToString());
                Assert.AreEqual(projectDescription, response.Data.project.description.ToString());
                //Etc
            });

            #endregion
        }
    }
}
