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
    class DeleteAUserRequest : RequestBase
    {
        public DeleteAUserRequest(int idUser)
        {
            requestService = "/api/rest/users/"+ idUser;
            method = Method.DELETE;
        }
    }
}
