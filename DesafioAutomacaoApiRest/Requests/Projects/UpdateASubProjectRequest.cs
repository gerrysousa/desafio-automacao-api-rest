using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Pages;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.Projects
{
    class UpdateASubProjectRequest : RequestBase
    {
        public UpdateASubProjectRequest(int idProject, int idSubProject)
        {
            requestService = "/api/rest/projects/{project_id}/subprojects/{subproject_id}";
            method = Method.PATCH;

            headers.Add("Authorization", Global.token);
            parameters.Add("project_id", idProject.ToString());
            parameters.Add("subproject_id", idSubProject.ToString());
        }

        public void SetJsonBody(SubProject subProject)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(subProject);
        }
    }
}