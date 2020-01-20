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
        #region Objects
        Issue issue = new Issue();
        Category category = new Category();
        Project project = new Project();
        Handler handler = new Handler();
        ViewState viewState = new ViewState();
        Priority priority = new Priority();
        Severity severity = new Severity();
        Reproducibility reproducibility = new Reproducibility();
        List<CustomField> customFields = new List<CustomField>();
        List<Tag> tags = new List<Tag>();
        Tag tag = new Tag();
        CustomField customField = new CustomField();
        Field field = new Field();

        #endregion


        [Test]
        public void Test_ObterInformacoesDeUmProblemaComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";
            int idIssue = 1;
            string summary = "Descrição simples";
            string description = "Descrição detalhada ssss";

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
        public void Test_ObterProblemasPorProjetoComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";
            int idProjeto = 1;
            

            int idIssue1 = 1;
            string summary1 = "Descrição simples";
            string description1 = "Descrição detalhada ssss";

            int idIssue2 = 2;
            string summary2 = "This is a test issue";
            string description2 = "This is a test description";
            #endregion

            #region Acoes
            GetIssuesForAProjectRequest getIssuesForAProjectRequest = new GetIssuesForAProjectRequest(idProjeto);
            IRestResponse<dynamic> response = getIssuesForAProjectRequest.ExecuteRequest();
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
        public void Test_ObterInformacoesDeProblemasAssinadosParaMimComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";

            int idIssue = 2;
            string summary = "This is a test issue";
            string description = "This is a test description";

            #endregion

            #region Acoes
            GetIssuesAssignedToMeRequest getIssuesAssignedToMeRequest = new GetIssuesAssignedToMeRequest();
            IRestResponse<dynamic> response = getIssuesAssignedToMeRequest.ExecuteRequest();
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
        public void Test_ObterInformacoesDeProblemasReportadosPorMimComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";

            int idIssue = 2;
            string summary = "This is a test issue";
            string description = "This is a test description";

            #endregion

            #region Acoes
            GetIssuesReportedByMeRequest getIssuesReportedByMeRequest = new GetIssuesReportedByMeRequest();
            IRestResponse<dynamic> response = getIssuesReportedByMeRequest.ExecuteRequest();
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
        public void Test_ObterInformacoesDeProblemasMonitoradosPorMimComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";

            int idIssue = 2;
            string summary = "This is a test issue";
            string description = "This is a test description";

            #endregion

            #region Acoes
            GetIssuesMonitoredByMeRequest getIssuesMonitoredByMeRequest = new GetIssuesMonitoredByMeRequest();
            IRestResponse<dynamic> response = getIssuesMonitoredByMeRequest.ExecuteRequest();
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
        public void Test_ObterInformacoesDeProblemasNaoAtribuidosComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";

            int idIssue = 1;
            string summary = "Descrição simples";
            string description = "Descrição detalhada ssss";

            #endregion

            #region Acoes
            GetUnassignedIssuesRequest getUnassignedIssuesRequest = new GetUnassignedIssuesRequest();
            IRestResponse<dynamic> response = getUnassignedIssuesRequest.ExecuteRequest();
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



        //=============================================================
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

        [Test]
        public void Test_CadastrarProblemaTodasInformacoesComSucesso()
        {
            #region Parameters
            CreateAnIssueRequest createAnIssueRequest = new CreateAnIssueRequest();

            string statusEsperado = "Created";//201

            string summary = "Sample REST issue";
            string description = "Description for sample REST issue.";
            string additional_information = "More info about the issue";
            int projectId = 1;
            string projectName = "Projeto 01";
            int categoryid = 5;
            string categoryname = "bugtracker";
            string handlername = "vboctor";
            int view_stateid = 10;
            string view_statename = "public";
            string priorityname = "normal";
            string severityname = "trivial";
            string reproducibilityname = "always";
            bool sticky = false;

            int custom_fieldsfieldid = 4;
            string custom_fieldsfieldName = "The City";
            string custom_fieldsValue = "Seattle";

            string tagsname = "mantishub";


            #endregion

            #region Acoes

            project.id = projectId;
            project.name = projectName;

            category.id = categoryid;
            category.name = categoryname;

            handler.name = handlername;

            viewState.id = view_stateid;
            viewState.name = view_statename;

            priority.name = priorityname;

            severity.name = severityname;

            reproducibility.name = reproducibilityname;

            field.id = custom_fieldsfieldid;
            field.name = custom_fieldsfieldName;

            customField.value = custom_fieldsValue;
            customField.field = field;

            customFields.Add(customField);

            tag.name = tagsname;
            tags.Add(tag);

            //montando body
            issue.summary = summary;
            issue.description = description;
            issue.additional_information = additional_information;
            issue.category = category;
            issue.project = project;
            issue.category = category;
            issue.handler = handler;
            issue.view_state = viewState;
            issue.priority = priority;
            issue.severity = severity;
            issue.reproducibility = reproducibility;
            issue.sticky = sticky;
            //issue.custom_fields = customFields;
            issue.tags = tags;

            createAnIssueRequest.SetJsonBody(issue);

            IRestResponse<dynamic> response = createAnIssueRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(summary, response.Data.issue.summary.ToString());
                Assert.AreEqual(description, response.Data.issue.description.ToString());
                Assert.AreEqual(additional_information, response.Data.issue.additional_information.ToString());
                Assert.AreEqual(projectName, response.Data.issue.project.name.ToString());
                //Etc
            });

            #endregion
        }


        //=============================================================
        [Test]
        public void Test_DeletarUmProblemaComSucesso()
        {
            #region Parameters
            string statusEsperado = "NoContent";//204 No Content
            int idIssue = 15;

            #endregion

            #region Acoes
            DeleteAnIssueRequest deleteAnIssueRequest = new DeleteAnIssueRequest(idIssue);
            IRestResponse<dynamic> response = deleteAnIssueRequest.ExecuteRequest();
            #endregion

            #region Asserts
           
            Assert.AreEqual(statusEsperado, response.StatusCode.ToString());

            #endregion
        }



    }
}
