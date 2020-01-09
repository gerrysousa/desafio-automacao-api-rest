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
    class GetIssuesReportedByMeRequest : RequestBase
    {
        public GetIssuesReportedByMeRequest()
        {
            requestService = "/api/rest/issues?filter_id=reported";
            method = Method.GET;

            headers.Add("Authorization", Global.token);
        }
    }
}
