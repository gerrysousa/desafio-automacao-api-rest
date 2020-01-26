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


namespace DesafioAutomacaoApiRest.Tests.Regex
{
    [Parallelizable(ParallelScope.All)]
    class ValidRegexTests : TestBase
    {
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
  
