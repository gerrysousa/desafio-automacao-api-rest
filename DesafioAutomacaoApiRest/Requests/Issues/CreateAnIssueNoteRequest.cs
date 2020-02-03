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
    class CreateAnIssueNoteRequest : RequestBase
    {
        public CreateAnIssueNoteRequest(int idIssue)
        {
            requestService = "/api/rest/issues/{issue_id}/notes";
            method = Method.POST;

            parameters.Add("issue_id", idIssue.ToString());
        }

        public void SetJsonBody(Note note)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(note);
        }

    }
}