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
    class DeletarUsuarioRequest : RequestBase
    {
        public DeletarUsuarioRequest(int idUser)
        {
            requestService = "/api/rest/users/"+ idUser;
            method = Method.DELETE;

            headers.Add("Authorization", Global.token);
        }
    }
}
