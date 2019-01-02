using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    //[Table("Processo")]
    public class Processo
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string tipoProcesso { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fim { get; set; }
        public String statusProcesso { get; set; }
        public Ocorrencia ocorrencia { get; set; }
        public string error { get; set; }
        public string msgFechamentoProtocolo { get; set; }

       
        //public List<Arquivo> getArquivo { get; set; }
        public List<Processo> getStatus { get; set; }
       
    }
}
