using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace LeicaBimLinkGUI.Properties
{
	// Token: 0x02000003 RID: 3
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000013 RID: 19 RVA: 0x0000459D File Offset: 0x0000279D
		internal Resources()
		{
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000045A5 File Offset: 0x000027A5
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("LeicaBimLinkGUI.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000045D1 File Offset: 0x000027D1
		// (set) Token: 0x06000016 RID: 22 RVA: 0x000045D8 File Offset: 0x000027D8
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

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000045E0 File Offset: 0x000027E0
		internal static Bitmap CSV
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("CSV", Resources.resourceCulture);
			}
		}

		// Token: 0x0400000C RID: 12
		private static ResourceManager resourceMan;

		// Token: 0x0400000D RID: 13
		private static CultureInfo resourceCulture;
	}
}
