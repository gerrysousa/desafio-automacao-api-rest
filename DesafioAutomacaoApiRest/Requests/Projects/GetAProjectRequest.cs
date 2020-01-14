using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesafioAutomacaoApiRest.Requests.Projects
{
    class GetAProjectRequest : RequestBase
    {
        public GetAProjectRequest(int idProject)
        {
            requestService = "/api/rest/projects/{project_id}";
            method = Method.GET;

            headers.Add("Authorization", Global.token);
            parameters.Add("project_id", idProject.ToString());
        }
    }
}