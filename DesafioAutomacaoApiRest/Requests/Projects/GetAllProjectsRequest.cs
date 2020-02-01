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
    class GetAllProjectsRequest : RequestBase
    {
        public GetAllProjectsRequest()
        {
            requestService = "/api/rest/projects/";
            method = Method.GET;
        }
    }
}
