using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.Usuarios
{
    class ObterInformacaoMeuUsuarioRequest : RequestBase
    {
        public ObterInformacaoMeuUsuarioRequest()
        {
            requestService = "/api/rest/users/me";
            method = Method.GET;

            headers.Add("Authorization", Global.token);
        }
    }
}