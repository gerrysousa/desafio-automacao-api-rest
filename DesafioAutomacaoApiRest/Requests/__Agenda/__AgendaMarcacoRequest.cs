using RestSharp;
using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.Agenda
{
    public class __AgendaMarcacoRequest : RequestBase
    {
        public __AgendaMarcacoRequest(string localAtendimentoId, string prestaorLocalAtendimentoIds)
        {
            requestService = "/api/Agenda/Marcacao";
            method = Method.POST;
            headers.Add("LocalAtendimentoId", localAtendimentoId);
            headers.Add("PrestadorLocalAtendimentoIds", prestaorLocalAtendimentoIds);
        }

        public void SetJsonBody(string pacienteId, 
                                string medicoId, 
                                string dataAgendamento, 
                                string orderProperty, 
                                string orderType, 
                                string orderFirst, 
                                string localAtendimentoId, 
                                string especialidadesId, 
                                string prestadoresLocalAtendimentoIds)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Agenda/AgendaMarcacaoJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$pacienteId", pacienteId);
            jsonBody = jsonBody.Replace("$medicoId", medicoId);
            jsonBody = jsonBody.Replace("$dataAgendamento", dataAgendamento);
            jsonBody = jsonBody.Replace("$orderProperty", orderProperty);
            jsonBody = jsonBody.Replace("$orderType", orderType);
            jsonBody = jsonBody.Replace("$orderFirst", orderFirst);
            jsonBody = jsonBody.Replace("$localAtendimentoId", localAtendimentoId);
            jsonBody = jsonBody.Replace("$especialidadesId", especialidadesId);
            jsonBody = jsonBody.Replace("$prestadoresLocalAtendimentoIds", prestadoresLocalAtendimentoIds);
        }
    }
}
