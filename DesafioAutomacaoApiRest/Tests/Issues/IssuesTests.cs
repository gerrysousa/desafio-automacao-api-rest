using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Requests.Issues;
using DesafioAutomacaoApiRest.Requests.Users;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Tests.Issues
{
    class IssuesTestsTestBase : TestBase
    {
        [Test]
        public void Test_ObterInformacoesDeUmProblemaComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";
            int idIssue = 1;
            string summary = "Descrição simples";
            string description = "Descrição detalhada ssss";

            //    "issues": [
            //{


            #endregion

            #region Acoes
            GetAnIssueRequest getAnIssueRequest = new GetAnIssueRequest(idIssue);
            IRestResponse<dynamic> response = getAnIssueRequest.ExecuteRequest();
            #endregion

            #region Asserts
            int idResposta = response.Data["issues"][0]["id"];
            string summaryResposta = response.Data["issues"][0]["summary"];
            string descriptionResposta = response.Data["issues"][0]["description"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idIssue, idResposta);
                Assert.AreEqual(summary, summaryResposta);
                Assert.AreEqual(description, descriptionResposta);
            });

            #endregion
        }
    }
}
