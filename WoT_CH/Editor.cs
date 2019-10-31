using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WoT_CH {
	public class Editor : IEditor {
		TXT file;
		TypeFile type = TypeFile.txt;
		
		public Editor() {
			file = new TXT();
		}

		#region IEditor
		public int ActiveLayer { get; set; }
		public string Path { get; private set; }
		public FileState State { get; private set; } = FileState.NoOpen;

		public void Save() {
			if(State == FileState.OK) {
				if(type == TypeFile.txt)
					File.WriteAllText(Path, file.ToString());
				else {
					File.WriteAllBytes(Path, DVPL.ToDVPL(file.ToString()));
				}
			}
		}
		public void Reset() {
			if(State == FileState.OK) Open(Path, type);
		}
		public void Open(string path, TypeFile type) {
			FileState preview = State;

			if (!File.Exists(path)){
				if(preview != FileState.OK)
					State = FileState.FileNotExists;

				string message = Words.Get(Key.FileNotExists);
				string caption = Words.Get(Key.Error);

				Err.Show(message, caption);

				return;
			}

			Path = path;
			string data = File.ReadAllText(Path);
			if(type == TypeFile.txt) {
				file = new TXT(data);
			}
			else {
				file = new TXT(DVPL.Parse(data));
			}

			State = FileState.OK;
		}

		public void SaveAs(string path) {
			if(State == FileState.OK) {
				if (System.IO.Path.GetExtension(path) == "dvpl") {
					File.WriteAllBytes(path, DVPL.ToDVPL(file.ToString()));
				}
				else {
					File.WriteAllText(path, file.ToString());
				}
				Path = path;
			}
		}

		public void SetOffset(int dx, int dy) {
			file.SetOffset(ActiveLayer, dx, dy);
		}

		public string[] Texs(){
			return file.Texs();
		}
		public Layer[] GetLayers() {
			return file.GetLayers();
		}

		public string GetTex()  {
			string res = "";
			
			int id = GetLayer().ImageID;
			res = file.GetTex(id);

			return res;
		}
		public Layer GetLayer(){
			return file.GetLayer(ActiveLayer);	
		}
		#endregion
	}
}
