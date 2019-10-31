using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoT_CH {
	public enum TypeFile {
		txt, dvpl
	}
	public enum FileState {
		OK,
		FileNotExists,
		NoOpen
	}
	public enum BackImage {
		Cross,
		GameCircle,
		SimpleCircle
	}
}
