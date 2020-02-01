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
    class CreateAProjectRequest : RequestBase
    {
        public CreateAProjectRequest()
        {
            requestService = "/api/rest/projects/";
            method = Method.POST;
        }

        public void SetJsonBody(Project project)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(project);
        }
    }
}