using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.Automation.TN3270Lib.Models
{
    public class LaminaHistPagamento
    {
        public string prt { get; set; }
        public string dataMotivo { get; set; }
        public string dataOcorrencia { get; set; }
        public string situacao { get; set; }
        public string ageReceb { get; set; }
        public string vlOcorrencia { get; set; }
        public string vlPrestacao { get; set; }
    }
}
