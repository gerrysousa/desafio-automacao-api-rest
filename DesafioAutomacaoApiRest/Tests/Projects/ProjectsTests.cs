using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DesafioAutomacaoApiRest.Pages;
using DesafioAutomacaoApiRest.Requests.Projects;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = DesafioAutomacaoApiRest.Pages.Version;
using DesafioAutomacaoApiRest.DBSteps;

namespace DesafioAutomacaoApiRest.Tests.Projects
{
    //[Parallelizable(ParallelScope.All)]
    class ProjectsTests : TestBase
    {
        #region Objects
        Project project = new Project();
        Status status = new Status();
        ViewState viewState = new ViewState();
        SubProject subProject = new SubProject();
        Version version = new Version();

        #endregion


        [Test]
        public void Test_CadastrarUmProjetoComSucesso()
        {
            #region Parameters
            CreateAProjectRequest createAProjectRequest = new CreateAProjectRequest();
            Project project = new Project();
            Status status = new Status();
            ViewState viewState = new ViewState();

            string statusEsperado = "Created";

            //int projectId = 1;
            string projectName = "Projeto test api 01";
            string projectDescription = "Mantis.  Report problems with the actual bug tracker here. (Do not remove this account)";
            bool projectEnabled = true;
            string projectFilePath = "/tmp/";

            int statusId = 10;
            string statusName = "development";
            string statusLabel = "development";

            int viewStateId = 10;
            string viewStateName = "public";
            string viewStateLabel = "public";

            #endregion

            #region Acoes

            status.id = statusId;
            status.name = statusName;
            status.label = statusLabel;

            viewState.id = viewStateId;
            viewState.name = viewStateName;
            viewState.label = viewStateLabel;

            //montando body
           // project.id = projectId;
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

        [Test]
        public void Test_ObterUmProjetoComSucesso()
        {
            #region Parameters
            SetupCenariosHelpers.CadastrarUmProjeto("Projeto 01");

            string statusEsperado = "OK";
            int idIssue = 1;
            string projectName = "Projeto 01";
            string description = projectName + " descrição";

            #endregion

            #region Acoes
            GetAProjectRequest getAProjectRequest = new GetAProjectRequest(idIssue);
            IRestResponse<dynamic> response = getAProjectRequest.ExecuteRequest();
            #endregion

            #region Asserts
            int idResposta = response.Data["projects"][0]["id"];
            string nomeResposta = response.Data["projects"][0]["name"];
            string descriptionResposta = response.Data["projects"][0]["description"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(projectName, nomeResposta);
                Assert.AreEqual(description, descriptionResposta);
            });

            #endregion
        }

        [Test]
        public void Test_ObterTodosOsProjetosComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";

            string projectName1 = "Projeto 01";
            string description1 = projectName1 + " descrição";

            string projectName2 = "Projeto 02";
            string description2 = projectName2 + " descrição";

            SetupCenariosHelpers.CadastrarUmProjeto(projectName1);
            SetupCenariosHelpers.CadastrarUmProjeto(projectName2);
            #endregion

            #region Acoes
            GetAllProjectsRequest getAllProjectsRequest = new GetAllProjectsRequest();
            IRestResponse<dynamic> response = getAllProjectsRequest.ExecuteRequest();
            #endregion

            #region Asserts
            int idResposta = response.Data["projects"][0]["id"];
            string nomeResposta = response.Data["projects"][0]["name"];
            string descriptionResposta = response.Data["projects"][0]["description"];

