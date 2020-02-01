using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.Issues
{
    class GetAllIssuesRequest : RequestBase
    {
        public GetAllIssuesRequest(int pageSize, int page)
        {
            requestService = "/api/rest/issues?page_size="+pageSize+"&page=" + page;
            method = Method.GET;
        }
    }
}
