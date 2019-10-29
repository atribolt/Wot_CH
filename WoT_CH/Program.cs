using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoT_CH {
	static class Program {
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Words.ReadLanguageCFG(Lang.ru);

			Form form1 = new Form1();

			IForm1 iForm = (IForm1)form1;
			IEditor edit = new Editor();

			Presenter presenter = new Presenter(iForm, edit);

			Application.Run(form1);
		}
	}
}
