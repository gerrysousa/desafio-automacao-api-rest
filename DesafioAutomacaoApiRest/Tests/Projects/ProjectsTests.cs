using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DesafioAutomacaoApiRest.Objects;
using DesafioAutomacaoApiRest.Requests.Projects;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = DesafioAutomacaoApiRest.Objects.Version;
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
            string projectName = "Projeto Post Create 01";
            string projectDescription = "Projeto Post Create 01 description";
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
            string statusEsperado = "OK";
            int projectId = 1;
            string projectName = "Project 01 Default";
            string description = "Project 01 Default description";

            #endregion

            #region Acoes
            GetAProjectRequest getAProjectRequest = new GetAProjectRequest(projectId);
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

            string projectName1 = "Project 01 Default";
            string description1 = "Project 01 Default description";

            string projectName2 = "Projeto 03 Updated";
            string description2 = "Project 03 Update description";
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
            string statusEsperado = "OK";

            int projectId = 3;
            string projectNameUpdate = "Projeto 03 Updated";
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
            string statusEsperado = "OK"; 
            int idProject = 4;

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
            string statusEsperado = "NoContent";

            int projectParentId = 2;
            int subProjectId = 8;
            string projectName = "Sub-project 04 from Project 02 Create";
            bool inheritParent = true;
            #endregion

            #region Acoes
            AddASubProjectRequest addASubProjectRequest = new AddASubProjectRequest(projectParentId);

            project.id = subProjectId;
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
            string statusEsperado = "NoContent";

            int projectId = 2;
            int subProjectId = 6;
            string projectName = "Sub-project 02 from Project 02 Updated OK";
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

        //=======Cenarios de Falha
        [Test]
        public void Test_CadastrarUmaVersaoQueJaExiste()
        {
            #region Parameters
            string statusEsperado = "BadRequest";

            int idProject = 1;
            string versionName = "v1.0.0";
            bool versionReleased = true;
            bool versionObsolete = true;

            string mensagemEsperada = "Version 'v1.0.0' already exists";
            string codigoEsperado ="1600";
            string localizadorEsperado = "A version with that name already exists.";

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
            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(mensagemEsperada, response.Data.message.ToString());
                Assert.AreEqual(codigoEsperado, response.Data.code.ToString());
                Assert.AreEqual(localizadorEsperado, response.Data.localized.ToString());
                //Etc
            });
           

            #endregion
        }
    }
}
