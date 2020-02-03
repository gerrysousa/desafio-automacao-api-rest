using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Objects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = DesafioAutomacaoApiRest.Objects.File;

namespace DesafioAutomacaoApiRest.Requests.Issues
{
    class AddAttachmentsToIssueRequest : RequestBase
    {
        public AddAttachmentsToIssueRequest(int idIssue)
        {
            requestService = "/api/rest/issues/{issue_id}/files";
            method = Method.POST;

            parameters.Add("issue_id", idIssue.ToString());
        }

        public void SetJsonBody(Issue issue)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(issue);
        }

    }
}