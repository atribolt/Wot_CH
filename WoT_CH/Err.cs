using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoT_CH {
	public static class Err {
		public static void Show(string message, string caption) {
			MessageBox.Show(message, caption, MessageBoxButtons.OK);
		}
		public static void Show(Key message, Key caption) {
			string msg = Words.Get(message);
			string cpn = Words.Get(caption);
			Show(msg, cpn);
		}
	}
}
