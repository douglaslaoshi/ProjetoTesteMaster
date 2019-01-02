using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.TN3270
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainframe = new Santander.Automation.TN3270Lib.CICS("", "", "TCPIP71.santanderbr.corp", 2023);
            //var data = mainframe.GetOcalCalc("20022876185");



            //Console.WriteLine($"NomeCliente-{data.NomeCliente}");
            //Console.WriteLine($"NomeCliente-{data.BairroC}");
            //Console.WriteLine($"NomeCliente-{data.Nascimento}");
            //Console.WriteLine($"ContratoCliente-{data.ContratoCliente}");
            //Console.WriteLine($"CpfCliente-{data.CpfCli}");
            //Console.WriteLine($"Endereco-{data.Endereco}");
            //Console.WriteLine($"Cidade-{data.Cidade}");
            //Console.WriteLine($"Marca-{data.Marca}");
            //Console.WriteLine($"Cor-{data.Cor}");
            
            //foreach (var parcela in data.Parcelas)
            //{
            //    Console.WriteLine($"\tParcela.Tic-{parcela.Tic}");
            //    Console.WriteLine($"\tParcela.Parcela-{parcela.Parcela}");
            //    Console.WriteLine($"\tParcela.Vencimento-{parcela.Vencimento}");
            //    Console.WriteLine($"\tParcela.JurosDesc-{parcela.JurosDesc}");
            //    Console.WriteLine($"\tParcela.IOF-{parcela.IOF}");
            //    Console.WriteLine($"\tParcela.TEC-{parcela.Tec}");
            //    Console.WriteLine($"\tParcela.ValorTotal-{parcela.ValorTotal}");
            //}

            //Console.ReadLine();
        }
    }
}
