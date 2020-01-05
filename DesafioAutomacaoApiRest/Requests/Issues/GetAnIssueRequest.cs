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
    class GetAnIssueRequest : RequestBase
    {
        public GetAnIssueRequest(int idIssue)
        {
            requestService = "/api/rest/issues/" + idIssue;
            method = Method.GET;

            headers.Add("Authorization", Global.token);
        }
    }
}
