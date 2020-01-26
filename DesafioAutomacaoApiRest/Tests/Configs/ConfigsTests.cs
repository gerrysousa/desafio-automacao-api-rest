using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DesafioAutomacaoApiRest.Pages;
using DesafioAutomacaoApiRest.Requests.Projects;
using NUnit.Framework;
using RestSharp;
using DesafioAutomacaoApiRest.Requests.Config;

namespace DesafioAutomacaoApiRest.Tests.Configs
{
    [Parallelizable(ParallelScope.All)]
    class ConfigsTests : TestBase
    {
        [Test]
        public void Test_ObterConfiguracaoDoCSVComSucesso()
        {
            #region Parameters
            string statusEsperado = "OK";
            string option = "csv_separator";
            string valorEsperado = ",";
            #endregion

            #region Acoes
            GetConfigurationOptionRequest getConfigurationOptionRequest = new GetConfigurationOptionRequest(option);
            IRestResponse<dynamic> response = getConfigurationOptionRequest.ExecuteRequest();
            #endregion

            #region Asserts
            string optionResposta = response.Data["configs"][0]["option"];
            string valorResposta = response.Data["configs"][0]["value"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(valorEsperado, valorResposta);
                Assert.AreEqual(option, optionResposta);
            });

            #endregion
        }


    }
}
