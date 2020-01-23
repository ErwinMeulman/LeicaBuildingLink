using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace LeicaBimLinkRevit.Properties
{
	// Token: 0x02000003 RID: 3
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000021D3 File Offset: 0x000003D3
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000021DB File Offset: 0x000003DB
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("LeicaBimLinkRevit.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002207 File Offset: 0x00000407
		// (set) Token: 0x06000007 RID: 7 RVA: 0x0000220E File Offset: 0x0000040E
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
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002216 File Offset: 0x00000416
		internal static Bitmap Export_HeXML
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("Export_HeXML", Resources.resourceCulture);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002231 File Offset: 0x00000431
		internal static Bitmap Help_HeXML
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("Help_HeXML", Resources.resourceCulture);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000224C File Offset: 0x0000044C
		internal static Bitmap Import_HeXML
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("Import_HeXML", Resources.resourceCulture);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000B RID: 11 RVA: 0x00002267 File Offset: 0x00000467
		internal static Bitmap MeasurementPoint_Place
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("MeasurementPoint_Place", Resources.resourceCulture);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002282 File Offset: 0x00000482
		internal static Bitmap open
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("open", Resources.resourceCulture);
			}
		}

		// Token: 0x04000001 RID: 1
		private static ResourceManager resourceMan;

		// Token: 0x04000002 RID: 2
		private static CultureInfo resourceCulture;
	}
}
