using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using LeicaBimLinkGUI.Forms;
using LeicaBimLinkGUI.UserControls;
using LeicaBimLinkNet.Methods;
using LeicaBimLinkNet.Objects;
using LeicaBimLinkRevit.Extensions;
using LeicaBimLinkRevit.Methods;
using LeicaBimLinkRevit.Properties;

namespace LeicaBimLinkRevit.Forms
{
	// Token: 0x02000007 RID: 7
	public partial class frm_HeXML_Import : Form
	{
		// Token: 0x06000026 RID: 38 RVA: 0x00004CF1 File Offset: 0x00002EF1
		public frm_HeXML_Import(ExternalCommandData commandData)
		{
			this.InitializeComponent();
			this._commandData = commandData;
			this.Set_Help();
			this.Check_Controls();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00004D2B File Offset: 0x00002F2B
		private void Check_Controls()
		{
			if (this._List_Object.Count == 0)
			{
				this.TSB_ImportHeXML.Enabled = false;
				return;
			}
			this.TSB_ImportHeXML.Enabled = true;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00004D54 File Offset: 0x00002F54
		private void Set_Help()
		{
			string helpNamespace = Path.GetDirectoryName(Assembly.GetAssembly(typeof(frm_HeXML_Import)).Location) + "\\LeicaBimLink.chm";
			this.helpProvider.HelpNamespace = helpNamespace;
			this.helpProvider.SetHelpKeyword(this, "LeicaBimLinkImportHeXml.html");
			this.helpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
			this.helpProvider.SetShowHelp(this, true);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00004DC0 File Offset: 0x00002FC0
		private void TSB_OpenHeXML_Click(object sender, EventArgs e)
		{
			this.toolStrip.Enabled = false;
			this.uc_HeXML_DetailTreeview.Enabled = false;
			this.uc_HeXML_DetailTreeview.Clear();
			this._LandXML_Header = null;
			this._UnitConverter = RevitDocument.UnitConverter.None;
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "XML Files (*.XML)|*.XML|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				HeXML heXML = new HeXML();
				this._List_Object = heXML.Read(openFileDialog.FileName, out this._LandXML_Header);
				RevitDocument revitDocument = new RevitDocument();
				this._UnitConverter = revitDocument.Test_LinearUnitType_Agreement(this._commandData.Application.ActiveUIDocument.Document, this._LandXML_Header.Units_linearUnit);
				if (this._List_Object != null && this._List_Object.Count != 0)
				{
					this.toolStripStatus.Text = "Status: Update display";
					Application.DoEvents();
					this.uc_HeXML_DetailTreeview.Load(this._List_Object);
					if (this._UnitConverter == RevitDocument.UnitConverter.None)
					{
						this.toolStripStatus.Text = "Status: Ready";
					}
					else
					{
						this.toolStripStatus.Text = "Information: Different unit types";
					}
				}
				else
				{
					MessageBox.Show("No usable objects exist.", "Leica", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				this._UnitConverterIntern = revitDocument.Test_LinearUnitType_AgreementIntern(this._LandXML_Header.Units_linearUnit);
			}
			this.Check_Controls();
			this.toolStrip.Enabled = true;
			this.uc_HeXML_DetailTreeview.Enabled = true;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00004F1C File Offset: 0x0000311C
		private void TSB_ImportHeXML_Click(object sender, EventArgs e)
		{
			this.toolStrip.Enabled = false;
			this.uc_HeXML_DetailTreeview.Enabled = false;
			if (this._List_Object.Count != 0)
			{
				RevitDocument revitDocument = new RevitDocument();
				List<string> listExisting_UniqueIDs = revitDocument.Get_FamilyParameterValue(revitDocument.MeasurementFamilyPointTypName, HeXML_Point_Strings.FamilyParameterName_UniqueID, this._commandData.Application.ActiveUIDocument.Document);
				HeXML_Details heXML_Details;
				if (this._UnitConverter == RevitDocument.UnitConverter.FeetToMeter)
				{
					heXML_Details = new HeXML_Details(HeXML_Details.UnitConverter.FeetToMeter);
				}
				else if (this._UnitConverter == RevitDocument.UnitConverter.MeterToFeet)
				{
					heXML_Details = new HeXML_Details(HeXML_Details.UnitConverter.MeterToFeet);
				}
				else
				{
					heXML_Details = new HeXML_Details(HeXML_Details.UnitConverter.None);
				}
				heXML_Details.Detect_Details(this._List_Object, listExisting_UniqueIDs);
				heXML_Details.Get_HeXMLPoints();
				listExisting_UniqueIDs = revitDocument.Get_FamilyParameterValue(revitDocument.MeasurementFamilyPointTypName, HeXML_Point_Strings.FamilyParameterName_UniqueID, this._commandData.Application.ActiveUIDocument.Document);
				HeXML_Details heXML_Details2 = null;
				if (this._UnitConverterIntern == RevitDocument.UnitConverter.FeetToMeter)
				{
					heXML_Details2 = new HeXML_Details(HeXML_Details.UnitConverter.FeetToMeter);
				}
				if (this._UnitConverterIntern == RevitDocument.UnitConverter.MeterToFeet)
				{
					heXML_Details2 = new HeXML_Details(HeXML_Details.UnitConverter.MeterToFeet);
				}
				if (this._UnitConverterIntern == RevitDocument.UnitConverter.None)
				{
					heXML_Details2 = new HeXML_Details(HeXML_Details.UnitConverter.None);
				}
				heXML_Details2.Detect_Details(this._List_Object, listExisting_UniqueIDs);
				List<HeXML_Point> heXMLPoints = heXML_Details2.Get_HeXMLPoints();
				if (heXMLPoints.Count != 0 || heXML_Details.List_HeXML_Point_Index_Fail.Count != 0)
				{
					revitDocument.ToolStripProgressBar = this.toolStripProgressBar;
					revitDocument.ToolStripStatusLabel = this.toolStripStatus;
					Path.GetDirectoryName(Assembly.GetAssembly(typeof(frm_HeXML_Import)).Location) + "\\" + revitDocument.MeasurementFamilyPointPath;
					this.toolStripStatus.Text = "Status: Loads the family";
					Application.DoEvents();
					Family family = null;
					if (family == null)
					{
						family = revitDocument.Get_Family(revitDocument.MeasurementFamilyPointName, this._commandData.Application.ActiveUIDocument.Document);
					}
					this.toolStripProgressBar.Visible = true;
					revitDocument.Set_HeXMLPoints(family, heXMLPoints, this._commandData.Application.ActiveUIDocument.Document, this.HeXML_Import);
					this.toolStripProgressBar.Visible = false;
					this.toolStripStatus.Text = "Status: The points were imported";
					frm_Report frm_Report = new frm_Report();
					frm_Report.FillTextBox(heXML_Details, "Protocol Import HeXML");
					frm_Report.ShowDialog();
					this.uc_HeXML_DetailTreeview.Clear();
					base.Close();
				}
			}
			this.Check_Controls();
			this.toolStrip.Enabled = true;
			this.uc_HeXML_DetailTreeview.Enabled = true;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00005158 File Offset: 0x00003358
		private void frm_HeXML_Import_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000516C File Offset: 0x0000336C
		private void btnOK_Click(object sender, EventArgs e)
		{
			bool flag = false;
			if (this.uc_HeXML_DetailTreeview.NodesCount == 0)
			{
				flag = true;
			}
			else if (MessageBox.Show("The selected data has not been imported yet.\nAre you sure you want to quit the process?", "Leica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				flag = true;
			}
			if (flag)
			{
				base.Close();
			}
		}

		// Token: 0x0400000B RID: 11
		private List<object> _List_Object = new List<object>();

		// Token: 0x0400000C RID: 12
		private ExternalCommandData _commandData;

		// Token: 0x0400000D RID: 13
		public HeXML_Import HeXML_Import;

		// Token: 0x0400000E RID: 14
		private LandXML_Header _LandXML_Header;

		// Token: 0x0400000F RID: 15
		private RevitDocument.UnitConverter _UnitConverter = RevitDocument.UnitConverter.None;

		// Token: 0x04000010 RID: 16
		private RevitDocument.UnitConverter _UnitConverterIntern = RevitDocument.UnitConverter.None;
	}
}
