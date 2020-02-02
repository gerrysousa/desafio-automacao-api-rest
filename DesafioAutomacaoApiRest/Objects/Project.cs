using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Objects
{
    class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public Status status { get; set; }
        public string description { get; set; }
        public bool enabled { get; set; }
        public string file_path { get; set; }
        public ViewState view_state { get; set; }
    }
}
