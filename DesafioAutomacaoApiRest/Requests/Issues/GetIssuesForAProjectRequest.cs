using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.Issues
{
    class GetIssuesForAProjectRequest : RequestBase
    {
        public GetIssuesForAProjectRequest(int idProject)
        {
            requestService = "/api/rest/issues?project_id=" + idProject;
            method = Method.GET;
        }
    }
}
