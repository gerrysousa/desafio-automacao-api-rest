using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Objects
{
    class SubProject
    {
        public Project project { get; set; }
        public bool inherit_parent { get; set; }
    }
}
