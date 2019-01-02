using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CSVUtils
    {
        public static List<string> getProtocolInCSV(string absolutePath)
        {
            List<string> result = new List<string>();
            Regex rgx = new Regex("^[0-9]+[/-]");
            using (var reader = new StreamReader(absolutePath))
            { 
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Match protocolo = rgx.Match(values[0]);
                    if (protocolo.Success && values[0].Count() == 14)
                    {
                        result.Add(values[0]);
                    }
                    
                }
            }
            return result;
        }

        public static String[] LoadCSV(string path)
        {
           
            DirectoryInfo di = new DirectoryInfo(path);
            
            FileInfo[] CSVFiles = di.GetFiles("*.csv");

            do
            {
                CSVFiles = di.GetFiles("*.csv");
                Thread.Sleep(2000);
            } while (CSVFiles.Length == 0);

            Logger.Log("CSV encontrado!");
            

            return Directory.GetFiles(path);
        }

    //    public static void CSVAppend(string file, Processo processo)
    //    {
    //        IniFile ini = new IniFile("config.ini");
    //        string path = ini.Read("Output", "Geral");
            
    //        var csv = new StringBuilder();

    //        if (File.Exists(path + "\\" + file))
    //        {
                
    //            var newLine = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", processo.inicio.ToString(), processo.tipoProcesso, processo.ocorrencia.Protocolo, processo.ocorrencia.IdentificadorCartao, processo.ocorrencia.Observacao.Replace("\r\n", ""), processo.ocorrencia.Email, processo.error, processo.msgFechamentoProtocolo, processo.statusProcesso + Environment.NewLine);
    //            csv.Append(newLine);

    //        } else{
                
    //            var header = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", "INICIO", "TIPO_PROCESSO", "PROTOCOLO", "IDENTIFICADOR_CARTAO", "OBSERVACAO", "EMAIL", "MENSAGEM_ERRO", "MENSAGEM_FECHAMENTO", "STATUS" + Environment.NewLine);
    //            csv.Append(header);

    //            var newLine = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", processo.inicio.ToString(), processo.tipoProcesso, processo.ocorrencia.Protocolo, processo.ocorrencia.IdentificadorCartao, processo.ocorrencia.Observacao.Replace("\r\n", ""), processo.ocorrencia.Email, processo.error, processo.msgFechamentoProtocolo, processo.statusProcesso + Environment.NewLine);
    //            csv.Append(newLine);
    //        }

    //        File.AppendAllText(path + "\\" + file, csv.ToString(), Encoding.UTF8);
    //    }

    }
}
