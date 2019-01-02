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

        public static void Init(string fileName)
        {
            FileName = fileName;

        }

        public static void Start()
        {
           
            Log("Automação Iniciada...");
            Log(pass);
        }
       

        public static void Log(string text)
        {
            DateTime now = DateTime.Now;
            File.AppendAllText(FileName, now + " : " + text + Environment.NewLine);
            Console.WriteLine(now + " : " + text);
           
        }


    }


}