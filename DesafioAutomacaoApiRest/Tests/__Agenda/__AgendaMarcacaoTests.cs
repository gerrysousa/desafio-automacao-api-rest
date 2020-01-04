using NUnit.Framework;
using RestSharp;
using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Requests.Agenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Tests.Agenda
{
    [TestFixture]
    public class AgendaMarcacaoTests : TestBase
    {
        [Test]
        public void DadosValidos()
        { 
            #region Parameters
            string localAtendimentoId = "0a66ce87-9292-497f-a157-d290c504575b";
            string prestadoresLocalAtendimentoIds = "c8b703db-621d-48c9-8c2a-3365def42f99";
            string pacienteId = "";
            string medicoId = "ff2af2c7-6890-4dd9-8b1e-4ae92b2b823d";
            string dataAgendamento = "2019-07-22";
            string orderProperty = "horaInicio";
            string orderType = "ASC";
            string orderFirst = "true";
            string especialidadesId = "";

            //Resultado esperado
            string status = "OK";
            #endregion

            __AgendaMarcacoRequest agendaMarcacaoRequest = new __AgendaMarcacoRequest(localAtendimentoId, prestadoresLocalAtendimentoIds);
            agendaMarcacaoRequest.SetJsonBody(pacienteId, medicoId, dataAgendamento, orderProperty, orderType, orderFirst, localAtendimentoId, especialidadesId, prestadoresLocalAtendimentoIds);

            IRestResponse<dynamic> response = agendaMarcacaoRequest.ExecuteRequest();

            Assert.AreEqual(status, response.StatusCode.ToString());
        }
    }
}
