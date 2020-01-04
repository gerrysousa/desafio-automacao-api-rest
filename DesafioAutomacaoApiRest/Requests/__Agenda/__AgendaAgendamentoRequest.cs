using RestSharp;
using DesafioAutomacaoApiRest.Bases;

namespace DesafioAutomacaoApiRest.Requests.Agenda
{
    public class __AgendaAgendamentoRequest : RequestBase
    {

        public __AgendaAgendamentoRequest(string idAgendamento)
        {
            requestService = "/api/Agenda/Agendamento/{idAgendamento}";
            method = Method.GET;

            parameters.Add("idAgendamento", idAgendamento);
        }
    }
}
