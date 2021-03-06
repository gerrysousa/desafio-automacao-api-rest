﻿using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Objects;
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
        }

        public void SetJsonBody(Issue issue)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(issue);
        }      

    }
}
