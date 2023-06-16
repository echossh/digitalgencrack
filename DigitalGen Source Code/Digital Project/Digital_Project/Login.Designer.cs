namespace Digital_Project
{
	// Token: 0x02000005 RID: 5
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00003D70 File Offset: 0x00001F70
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003DA8 File Offset: 0x00001FA8
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Digital_Project.Login));
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.username = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.password = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.license = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2TextBox4 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2ControlBox1 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2PictureBox1 = new global::Guna.UI2.WinForms.Guna2PictureBox();
			this.guna2AnimateWindow1 = new global::Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).BeginInit();
			base.SuspendLayout();
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			this.guna2BorderlessForm1.TransparentWhileDrag = true;
			this.guna2Button1.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.guna2Button1.BorderRadius = 6;
			this.guna2Button1.BorderThickness = 1;
			this.guna2Button1.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button1.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.guna2Button1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.guna2Button1.FillColor = global::System.Drawing.Color.FromArgb(64, 0, 64);
			this.guna2Button1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.Location = new global::System.Drawing.Point(54, 382);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.Size = new global::System.Drawing.Size(115, 37);
			this.guna2Button1.TabIndex = 12;
			this.guna2Button1.Text = "Login";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.username.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.username.BorderColor = global::System.Drawing.Color.FromArgb(100, 40, 100);
			this.username.BorderRadius = 6;
			this.username.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.username.DefaultText = "";
			this.username.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.username.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.username.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.username.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.username.FillColor = global::System.Drawing.Color.FromArgb(70, 50, 70);
			this.username.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.username.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.username.ForeColor = global::System.Drawing.Color.Black;
			this.username.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.username.Location = new global::System.Drawing.Point(51, 213);
			this.username.Name = "username";
			this.username.PasswordChar = '\0';
			this.username.PlaceholderForeColor = global::System.Drawing.Color.Black;
			this.username.PlaceholderText = "Username\r\n";
			this.username.SelectedText = "";
			this.username.Size = new global::System.Drawing.Size(236, 36);
			this.username.TabIndex = 14;
			this.username.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.password.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.password.BorderColor = global::System.Drawing.Color.FromArgb(100, 40, 100);
			this.password.BorderRadius = 6;
			this.password.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.password.DefaultText = "";
			this.password.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.password.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.password.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.password.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.password.FillColor = global::System.Drawing.Color.FromArgb(70, 50, 70);
			this.password.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.password.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.password.ForeColor = global::System.Drawing.Color.Black;
			this.password.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.password.Location = new global::System.Drawing.Point(51, 255);
			this.password.Name = "password";
			this.password.PasswordChar = '\0';
			this.password.PlaceholderForeColor = global::System.Drawing.Color.Black;
			this.password.PlaceholderText = "Password";
			this.password.SelectedText = "";
			this.password.Size = new global::System.Drawing.Size(236, 36);
			this.password.TabIndex = 15;
			this.password.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.license.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.license.BorderColor = global::System.Drawing.Color.FromArgb(100, 40, 100);
			this.license.BorderRadius = 6;
			this.license.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.license.DefaultText = "";
			this.license.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.license.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.license.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.license.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.license.FillColor = global::System.Drawing.Color.FromArgb(70, 50, 70);
			this.license.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.license.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.license.ForeColor = global::System.Drawing.Color.Black;
			this.license.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.license.Location = new global::System.Drawing.Point(51, 297);
			this.license.Name = "license";
			this.license.PasswordChar = '\0';
			this.license.PlaceholderForeColor = global::System.Drawing.Color.Black;
			this.license.PlaceholderText = "License Key";
			this.license.SelectedText = "";
			this.license.Size = new global::System.Drawing.Size(236, 36);
			this.license.TabIndex = 16;
			this.license.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.label2.Font = new global::System.Drawing.Font("Yu Gothic UI", 15.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DarkMagenta;
			this.label2.Location = new global::System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(143, 30);
			this.label2.TabIndex = 17;
			this.label2.Text = "Digital Project";
			this.guna2Button2.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.guna2Button2.BorderRadius = 6;
			this.guna2Button2.BorderThickness = 1;
			this.guna2Button2.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button2.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.guna2Button2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.guna2Button2.FillColor = global::System.Drawing.Color.FromArgb(64, 0, 64);
			this.guna2Button2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.Location = new global::System.Drawing.Point(172, 382);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.Size = new global::System.Drawing.Size(115, 37);
			this.guna2Button2.TabIndex = 18;
			this.guna2Button2.Text = "Register";
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			this.guna2TextBox4.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.guna2TextBox4.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.guna2TextBox4.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox4.DefaultText = "";
			this.guna2TextBox4.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox4.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox4.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox4.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox4.FillColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.guna2TextBox4.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox4.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.guna2TextBox4.ForeColor = global::System.Drawing.Color.Black;
			this.guna2TextBox4.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox4.Location = new global::System.Drawing.Point(54, 374);
			this.guna2TextBox4.Name = "guna2TextBox4";
			this.guna2TextBox4.PasswordChar = '\0';
			this.guna2TextBox4.PlaceholderForeColor = global::System.Drawing.Color.Black;
			this.guna2TextBox4.PlaceholderText = "";
			this.guna2TextBox4.SelectedText = "";
			this.guna2TextBox4.Size = new global::System.Drawing.Size(233, 2);
			this.guna2TextBox4.TabIndex = 19;
			this.guna2TextBox4.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.guna2ControlBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.guna2ControlBox1.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.guna2ControlBox1.BorderRadius = 6;
			this.guna2ControlBox1.FillColor = global::System.Drawing.Color.FromArgb(5, 5, 5);
			this.guna2ControlBox1.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new global::System.Drawing.Point(278, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.Size = new global::System.Drawing.Size(45, 29);
			this.guna2ControlBox1.TabIndex = 20;
			this.guna2PictureBox1.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.guna2PictureBox1.Image = global::Digital_Project.Properties.Resources._1653365_removebg_preview;
			this.guna2PictureBox1.ImageRotate = 0f;
			this.guna2PictureBox1.Location = new global::System.Drawing.Point(31, 26);
			this.guna2PictureBox1.Name = "guna2PictureBox1";
			this.guna2PictureBox1.Size = new global::System.Drawing.Size(282, 223);
			this.guna2PictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.guna2PictureBox1.TabIndex = 13;
			this.guna2PictureBox1.TabStop = false;
			this.guna2PictureBox1.Click += new global::System.EventHandler(this.guna2PictureBox1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			base.ClientSize = new global::System.Drawing.Size(335, 454);
			base.Controls.Add(this.guna2ControlBox1);
			base.Controls.Add(this.guna2TextBox4);
			base.Controls.Add(this.guna2Button2);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.license);
			base.Controls.Add(this.password);
			base.Controls.Add(this.username);
			base.Controls.Add(this.guna2PictureBox1);
			base.Controls.Add(this.guna2Button1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Login";
			base.Opacity = 0.9;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			base.Load += new global::System.EventHandler(this.Login_Load);
			((global::System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000011 RID: 17
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000012 RID: 18
		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		// Token: 0x04000013 RID: 19
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000014 RID: 20
		private global::Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000016 RID: 22
		private global::Guna.UI2.WinForms.Guna2TextBox license;

		// Token: 0x04000017 RID: 23
		private global::Guna.UI2.WinForms.Guna2TextBox password;

		// Token: 0x04000018 RID: 24
		private global::Guna.UI2.WinForms.Guna2TextBox username;

		// Token: 0x04000019 RID: 25
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox4;

		// Token: 0x0400001A RID: 26
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;

		// Token: 0x0400001B RID: 27
		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

		// Token: 0x0400001C RID: 28
		private global::Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
	}
}
