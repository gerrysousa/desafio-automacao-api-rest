using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.Users
{
    class GetMyUserInfoRequest : RequestBase
    {
        public GetMyUserInfoRequest()
        {
            requestService = "/api/rest/users/me";
            method = Method.GET;
        }
    }
}