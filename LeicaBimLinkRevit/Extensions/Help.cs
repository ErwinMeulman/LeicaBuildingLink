using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using LeicaBimLinkNet.Objects;
using LeicaBimLinkRevit.Methods;

namespace LeicaBimLinkRevit.Extensions
{
	// Token: 0x0200000C RID: 12
	[Transaction(1)]
	[Regeneration(0)]
	public class Help : IExternalCommand
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00006400 File Offset: 0x00004600
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			try
			{
				if (Control.ModifierKeys != Keys.Control)
				{
					string text = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Help)).Location) + "\\LeicaBimLink.chm";
					if (File.Exists(text))
					{
						Process.Start(text);
					}
				}
				else
				{
					List<HeXML_Point> list = new RevitDocument().Select_HeXMLPoints(commandData.Application, commandData.Application.ActiveUIDocument.Document);
					if (list.Count != 0)
					{
						string text2 = "";
						foreach (HeXML_Point heXML_Point in list)
						{
							text2 = string.Concat(new object[]
							{
								text2,
								"n: ",
								heXML_Point.Coordinate_Local_Grid.n,
								"; e: ",
								heXML_Point.Coordinate_Local_Grid.e,
								"; hghthO: ",
								heXML_Point.Coordinate_Local_Grid.hghthO,
								"\n"
							});
						}
						MessageBox.Show(text2);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			return 0;
		}
	}
}
