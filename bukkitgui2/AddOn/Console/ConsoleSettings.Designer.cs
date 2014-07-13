﻿using Net.Bertware.Bukkitgui2.Controls;

namespace Net.Bertware.Bukkitgui2.AddOn.Console
{
	partial class ConsoleSettings
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.chkTime = new SettingsCheckbox();
			this.chkDate = new SettingsCheckbox();
			this.button1 = new System.Windows.Forms.Button();
			this.CpInfo = new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker();
			this.gbColors = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cpPlayer = new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker();
			this.label3 = new System.Windows.Forms.Label();
			this.cpSevere = new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker();
			this.label2 = new System.Windows.Forms.Label();
			this.cpWarn = new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker();
			this.label1 = new System.Windows.Forms.Label();
			this.gbColors.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkTime
			// 
			this.chkTime.AutoSize = true;
			this.chkTime.Location = new System.Drawing.Point(3, 3);
			this.chkTime.Name = "chkTime";
			this.chkTime.Size = new System.Drawing.Size(79, 17);
			this.chkTime.TabIndex = 0;
			this.chkTime.Text = "Show &Time";
			this.chkTime.UseVisualStyleBackColor = true;
			// 
			// chkDate
			// 
			this.chkDate.AutoSize = true;
			this.chkDate.Location = new System.Drawing.Point(3, 26);
			this.chkDate.Name = "chkDate";
			this.chkDate.Size = new System.Drawing.Size(79, 17);
			this.chkDate.TabIndex = 1;
			this.chkDate.Text = "Show &Date";
			this.chkDate.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(482, 464);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "&Apply";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// CpInfo
			// 
			this.CpInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CpInfo.Color = System.Drawing.Color.Empty;
			this.CpInfo.Location = new System.Drawing.Point(109, 12);
			this.CpInfo.Name = "CpInfo";
			this.CpInfo.Size = new System.Drawing.Size(76, 20);
			this.CpInfo.TabIndex = 3;
			this.CpInfo.ColorChanged += new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker.ColorChangedEventHandler(this.CpInfo_ColorChanged);
			// 
			// gbColors
			// 
			this.gbColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbColors.Controls.Add(this.label4);
			this.gbColors.Controls.Add(this.cpPlayer);
			this.gbColors.Controls.Add(this.label3);
			this.gbColors.Controls.Add(this.cpSevere);
			this.gbColors.Controls.Add(this.label2);
			this.gbColors.Controls.Add(this.cpWarn);
			this.gbColors.Controls.Add(this.label1);
			this.gbColors.Controls.Add(this.CpInfo);
			this.gbColors.Location = new System.Drawing.Point(3, 49);
			this.gbColors.Name = "gbColors";
			this.gbColors.Size = new System.Drawing.Size(554, 155);
			this.gbColors.TabIndex = 4;
			this.gbColors.TabStop = false;
			this.gbColors.Text = "Colors";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 99);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(85, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "player messages";
			// 
			// cpPlayer
			// 
			this.cpPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cpPlayer.Color = System.Drawing.Color.Empty;
			this.cpPlayer.Location = new System.Drawing.Point(109, 92);
			this.cpPlayer.Name = "cpPlayer";
			this.cpPlayer.Size = new System.Drawing.Size(76, 20);
			this.cpPlayer.TabIndex = 9;
			this.cpPlayer.ColorChanged += new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker.ColorChangedEventHandler(this.cpPlayer_ColorChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "severe messages";
			// 
			// cpSevere
			// 
			this.cpSevere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cpSevere.Color = System.Drawing.Color.Empty;
			this.cpSevere.Location = new System.Drawing.Point(109, 66);
			this.cpSevere.Name = "cpSevere";
			this.cpSevere.Size = new System.Drawing.Size(76, 20);
			this.cpSevere.TabIndex = 7;
			this.cpSevere.ColorChanged += new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker.ColorChangedEventHandler(this.cpSevere_ColorChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "warning messages";
			// 
			// cpWarn
			// 
			this.cpWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cpWarn.Color = System.Drawing.Color.Empty;
			this.cpWarn.Location = new System.Drawing.Point(109, 40);
			this.cpWarn.Name = "cpWarn";
			this.cpWarn.Size = new System.Drawing.Size(76, 20);
			this.cpWarn.TabIndex = 5;
			this.cpWarn.ColorChanged += new Net.Bertware.Bukkitgui2.Controls.ColorPicker.ColorPicker.ColorChangedEventHandler(this.cpWarn_ColorChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "info messages";
			// 
			// ConsoleSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbColors);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.chkDate);
			this.Controls.Add(this.chkTime);
			this.Name = "ConsoleSettings";
			this.Size = new System.Drawing.Size(560, 490);
			this.gbColors.ResumeLayout(false);
			this.gbColors.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private SettingsCheckbox chkTime;
		private SettingsCheckbox chkDate;
		private System.Windows.Forms.Button button1;
		private Controls.ColorPicker.ColorPicker CpInfo;
		private System.Windows.Forms.GroupBox gbColors;
		private System.Windows.Forms.Label label2;
		private Controls.ColorPicker.ColorPicker cpWarn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private Controls.ColorPicker.ColorPicker cpPlayer;
		private System.Windows.Forms.Label label3;
		private Controls.ColorPicker.ColorPicker cpSevere;

	}
}
