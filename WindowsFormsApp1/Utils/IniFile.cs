using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class IniFile   // revision 11
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
       
        public IniFile(string IniPath = null)
        {
            if (!File.Exists(IniPath))
            {
                Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
                CreateStartINI(IniPath);
            }
            else
            {
                Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
            }
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return @RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }

        public void CreateStartINI(string file)
        {
            //Config Geral
            Write("Input", "", "Geral");
            Write("Output", "", "Geral");

            //Config Tags Write("Janeiro", "", "Tags");
            Write("Janeiro", "jan/YYYY;janeiro/YYYY;01/YYYY;jan/YY;janeiro/YY;01/YY;janeiro de YYYY;janeiro de YY", "Tags");
            Write("Fevereiro", "fev/YYYY;fevereiro/YYYY;02/YYYY;fev/YY;fevereiro/YY;02/YY;fevereiro de YYYY;fevereiro de YY", "Tags");
            Write("Março", "mar/YYYY;março/YYYY;03/YYYY;mar/YY;março/YY;03/YY;março de YYYY;março de YY;marco de YYYY;marco de YY", "Tags");
            Write("Abril", "abr/YYYY;abril/YYYY;04/YYYY;abr/YY;abril/YY;04/YY;abril de YYYY; abril de YY", "Tags");
            Write("Maio", "mai/YYYY;maio/YYYY;05/YYYY;mai/YY;maio/YY;05/YY;maio de YYYY;maio de YY", "Tags");
            Write("Junho", "jun/YYYY;junho/YYYY;06/YYYY;jun/YY;junho/YY;06/YY;junho de YYYY; junho de YY", "Tags");
            Write("Julho", "jul/YYYY;julho/YYYY;07/YYYY;jul/YY;julho/YY;07/YY;julho de YYYY;julho de YY", "Tags");
            Write("Agosto", "ago/YYYY;agosto/YYYY;08/YYYY;ago/YY;agosto/YY;08/YY;agosto de YYYY; agosto de YY", "Tags");
            Write("Setembro", "set/YYYY;setembro/YYYY;09/YYYY;set/YY;setembro/YY;09/YY;setembro de YYYY;setembro de YY", "Tags");
            Write("Outubro", "out/YYYY;outubro/YYYY;10/YYYY;out/YY;outubro/YY;10/YY;outubro de YYYY;outubro de YY", "Tags");
            Write("Novembro", "nov/YYYY;novembro/YYYY;11/YYYY;nov/YY;novembro/YY;11/YY;novembro de YYYY;novembro de YY", "Tags");
            Write("Dezembro", "dez/YYYY;dezembro/YYYY;12/YYYY;dez/YY;dezembro/YY;12/YY;dezembro de YYYY;dezembro de YY", "Tags");

            Write("ValidaIntervalo", "YYYY a ;YY a ;YYYY ate ;YY ate ;YYYY à ;YY à ;YYYY até ; YYYY até", "Tags");
            Write("AnosAnteriores", "2", "Tags");
        }
    }
}
