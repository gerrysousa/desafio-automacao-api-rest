using NUnit.Framework;
using DesafioAutomacaoApiRest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioAutomacaoApiRest.DBSteps;

[assembly: LevelOfParallelism(2)]
namespace DesafioAutomacaoApiRest.Bases
{
    public class TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            new Global().Initializer();
            DBHelpers.ResetBD();
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
