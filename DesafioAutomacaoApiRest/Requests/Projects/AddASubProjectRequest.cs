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
    class AddASubProjectRequest : RequestBase
    {
        public AddASubProjectRequest(int idProjeto)
        {
            requestService = "/api/rest/projects/{project_id}/subprojects";
            method = Method.POST;

            parameters.Add("project_id", idProjeto.ToString());
        }

        public void SetJsonBody(SubProject subProject)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(subProject);
        }
    }
}
