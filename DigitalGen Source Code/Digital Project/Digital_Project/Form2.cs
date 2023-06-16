using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Digital_Project.Properties;
using Guna.UI2.WinForms;

namespace Digital_Project
{
	// Token: 0x02000006 RID: 6
	public partial class Form2 : Form
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00004D2B File Offset: 0x00002F2B
		public Form2()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004D44 File Offset: 0x00002F44
		private void guna2Button9_Click(object sender, EventArgs e)
		{
			string[] accounts = new WebClient().DownloadString("https://pastebin.com/raw/bu77Q1Hy").Split(new char[]
			{
				'\n'
			});
			this.guna2TextBox1.Text = accounts[new Random().Next(0, accounts.Length)];
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00004D90 File Offset: 0x00002F90
		private void guna2Button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00004D93 File Offset: 0x00002F93
		private void Form2_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00004D96 File Offset: 0x00002F96
		private void guna2ControlBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00004D9C File Offset: 0x00002F9C
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			string[] accounts = new WebClient().DownloadString("https://pastebin.com/raw/ntgtm2yy").Split(new char[]
			{
				'\n'
			});
			this.guna2TextBox1.Text = accounts[new Random().Next(0, accounts.Length)];
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00004DE8 File Offset: 0x00002FE8
		private void guna2Button6_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00004DEC File Offset: 0x00002FEC
		private void guna2Button8_Click(object sender, EventArgs e)
		{
			string[] accounts = new WebClient().DownloadString("https://pastebin.com/raw/nutcAhTL").Split(new char[]
			{
				'\n'
			});
			this.guna2TextBox1.Text = accounts[new Random().Next(0, accounts.Length)];
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00004E38 File Offset: 0x00003038
		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004E3B File Offset: 0x0000303B
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00004E3E File Offset: 0x0000303E
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004E41 File Offset: 0x00003041
		private void guna2Button9_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004E44 File Offset: 0x00003044
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			string[] accounts = new WebClient().DownloadString("https://pastebin.com/raw/ruEVWkV3").Split(new char[]
			{
				'\n'
			});
			this.guna2TextBox1.Text = accounts[new Random().Next(0, accounts.Length)];
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004E90 File Offset: 0x00003090
		private void guna2Button3_Click_1(object sender, EventArgs e)
		{
			string[] accounts = new WebClient().DownloadString("https://pastebin.com/raw/yEk9HqQY").Split(new char[]
			{
				'\n'
			});
			this.guna2TextBox1.Text = accounts[new Random().Next(0, accounts.Length)];
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004EDC File Offset: 0x000030DC
		private void guna2Button1_Click_1(object sender, EventArgs e)
		{
			string[] accounts = new WebClient().DownloadString("https://pastebin.com/raw/PPiuWG2P").Split(new char[]
			{
				'\n'
			});
			this.guna2TextBox1.Text = accounts[new Random().Next(0, accounts.Length)];
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004F28 File Offset: 0x00003128
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			string[] accounts = new WebClient().DownloadString("https://pastebin.com/raw/eCB3nuxG").Split(new char[]
			{
				'\n'
			});
			this.guna2TextBox1.Text = accounts[new Random().Next(0, accounts.Length)];
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004F74 File Offset: 0x00003174
		private void guna2Button7_Click(object sender, EventArgs e)
		{
			string[] accounts = new WebClient().DownloadString("https://pastebin.com/raw/jF9wZGvY").Split(new char[]
			{
				'\n'
			});
			this.guna2TextBox1.Text = accounts[new Random().Next(0, accounts.Length)];
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004FC0 File Offset: 0x000031C0
		private void guna2Button6_Click_1(object sender, EventArgs e)
		{
			string[] accounts = new WebClient().DownloadString("https://pastebin.com/raw/ypAx25iC").Split(new char[]
			{
				'\n'
			});
			this.guna2TextBox1.Text = accounts[new Random().Next(0, accounts.Length)];
		}
	}
}
