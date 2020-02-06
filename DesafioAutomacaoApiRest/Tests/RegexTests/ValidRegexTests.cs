using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Objects;
using DesafioAutomacaoApiRest.Requests.Users;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace DesafioAutomacaoApiRest.Tests.RegexTests
{
    [Parallelizable(ParallelScope.All)]
    class ValidRegexTests : TestBase
    {
        [Test]
        public void Test_ObterInformacoeslDoJsonRespostaUsandoRegexComSucesso()
        {
            #region Parameters
            string name = "administrator";
            string real_name = "Gerry";
            string email = "root@localhost";
            string language = "english";
            string statusEsperado = "OK";
            #endregion

            #region Acoes
            GetMyUserInfoRequest obterInformacaoMeuUsuarioRequest = new GetMyUserInfoRequest();

            IRestResponse<dynamic> response = obterInformacaoMeuUsuarioRequest.ExecuteRequest();

            string resposta = response.Data.ToString();

            //string teste = "{  \"id\": 1,  \"name\": \"administrator\",  \"real_name\": \"Gerry\",  \"email\": \"root@localhost\",  \"language\": \"english\",  \"timezone\": \"America/Argentina/Buenos_Aires\",  \"access_level\": {   \"id\": 90,    \"name\": \"administrator\",    \"label\": \"administrator\"  },  \"projects\": [    {      \"id\": 1,      \"name\": \"Project 01 Default\"    },    {      \"id\": 2,      \"name\":\"Project02 With A Sub-project\"    },    {      \"id\": 3,      \"name\": \"Project 03 Update\"    },    {      \"id\": 4,      \"name\": \"Project 04 Delete\"    },    {      \"id\": 8,     \"name\": \"Sub-project 04 from Project 02 Create\"   }  ]}";

            //string str = @"""ouioieu"":""Canister"",""price"":""59.0000"",""sku"":""DECC500"",""barcode_gtin sjh""";
            //var m = Regex.Match(str, @".*""price"":""(.*?)"".*");

            //var emailRespsta = Regex.Match(teste, @".*""name"": ""(.*?)"",.*");
            //Console.WriteLine(emailRespsta.Groups[1].Value);

            var regexNome = Regex.Match(resposta, @".*""name"": ""(.*?)"",.*");
            var regexNomeReal = Regex.Match(resposta, @".*""real_name"": ""(.*?)"",.*");
            var regexEmail = Regex.Match(resposta, @".*""email"": ""(.*?)"",.*");

            //string resposta = emailRespsta.Groups[1].Value;


            string resposta_name = regexNome.Groups[1].Value;
            string resposta_real_name = regexNomeReal.Groups[1].Value;
            string resposta_email = regexEmail.Groups[1].Value;
            #endregion

            #region Asserts

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(name, resposta_name);
                Assert.AreEqual(real_name, resposta_real_name);
                Assert.AreEqual(email, resposta_email);

            });

            #endregion
        }

        [Test]
        public void Test_EmailValidoComSucesso()
        {
            #region Parameters
            string email = "email@valido.com";

            #endregion

            #region Acoes
            bool isValidEmail = RegexHelpers.IsValidEmail(email);
            #endregion

            #region Asserts

            Assert.IsTrue(isValidEmail);

            #endregion
        }

        [Test]
        public void Test_EmailInvalidoComSucesso()
        {
            #region Parameters
            string email = "email@valido";

            #endregion

            #region Acoes
            bool isValidEmail = RegexHelpers.IsValidEmail(email);
            #endregion

            #region Asserts

            Assert.IsFalse(isValidEmail);

            #endregion
        }

    }
}
  
