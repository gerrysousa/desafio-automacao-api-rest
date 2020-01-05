using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Requests.Usuarios;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Tests.Usuarios
{
    class UsuariosTests : TestBase
    {
        [Test]
        public void Test_ObterInformacoesDoUsuarioComSucesso()
        {
            #region Parameters
            //Resultado esperado
            int id = 1;
            string name = "administrator";
            string real_name = "Administrator";
            string email = "root@localhost";
            string language = "english";
            string status = "OK";
            #endregion

            #region Acoes
            ObterInformacaoMeuUsuarioRequest obterInformacaoMeuUsuarioRequest = new ObterInformacaoMeuUsuarioRequest();

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
                Assert.AreEqual(status, response.StatusCode.ToString());
                Assert.AreEqual(id, resposta_id);
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
            CadastrarUsuarioRequest cadastrarUsuarioRequest = new CadastrarUsuarioRequest();
            AccessLevel accessLevel = new AccessLevel();

            string username = "test7";
            string password = "p@ssw0rd";
            string real_name = "Gerry Test1";
            string email = "test7@example2.com";
            string access_level = "updater";
            bool enabled = true;
            bool @protected = false;

            //Resultado esperado
            string status = "Created";//201

            #endregion

            #region Acoes
            accessLevel.name = access_level;

            cadastrarUsuarioRequest.username = username;
            cadastrarUsuarioRequest.password = password;
            cadastrarUsuarioRequest.real_name = real_name;
            cadastrarUsuarioRequest.email = email;
            cadastrarUsuarioRequest.access_level = accessLevel;
            cadastrarUsuarioRequest.enabled = enabled;
            cadastrarUsuarioRequest.@protected = @protected;

            cadastrarUsuarioRequest.SetJsonBody(cadastrarUsuarioRequest);

            IRestResponse<dynamic> response = cadastrarUsuarioRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.Multiple(() =>
            {
                Assert.AreEqual(status, response.StatusCode.ToString());
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
            int id = 6;
            string status = "NoContent";
            #endregion

            #region Acoes
            DeletarUsuarioRequest deletarUsuarioRequest = new DeletarUsuarioRequest(id);

            IRestResponse<dynamic> response = deletarUsuarioRequest.ExecuteRequest();
            #endregion

            #region Asserts
            Assert.AreEqual(status, response.StatusCode.ToString());
            #endregion
        }


        #region primeiro create
        /*
        [Test]
        public void Test_ObterInformacoesDoUsuario2()
        {

            #region Parameters
            CadastrarUsuarioRequest cadastrarUsuarioRequest = new CadastrarUsuarioRequest();
            AccessLevel accessLevel = new AccessLevel();

            accessLevel.name = "updater";
            string username = "test2";
            string password = "p@ssw0rd";
            string real_name = "Gerry Test1";
            string email = "test1@example2.com";
            bool enabled = true;
            bool @protected = false;

            //Resultado esperado
            string status = "Created";//201
            #endregion

            #region Acoes


            cadastrarUsuarioRequest.username = username;
            cadastrarUsuarioRequest.password = password;
            cadastrarUsuarioRequest.real_name = real_name;
            cadastrarUsuarioRequest.email = email;
            cadastrarUsuarioRequest.access_level = accessLevel;
            cadastrarUsuarioRequest.enabled = enabled;
            cadastrarUsuarioRequest.@protected = @protected;

            cadastrarUsuarioRequest.SetJsonBody(cadastrarUsuarioRequest);

            IRestResponse<dynamic> response = cadastrarUsuarioRequest.ExecuteRequest();
            #endregion

            #region Asserts

            Assert.Multiple(() =>
            {
                Assert.AreEqual(status, response.StatusCode.ToString());
                //Assert.AreEqual(username, response.Content);
                //Assert.AreEqual(real_name, resposta_name);
                //Assert.AreEqual(email, resposta_real_name);
            });

            #endregion
        }
        */

        #endregion
    }
}
