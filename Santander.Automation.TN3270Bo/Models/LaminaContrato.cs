using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.Automation.TN3270Lib.Models
{
    public class LaminaContrato
    {
        public string NomeCliente { get; set; }
        public string BairroC { get; set; }
        public string Nascimento{ get; set; }
        public string ContratoCliente { get; set; }
        public string CpfCli { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string TIC { get; set; }
        public DateTime dataConsulta { get; set; }
        public List<ParcelaLaminaContrato> Parcelas { get; set; }
        public LaminaContrato()
        {
            Parcelas = new List<ParcelaLaminaContrato>();
        }
    }

    public class ParcelaLaminaContrato
    {
        public  string Tic { get; set; }
        public  string Parcela { get; set; }
        public  string Vencimento { get; set; }
        public  string ValorParcela { get; set; }
        public  string JurosDesc { get; set; }
        public  string IOF { get; set; }
        public  string Tec { get; set; }
        public  string ValorTotal { get; set; }
        public string Gca { get; set; }
    }
   
   
}