            int idResposta2 = response.Data["projects"][1]["id"];
            string nomeResposta2 = response.Data["projects"][1]["name"];
            string descriptionResposta2 = response.Data["projects"][1]["description"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(projectName1, nomeResposta);
                Assert.AreEqual(description1, descriptionResposta);

                Assert.AreEqual(projectName2, nomeResposta2);
                Assert.AreEqual(description2, descriptionResposta2);
            });
            #endregion
        }

        [Test]
        public void Test_AtualizarUmProjetoComSucesso()
        {
            #region Parameters
            SetupCenariosHelpers.CadastrarUmProjeto("Projeto 01");

            string statusEsperado = "OK";

            int projectId = 1;
            string projectNameUpdate = "Projeto 01 Updated";
            bool projectEnabled = false;
            #endregion

            #region Acoes

            //montando body
            project.id = projectId;
            project.name = projectNameUpdate;
            project.enabled = projectEnabled;

            UpdateAProjectRequest updateAProjectRequest = new UpdateAProjectRequest(projectId);
            updateAProjectRequest.SetJsonBody(project);

            IRestResponse<dynamic> response = updateAProjectRequest.ExecuteRequest();
            #endregion

            #region Asserts
            Assert.Multiple(() =>
                        {
                            Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                            Assert.AreEqual(projectNameUpdate, response.Data.project.name.ToString());
                // Assert.AreEqual(projectDescription, response.Data.project.description.ToString());
                //Etc
            });
            #endregion
        }

        [Test]
        public void Test_DeletarUmProjetoComSucesso()
        {
            #region Parameters
            SetupCenariosHelpers.CadastrarUmProjeto("Projeto 01");

            string statusEsperado = "OK"; //Forbidden
            int idProject = 1;

            #endregion

            #region Acoes
            DeleteAProjectRequest deleteAProjectRequest = new DeleteAProjectRequest(idProject);
            IRestResponse<dynamic> response = deleteAProjectRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.AreEqual(statusEsperado, response.StatusCode.ToString());

            #endregion
        }

        [Test]
        public void Test_CadastrarUmSubProjetoComSucesso()
        {
            #region Parameters
            SetupCenariosHelpers.CadastrarUmProjeto("Projeto 01");
            SetupCenariosHelpers.CadastrarUmProjeto("Sub Projeto 01");

            string statusEsperado = "NoContent";//201  204Subproject '6' added to project '1'

            int projectId = 1;
            string projectName = "Sub Projeto 01";
            bool inheritParent = true;
            #endregion

            #region Acoes
            AddASubProjectRequest addASubProjectRequest = new AddASubProjectRequest(projectId);
            project.name = projectName;

            //montando body
            subProject.project = project;
            subProject.inherit_parent = inheritParent;

            addASubProjectRequest.SetJsonBody(subProject);
            IRestResponse<dynamic> response = addASubProjectRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.AreEqual(statusEsperado, response.StatusCode.ToString());

            #endregion
        }

        [Test]
        public void Test_AtualizarUmSubProjetoComSucesso()
        {
            #region Parameters
            SetupCenariosHelpers.CadastrarUmProjeto("Projeto 01");
            SetupCenariosHelpers.CadastrarUmProjeto("Sub Projeto 01");
            SetupCenariosHelpers.CadastrarUmSubProjeto("Sub Projeto 01");

            string statusEsperado = "NoContent";

            int projectId = 1;
            int subProjectId = 2;
            string projectName = "Sub Projeto update 2";
            bool inheritParent = true;

            #endregion

            #region Acoes
            //montando body
            project.name = projectName;
            project.id = projectId;

            subProject.project = project;
            subProject.inherit_parent = inheritParent;
                        
            UpdateASubProjectRequest updateASubProjectRequest = new UpdateASubProjectRequest(projectId, subProjectId);
            updateASubProjectRequest.SetJsonBody(subProject);

            IRestResponse<dynamic> response = updateASubProjectRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.AreEqual(statusEsperado, response.StatusCode.ToString());


            #endregion
        }

        [Test]
        public void Test_DeletarUmSubProjetoComSucesso()
        {
            #region Parameters
            SetupCenariosHelpers.CadastrarUmProjeto("Projeto 01");
            SetupCenariosHelpers.CadastrarUmProjeto("Sub Projeto 01");
            SetupCenariosHelpers.CadastrarUmSubProjeto("Sub Projeto 01");

            string statusEsperado = "OK";
            int idProject = 2;

            #endregion

            #region Acoes
            DeleteAProjectRequest deleteAProjectRequest = new DeleteAProjectRequest(idProject);
            IRestResponse<dynamic> response = deleteAProjectRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.AreEqual(statusEsperado, response.StatusCode.ToString());

            #endregion
        }

        [Test]
        public void Test_CadastrarUmaVersaoComSucesso()
        {
            #region Parameters
            string statusEsperado = "NoContent";

            int idProject = 2;
            string versionName = "v1.0.1";
            bool versionReleased = true;
            bool versionObsolete = true;
            #endregion

            #region Acoes
            AddVersionRequest addVersionRequest = new AddVersionRequest(idProject);

            //montando body
            version.name = versionName;
            version.released = versionReleased;
            version.obsolete = versionObsolete;

            addVersionRequest.SetJsonBody(version);
            IRestResponse<dynamic> response = addVersionRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.AreEqual(statusEsperado, response.StatusCode.ToString());

            #endregion
        }
    }
}
