using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using LeicaBimLinkRevit.Properties;

namespace LeicaBimLinkRevit
{
	// Token: 0x02000002 RID: 2
	[Transaction(1)]
	[Regeneration(0)]
	[Journaling(1)]
	public class Extension : IExternalApplication
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002048 File Offset: 0x00000248
		public Result OnStartup(UIControlledApplication application)
		{
			try
			{
				application.CreateRibbonTab("Leica");
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
			RibbonPanel ribbonPanel = application.CreateRibbonPanel("Leica", "Leica Building Link");
			string text = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LeicaBimLinkRevit.dll");
			ribbonPanel.AddItem(new PushButtonData("HeXML_Import", "HeXML Import", text, "LeicaBimLinkRevit.Extensions.HeXML_Import")
			{
				ToolTip = "\"HeXML Import\" allows to import \"Measurement Points\" from a file into the current project.",
				LargeImage = Imaging.CreateBitmapSourceFromHBitmap(Resources.Import_HeXML.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions())
			});
			ribbonPanel.AddItem(new PushButtonData("Family_Place", "Measurement Point", text, "LeicaBimLinkRevit.Extensions.Family_Place")
			{
				ToolTip = "Allows the user to place a \"Measurement Point\" in the current project.",
				LargeImage = Imaging.CreateBitmapSourceFromHBitmap(Resources.MeasurementPoint_Place.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions())
			});
			ribbonPanel.AddItem(new PushButtonData("HeXML_Export", "HeXML Export", text, "LeicaBimLinkRevit.Extensions.HeXML_Export")
			{
				ToolTip = "\"HeXML Export\" allows to select \"Measurement Points\" from the current project and export them into an *.hexml file.",
				LargeImage = Imaging.CreateBitmapSourceFromHBitmap(Resources.Export_HeXML.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions())
			});
			ribbonPanel.AddItem(new PushButtonData("Help", "Help", text, "LeicaBimLinkRevit.Extensions.Help")
			{
				LargeImage = Imaging.CreateBitmapSourceFromHBitmap(Resources.Help_HeXML.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions())
			});
			return 0;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000021D0 File Offset: 0x000003D0
		public Result OnShutdown(UIControlledApplication application)
		{
			return 0;
		}
	}
}
