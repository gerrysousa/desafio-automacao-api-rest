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

namespace DesafioAutomacaoApiRest.Requests.Issues
{
    class DeleteAnIssueNoteRequest : RequestBase
    {
        public DeleteAnIssueNoteRequest(int idIssue, int idNote)
        {
            requestService = "/api/rest/issues/{issue_id}/notes/{issue_note_id}";
            method = Method.DELETE;

            parameters.Add("issue_id", idIssue.ToString());
            parameters.Add("issue_note_id", idNote.ToString());
        }

        public void SetJsonBody(Note note)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(note);
        }

    }
}