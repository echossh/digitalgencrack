using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Digital_Project.Properties
{
	// Token: 0x02000008 RID: 8
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000055 RID: 85 RVA: 0x000063A1 File Offset: 0x000045A1
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000063AC File Offset: 0x000045AC
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager temp = new ResourceManager("Digital_Project.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = temp;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000063F4 File Offset: 0x000045F4
		// (set) Token: 0x06000058 RID: 88 RVA: 0x0000640B File Offset: 0x0000460B
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00006414 File Offset: 0x00004614
		internal static Bitmap _1653365_removebg_preview
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("1653365-removebg-preview", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x0400002E RID: 46
		private static ResourceManager resourceMan;

		// Token: 0x0400002F RID: 47
		private static CultureInfo resourceCulture;
	}
}
