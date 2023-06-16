using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Digital_Project.Properties;
using Guna.UI2.WinForms;
using KeyAuth;

namespace Digital_Project
{
	// Token: 0x02000005 RID: 5
	public partial class Login : Form
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00003916 File Offset: 0x00001B16
		private void ShowResponse(string type)
		{
			MessageBox.Show(string.Format("It took {0} msg to {1}", api.responseTime, type));
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003934 File Offset: 0x00001B34
		public static bool SubExist(string name)
		{
			return Login.KeyAuthApp.user_data.subscriptions.Exists((api.Data x) => x.subscription == name);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000397C File Offset: 0x00001B7C
		public Login()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003994 File Offset: 0x00001B94
		public Login(object siticoneLabel1)
		{
			this.siticoneLabel1 = siticoneLabel1;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000039AC File Offset: 0x00001BAC
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000039AF File Offset: 0x00001BAF
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000039B2 File Offset: 0x00001BB2
		private void label1_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000039B8 File Offset: 0x00001BB8
		private void Login_Load(object sender, EventArgs e)
		{
			Login.KeyAuthApp.init();
			bool flag = Login.KeyAuthApp.response.message == "invalidver";
			if (flag)
			{
				bool flag2 = !string.IsNullOrEmpty(Login.KeyAuthApp.app_data.downloadLink);
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo);
					DialogResult dialogResult2 = dialogResult;
					DialogResult dialogResult3 = dialogResult2;
					if (dialogResult3 != DialogResult.Yes)
					{
						if (dialogResult3 != DialogResult.No)
						{
							MessageBox.Show("Invalid option");
							Environment.Exit(0);
						}
						else
						{
							WebClient webClient = new WebClient();
							string destFile = Application.ExecutablePath;
							string rand = Login.random_string();
							destFile = destFile.Replace(".exe", "-" + rand + ".exe");
							webClient.DownloadFile(Login.KeyAuthApp.app_data.downloadLink, destFile);
							Process.Start(destFile);
							Process.Start(new ProcessStartInfo
							{
								Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
								WindowStyle = ProcessWindowStyle.Hidden,
								CreateNoWindow = true,
								FileName = "cmd.exe"
							});
							Environment.Exit(0);
						}
					}
					else
					{
						Process.Start(Login.KeyAuthApp.app_data.downloadLink);
						Environment.Exit(0);
					}
				}
				MessageBox.Show("Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer");
				Environment.Exit(0);
			}
			bool flag3 = !Login.KeyAuthApp.response.success;
			if (flag3)
			{
				MessageBox.Show(Login.KeyAuthApp.response.message);
				Environment.Exit(0);
			}
			Login.KeyAuthApp.check();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003B64 File Offset: 0x00001D64
		private static string random_string()
		{
			string str = null;
			Random random = new Random();
			for (int i = 0; i < 5; i++)
			{
				str += Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0))).ToString();
			}
			return str;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003BD0 File Offset: 0x00001DD0
		private void guna2GradientButton3_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.register(this.username.Text, this.password.Text, this.license.Text, "");
			bool success = Login.KeyAuthApp.response.success;
			if (success)
			{
				Form2 gkhanh = new Form2();
				gkhanh.Show();
				base.Hide();
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003C38 File Offset: 0x00001E38
		private void guna2GradientButton2_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.login(this.username.Text, this.password.Text);
			bool success = Login.KeyAuthApp.response.success;
			if (success)
			{
				Form2 gkhanh = new Form2();
				gkhanh.Show();
				base.Hide();
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003C92 File Offset: 0x00001E92
		private void license_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003C95 File Offset: 0x00001E95
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003C98 File Offset: 0x00001E98
		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003C9B File Offset: 0x00001E9B
		private void username_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003CA0 File Offset: 0x00001EA0
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.login(this.username.Text, this.password.Text);
			bool success = Login.KeyAuthApp.response.success;
			if (success)
			{
				Form2 gkhanh = new Form2();
				gkhanh.Show();
				base.Hide();
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003CFC File Offset: 0x00001EFC
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.register(this.username.Text, this.password.Text, this.license.Text, "");
			bool success = Login.KeyAuthApp.response.success;
			if (success)
			{
				Form2 gkhanh = new Form2();
				gkhanh.Show();
				base.Hide();
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003D64 File Offset: 0x00001F64
		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003D67 File Offset: 0x00001F67
		private void progressBar1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003D6A File Offset: 0x00001F6A
		private void timer1_Tick(object sender, EventArgs e)
		{
		}

		// Token: 0x0400000F RID: 15
		public static api KeyAuthApp = new api("Digital Generator", "eWf25QRLpT", "cd6a84dece6160f8cee510a8c1ff9e81848efaa7ec279632a0658b4779b5b733", "1.0");

		// Token: 0x04000010 RID: 16
		private object siticoneLabel1;
	}
}
