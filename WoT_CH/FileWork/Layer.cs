using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
}
