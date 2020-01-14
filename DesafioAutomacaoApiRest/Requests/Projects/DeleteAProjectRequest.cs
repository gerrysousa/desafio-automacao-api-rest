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
    class DeleteAProjectRequest : RequestBase
    {
        public DeleteAProjectRequest(int idProject)
        {
            requestService = "/api/rest/projects/{project_id}";
            method = Method.DELETE;

            headers.Add("Authorization", Global.token);
            parameters.Add("project_id", idProject.ToString());
        }
    }
}