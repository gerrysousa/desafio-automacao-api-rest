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
    class GetIssuesAssignedToMeRequest : RequestBase
    {
        public GetIssuesAssignedToMeRequest()
        {
            requestService = "/api/rest/issues?filter_id=assigned";
            method = Method.GET;
        }
    }
}
