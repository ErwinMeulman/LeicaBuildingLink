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
using LeicaBimLinkRevit.Methods;
using LeicaBimLinkRevit.Properties;

namespace LeicaBimLinkRevit.Forms
{
	// Token: 0x02000008 RID: 8
	public partial class frm_HeXML_Export : Form
	{
		// Token: 0x0600002F RID: 47 RVA: 0x000056E4 File Offset: 0x000038E4
		public frm_HeXML_Export(ExternalCommandData commandData)
		{
			this.InitializeComponent();
			this._commandData = commandData;
			this.Set_Help();
			this.Check_Controls();
			new RevitDocument().FixDuplicatedIds(this._commandData.Application.ActiveUIDocument.Document);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000573A File Offset: 0x0000393A
		private void Check_Controls()
		{
			if (this._List_Object.Count == 0)
			{
				this.TSB_ExportHeXML.Enabled = false;
				return;
			}
			this.TSB_ExportHeXML.Enabled = true;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00005764 File Offset: 0x00003964
		private void Set_Help()
		{
			string helpNamespace = Path.GetDirectoryName(Assembly.GetAssembly(typeof(frm_HeXML_Export)).Location) + "\\LeicaBimLink.chm";
			this.helpProvider.HelpNamespace = helpNamespace;
			this.helpProvider.SetHelpKeyword(this, "LeicaBimLinkExportHeXml.html");
			this.helpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
			this.helpProvider.SetShowHelp(this, true);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000057D0 File Offset: 0x000039D0
		private void TSB_Select_Click(object sender, EventArgs e)
		{
			RevitDocument revitDocument = new RevitDocument();
			base.Visible = false;
			List<HeXML_Point> list = revitDocument.Select_HeXMLPoints(this._commandData.Application, this._commandData.Application.ActiveUIDocument.Document);
			base.Visible = true;
			this._List_Object = new List<object>();
			if (list.Count != 0)
			{
				foreach (HeXML_Point item in list)
				{
					this._List_Object.Add(item);
				}
				this.uc_HeXML_DetailTreeview.Load(this._List_Object);
			}
			this.Check_Controls();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00005888 File Offset: 0x00003A88
		private void TSB_ExportHeXML_Click(object sender, EventArgs e)
		{
			if (this._List_Object.Count != 0)
			{
				this.toolStrip.Enabled = false;
				this.uc_HeXML_DetailTreeview.Enabled = false;
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "XML Files (*.XML)|*.XML|All files (*.*)|*.*";
				saveFileDialog.FileName = "HeXML.xml";
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.toolStripStatus.Text = "Status: Saving ...";
					Application.DoEvents();
					LandXML_Header landXML_Header = new LandXML_Header();
					RevitDocument revitDocument = new RevitDocument();
					landXML_Header.Application_version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
					string str = string.Concat(new string[]
					{
						string.Format("{0:D2}", DateTime.Now.Year),
						"-",
						string.Format("{0:D2}", DateTime.Now.Month),
						"-",
						string.Format("{0:D2}", DateTime.Now.Day)
					});
					string str2 = string.Concat(new string[]
					{
						string.Format("{0:D2}", DateTime.Now.Hour),
						":",
						string.Format("{0:D2}", DateTime.Now.Minute),
						":",
						string.Format("{0:D2}", DateTime.Now.Second)
					});
					landXML_Header.Author_timeStamp = str + "T" + str2;
					bool flag = true;
					DisplayUnitType displayUnitType = revitDocument.Detect_UnitType(this._commandData.Application.ActiveUIDocument.Document, 0);
					DisplayUnitType displayUnitType2 = revitDocument.Detect_UnitType(this._commandData.Application.ActiveUIDocument.Document, 1);
					DisplayUnitType displayUnitType3 = revitDocument.Detect_UnitType(this._commandData.Application.ActiveUIDocument.Document, 2);
					revitDocument.Detect_UnitType(this._commandData.Application.ActiveUIDocument.Document, 3);
					string text = displayUnitType.ToString().ToLower();
					if (text.Contains("feet") || text.Contains("foot") || text.Contains("inches"))
					{
						landXML_Header.Units_linearUnit = "foot";
						flag = false;
					}
					else
					{
						landXML_Header.Units_linearUnit = "meter";
					}
					string text2 = displayUnitType2.ToString().ToLower();
					if (text2.Contains("feet") || text2.Contains("acres") || text2.Contains("inches"))
					{
						landXML_Header.Units_areaUnit = "squareFoot";
					}
					else
					{
						landXML_Header.Units_areaUnit = "squareMeter";
					}
					string text3 = displayUnitType3.ToString().ToLower();
					if (text3.Contains("gallon") || text3.Contains("inch") || text3.Contains("feet") || text3.Contains("yard"))
					{
						landXML_Header.Units_volumeUnit = "cubicFeet";
					}
					else
					{
						landXML_Header.Units_volumeUnit = "cubicMeter";
					}
					landXML_Header.Units_angularUnit = "decimal degrees";
					if (!flag)
					{
						landXML_Header.Units_pressureUnit = "inchHG";
					}
					else
					{
						landXML_Header.Units_pressureUnit = "milliBars";
					}
					if (!flag)
					{
						landXML_Header.Units_temperatureUnit = "fahrenheit";
					}
					else
					{
						landXML_Header.Units_temperatureUnit = "celsius";
					}
					new HeXML().Write(saveFileDialog.FileName, this._List_Object, landXML_Header);
					this.toolStripStatus.Text = "Status: The file has been written";
					frm_Report frm_Report = new frm_Report();
					frm_Report.FillTextBox(this._List_Object, "Protocol Export HeXML");
					frm_Report.ShowDialog();
					this.toolStripStatus.Text = "Status: Ready";
					this.uc_HeXML_DetailTreeview.Clear();
				}
				this.toolStrip.Enabled = true;
				this.uc_HeXML_DetailTreeview.Enabled = true;
			}
			this.Check_Controls();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00005158 File Offset: 0x00003358
		private void frm_HeXML_Export_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00005C78 File Offset: 0x00003E78
		private void btnOK_Click(object sender, EventArgs e)
		{
			bool flag = false;
			if (this.uc_HeXML_DetailTreeview.NodesCount == 0)
			{
				flag = true;
			}
			else if (MessageBox.Show("The selected data has not been exported yet.\nAre you sure you want to quit the process?", "Leica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				flag = true;
			}
			if (flag)
			{
				base.Close();
			}
		}

		// Token: 0x0400001B RID: 27
		private List<object> _List_Object = new List<object>();

		// Token: 0x0400001C RID: 28
		private ExternalCommandData _commandData;
	}
}
