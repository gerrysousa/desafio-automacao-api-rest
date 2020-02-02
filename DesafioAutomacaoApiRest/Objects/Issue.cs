using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Objects
{
    class Issue
    {
        public string summary { get; set; }
        public string description { get; set; }
        public string additional_information { get; set; }
        public Project project { get; set; }
        public Category category { get; set; }
        public Handler handler { get; set; }
        public ViewState view_state { get; set; }
        public Priority priority { get; set; }
        public Severity severity { get; set; }
        public Reproducibility reproducibility { get; set; }
        public bool sticky { get; set; }
        public List<CustomField> custom_fields { get; set; }
        public List<Tag> tags { get; set; }
    }
}
