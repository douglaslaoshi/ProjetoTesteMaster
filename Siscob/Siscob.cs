using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siscob
{
	class Siscob
	{
		static void Main(string[] args)
		{
			Siscob sis;
			sis = new Siscob();

			Thread.Sleep(1000);
			Process.Start(@"C:\Program Files\3CXPhone\3CXPhone.exe");
			Thread.Sleep(4000);
			SendKeys.SendWait("{LEFT}");
			Thread.Sleep(400);
			SendKeys.SendWait("{RIGHT}");
			Thread.Sleep(400);
			SendKeys.SendWait("{ENTER}");
			Thread.Sleep(400);
			SendKeys.SendWait("{ENTER}");
			Thread.Sleep(700);
			SendKeys.SendWait("(^){C} ");
			Thread.Sleep(700);
			SendKeys.SendWait("{ESC}");
			Thread.Sleep(700);
			SendKeys.SendWait("{ESC}");



			Thread.Sleep(2000);


			Process.Start(@"C:\Program Files\CSLog\Cobranca2\startsiscob.exe");
			Thread.Sleep(6000);
			//SendKeys.SendWait(textBox7.Text);
			//SendKeys.SendWait("{ENTER}");
			//Thread.Sleep(700);
			//SendKeys.SendWait(textBox6.Text);
			//Thread.Sleep(700);

			//SendKeys.SendWait("(^){ENTER} ");
			//Thread.Sleep(700);
			//SendKeys.SendWait("{ENTER}");
			//Thread.Sleep(700);

			//Thread.Sleep(700);
			//SendKeys.SendWait("(^){V} ");
			//Thread.Sleep(300);
			//SendKeys.SendWait("{BACKSPACE}");
			//Thread.Sleep(700);
			//SendKeys.SendWait("{ENTER}");

			//DialogResult FirefoxDriver = MessageBox.Show("Logado com sucesso !!!");

			Application.Exit();
		}
	}
}
