using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using LeicaBimLinkGUI.Properties;
using LeicaBimLinkNet.Objects;

namespace LeicaBimLinkGUI.Forms
{
	// Token: 0x02000004 RID: 4
	public partial class frm_Report : Form
	{
		// Token: 0x06000018 RID: 24 RVA: 0x000045FB File Offset: 0x000027FB
		public frm_Report()
		{
			this.InitializeComponent();
			this.Set_Help();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00004610 File Offset: 0x00002810
		public void FillTextBox(HeXML_Details HeXML_Details, string Title)
		{
			this.Clear();
			this._HeXML_Details = HeXML_Details;
			if (this._HeXML_Details != null)
			{
				List<string> list = this._HeXML_Details.Get_Protocol(Title);
				if (list.Count != 0)
				{
					this.textBox.Lines = list.ToArray();
				}
				this.textBox.Select(0, 0);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00004668 File Offset: 0x00002868
		public void FillTextBox(List<object> List_HeXMLObjects, string Title)
		{
			this.Clear();
			if (List_HeXMLObjects != null && List_HeXMLObjects.Count != 0)
			{
				this._HeXML_Details = new HeXML_Details(HeXML_Details.UnitConverter.None);
				this._HeXML_Details.Detect_Details(List_HeXMLObjects, new List<string>());
				List<string> list = this._HeXML_Details.Get_Protocol(Title);
				if (list.Count != 0)
				{
					this.textBox.Lines = list.ToArray();
				}
				this.textBox.Select(0, 0);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000046D6 File Offset: 0x000028D6
		public void Clear()
		{
			this.textBox.Clear();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000046E4 File Offset: 0x000028E4
		private void Set_Help()
		{
			string helpNamespace = Path.GetDirectoryName(Assembly.GetAssembly(typeof(frm_Report)).Location) + "\\LeicaBimLink.chm";
			this.helpProvider.HelpNamespace = helpNamespace;
			this.helpProvider.SetHelpKeyword(this, "");
			this.helpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
			this.helpProvider.SetShowHelp(this, true);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00004750 File Offset: 0x00002950
		private void TSB_ExportCSV_Click(object sender, EventArgs e)
		{
			if (this._HeXML_Details != null)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "CSV Files (*.CSV)|*.CSV|All files (*.*)|*.*";
				saveFileDialog.FileName = "Leica.csv";
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					bool flag = this._HeXML_Details.Write_CSV(saveFileDialog.FileName);
					FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
					if (!flag)
					{
						MessageBox.Show(fileInfo.Name + " could not be exported.", "Leica", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					if (MessageBox.Show(fileInfo.Name + " was exported.\nDo you want to open the file?", "Leica", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
					{
						Process.Start(fileInfo.FullName);
					}
				}
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000047F7 File Offset: 0x000029F7
		private void frm_Report_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x0400000E RID: 14
		private HeXML_Details _HeXML_Details;
	}
}
