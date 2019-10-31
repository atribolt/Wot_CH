namespace WoT_CH {
	partial class Form1 {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lbl_Images = new System.Windows.Forms.ToolStripStatusLabel();
			this.lbl_ImageFound = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menu_File = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_OpenTxt = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_SaveTxt = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_FAQ = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_About = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_Edit = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_Refresh = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_Settings = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_Language = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_LanguageRU = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_LanguageEN = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_Render = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_SmoothMode = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_IM_BC = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_IM_BL = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_IM_H = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_IM_L = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_IM_NN = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_IM_HQBL = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_IM_HQBC = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_IM_D = new System.Windows.Forms.ToolStripMenuItem();
			this.lb_Layers = new System.Windows.Forms.ListBox();
			this.pb_ShowCrosshair = new System.Windows.Forms.PictureBox();
			this.gb_SetShift = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.nud_ShiftY = new System.Windows.Forms.NumericUpDown();
			this.nud_ShiftX = new System.Windows.Forms.NumericUpDown();
			this.gb_Back = new System.Windows.Forms.GroupBox();
			this.rb_Back_GameCircle = new System.Windows.Forms.RadioButton();
			this.rb_Back_Cross = new System.Windows.Forms.RadioButton();
			this.rb_Back_Circle = new System.Windows.Forms.RadioButton();
			this.tt_ShowInfoElement = new System.Windows.Forms.ToolTip(this.components);
			this.menu_SaveDVPL = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_OpenDVPL = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_ShowCrosshair)).BeginInit();
			this.gb_SetShift.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_ShiftY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_ShiftX)).BeginInit();
			this.gb_Back.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_Images,
            this.lbl_ImageFound});
			this.statusStrip1.Location = new System.Drawing.Point(0, 230);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(659, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lbl_Images
			// 
			this.lbl_Images.Name = "lbl_Images";
			this.lbl_Images.Size = new System.Drawing.Size(78, 17);
			this.lbl_Images.Text = "Image found:";
			// 
			// lbl_ImageFound
			// 
			this.lbl_ImageFound.Name = "lbl_ImageFound";
			this.lbl_ImageFound.Size = new System.Drawing.Size(0, 17);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_File,
            this.menu_FAQ,
            this.menu_Edit,
            this.menu_Settings});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(659, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menu_File
			// 
			this.menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_OpenTxt,
            this.menu_OpenDVPL,
            this.menu_SaveTxt,
            this.menu_SaveAs,
            this.menu_SaveDVPL,
            this.menu_Exit});
			this.menu_File.Name = "menu_File";
			this.menu_File.Size = new System.Drawing.Size(37, 20);
			this.menu_File.Text = "File";
			// 
			// menu_OpenTxt
			// 
			this.menu_OpenTxt.Name = "menu_OpenTxt";
			this.menu_OpenTxt.Size = new System.Drawing.Size(180, 22);
			this.menu_OpenTxt.Text = "Open TXT";
			// 
			// menu_SaveTxt
			// 
			this.menu_SaveTxt.Name = "menu_SaveTxt";
			this.menu_SaveTxt.Size = new System.Drawing.Size(180, 22);
			this.menu_SaveTxt.Text = "Save";
			// 
			// menu_SaveAs
			// 
			this.menu_SaveAs.Name = "menu_SaveAs";
			this.menu_SaveAs.Size = new System.Drawing.Size(180, 22);
			this.menu_SaveAs.Text = "Save as";
			// 
			// menu_Exit
			// 
			this.menu_Exit.Name = "menu_Exit";
			this.menu_Exit.Size = new System.Drawing.Size(180, 22);
			this.menu_Exit.Text = "Exit";
			// 
			// menu_FAQ
			// 
			this.menu_FAQ.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_About});
			this.menu_FAQ.Name = "menu_FAQ";
			this.menu_FAQ.Size = new System.Drawing.Size(41, 20);
			this.menu_FAQ.Text = "FAQ";
			// 
			// menu_About
			// 
			this.menu_About.Name = "menu_About";
			this.menu_About.Size = new System.Drawing.Size(107, 22);
			this.menu_About.Text = "About";
			// 
			// menu_Edit
			// 
			this.menu_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Refresh});
			this.menu_Edit.Name = "menu_Edit";
			this.menu_Edit.Size = new System.Drawing.Size(39, 20);
			this.menu_Edit.Text = "Edit";
			// 
			// menu_Refresh
			// 
			this.menu_Refresh.Name = "menu_Refresh";
			this.menu_Refresh.Size = new System.Drawing.Size(113, 22);
			this.menu_Refresh.Text = "Refresh";
			// 
			// menu_Settings
			// 
			this.menu_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Language,
            this.menu_Render});
			this.menu_Settings.Name = "menu_Settings";
			this.menu_Settings.Size = new System.Drawing.Size(61, 20);
			this.menu_Settings.Text = "Settings";
			// 
			// menu_Language
			// 
			this.menu_Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_LanguageRU,
            this.menu_LanguageEN});
			this.menu_Language.Name = "menu_Language";
			this.menu_Language.Size = new System.Drawing.Size(142, 22);
			this.menu_Language.Text = "Language";
			// 
			// menu_LanguageRU
			// 
			this.menu_LanguageRU.Name = "menu_LanguageRU";
			this.menu_LanguageRU.Size = new System.Drawing.Size(119, 22);
			this.menu_LanguageRU.Text = "Русский";
			// 
			// menu_LanguageEN
			// 
			this.menu_LanguageEN.Name = "menu_LanguageEN";
			this.menu_LanguageEN.Size = new System.Drawing.Size(119, 22);
			this.menu_LanguageEN.Text = "English";
			// 
			// menu_Render
			// 
			this.menu_Render.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_SmoothMode});
			this.menu_Render.Name = "menu_Render";
			this.menu_Render.Size = new System.Drawing.Size(142, 22);
			this.menu_Render.Text = "RenderMode";
			// 
			// menu_SmoothMode
			// 
			this.menu_SmoothMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_IM_BC,
            this.menu_IM_BL,
            this.menu_IM_H,
            this.menu_IM_L,
            this.menu_IM_NN,
            this.menu_IM_HQBL,
            this.menu_IM_HQBC,
            this.menu_IM_D});
			this.menu_SmoothMode.Name = "menu_SmoothMode";
			this.menu_SmoothMode.Size = new System.Drawing.Size(147, 22);
			this.menu_SmoothMode.Text = "SmoothMode";
			// 
			// menu_IM_BC
			// 
			this.menu_IM_BC.Name = "menu_IM_BC";
			this.menu_IM_BC.Size = new System.Drawing.Size(177, 22);
			this.menu_IM_BC.Text = "Bicubic";
			// 
			// menu_IM_BL
			// 
			this.menu_IM_BL.Name = "menu_IM_BL";
			this.menu_IM_BL.Size = new System.Drawing.Size(177, 22);
			this.menu_IM_BL.Text = "Bilinear";
			// 
			// menu_IM_H
			// 
			this.menu_IM_H.Name = "menu_IM_H";
			this.menu_IM_H.Size = new System.Drawing.Size(177, 22);
			this.menu_IM_H.Text = "High";
			// 
			// menu_IM_L
			// 
			this.menu_IM_L.Name = "menu_IM_L";
			this.menu_IM_L.Size = new System.Drawing.Size(177, 22);
			this.menu_IM_L.Text = "Low";
			// 
			// menu_IM_NN
			// 
			this.menu_IM_NN.Name = "menu_IM_NN";
			this.menu_IM_NN.Size = new System.Drawing.Size(177, 22);
			this.menu_IM_NN.Text = "NearestNeighbor";
			// 
			// menu_IM_HQBL
			// 
			this.menu_IM_HQBL.Name = "menu_IM_HQBL";
			this.menu_IM_HQBL.Size = new System.Drawing.Size(177, 22);
			this.menu_IM_HQBL.Text = "HighQualityBilinear";
			// 
			// menu_IM_HQBC
			// 
			this.menu_IM_HQBC.Name = "menu_IM_HQBC";
			this.menu_IM_HQBC.Size = new System.Drawing.Size(177, 22);
			this.menu_IM_HQBC.Text = "HighQualityBicubic";
			// 
			// menu_IM_D
			// 
			this.menu_IM_D.Name = "menu_IM_D";
			this.menu_IM_D.Size = new System.Drawing.Size(177, 22);
			this.menu_IM_D.Text = "Default";
			// 
			// lb_Layers
			// 
			this.lb_Layers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lb_Layers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lb_Layers.FormattingEnabled = true;
			this.lb_Layers.Location = new System.Drawing.Point(14, 28);
			this.lb_Layers.Name = "lb_Layers";
			this.lb_Layers.Size = new System.Drawing.Size(151, 171);
			this.lb_Layers.TabIndex = 2;
			this.lb_Layers.TabStop = false;
			// 
			// pb_ShowCrosshair
			// 
			this.pb_ShowCrosshair.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pb_ShowCrosshair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pb_ShowCrosshair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pb_ShowCrosshair.Location = new System.Drawing.Point(171, 28);
			this.pb_ShowCrosshair.Name = "pb_ShowCrosshair";
			this.pb_ShowCrosshair.Size = new System.Drawing.Size(338, 185);
			this.pb_ShowCrosshair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pb_ShowCrosshair.TabIndex = 3;
			this.pb_ShowCrosshair.TabStop = false;
			// 
			// gb_SetShift
			// 
			this.gb_SetShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gb_SetShift.Controls.Add(this.label2);
			this.gb_SetShift.Controls.Add(this.label1);
			this.gb_SetShift.Controls.Add(this.nud_ShiftY);
			this.gb_SetShift.Controls.Add(this.nud_ShiftX);
			this.gb_SetShift.Location = new System.Drawing.Point(515, 28);
			this.gb_SetShift.Name = "gb_SetShift";
			this.gb_SetShift.Size = new System.Drawing.Size(134, 79);
			this.gb_SetShift.TabIndex = 4;
			this.gb_SetShift.TabStop = false;
			this.gb_SetShift.Text = "Set Shift";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Y";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "X";
			// 
			// nud_ShiftY
			// 
			this.nud_ShiftY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nud_ShiftY.Location = new System.Drawing.Point(26, 48);
			this.nud_ShiftY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nud_ShiftY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.nud_ShiftY.Name = "nud_ShiftY";
			this.nud_ShiftY.Size = new System.Drawing.Size(99, 20);
			this.nud_ShiftY.TabIndex = 1;
			this.nud_ShiftY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// nud_ShiftX
			// 
			this.nud_ShiftX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nud_ShiftX.Location = new System.Drawing.Point(26, 19);
			this.nud_ShiftX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nud_ShiftX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.nud_ShiftX.Name = "nud_ShiftX";
			this.nud_ShiftX.Size = new System.Drawing.Size(99, 20);
			this.nud_ShiftX.TabIndex = 0;
			this.nud_ShiftX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// gb_Back
			// 
			this.gb_Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.gb_Back.Controls.Add(this.rb_Back_GameCircle);
			this.gb_Back.Controls.Add(this.rb_Back_Cross);
			this.gb_Back.Controls.Add(this.rb_Back_Circle);
			this.gb_Back.Location = new System.Drawing.Point(515, 113);
			this.gb_Back.Name = "gb_Back";
			this.gb_Back.Size = new System.Drawing.Size(134, 100);
			this.gb_Back.TabIndex = 5;
			this.gb_Back.TabStop = false;
			this.gb_Back.Text = "Background";
			// 
			// rb_Back_GameCircle
			// 
			this.rb_Back_GameCircle.AutoSize = true;
			this.rb_Back_GameCircle.Enabled = false;
			this.rb_Back_GameCircle.Location = new System.Drawing.Point(9, 67);
			this.rb_Back_GameCircle.Name = "rb_Back_GameCircle";
			this.rb_Back_GameCircle.Size = new System.Drawing.Size(81, 17);
			this.rb_Back_GameCircle.TabIndex = 2;
			this.rb_Back_GameCircle.TabStop = true;
			this.rb_Back_GameCircle.Text = "Game circle";
			this.rb_Back_GameCircle.UseVisualStyleBackColor = true;
			// 
			// rb_Back_Cross
			// 
			this.rb_Back_Cross.AutoSize = true;
			this.rb_Back_Cross.Location = new System.Drawing.Point(9, 43);
			this.rb_Back_Cross.Name = "rb_Back_Cross";
			this.rb_Back_Cross.Size = new System.Drawing.Size(51, 17);
			this.rb_Back_Cross.TabIndex = 1;
			this.rb_Back_Cross.TabStop = true;
			this.rb_Back_Cross.Text = "Cross";
			this.rb_Back_Cross.UseVisualStyleBackColor = true;
			// 
			// rb_Back_Circle
			// 
			this.rb_Back_Circle.AutoSize = true;
			this.rb_Back_Circle.Checked = true;
			this.rb_Back_Circle.Location = new System.Drawing.Point(9, 20);
			this.rb_Back_Circle.Name = "rb_Back_Circle";
			this.rb_Back_Circle.Size = new System.Drawing.Size(51, 17);
			this.rb_Back_Circle.TabIndex = 0;
			this.rb_Back_Circle.TabStop = true;
			this.rb_Back_Circle.Text = "Circle";
			this.rb_Back_Circle.UseVisualStyleBackColor = true;
			// 
			// menu_SaveDVPL
			// 
			this.menu_SaveDVPL.Name = "menu_SaveDVPL";
			this.menu_SaveDVPL.Size = new System.Drawing.Size(180, 22);
			this.menu_SaveDVPL.Text = "SaveDVPL";
			// 
			// menu_OpenDVPL
			// 
			this.menu_OpenDVPL.Name = "menu_OpenDVPL";
			this.menu_OpenDVPL.Size = new System.Drawing.Size(180, 22);
			this.menu_OpenDVPL.Text = "OpenDVPL";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(659, 252);
			this.Controls.Add(this.gb_SetShift);
			this.Controls.Add(this.gb_Back);
			this.Controls.Add(this.pb_ShowCrosshair);
			this.Controls.Add(this.lb_Layers);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(662, 288);
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "WoT Crosshair Helper";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_ShowCrosshair)).EndInit();
			this.gb_SetShift.ResumeLayout(false);
			this.gb_SetShift.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_ShiftY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_ShiftX)).EndInit();
			this.gb_Back.ResumeLayout(false);
			this.gb_Back.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lbl_Images;
		private System.Windows.Forms.ToolStripStatusLabel lbl_ImageFound;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menu_File;
		private System.Windows.Forms.ToolStripMenuItem menu_OpenTxt;
		private System.Windows.Forms.ToolStripMenuItem menu_SaveTxt;
		private System.Windows.Forms.ToolStripMenuItem menu_SaveAs;
		private System.Windows.Forms.ToolStripMenuItem menu_Exit;
		private System.Windows.Forms.ToolStripMenuItem menu_FAQ;
		private System.Windows.Forms.ToolStripMenuItem menu_About;
		private System.Windows.Forms.ListBox lb_Layers;
		private System.Windows.Forms.PictureBox pb_ShowCrosshair;
		private System.Windows.Forms.GroupBox gb_SetShift;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nud_ShiftY;
		private System.Windows.Forms.NumericUpDown nud_ShiftX;
		private System.Windows.Forms.GroupBox gb_Back;
		private System.Windows.Forms.RadioButton rb_Back_GameCircle;
		private System.Windows.Forms.RadioButton rb_Back_Cross;
		private System.Windows.Forms.RadioButton rb_Back_Circle;
		private System.Windows.Forms.ToolStripMenuItem menu_Edit;
		private System.Windows.Forms.ToolStripMenuItem menu_Refresh;
		private System.Windows.Forms.ToolStripMenuItem menu_Settings;
		private System.Windows.Forms.ToolStripMenuItem menu_Language;
		private System.Windows.Forms.ToolStripMenuItem menu_LanguageRU;
		private System.Windows.Forms.ToolStripMenuItem menu_LanguageEN;
		private System.Windows.Forms.ToolStripMenuItem menu_Render;
		private System.Windows.Forms.ToolStripMenuItem menu_SmoothMode;
		private System.Windows.Forms.ToolTip tt_ShowInfoElement;
		private System.Windows.Forms.ToolStripMenuItem menu_IM_BC;
		private System.Windows.Forms.ToolStripMenuItem menu_IM_BL;
		private System.Windows.Forms.ToolStripMenuItem menu_IM_H;
		private System.Windows.Forms.ToolStripMenuItem menu_IM_L;
		private System.Windows.Forms.ToolStripMenuItem menu_IM_NN;
		private System.Windows.Forms.ToolStripMenuItem menu_IM_HQBL;
		private System.Windows.Forms.ToolStripMenuItem menu_IM_HQBC;
		private System.Windows.Forms.ToolStripMenuItem menu_IM_D;
		private System.Windows.Forms.ToolStripMenuItem menu_OpenDVPL;
		private System.Windows.Forms.ToolStripMenuItem menu_SaveDVPL;
	}
}

