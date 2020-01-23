namespace LeicaBimLinkRevit.Forms
{
	// Token: 0x02000008 RID: 8
	public partial class frm_HeXML_Export : global::System.Windows.Forms.Form
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00005CB8 File Offset: 0x00003EB8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00005CD8 File Offset: 0x00003ED8
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::LeicaBimLinkRevit.Forms.frm_HeXML_Export));
			this.uc_HeXML_DetailTreeview = new global::LeicaBimLinkGUI.UserControls.uc_HeXML_DetailTreeview();
			this.toolStrip = new global::System.Windows.Forms.ToolStrip();
			this.TSB_Select = new global::System.Windows.Forms.ToolStripButton();
			this.TSB_ExportHeXML = new global::System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.toolStripStatus = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar = new global::System.Windows.Forms.ToolStripProgressBar();
			this.helpProvider = new global::System.Windows.Forms.HelpProvider();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.toolStrip.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			base.SuspendLayout();
			this.uc_HeXML_DetailTreeview.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.uc_HeXML_DetailTreeview.Location = new global::System.Drawing.Point(0, 28);
			this.uc_HeXML_DetailTreeview.Name = "uc_HeXML_DetailTreeview";
			this.uc_HeXML_DetailTreeview.Size = new global::System.Drawing.Size(404, 430);
			this.uc_HeXML_DetailTreeview.TabIndex = 1;
			this.toolStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.TSB_Select,
				this.TSB_ExportHeXML
			});
			this.toolStrip.Location = new global::System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new global::System.Drawing.Size(404, 25);
			this.toolStrip.TabIndex = 2;
			this.toolStrip.Text = "toolStrip1";
			this.TSB_Select.Image = global::LeicaBimLinkRevit.Properties.Resources.open;
			this.TSB_Select.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.TSB_Select.Name = "TSB_Select";
			this.TSB_Select.Size = new global::System.Drawing.Size(58, 22);
			this.TSB_Select.Text = "Select";
			this.TSB_Select.Click += new global::System.EventHandler(this.TSB_Select_Click);
			this.TSB_ExportHeXML.Image = global::LeicaBimLinkRevit.Properties.Resources.Export_HeXML;
			this.TSB_ExportHeXML.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.TSB_ExportHeXML.Name = "TSB_ExportHeXML";
			this.TSB_ExportHeXML.Size = new global::System.Drawing.Size(102, 22);
			this.TSB_ExportHeXML.Text = "Export HeXML";
			this.TSB_ExportHeXML.Click += new global::System.EventHandler(this.TSB_ExportHeXML_Click);
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripStatus,
				this.toolStripProgressBar
			});
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 490);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new global::System.Drawing.Size(404, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatus.AutoSize = false;
			this.toolStripStatus.Name = "toolStripStatus";
			this.toolStripStatus.Size = new global::System.Drawing.Size(215, 17);
			this.toolStripStatus.Text = "Status: Ready";
			this.toolStripStatus.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new global::System.Drawing.Size(180, 16);
			this.toolStripProgressBar.Visible = false;
			this.btnOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.Location = new global::System.Drawing.Point(326, 462);
			this.btnOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(404, 512);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.toolStrip);
			base.Controls.Add(this.uc_HeXML_DetailTreeview);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(420, 550);
			this.MaximumSize = new global::System.Drawing.Size(420, 550);
			base.Name = "frm_HeXML_Export";
			this.Text = "Leica HeXML Export";
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.frm_HeXML_Export_KeyDown);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400001D RID: 29
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400001E RID: 30
		private global::LeicaBimLinkGUI.UserControls.uc_HeXML_DetailTreeview uc_HeXML_DetailTreeview;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.ToolStrip toolStrip;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.ToolStripButton TSB_Select;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.ToolStripButton TSB_ExportHeXML;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatus;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.HelpProvider helpProvider;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Button btnOK;
	}
}
