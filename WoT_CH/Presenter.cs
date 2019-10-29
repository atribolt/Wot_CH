using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace WoT_CH {
	public class Presenter {
		IForm1 iForm;
		IEditor iEdit;
		float scale = 1;
		BackImage Background = BackImage.SimpleCircle;
		InterpolationMode tileInterpMode = InterpolationMode.Default;

		bool PNG = false;
		int CountAtlases = 0;

		Bitmap tile;
		Bitmap ScaleTile {
			get {
				try {
					return new Bitmap(tile, 
							new Size((int)(tile.Width * scale), (int)(tile.Height * scale)));
				}
				catch (Exception) {
					return new Bitmap(tile, 
							new Size((int)(tile.Width * 0.1), (int)(tile.Height * 0.1)));
				}
			}
		}

		public Presenter(IForm1 form, IEditor iEditor) {
			iForm = form;
			iEdit = iEditor;

			iForm.ExitClk += ShowMessageWithoutExit;
			iForm.AboutClk += ShowAbout;
			
			iForm.ResetFile += Reset;
			iForm.FormResize += DrawTile;
			iForm.ChangeImage += SetBackground;
			iForm.ChangeLayer += UpdateActiveLayer;
			iForm.ChangeLayer += UpdateCounter;
			iForm.FileOpenClk += OpenFile;
			iForm.FileSaveClk += SaveFile;
			iForm.ChangeOffset += EditDataLayer;
			iForm.FileSaveAsClk += SaveAsFile;
			iForm.BackgroundUpdate += DrawTile;
			iForm.ChangeTileScale += SetScale;
			iForm.ChangeInterpolationTile += SetInterpolation;

			iForm.DisableBtns();
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
		
		void SetScale(int value) {
			scale += value / 10.0F;
			if(scale <= 0) scale = 0.1F;
			DrawTile();
		}

		void EditDataLayer(int ox, int oy) {
			iEdit.SetOffset(ox, oy);
			
			tile = TileFromLayer();
			DrawTile();
		}

		void SetBackground(BackImage bgrnd) {
			Background = bgrnd;
			DrawTile();
			//string path = path = Resource.Get(Res.Cross);

			//switch (bgrnd) {
			//	//case BackImage.Cross:        path = Resource.Get(Res.Cross);	    break;
			//	case BackImage.GameCircle:   path = Resource.Get(Res.GameCircle);   break;
			//	case BackImage.SimpleCircle: path = Resource.Get(Res.SimpleCircle); break;
			//	default: break;
			//}

			//iForm.SetBackground(path);
		}
		
		void SetInterpolation(InterpolationMode mode) {
			tileInterpMode = mode;

			DrawTile();
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
		void DrawCross(ref Graphics g) {
			int width = iForm.ShowTile.Width;
			int height = iForm.ShowTile.Height;
			int x = width / 2;
			int y = height / 2;

			g.DrawLine(Pens.Black, new Point(x, 0), new Point(x, height)); // vertical
			g.DrawLine(Pens.Black, new Point(0, y), new Point(width, y)); // horizontal
		}
		void DrawCircle(ref Graphics g) {
			int radius = 100;
			float x = iForm.ShowTile.Width / 2 - radius;
			float y = iForm.ShowTile.Height / 2 - radius;
			g.DrawArc(Pens.Black, x, y, 2 * radius, 2 * radius, 0, 360);
			
		}
		void DrawTile() {
			if(iEdit.State == FileState.OK) {
				iForm.ShowTile.Refresh();
				Graphics g = iForm.ShowTile.CreateGraphics();

				switch (Background) {
					case BackImage.Cross: DrawCross(ref g); break;
					case BackImage.SimpleCircle: DrawCircle(ref g); break;
				}

				g.InterpolationMode = tileInterpMode;

				
				
				Point offset = iEdit.GetLayer().Offset;
				
				int x = offset.X + (iForm.ShowTile.Width - ScaleTile.Width) / 2;
				int y = offset.Y + (iForm.ShowTile.Height - ScaleTile.Height) / 2;
				if(iEdit.Path.Contains("GunAim"))
					y = offset.Y + (iForm.ShowTile.Height + ScaleTile.Height) / 2;

				g.DrawImage(ScaleTile, x, y);
			}
		}
	}
}
