using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Objects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.Projects
{
    class UpdateAProjectRequest : RequestBase
    {
        public UpdateAProjectRequest(int idProject)
        {
            requestService = "/api/rest/projects/{project_id}";
            method = Method.PATCH;

            parameters.Add("project_id", idProject.ToString());
        }

        public void SetJsonBody(Project project)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(project);
        }
    }
}