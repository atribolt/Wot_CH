using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Names = System.Collections.Generic.List<string>;
using Sizes = System.Collections.Generic.List<System.Drawing.Size>;
using Layers = System.Collections.Generic.List<WoT_CH.Layer>;

namespace WoT_CH {
	public class Data {
		public int cTEX;						// кол-во tex файлов
		public int cLayers;						// кол-во слоев
		public Names tex = new Names();			// имена tex файлов
		public Sizes sizes = new Sizes();		// размеры атласов
		public Layers layers = new Layers();	// слои

		public override string ToString() {
			string result = "";

			result += cTEX.ToString() + "\r\n";

			for(int i = 0; i < tex.Count; ++i) {
				result += (tex[i] + "\r\n");
			}
			for(int i = 0; i < sizes.Count; ++i) {
				result += string.Format("{0} {1}\r\n", sizes[i].Width, sizes[i].Height);
			}
			result += cLayers.ToString() + "\r\n";
			for(int i = 0; i < layers.Count; ++i) {
				result += layers[i].ToString() + "\r\n";
			}
			return result;
		}
	}
}
