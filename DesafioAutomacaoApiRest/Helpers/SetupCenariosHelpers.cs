using DesafioAutomacaoApiRest.DBSteps;
using DesafioAutomacaoApiRest.Pages;
using DesafioAutomacaoApiRest.Requests.Issues;
using DesafioAutomacaoApiRest.Requests.Projects;
using DesafioAutomacaoApiRest.Requests.Users;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = DesafioAutomacaoApiRest.Pages.Version;

namespace DesafioAutomacaoApiRest.Helpers
{
    class SetupCenariosHelpers
    {
        static Project project = new Project();
        static Status status = new Status();
        static ViewState viewState = new ViewState();
        static SubProject subProject = new SubProject();
        static Version version = new Version();
       
        public static void CadastrarUmProjeto(string nomeProjeto)
        {
            CreateAProjectRequest createAProjectRequest = new CreateAProjectRequest();

            status.id = 10;
            status.name = "development";
            status.label = "development";
            viewState.id = 10;
            viewState.name = "public";
            viewState.label = "public";

            project.name = nomeProjeto;
            project.description = nomeProjeto + " descrição";
            project.enabled = true;
            project.file_path = "/tmp/";
            project.status = status;
            project.view_state = viewState;
            createAProjectRequest.SetJsonBody(project);

            createAProjectRequest.ExecuteRequest();
        }

        public static void CadastrarUmProjetoPadrao()
        {
            CreateAProjectRequest createAProjectRequest = new CreateAProjectRequest();
            Project project = new Project();
            Status status = new Status();
            ViewState viewState = new ViewState();

            status.id = 10;
            status.name = "development";
            status.label = "development";
            viewState.id = 10;
            viewState.name = "public";
            viewState.label = "public";

            project.name = "Projeto padrao";
            project.description = "Projeto padrao descricao";
            project.enabled = true;
            project.file_path = "/tmp/";
            project.status = status;
            project.view_state = viewState;
            createAProjectRequest.SetJsonBody(project);

            createAProjectRequest.ExecuteRequest();
        }

        public static void CadastrarUmUsuario(string nomeUsuario, string loginUsuario, string tipoUsuario)
        {
            #region Parameters
            CreateAUserRequest createAUserRequest = new CreateAUserRequest();
            User user = new User();
            AccessLevel accessLevel = new AccessLevel();
            #endregion

            accessLevel.name = tipoUsuario;

            user.username = loginUsuario;
            user.password = "p@ssw0rd";
            user.real_name = nomeUsuario;
            user.email = loginUsuario+ "@email.com";
            user.access_level = accessLevel;
            user.enabled = true;
            user.@protected = false;

            createAUserRequest.SetJsonBody(user);
            createAUserRequest.ExecuteRequest();

        }

        public static void CadastrarUmSubProjeto(string nomeSubProjeto)
        {
            int projectId = 1;
            string projectName = nomeSubProjeto;
            bool inheritParent = true;

            AddASubProjectRequest addASubProjectRequest = new AddASubProjectRequest(projectId);
            project.name = projectName;
            //montando body
            subProject.project = project;
            subProject.inherit_parent = inheritParent;

            addASubProjectRequest.SetJsonBody(subProject);
            IRestResponse<dynamic> response = addASubProjectRequest.ExecuteRequest();
        }

        public static void CadastrarUmBug(string sumarioBug, string projetoNome)
        {
            CreateAnIssueRequest createAnIssueRequest = new CreateAnIssueRequest();
            Issue issue = new Issue();
            Category category = new Category();
            Project project = new Project();

            string summary = sumarioBug;
            string description = sumarioBug + " description";
            string categoryName = "General";
            string projectName = projetoNome;

            category.name = categoryName;
            project.name = projectName;

            issue.summary = summary;
            issue.description = description;
            issue.category = category;
            issue.project = project;

            createAnIssueRequest.SetJsonBody(issue);

            //IRestResponse<dynamic> response = 
            createAnIssueRequest.ExecuteRequest();
        }

    }
}