using System;
using System.Windows.Forms;

namespace Digital_Project
{
	// Token: 0x02000007 RID: 7
	internal static class Program
	{
		// Token: 0x06000054 RID: 84
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form2());
		}
	}
}
