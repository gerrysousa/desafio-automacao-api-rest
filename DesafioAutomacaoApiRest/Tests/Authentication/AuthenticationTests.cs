using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using DesafioAutomacaoApiRest.Objects;
using DesafioAutomacaoApiRest.Requests.Authentication;
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

namespace DesafioAutomacaoApiRest.Tests.Authentication
{
    class AuthenticationTests : TestBase
    {
      
        [Test]
        public void Test_AcessarUrlComAutenticacaoBasicaComSucesso()
        {            
            #region Parameters
            AuthenticationRequest authenticationRequest;

            string statusEsperado = "OK"; //Resultado esperado
            string FaultId = "OPERATION_SUCCESS";
            string Fault = "Operation completed successfully";
            #endregion

            #region Acoes
            authenticationRequest = new AuthenticationRequest();
            authenticationRequest.AddAuthentication();

            IRestResponse<dynamic> response = authenticationRequest.ExecuteRequest();
            #endregion

            #region Asserts            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(FaultId, response.Data.FaultId.ToString());
                Assert.AreEqual(Fault, response.Data.Fault.ToString());
            });
           /*
           {
               "FaultId": "OPERATION_SUCCESS",
               "Fault": "Operation completed successfully",
               "Username:Password": "ToolsQA:TestPassword",
               "Authentication Type": "Basic"
           }
            */
            #endregion
        }

        [Test]
        public void Test_TentarAcessarUrlSemFazerAutenticacao()
        {
            #region Parameters
            AuthenticationRequest authenticationRequest;

            string statusEsperado = "Unauthorized"; //Resultado esperado
            string StatusID = "FAULT_USER_INVALID_USER_PASSWORD";
            string Status = "Invalid or expired Authentication key provided";
            #endregion

            #region Acoes
            authenticationRequest = new AuthenticationRequest();

            IRestResponse<dynamic> response = authenticationRequest.ExecuteRequest();
            #endregion

            #region Asserts            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(StatusID, response.Data.StatusID.ToString());
                Assert.AreEqual(Status, response.Data.Status.ToString());
            });
            /*
             Unauthorized
             {

            “StatusID”: “FAULT_USER_INVALID_USER_PASSWORD”,

            “Status”: “Invalid or expired Authentication key provided”

            }
             */
            #endregion
        }
    }
}



