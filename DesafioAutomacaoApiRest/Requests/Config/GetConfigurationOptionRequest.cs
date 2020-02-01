using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Requests.Config
{
    class GetConfigurationOptionRequest : RequestBase
    {
        public GetConfigurationOptionRequest(string optionParametro)
        {
            requestService = "/api/rest/config?option="+ optionParametro;
            method = Method.GET;

            parameters.Add("option", optionParametro);
        }
    }
}
