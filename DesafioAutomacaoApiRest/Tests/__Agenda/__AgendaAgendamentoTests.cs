using NUnit.Framework;
using RestSharp;
using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Requests.Agenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Tests.Agenda
{
    [TestFixture]
    public class AgendaAgendamentoTests : TestBase
    {
        [Test]
        public void DadosValidos()
        {
            #region Parameters
            string idAgendamento = "B6B41CD6-746D-4878-AAB7-0044E4DCE436";

            //Resultado esperado
            string statusCodeEsperado = "OK";
            string agendamentoId = "b6b41cd6-746d-4878-aab7-0044e4dce436";
            string createDate = "2019-05-07T14:07:14.037";
            string recepcaoId = "796e4311-ee38-4d72-88a0-59f1ec6643b6";
            string carteiraPacienteId = "017d996f-2d59-41be-8a17-03ffde36c2bf";
            string dataAgendamento = "2019-05-07T14:15:00";
            string horaInicio = "2019-05-07T14:15:00";
            string horaFim = "2019-05-07T14:45:00";
            string horaChegada = "2019-05-07T14:08:53";
            string status = "Ausente";
            string pacienteId = "da64fe86-0bda-4370-a2c8-1128433d2c93";
            string pacienteNome = "Arlindo Luiz Queiroz Silva";
            string medicoId = "44fb0522-16a3-4db2-948f-02fe39b2c48a";
            string medicoNome = "Luciana Vale Cypriano";
            #endregion

            __AgendaAgendamentoRequest agendaAgendamento = new __AgendaAgendamentoRequest(idAgendamento);

            IRestResponse<dynamic> response = agendaAgendamento.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(agendamentoId, response.Data["result"]["id"]);
                Assert.AreEqual(createDate, response.Data["result"]["createDate"]);
                Assert.AreEqual(recepcaoId, response.Data["result"]["recepcaoId"]);
                Assert.AreEqual(carteiraPacienteId, response.Data["result"]["carteiraPacienteId"]);
                Assert.AreEqual(dataAgendamento, response.Data["result"]["dataAgendamento"]);
                Assert.AreEqual(horaInicio, response.Data["result"]["horaInicio"]);
                Assert.AreEqual(horaFim, response.Data["result"]["horaFim"]);
                Assert.AreEqual(horaChegada, response.Data["result"]["horaChegada"]);
                Assert.AreEqual(status, response.Data["result"]["status"]);
                Assert.AreEqual(pacienteId, response.Data["result"]["pacienteId"]);
                Assert.AreEqual(pacienteNome, response.Data["result"]["pacienteNome"]);
                Assert.AreEqual(medicoId, response.Data["result"]["medicoId"]);
                Assert.AreEqual(medicoNome, response.Data["result"]["medicoNome"]);
                Assert.AreEqual(carteiraPacienteId, response.Data["result"]["paciente"]["carteiras"][0]["id"]);
            });
        }
    }
}
