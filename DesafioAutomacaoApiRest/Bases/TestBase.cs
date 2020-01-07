using NUnit.Framework;
using DesafioAutomacaoApiRest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Bases
{
    public class TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ExtentReportHelpers.CreateReport();
        }

        [SetUp]
        public void SetUp()
        {
            ExtentReportHelpers.AddTest();
        }

        [TearDown]
        public void TearDown()
        {
            ExtentReportHelpers.AddTestResult();
            ExtentReportHelpers.GenerateReport();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReportHelpers.GenerateReport();
        }
    }
}
