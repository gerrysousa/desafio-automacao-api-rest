using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesafioAutomacaoApiRest.Requests.Authentication
{
    class AuthenticationRequest : RequestBase
    {
        public AuthenticationRequest()
        {
            url = "http://restapi.demoqa.com";

            requestService = "/authentication/CheckForAuthentication";
            method = Method.GET;
            RemoveHeader("Authorization");            
        }

        public void AddAuthentication()
        {
            httpBasicAuthenticator = true;            
        }        
    }
}