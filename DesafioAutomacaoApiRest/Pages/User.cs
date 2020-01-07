using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Pages
{
    class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string real_name { get; set; }
        public string email { get; set; }
        public AccessLevel access_level { get; set; }
        public bool enabled { get; set; }
        public bool @protected { get; set; }
    }
}
