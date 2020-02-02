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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace DesafioAutomacaoApiRest.Tests.Users
{
    [Parallelizable(ParallelScope.All)]
    class UsersTests : TestBase
    {

        [Test]
        public void Test_ObterInformacoesDoUsuarioComSucesso()
        {
            #region Parameters
            //Resultado esperado
            int id = 1;
            string name = "administrator";
            string real_name = "Gerry";
            string email = "root@localhost";
            string language = "english";
            string statusEsperado = "OK";
            #endregion

            #region Acoes
            GetMyUserInfoRequest obterInformacaoMeuUsuarioRequest = new GetMyUserInfoRequest();

            IRestResponse<dynamic> response = obterInformacaoMeuUsuarioRequest.ExecuteRequest();


            int resposta_id = response.Data.id;
            string resposta_name = response.Data.name;
            string resposta_real_name = response.Data.real_name;
            string resposta_email = response.Data.email;
            string resposta_language = response.Data.language;
            #endregion

            #region Asserts

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(name, resposta_name);
                Assert.AreEqual(real_name, resposta_real_name);
                Assert.AreEqual(email, resposta_email);
                Assert.AreEqual(language, resposta_language);
            });

            #endregion
        }

        [Test]
        public void Test_CadastrarUsuarioComSucesso()
        {

            #region Parameters
            CreateAUserRequest createAUserRequest = new CreateAUserRequest();
            User user = new User();
            AccessLevel accessLevel = new AccessLevel();

            string username = "test8";
            string password = "p@ssw0rd";
            string real_name = "Gerry Test1";
            string email = "test8@example2.com";
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

        [Test]
        public void Test_DeletarUsuarioComSucesso()
        {
            #region Parameters
            //Resultado esperado
            int id = 2;
            string statusEsperado = "NoContent";
            #endregion

            #region Acoes
            DeleteAUserRequest deletarUsuarioRequest = new DeleteAUserRequest(id);

            IRestResponse<dynamic> response = deletarUsuarioRequest.ExecuteRequest();
            #endregion

            #region Asserts
            Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
            #endregion
        }



    }
}
