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
        public void Test_ObterInformacoesDoUsuario()
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


            ObterInformacaoMeuUsuarioRequest obterInformacaoMeuUsuarioRequest = new ObterInformacaoMeuUsuarioRequest();

            IRestResponse<dynamic> response = obterInformacaoMeuUsuarioRequest.ExecuteRequest();


            int resposta_id = response.Data.id;
            string resposta_name = response.Data.name;
            string resposta_real_name = response.Data.real_name;
            string resposta_email = response.Data.email;
            string resposta_language = response.Data.language;


            Assert.Multiple(() =>
            {
                Assert.AreEqual(status, response.StatusCode.ToString());
                Assert.AreEqual(id, resposta_id);
                Assert.AreEqual(name, resposta_name);
                Assert.AreEqual(real_name, resposta_real_name);
                Assert.AreEqual(email, resposta_email);
                Assert.AreEqual(language, resposta_language);
            });
        }
    }
}
