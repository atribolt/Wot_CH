using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoT_CH {
	public partial class Form1 : Form, IForm1 {
		
		public PictureBox ShowTile {
			get { return pb_ShowCrosshair; }
		}
		
		public Form1() {
			InitializeComponent();
			Words.ChangeLang += AppLanguage;
			
			AppLanguage();
			SetEventsMenu();
			SetEventsOther();
			SetEventModifyLayer();
		}

		void AppLanguage() {
			menu_FAQ.Text			= Words.Get(Key.Info);
			menu_Edit.Text			= Words.Get(Key.Edit);
			menu_Exit.Text			= Words.Get(Key.Exit);
			menu_File.Text			= Words.Get(Key.Menu);
			menu_About.Text			= Words.Get(Key.About);
			menu_SaveAs.Text		= Words.Get(Key.SaveAs);
			menu_Render.Text		= Words.Get(Key.RenderMode);
			menu_OpenTxt.Text		= Words.Get(Key.OpenTXT);
			menu_Refresh.Text		= Words.Get(Key.Refresh);
			menu_SaveTxt.Text		= Words.Get(Key.Save);
			menu_Settings.Text		= Words.Get(Key.Settings);
			menu_Language.Text		= Words.Get(Key.Language);
			menu_OpenDVPL.Text		= Words.Get(Key.OpenDVPL);
			menu_SaveDVPL.Text		= Words.Get(Key.SaveDVPL);
			menu_SmoothMode.Text	= Words.Get(Key.SmoothMode);

			lbl_Images.Text			= Words.Get(Key.ImageFound);

			gb_Back.Text			= Words.Get(Key.Background);
			gb_SetShift.Text		= Words.Get(Key.Shift);

			rb_Back_Cross.Text		= Words.Get(Key.Cross);
			rb_Back_Circle.Text		= Words.Get(Key.SimpleCircle);
			rb_Back_GameCircle.Text = Words.Get(Key.GameCircle);
		}
		
		void SetEventsMenu() {
			menu_Exit.Click     += mExitClk;
			menu_About.Click    += mAboutClk;
			menu_SaveAs.Click   += mSaveAsClk;
			menu_OpenTxt.Click  += mOpenClk;
			menu_SaveTxt.Click  += mSaveClk;
			menu_Refresh.Click  += mRefreshClk;
			menu_OpenDVPL.Click += mOpenDvplClk;
			menu_SaveDVPL.Click += mSaveDvplClk;

			menu_LanguageRU.Click += langUpdate;
			menu_LanguageEN.Click += langUpdate;

			menu_IM_D.Click    += setInterpolation;
			menu_IM_L.Click    += setInterpolation;
			menu_IM_H.Click    += setInterpolation;
			menu_IM_BC.Click   += setInterpolation;
			menu_IM_BL.Click   += setInterpolation;
			menu_IM_NN.Click   += setInterpolation;
			menu_IM_HQBC.Click += setInterpolation;
			menu_IM_HQBL.Click += setInterpolation;
		}
		void SetEventModifyLayer() {
			nud_ShiftX.ValueChanged += setOffset;
			nud_ShiftY.ValueChanged += setOffset;
			
			lb_Layers.SelectedIndexChanged += changeLayer;
		}
		void SetEventsOther() {
			rb_Back_Cross.Click		 += changeBackground;
			rb_Back_Circle.Click	 += changeBackground;
			rb_Back_GameCircle.Click += changeBackground;
			
			this.ResizeEnd   += formResize;
			this.FormClosing += formClosing;
			
			
			pb_ShowCrosshair.MouseWheel				+= scaleTilSet;
			pb_ShowCrosshair.MouseClick				+= changeBackColor;
			pb_ShowCrosshair.MouseMove				+= moveTile;
			pb_ShowCrosshair.BackgroundImageChanged += backgroundChanged;
		}

		#region >>> IForm1
		public event Action ExitClk          = delegate{ };
		public event Action AboutClk         = delegate{ };
		public event Action ResetFile		 = delegate{ };
		public event Action FormResize		 = delegate{ };
		public event Action FileOpenClk      = delegate{ };
		public event Action FileSaveClk      = delegate{ };
		public event Action FileSaveDVPL	 = delegate{ };
		public event Action FileSaveAsClk    = delegate{ };
		public event Action FileOpenDVPLClk  = delegate{ };
		public event Action BackgroundUpdate = delegate{ };

		public event Action<int> ChangeLayer	   = delegate{ };
		public event Action<int> ChangeTileScale   = delegate{ };
		public event Action<int, int> ChangeOffset = delegate{ };
		public event Action<BackImage> ChangeImage = delegate{ };
		public event Action<InterpolationMode> ChangeInterpolationTile = delegate { };

		public void SetNumerics(int x, int y) {
			nud_ShiftX.Value = x;
			nud_ShiftY.Value = y;
		}
		public void SetLayers(string[] layersData) {
			lb_Layers.Items.Clear();

			for(int i = 0; i < layersData.Length; ++i) {
				lb_Layers.Items.Add(layersData[i]);
			}

			lb_Layers.ClearSelected();
			lb_Layers.SelectedIndex = 0;
		}
		public void SetCountImgs(int count) {
			lbl_ImageFound.Text = count.ToString();
		}
		public void SetLayerData(int id, string data) {
			lb_Layers.Items[id] = data;
		}
		public void SetBackground(string pathImg) {
			pb_ShowCrosshair.BackgroundImage = new Bitmap(pathImg);
		}

		public void DisableBtns() {
			nud_ShiftX.Enabled    = false;
			nud_ShiftY.Enabled    = false;
			menu_SaveAs.Enabled   = false;
			menu_Refresh.Enabled  = false;
			menu_SaveTxt.Enabled  = false;
			menu_SaveDVPL.Enabled = false;
		}
		public void EnableBtns() {
			nud_ShiftX.Enabled    = true;
			nud_ShiftY.Enabled    = true;
			menu_SaveAs.Enabled   = true;
			menu_Refresh.Enabled  = true;
			menu_SaveTxt.Enabled  = true;
			menu_SaveDVPL.Enabled = true;
		}
		#endregion

		#region >>> Events menu
		void mSaveClk     (object o, EventArgs e) => FileSaveClk();
		void mExitClk     (object o, EventArgs e) => this.Close();
		void mOpenClk     (object o, EventArgs e) => FileOpenClk();
		void mAboutClk    (object o, EventArgs e) => AboutClk();
		void mSaveAsClk   (object o, EventArgs e) => FileSaveAsClk();
		void mRefreshClk  (object o, EventArgs e) => ResetFile();
		void mSaveDvplClk (object o, EventArgs e) => FileSaveDVPL();
		void mOpenDvplClk (object o, EventArgs e) => FileOpenDVPLClk();

		void langUpdate(object o, EventArgs e) {
			if ((ToolStripMenuItem)o == menu_LanguageEN) Words.ReadLanguageCFG(Lang.en); else 
			if ((ToolStripMenuItem)o == menu_LanguageRU) Words.ReadLanguageCFG(Lang.ru);
		}

		void setInterpolation(object o, EventArgs e) {
			InterpolationMode mode = (InterpolationMode)Enum.Parse(typeof(InterpolationMode), ((ToolStripMenuItem)o).Text);
			ChangeInterpolationTile(mode);
		}
		#endregion

		#region >>> EventsModifyLayer
		void setOffset(object o, EventArgs e) {
			int offsetX = (int)nud_ShiftX.Value;
			int offsetY = (int)nud_ShiftY.Value;
			ChangeOffset(offsetX, offsetY);
		}
		void changeLayer(object o, EventArgs e) {
			int select = ((ListBox)o).SelectedIndex;
			ChangeLayer(select);
		}
		#endregion

		#region >>> EventOther
		void changeBackground(object o, EventArgs e) {
			BackImage back = BackImage.SimpleCircle;
			if (rb_Back_Cross.Checked) back = BackImage.Cross;
			ChangeImage(back);
		}

		void formClosing(object o, FormClosingEventArgs e) => ExitClk();

		void backgroundChanged(object o, EventArgs e) => BackgroundUpdate();
		
		void changeBackColor(object o, MouseEventArgs me) {
			if(me.Button == MouseButtons.Right) {
				ColorDialog cd = new ColorDialog();

				if(cd.ShowDialog() == DialogResult.OK) {
					((Control)o).BackColor = cd.Color;
				}
				BackgroundUpdate();
			}
		}
		void moveTile(object o, MouseEventArgs me) {
			if(me.Button == MouseButtons.Left) {
				int x = me.Location.X - pb_ShowCrosshair.Width / 2;
				int y = me.Location.Y - pb_ShowCrosshair.Height / 2;

				SetNumerics(x, y);
			}
		}

		void formResize(object o , EventArgs e) {
			FormResize();
		}

		void scaleTilSet(object o, MouseEventArgs me) {
			int incr = 1;

			if(me.Delta < 0) incr = -1;
			ChangeTileScale(incr);
		}
		#endregion
		
	}
}
