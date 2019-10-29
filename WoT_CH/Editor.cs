using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WoT_CH {
	public enum FileState {
		OK,
		FileNotExists,
		NoOpen
	}
	public interface IEditor {
		/// <summary>
		/// Текущий модифицируемый слой
		/// </summary>
		int ActiveLayer { get; set; }
		/// <summary>
		/// Путь к редактируемому файлу
		/// </summary>
		string Path { get; }
		/// <summary>
		/// Состояние чтения файла
		/// </summary>
		FileState State { get; }
		
		void Save();
		void Reset();
		void Open(string path);
		void SaveAs(string path);
		void SetOffset(int dx, int dy);


		string[] Texs();
		Layer[] GetLayers();

		/// <summary>
		/// Возвращает имя tex файла в активном слое
		/// </summary>
		string GetTex();
		/// <summary>
		/// Возвращает активный слой
		/// </summary>
		Layer  GetLayer();
	}

	public class Editor : IEditor {
		TXT file;
		
		public Editor() {
			file = new TXT();
		}

		#region IEditor
		public int ActiveLayer { get; set; }
		public string Path { get; private set; }
		public FileState State { get; private set; } = FileState.NoOpen;

		public void Save() {
			if(State == FileState.OK)
				File.WriteAllText(Path, file.ToString());
		}
		public void Reset() {
			if(State == FileState.OK)
				file = new TXT(File.ReadAllText(Path));
		}
		public void Open(string path) {
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
			file = new TXT(File.ReadAllText(path));

			State = FileState.OK;
		}
		public void SaveAs(string path) {
			if(State == FileState.OK) {
				File.WriteAllText(path, file.ToString());
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
