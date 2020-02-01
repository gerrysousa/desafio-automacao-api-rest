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
    class GetUnassignedIssuesRequest : RequestBase
    {
        public GetUnassignedIssuesRequest()
        {
            requestService = "/api/rest/issues?filter_id=unassigned";
            method = Method.GET;
        }
    }
}