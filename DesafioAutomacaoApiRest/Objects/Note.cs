using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Objects
{
    class Note
    {
        public string text { get; set; }
        public ViewState view_state { get; set; }
        public TimeTracking time_tracking { get; set; }
        public List<File> files { get; set; }
    }
}
