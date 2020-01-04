using RestSharp;
using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.Solicitacao
{
    public class SolicitacaoItensAssistenciaisValidosRequest : RequestBase
    {
        public SolicitacaoItensAssistenciaisValidosRequest()
        {
            requestService = "/api/Solicitacao/ItensAssistenciais/Validos";
            method = Method.POST;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody(string pacienteId, string itensAssistenciais)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath()+"Jsons/Solicitacao/SolicitacaoItensAssitenciaisValidosJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$pacienteId", pacienteId).Replace("$itensAssistenciais", itensAssistenciais);
        }
    }
}
