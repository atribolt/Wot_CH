using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Layers = System.Collections.Generic.List<WoT_CH.Layer>;
using Sizes = System.Collections.Generic.List<System.Drawing.Size>;
using Names = System.Collections.Generic.List<string>;

namespace WoT_CH {

	public class Layer {
		public int ImageID;
		public string Frame;
		public Point Offset = new Point();
		public Rectangle Tile = new Rectangle();
		
		public Layer() { }
		public Layer(string layer) {
			string[] param = layer.Split(' ');

			if (param.Length < 8) {
				string message = Words.Get(Key.ErrorFewParamsInLayer);
				string caption = Words.Get(Key.Exception);
				Err.Show(message, caption);

				return;
			}

			Tile.X		= Convert.ToInt32(param[0]);
			Tile.Y      = Convert.ToInt32(param[1]);
			Tile.Width  = Convert.ToInt32(param[2]);
			Tile.Height = Convert.ToInt32(param[3]);
			Offset.X    = Convert.ToInt32(param[4]);
			Offset.Y    = Convert.ToInt32(param[5]);
			ImageID		= Convert.ToInt32(param[6]);
			Frame		= param[7];
		}

		public override string ToString() {
			return String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", 
				Tile.X,
				Tile.Y,
				Tile.Width,
				Tile.Height,
				Offset.X, 
				Offset.Y,
				ImageID,
				Frame);
		}
	}
	public class Data {
		public int cTEX;						// кол-во tex файлов
		public int cLayers;						// кол-во слоев
		public Names tex = new Names();			// имена tex файлов
		public Sizes sizes = new Sizes();		// размеры атласов
		public Layers layers = new Layers();	// слои

		public override string ToString() {
			string result = "";

			result += cTEX.ToString() + '\n';

			for(int i = 0; i < tex.Count; ++i) {
				result += (tex[i] + '\n');
			}
			for(int i = 0; i < sizes.Count; ++i) {
				result += string.Format("{0} {1}\n", sizes[i].Width, sizes[i].Height);
			}
			result += cLayers.ToString() + '\n';
			for(int i = 0; i < layers.Count; ++i) {
				result += layers[i].ToString() + '\n';
			}
			return result;
		}
	}

	public class TXT {
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
				int width = Convert.ToInt32(size[0]);
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
