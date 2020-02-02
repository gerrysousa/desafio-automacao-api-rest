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
using Version = DesafioAutomacaoApiRest.Objects.Version;

namespace DesafioAutomacaoApiRest.Requests.Projects
{
    class AddVersionRequest : RequestBase
    {
        public AddVersionRequest(int idProject)
        {
            requestService = "/api/rest/projects/{project_id}/versions/";
            method = Method.POST;

            parameters.Add("project_id", idProject.ToString());
        }

        public void SetJsonBody(Version version)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(version);
        }
    }
}