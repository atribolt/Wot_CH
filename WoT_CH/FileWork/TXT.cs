using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace WoT_CH {
	public class TXT{
		Data data;
		
		public TXT() {
			data = new Data();
		}
		public TXT(Data d){
			data = d;
		}
		public TXT(string strData) {
			data = new Data();

			Parse(strData);
		}
		
		void Parse(string str) {
			str = str.Replace("\r\n", "\n");
			string[] lines = str.Split('\n');

			if (lines.Length < 5){
				string message = Words.Get(Key.ErrorFileShort);
				throw new Exception(message);	
			}
			
			data.cTEX = Convert.ToInt32(lines[0]);

			int counter = 1;
			for (int i = counter; counter < i + data.cTEX; ++counter) {
				data.tex.Add(lines[counter]);
			}
			for (int i = counter; counter < (i + data.cTEX); ++counter) {
				string[] size = lines[counter].Split(' ');

				int width  = Convert.ToInt32(size[0]);
				int height = Convert.ToInt32(size[1]);

				data.sizes.Add(new Size(width, height));
			}

			data.cLayers = Convert.ToInt32(lines[counter]);
			++counter;
			for (int i = counter; counter < i + data.cLayers; ++counter) {
				data.layers.Add(new Layer(lines[counter]));
			}
		}
		
		public void SetOffset(int layer, int dx, int dy) {
			data.layers[layer].Offset.X = dx;
			data.layers[layer].Offset.Y = dy;
		}
		public Layer[] GetLayers() {
			return data.layers.ToArray();
		}
		public string[] Texs() {
			return data.tex.ToArray();
		}
		public string GetTex(int id) {
			return data.tex[id];
		}
		public Layer GetLayer(int id) {
			return data.layers[id];
		}

		public override string ToString() {
			return data.ToString();
		}
	}
}
