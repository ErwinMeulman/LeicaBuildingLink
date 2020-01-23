using System;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using LeicaBimLinkRevit.Methods;

namespace LeicaBimLinkRevit.Extensions
{
	// Token: 0x0200000B RID: 11
	[Transaction(1)]
	[Regeneration(0)]
	public class Family_Place : IExternalCommand
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00006390 File Offset: 0x00004590
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			try
			{
				if (!commandData.Application.ActiveUIDocument.Document.IsFamilyDocument)
				{
					new RevitDocument().Place_MeasurementPointFamily(commandData.Application.ActiveUIDocument);
				}
				else
				{
					new RevitDocument().Place_MeasurementPointFamilyInFamily(commandData.Application.ActiveUIDocument);
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
