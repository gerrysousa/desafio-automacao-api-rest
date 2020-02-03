using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DesafioAutomacaoApiRest.Objects;
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
        List<File> files = new List<File>();


        #endregion

        [Test]
        public void Test_ObterInformacoesDeUmProblemaComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";
            int idIssue = 1;
            string summary = "Sumary Issue 01 Default";
            string description = "Sumary Issue 01 Default description";

            #endregion

            #region Acoes
            GetAnIssueRequest getAnIssueRequest = new GetAnIssueRequest(idIssue);
            IRestResponse<dynamic> response = getAnIssueRequest.ExecuteRequest();
            #endregion

            #region Asserts

            //Array teste = response.Data;
            Helpers.JsonDeserializer aux = new Helpers.JsonDeserializer();
            //jsonBody = aux.Deserialize(issue);
            
            JArray a = JArray.Parse(response.Data.issues.ToString());


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

            string summary1 = "This is a test issue";
            string description1 = "This is a test description";

            string summary2 = "Sumary Issue 09 Test Post";
            string description2 = "Sumary Issue 09 Test Post description";

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

            string summary1 = "Summary Issue 06 With Note to Delete";
            string description1 = "Summary Issue 06 With Note to Delete description";

            string summary2 = "Summary Issue 05 Update";
            string description2 = "Summary Issue 05 Update description";
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
            string statusEsperado = "OK";

            string summary = "Summary Issue 04 Assigned to me";
            string description = "Summary Issue 04 Assigned to me description";

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

            string summary = "Sumary Issue 09 Test Post";
            string description = "Sumary Issue 09 Test Post description";

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

            string summary = "Sumary Issue 03 Monitored by me";
            string description = "Sumary Issue 03 Monitored by me description";

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

            string summary = "Sumary Issue 09 Test Post";
            string description = "Sumary Issue 09 Test Post description";
            string categoryName = "General";
            string projectName = "Project 03 Update";

            #endregion

            #region Acoes
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
            string projectName = "Project 03 Update";
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

            string summary = "Sumary Issue 09 Test Post";
            string description = "Sumary Issue 09 Test Post description";
            string additional_information = "More info about the issue";
            int projectId = 3;
            string projectName = "Project 03 Update";
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

        [Test]
        public void Test_CadastrarProblemaComAnexosComSucesso()
        {
            #region Parameters
            CreateAnIssueRequest createAnIssueRequest = new CreateAnIssueRequest();
            Issue issue = new Issue();
            Category category = new Category();
            Project project = new Project();
            File file = new File();

            string statusEsperado = "Created";

            string summary = "Esse report contem um anexo";
            string description = "Esse report contem um anexo description";
            string categoryName = "General";
            string projectName = "Project 03 Update";

            string anexoNome = "test.txt";
            string anexoConteudo = "VGhpcyBpcyBhIFRFU1QuDQpUaGlzIGlzIGEgVEVTVC4NClRoaXMgaXMgYSBURVNULg0KVGhpcyBpcyBhIFRFU1QuDQpUaGlzIGlzIGEgVEVTVC4=";
            #endregion

            #region Acoes
            category.name = categoryName;
            project.name = projectName;

            file.name =anexoNome;
            file.content = anexoConteudo;

            files.Add(file);

            issue.summary = summary;
            issue.description = description;
            issue.category = category;
            issue.project = project;
            issue.files = files;

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
        public void Test_AddAnexoAUmProblemaComSucesso()
        {
            #region Parameters
            AddAttachmentsToIssueRequest addAttachmentsToIssueRequest;// = new AddAttachmentsToIssueRequest();
            File file = new File();

            string statusEsperado = "Created";

            int idIssue = 1;
            string anexoNome = "test.txt";
            string anexoConteudo = "VGhpcyBpcyBhIFRFU1QuDQpUaGlzIGlzIGEgVEVTVC4NClRoaXMgaXMgYSBURVNULg0KVGhpcyBpcyBhIFRFU1QuDQpUaGlzIGlzIGEgVEVTVC4=";
            #endregion

            #region Acoes
            file.name = anexoNome;
            file.content = anexoConteudo;

            files.Add(file);

            issue.files = files;

            addAttachmentsToIssueRequest = new AddAttachmentsToIssueRequest(idIssue);

            addAttachmentsToIssueRequest.SetJsonBody(issue);

            IRestResponse<dynamic> response = addAttachmentsToIssueRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
            #endregion
        }

        [Test]
        public void Test_AddNotasAUmProblemaComSucesso()
        {
            #region Parameters
            CreateAnIssueNoteRequest createAnIssueNoteRequest;
            Note note = new Note();

            string statusEsperado = "Created";

            int idIssue = 1;
            string textoNota = "test note";
            string viewStateName = "public";
            #endregion

            #region Acoes
            viewState.name = viewStateName;

            note.text = textoNota;
            note.view_state = viewState;


            createAnIssueNoteRequest = new CreateAnIssueNoteRequest(idIssue);

            createAnIssueNoteRequest.SetJsonBody(note);

            IRestResponse<dynamic> response = createAnIssueNoteRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
            #endregion
        }

        [Test]
        public void Test_TentaAddNotasComTempoCronometradoAUmProblema()
        {
            #region Parameters
            CreateAnIssueNoteRequest createAnIssueNoteRequest;
            Note note = new Note();
            TimeTracking timeTracking = new TimeTracking();

            string statusEsperado = "Forbidden";

            int idIssue = 1;
            string textoNota = "test note";
            string viewStateName = "public";
            string duracao = "00:15";

            string mensagemEsperada = "time tracking disabled";
            string codigoEsperado = "13";
            string localizadorEsperado = "Access Denied.";

            #endregion

            #region Acoes
            viewState.name = viewStateName;
            timeTracking.duration = duracao;

            note.text = textoNota;
            note.view_state = viewState;
            note.time_tracking = timeTracking;

            createAnIssueNoteRequest = new CreateAnIssueNoteRequest(idIssue);

            createAnIssueNoteRequest.SetJsonBody(note);

            IRestResponse<dynamic> response = createAnIssueNoteRequest.ExecuteRequest();
            #endregion

            #region Asserts
            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(mensagemEsperada, response.Data.message.ToString());
                Assert.AreEqual(codigoEsperado, response.Data.code.ToString());
                Assert.AreEqual(localizadorEsperado, response.Data.localized.ToString());
            });
            #endregion
        }
        //=============================================================
        [Test]
        public void Test_DeletarUmProblemaComSucesso()
        {
            #region Parameters
            string statusEsperado = "NoContent";
            int idIssue = 2;

            #endregion

            #region Acoes
            DeleteAnIssueRequest deleteAnIssueRequest = new DeleteAnIssueRequest(idIssue);
            IRestResponse<dynamic> response = deleteAnIssueRequest.ExecuteRequest();
            #endregion

            #region Asserts
           
            Assert.AreEqual(statusEsperado, response.StatusCode.ToString());

            #endregion
        }

        //=====Cenarios de Falha ==============
        [Test]
        public void Test_TentarCadastrarProblemaSemInformarOProjetoDoProblema()
        {
            #region Parameters
            CreateAnIssueRequest createAnIssueRequest = new CreateAnIssueRequest();
            Issue issue = new Issue();
            Category category = new Category();
            Project project = new Project();

            string summary = "This is a test issue";
            string description = "This is a test description";
            string categoryName = "General";
           // string projectName = "Project 03 Update";

            string statusEsperado = "BadRequest";

            string mensagemEsperada = "Project not specified";
            string codigoEsperado = "11";
            string localizadorEsperado = "A necessary field \"project\" was empty. Please recheck your inputs.";

            #endregion

            #region Acoes
            category.name = categoryName;
           // project.name = projectName;

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
                Assert.AreEqual(mensagemEsperada, response.Data.message.ToString());
                Assert.AreEqual(codigoEsperado, response.Data.code.ToString());
                Assert.AreEqual(localizadorEsperado, response.Data.localized.ToString());
            });
            #endregion
        }

        [Test]
        public void Test_TentarCadastrarProblemaSemInformarADescricaoDoProblema()
        {
            #region Parameters
            CreateAnIssueRequest createAnIssueRequest = new CreateAnIssueRequest();
            Issue issue = new Issue();
            Category category = new Category();
            Project project = new Project();

            string summary = "This is a test issue";
            //string description = "This is a test description";
            string categoryName = "General";
            string projectName = "Project 03 Update";

            string statusEsperado = "BadRequest";

            string mensagemEsperada = "Description not specified";
            string codigoEsperado = "11";
            string localizadorEsperado = "A necessary field \"description\" was empty. Please recheck your inputs.";

            #endregion

            #region Acoes
            category.name = categoryName;
            project.name = projectName;

            issue.summary = summary;
            //issue.description = description;
            issue.category = category;
            issue.project = project;

            createAnIssueRequest.SetJsonBody(issue);

            IRestResponse<dynamic> response = createAnIssueRequest.ExecuteRequest();
            #endregion

            #region Asserts
            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(mensagemEsperada, response.Data.message.ToString());
                Assert.AreEqual(codigoEsperado, response.Data.code.ToString());
                Assert.AreEqual(localizadorEsperado, response.Data.localized.ToString());
            });
            #endregion
        }

        [Test]
        public void Test_TentarCadastrarProblemaSemInformarOResumoDoProblema()
        {
            #region Parameters
            CreateAnIssueRequest createAnIssueRequest = new CreateAnIssueRequest();
            Issue issue = new Issue();
            Category category = new Category();
            Project project = new Project();

            //string summary = "This is a test issue";
            string description = "This is a test description";
            string categoryName = "General";
            string projectName = "Project 03 Update";

            string statusEsperado = "BadRequest";

            string mensagemEsperada = "Summary not specified";
            string codigoEsperado = "11";
            string localizadorEsperado = "A necessary field \"summary\" was empty. Please recheck your inputs.";

            #endregion

            #region Acoes
            category.name = categoryName;
            project.name = projectName;

            //issue.summary = summary;
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
                Assert.AreEqual(mensagemEsperada, response.Data.message.ToString());
                Assert.AreEqual(codigoEsperado, response.Data.code.ToString());
                Assert.AreEqual(localizadorEsperado, response.Data.localized.ToString());
            });
            #endregion
        }

        [Test]
        public void Test_TentarCadastrarProblemaSemInformarACategoriaDoProblema()
        {
            #region Parameters
            CreateAnIssueRequest createAnIssueRequest = new CreateAnIssueRequest();
            Issue issue = new Issue();
            Category category = new Category();
            Project project = new Project();

            string summary = "This is a test issue";
            string description = "This is a test description";
            string projectName = "Project 03 Update";

            string statusEsperado = "BadRequest";

            string mensagemEsperada = "Category field must be supplied.";
            string codigoEsperado = "11";
            string localizadorEsperado = "A necessary field \"category\" was empty. Please recheck your inputs.";

            #endregion

            #region Acoes
            project.name = projectName;

            issue.summary = summary;
            issue.description = description;
            issue.project = project;

            createAnIssueRequest.SetJsonBody(issue);

            IRestResponse<dynamic> response = createAnIssueRequest.ExecuteRequest();
            #endregion

            #region Asserts
            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(mensagemEsperada, response.Data.message.ToString());
                Assert.AreEqual(codigoEsperado, response.Data.code.ToString());
                Assert.AreEqual(localizadorEsperado, response.Data.localized.ToString());
            });
            #endregion
        }

        [Test]
        public void Test_TentarObterInformacoesDeUmProblemaQueNaoExiste()
        {
            #region Parameters
            string statusEsperado = "NotFound";
            int idIssue = 100;

            string mensagemEsperada = "Issue #100 not found";
            string codigoEsperado = "1100";
            string localizadorEsperado = "Issue 100 not found.";

            #endregion

            #region Acoes
            GetAnIssueRequest getAnIssueRequest = new GetAnIssueRequest(idIssue);
            IRestResponse<dynamic> response = getAnIssueRequest.ExecuteRequest();
            #endregion

            #region Asserts
            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(mensagemEsperada, response.Data.message.ToString());
                Assert.AreEqual(codigoEsperado, response.Data.code.ToString());
                Assert.AreEqual(localizadorEsperado, response.Data.localized.ToString());
            });

            #endregion
        }



    }
}
