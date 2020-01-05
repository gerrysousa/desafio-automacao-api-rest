using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
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
        #region Parameters
        public string username { get; set; }
        public string password { get; set; }
        public string real_name { get; set; }
        public string email { get; set; }
        public AccessLevel access_level { get; set; }
        public bool enabled { get; set; }
        public bool @protected { get; set; }
        #endregion

        public CreateAUserRequest()
        {
            requestService = "/api/rest/users/";
            method = Method.POST;

            headers.Add("Authorization", Global.token);
        }

        public void SetJsonBody(CreateAUserRequest cadastrarUsuarioRequest)
        {
            Helpers.JsonSerializer aux = new Helpers.JsonSerializer();
            jsonBody = aux.Serialize(cadastrarUsuarioRequest);
        }

        #region setJson antigo
        /*
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
            jsonBody = File.ReadAllText(Global.pathProject + "Jsons/Agenda/AgendaMarcacaoJson.json", Encoding.UTF8);
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
        */
        #endregion

    }

    public class AccessLevel
    {
        public string name { get; set; }
    }
}
