using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class Logger
    {
        private static string FileName { get; set; }
       

        public static void Init1(string fileName)
        {
            FileName = fileName;

        }

        public static void Start()
        {

            Log("Automação LoginFlex Iniciada...");
           

        }
        public static void LoginRCBError()
        {

            LoginRCB("Erro de Login RCB.");
           

        }
        public static void LoginSicobError()
        {

            LoginSicob("Erro de Login Siscob.");


        }
        public static void FimAutomacao()
        {

            Fim("Automação Finalizada...");


        }

        public static void Log(string text)
        {
            DateTime now = DateTime.Now;
            File.AppendAllText(FileName, now + " : " + text + Environment.NewLine);
            Console.WriteLine(now + " : " + text);

        }
        public static void LoginRCB(string text)
        {
            DateTime now = DateTime.Now;
            File.AppendAllText(FileName, now + " : " + text + Environment.NewLine);
            Console.WriteLine(now + " : " + text);

        }
        public static void LoginSicob(string text)
        {
            DateTime now = DateTime.Now;
            File.AppendAllText(FileName, now + " : " + text + Environment.NewLine);
            Console.WriteLine(now + " : " + text);

        }
        public static void Fim(string text)
        {
            DateTime now = DateTime.Now;
            File.AppendAllText(FileName, now + " : " + text + Environment.NewLine);
            Console.WriteLine(now + " : " + text);

        }

		internal class Init
		{
		}
	}
    }