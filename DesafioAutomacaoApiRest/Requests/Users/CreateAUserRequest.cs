﻿using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Pages;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.Users
{
    class CreateAUserRequest : RequestBase
    {
        public CreateAUserRequest()
        {
            requestService = "/api/rest/users/";
            method = Method.POST;

            headers.Add("Authorization", Global.token);
        }

        public void SetJsonBody(User user)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(user);
        }        
    }   
}
