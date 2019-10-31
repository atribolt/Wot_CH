using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WoT_CH {
	public interface IForm1 {
		PictureBox ShowTile { get; }

		event Action ExitClk;
		event Action AboutClk;
		event Action ResetFile;
		event Action FormResize;
		event Action FileOpenClk;
		event Action FileSaveClk;
		event Action FileSaveDVPL;
		event Action FileSaveAsClk;
		event Action FileOpenDVPLClk;
		event Action BackgroundUpdate;
		
		event Action<int> ChangeLayer;
		event Action<int> ChangeTileScale;
		event Action<int, int> ChangeOffset;
		event Action<BackImage> ChangeImage;
		event Action<InterpolationMode> ChangeInterpolationTile;
		
		void SetLayers(string[] layersData);
		void SetNumerics(int x, int y);
		void SetCountImgs(int count);
		void SetLayerData(int id, string data);
		void SetBackground(string pathImg);

		void EnableBtns();
		void DisableBtns();
	}
}
