using System;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using LeicaBimLinkRevit.Forms;
using LeicaBimLinkRevit.Methods;

namespace LeicaBimLinkRevit.Extensions
{
	// Token: 0x02000009 RID: 9
	[Transaction(1)]
	[Regeneration(0)]
	public class HeXML_Export : IExternalCommand
	{
		// Token: 0x06000038 RID: 56 RVA: 0x000061F0 File Offset: 0x000043F0
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			try
			{
				if (!commandData.Application.ActiveUIDocument.Document.IsFamilyDocument)
				{
					if (HeXML_Export.frm_HeXML_Export == null || !HeXML_Export.frm_HeXML_Export.Visible)
					{
						HeXML_Export.frm_HeXML_Export = new frm_HeXML_Export(commandData);
						HeXML_Export.frm_HeXML_Export.Show(new RevitWindowHandle());
					}
				}
				else
				{
					MessageBox.Show("The \"Leica HeXML Export\" can only be used with project documents.", "Leica", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			return 0;
		}

		// Token: 0x04000027 RID: 39
		private static frm_HeXML_Export frm_HeXML_Export;
	}
}
