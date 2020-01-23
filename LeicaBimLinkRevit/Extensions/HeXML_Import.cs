using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using LeicaBimLinkRevit.Forms;
using LeicaBimLinkRevit.Methods;

namespace LeicaBimLinkRevit.Extensions
{
	// Token: 0x0200000A RID: 10
	[Transaction(1)]
	[Regeneration(0)]
	public class HeXML_Import : IExternalCommand
	{
		// Token: 0x0600003B RID: 59 RVA: 0x0000627C File Offset: 0x0000447C
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			try
			{
				if (!commandData.Application.ActiveUIDocument.Document.IsFamilyDocument)
				{
					if (HeXML_Import.frm_HeXML_Import == null || !HeXML_Import.frm_HeXML_Import.Visible)
					{
						this._commandData = commandData;
						RevitDocument revitDocument = new RevitDocument();
						string familyPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(HeXML_Import)).Location) + "\\" + revitDocument.MeasurementFamilyPointPath;
						revitDocument.Load_Family(familyPath, commandData.Application.ActiveUIDocument.Document);
						Transaction transaction = new Transaction(this._commandData.Application.ActiveUIDocument.Document);
						transaction.Start("Leica_Transaction_HeXMLPoints");
						HeXML_Import.frm_HeXML_Import = new frm_HeXML_Import(commandData);
						HeXML_Import.frm_HeXML_Import.HeXML_Import = this;
						HeXML_Import.frm_HeXML_Import.ShowDialog(new RevitWindowHandle());
						transaction.Commit();
					}
				}
				else
				{
					MessageBox.Show("The \"Leica HeXML Import\" can only be used with project documents.", "Leica", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			return 0;
		}

		// Token: 0x04000028 RID: 40
		private static frm_HeXML_Import frm_HeXML_Import;

		// Token: 0x04000029 RID: 41
		private ExternalCommandData _commandData;
	}
}
