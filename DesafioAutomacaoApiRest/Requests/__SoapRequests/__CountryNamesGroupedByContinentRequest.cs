using RestSharp;
using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.SoapRequests
{
    public class __CountryNamesGroupedByContinentRequest : RequestSoapBase
    {
        public __CountryNamesGroupedByContinentRequest()
        {
            
        }

        public void SetXmlBody()
        {
            xmlBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Xmls/CountryNamesGroupedByContinentXML.xml", Encoding.UTF8);
        }
    }
}
