using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Pages;
using DesafioAutomacaoApiRest.Requests.Users;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesafioAutomacaoApiRest.Tests.TestesComNodeScript
{
    class ScriptNodeTests : TestBase
    {
        [Test]
        public void Test_CadastrarUsuarioComSucessoUsandoComandoNodeJS()
        {

            #region Parameters
            CreateAUserRequest createAUserRequest = new CreateAUserRequest();
            User user = new User();
            AccessLevel accessLevel = new AccessLevel();

            //Executa comando Node.js e retorna data no formato ano+mes+dia+horaCompleta 20190131235959
            string aux = GeneralHelpers.RetornaDataStringExecutarComandoNodeJS();

            string username = "name"+aux;
            string password = "p@ssw0rd";
            string real_name = "Gerry Teste";
            string email = aux+"@email.com";
            string access_level = "updater";
            bool enabled = true;
            bool @protected = false;

            //Resultado esperado
            string statusEsperado = "Created";//201

            #endregion

            #region Acoes
            accessLevel.name = access_level;

            user.username = username;
            user.password = password;
            user.real_name = real_name;
            user.email = email;
            user.access_level = accessLevel;
            user.enabled = enabled;
            user.@protected = @protected;

            createAUserRequest.SetJsonBody(user);

            IRestResponse<dynamic> response = createAUserRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(username, response.Data.user.name.ToString());
                Assert.AreEqual(real_name, response.Data.user.real_name.ToString());
                Assert.AreEqual(email, response.Data.user.email.ToString());
            });

            #endregion
        }



    }
}

