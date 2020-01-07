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

namespace DesafioAutomacaoApiRest.Tests.Issues
{
    class IssuesTestsTestBase : TestBase
    {
        [Test]
        public void Test_ObterInformacoesDeUmProblemaComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";
            int idIssue = 1;
            string summary = "Descrição simples";
            string description = "Descrição detalhada ssss";

            //    "issues": [
            //{


            #endregion

            #region Acoes
            GetAnIssueRequest getAnIssueRequest = new GetAnIssueRequest(idIssue);
            IRestResponse<dynamic> response = getAnIssueRequest.ExecuteRequest();
            #endregion

            #region Asserts
            int idResposta = response.Data["issues"][0]["id"];
            string summaryResposta = response.Data["issues"][0]["summary"];
            string descriptionResposta = response.Data["issues"][0]["description"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idIssue, idResposta);
                Assert.AreEqual(summary, summaryResposta);
                Assert.AreEqual(description, descriptionResposta);
            });

            #endregion
        }

        [Test]
        public void Test_ObterInformacoesDeTodosOsProblemaComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";
            int pageSize = 10;
            int page = 1;

            int idIssue1 = 1;
            string summary1 = "Descrição simples";
            string description1 = "Descrição detalhada ssss";

            int idIssue2 = 2;
            string summary2 = "This is a test issue";
            string description2 = "This is a test description";
            #endregion

            #region Acoes
            GetAllIssuesRequest getAllIssuesRequest = new GetAllIssuesRequest(pageSize, page);
            IRestResponse<dynamic> response = getAllIssuesRequest.ExecuteRequest();
            #endregion

            #region Asserts
            int idResposta1 = response.Data["issues"][1]["id"];
            string summaryResposta1 = response.Data["issues"][1]["summary"];
            string descriptionResposta1 = response.Data["issues"][1]["description"];

            int idResposta2 = response.Data["issues"][0]["id"];
            string summaryResposta2 = response.Data["issues"][0]["summary"];
            string descriptionResposta2 = response.Data["issues"][0]["description"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());

                Assert.AreEqual(idIssue1, idResposta1);
                Assert.AreEqual(summary1, summaryResposta1);
                Assert.AreEqual(description1, descriptionResposta1);

                Assert.AreEqual(idIssue2, idResposta2);
                Assert.AreEqual(summary2, summaryResposta2);
                Assert.AreEqual(description2, descriptionResposta2);
            });

            #endregion
        }

        [Test]
        public void Test_CadastrarProblemaMinimoInformacoesComSucesso()
        {
            #region Parameters
            CreateAnIssueRequest createAnIssueRequest = new CreateAnIssueRequest();
            Issue issue = new Issue();
            Category category = new Category();
            Project project = new Project();

            string statusEsperado = "Created";//201

            string summary = "This is a test issue";
            string description = "This is a test description";
            string categoryName = "General";
            string projectName = "Projeto 01";
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
    }
}
