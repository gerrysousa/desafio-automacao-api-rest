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
using DesafioAutomacaoApiRest.DBSteps;

namespace DesafioAutomacaoApiRest.Tests.Issues
{
    //[Parallelizable(ParallelScope.All)]
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
        
        [SetUp]
        public void SetUp1()
        {
            DBHelpers.ResetBD();
            SetupCenariosHelpers.CadastrarUmProjeto("Projeto 01");
        }


        [Test]
        public void Test_ObterInformacoesDeUmProblemaComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";
            int idIssue = 1;
            string summary = "This is a test issue";
            string description = "This is a test issue description";

            SetupCenariosHelpers.CadastrarUmBug(summary, "Projeto 01");
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

            string summary1 = "Issue No Assigned 01";
            string description1 = "Issue No Assigned 01 description";

            string summary2 = "Issue No Assigned 02";
            string description2 = "Issue No Assigned 02 description";

            SetupCenariosHelpers.CadastrarUmBug(summary1, "Projeto 01");
            SetupCenariosHelpers.CadastrarUmBug(summary2, "Projeto 01");

            #endregion

            #region Acoes
            GetAllIssuesRequest getAllIssuesRequest = new GetAllIssuesRequest(pageSize, page);
            IRestResponse<dynamic> response = getAllIssuesRequest.ExecuteRequest();
            #endregion

            #region Asserts
            string summaryResposta1 = response.Data["issues"][1]["summary"];
            string descriptionResposta1 = response.Data["issues"][1]["description"];

            string summaryResposta2 = response.Data["issues"][0]["summary"];
            string descriptionResposta2 = response.Data["issues"][0]["description"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());

                Assert.AreEqual(summary1, summaryResposta1);
                Assert.AreEqual(description1, descriptionResposta1);

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

            string summary1 = "Issue No Assigned 01";
            string description1 = "Issue No Assigned 01 description";

            string summary2 = "Issue No Assigned 02";
            string description2 = "Issue No Assigned 02 description";

            SetupCenariosHelpers.CadastrarUmBug(summary1, "Projeto 01");
            SetupCenariosHelpers.CadastrarUmBug(summary2, "Projeto 01");


            #endregion

            #region Acoes
            GetIssuesForAProjectRequest getIssuesForAProjectRequest = new GetIssuesForAProjectRequest(idProjeto);
            IRestResponse<dynamic> response = getIssuesForAProjectRequest.ExecuteRequest();
            #endregion

            #region Asserts
            string summaryResposta1 = response.Data["issues"][0]["summary"];
            string descriptionResposta1 = response.Data["issues"][0]["description"];

            string summaryResposta2 = response.Data["issues"][1]["summary"];
            string descriptionResposta2 = response.Data["issues"][1]["description"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());

                Assert.AreEqual(summary1, summaryResposta1);
                Assert.AreEqual(description1, descriptionResposta1);

                Assert.AreEqual(summary2, summaryResposta2);
                Assert.AreEqual(description2, descriptionResposta2);
            });

            #endregion
        }

        [Test]
        public void Test_ObterInformacoesDeProblemasAssinadosParaMimComSucesso()
        {
            #region Parameters
            SetupCenariosHelpers.CadastrarUmBug("Bug obter info","Projeto 01");
            IssuesDBSteps.InserirAssinarBugParaUser01DB();

            string statusEsperado = "OK";

            string summary = "Bug obter info";
            string description = "Bug obter info description";

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

            string summary = "This is a test issue No Assigned";
            string description = "This is a test issue No Assigned description";

            SetupCenariosHelpers.CadastrarUmBug(summary, "Projeto 01");
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

            string summary = "This is a test issue";
            string description = "This is a test issue description";

            SetupCenariosHelpers.CadastrarUmBug(summary, "Projeto 01");
            IssuesDBSteps.InserirMonitorBug01DB();
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

            string summary = "This is a test issue No Assigned";
            string description = "This is a test description No Assigned";
            string categoryName = "General";
            string projectName = "Projeto 01";

            #endregion

            #region Acoes
            CreateAnIssueRequest createAnIssueRequest = new CreateAnIssueRequest();
            Issue issue = new Issue();
            Category category = new Category();
            Project project = new Project();
            category.name = categoryName;
            project.name = projectName;

            issue.summary = summary;
            issue.description = description;
            issue.category = category;
            issue.project = project;

            createAnIssueRequest.SetJsonBody(issue);

            IRestResponse<dynamic> response1 = createAnIssueRequest.ExecuteRequest();


            GetUnassignedIssuesRequest getUnassignedIssuesRequest = new GetUnassignedIssuesRequest();
            IRestResponse<dynamic> response = getUnassignedIssuesRequest.ExecuteRequest();
            #endregion

            #region Asserts
            string summaryResposta = response.Data["issues"][0]["summary"];
            string descriptionResposta = response.Data["issues"][0]["description"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
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
            //SetupCenariosHelpers.CadastrarUmProjeto("Projeto 01");
            SetupCenariosHelpers.CadastrarUmBug("Bug 01", "Projeto 01");
            string statusEsperado = "NoContent";//204 No Content
            int idIssue = 1;

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
