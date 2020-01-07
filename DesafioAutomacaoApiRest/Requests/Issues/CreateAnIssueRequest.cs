using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Pages;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.Issues
{
    class CreateAnIssueRequest : RequestBase
    {
        public CreateAnIssueRequest()
        {
            requestService = "/api/rest/issues/";
            method = Method.POST;

            headers.Add("Authorization", Global.token);
        }

        public void SetJsonBody(Issue issue)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(issue);
        }      

    }
}
