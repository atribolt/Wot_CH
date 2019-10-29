using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace WoT_CH {
	public class Presenter {
		IForm1 iForm;
		IEditor iEdit;
		
		bool PNG = false;
		int CountAtlases = 0;
		Bitmap tile;

		public Presenter(IForm1 form, IEditor iEditor) {
			iForm = form;
			iEdit = iEditor;

			iForm.ExitClk += ShowMessageWithoutExit;
			iForm.AboutClk += ShowAbout;
			
			iForm.ChangeImage += SetBackground;
			iForm.ChangeLayer += UpdateActiveLayer;
			iForm.ChangeLayer += UpdateCounter;
			iForm.FileOpenClk += OpenFile;
			iForm.FileSaveClk += SaveFile;
			iForm.ChangeOffset += EditDataLayer;
			iForm.FileSaveAsClk += SaveAsFile;
			iForm.FormResize += DrawTile;
			iForm.BackgroundUpdate += DrawTile;
			iForm.ResetFile += Reset;

			iForm.DisableBtns();
			//FindAtlas(iEdit.Texs());
		}

		#region >>> iForm events handler
		void OpenFile() {
			OpenFileDialog od = new OpenFileDialog();
			od.Filter = Words.Get(Key.TextFile) + " | *.txt";

			if(od.ShowDialog() == DialogResult.OK) {
				iEdit.Open(od.FileName);
				FindAtlas(iEdit.Texs());
				SetForm();
			}
		}
		void Reset() {
			iEdit.Reset();
			Point offset = iEdit.GetLayer().Offset;

			iForm.SetNumerics(offset.X, offset.Y);
			DrawTile();
		}
		void SaveFile() {
			iEdit.Save();
		}
		void ShowAbout() {
			string message = Words.Get(Key.TextAbout);
			string caption = Words.Get(Key.About);

			MessageBox.Show(message, caption);
		}
		void SaveAsFile() {
			SaveFileDialog od = new SaveFileDialog();
			od.Filter = Words.Get(Key.TextFile) + " | *.txt";

			if(od.ShowDialog() == DialogResult.OK) {
				iEdit.SaveAs(od.FileName);
			}
		}
		void ShowMessageWithoutExit() {
			if(iEdit.State == FileState.OK) {
				string message = Words.Get(Key.SaveFileBeforeExit);
				string caption = Words.Get(Key.Exit);

				DialogResult save = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
				if(save == DialogResult.Yes) {

					iEdit.Save();
				}
			}
		}

		void UpdateCounter(int idLayer) {
			Point offset = iEdit.GetLayer().Offset;
			iForm.SetNumerics(offset.X, offset.Y);
		}
		void UpdateActiveLayer(int idLayer) {
			iEdit.ActiveLayer = idLayer;

			tile = TileFromLayer();
			DrawTile();
		}

		void EditDataLayer(int ox, int oy) {
			iEdit.SetOffset(ox, oy);
			
			tile = TileFromLayer();
			DrawTile();
		}

		void SetBackground(BackImage bgrnd) {
			string path = path = Resource.Get(Res.Cross);

			switch (bgrnd) {
				//case BackImage.Cross:        path = Resource.Get(Res.Cross);	    break;
				case BackImage.GameCircle:   path = Resource.Get(Res.GameCircle);   break;
				case BackImage.SimpleCircle: path = Resource.Get(Res.SimpleCircle); break;
				default: break;
			}

			iForm.SetBackground(path);
		}
		
		void SetForm() {
			int size = iEdit.GetLayers().Length;

			string[] frames = new string[size];

			for (int i = 0; i < frames.Length; ++i) {
				frames[i] = "frame" + i;
			}
			
			iForm.SetLayers(frames);
			
			iForm.SetCountImgs(CountAtlases);
			iForm.EnableBtns();
		}
		#endregion

		void FindAtlas (string[] texs) {
			string dir = Path.GetDirectoryName(iEdit.Path) + '/';
			CountAtlases = 0;

			for(int i = 0; i < texs.Length; ++i) {
				string name = Path.ChangeExtension(texs[i], ".png");

				if(File.Exists(dir + name)) ++CountAtlases;
				else {
					name = Path.ChangeExtension(texs[i], ".webp");
					if(File.Exists(dir + name)) {
						PNG = false;
						
						Err.Show(Key.ProgramDontWEBPformat, Key.Exception);

						return;
					}
				}
			}
			
			PNG = true;
		}
		Bitmap TileFromLayer (){
			Layer l = iEdit.GetLayer();
			Bitmap res = new Bitmap(l.Tile.Width, l.Tile.Height);

			if (PNG) {
				string dir = Path.GetDirectoryName(iEdit.Path) + '/';
				string name = iEdit.GetTex();

				name = Path.ChangeExtension(name, ".png");


				if (File.Exists(dir + name)) {
					res = new Bitmap(dir + name);

					if( l.Tile.X > res.Width  || 
						l.Tile.Y > res.Height ||
						l.Tile.X < 0 ||
						l.Tile.Y < 0) 
					{
						Err.Show(Key.TileOverImage, Key.Error);
						MessageBox.Show(Words.Get(Key.TileSetZeroPosition));
						l.Tile.X = 0;
						l.Tile.Y = 0;
					}
						
					res = res.Clone(l.Tile, res.PixelFormat);
				}
				else {
					Err.Show(Key.AtlasNotExists, Key.Error);
				}
			}

			return res;
		}
		
		void DrawTile() {
			if(iEdit.State == FileState.OK) {
				iForm.ShowTile.Refresh();

				Graphics g = iForm.ShowTile.CreateGraphics();

				Point offset = iEdit.GetLayer().Offset;

				int Ox = (iForm.ShowTile.Width - tile.Width) / 2;
				int Oy = (iForm.ShowTile.Height + tile.Height) / 2;

				g.TranslateTransform(Ox, Oy);
				
			
				g.DrawImage(tile, offset);
			}
		}
	}
}
