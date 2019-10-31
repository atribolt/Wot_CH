using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoT_CH {
	public interface IEditor {
		int ActiveLayer { get; set; }
		string Path { get; }
		FileState State { get; }
		
		void Save();
		void Reset();
		void Open(string path, TypeFile t);
		void SaveAs(string path);
		void SetOffset(int dx, int dy);


		string[] Texs();
		Layer[] GetLayers();
		
		string GetTex();
		Layer  GetLayer();
	}
}
