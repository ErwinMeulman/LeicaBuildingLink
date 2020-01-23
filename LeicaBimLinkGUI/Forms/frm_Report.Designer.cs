namespace LeicaBimLinkGUI.Forms
{
	// Token: 0x02000004 RID: 4
	public partial class frm_Report : global::System.Windows.Forms.Form
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00004809 File Offset: 0x00002A09
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00004828 File Offset: 0x00002A28
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::LeicaBimLinkGUI.Forms.frm_Report));
			this.textBox = new global::System.Windows.Forms.TextBox();
			this.toolStrip = new global::System.Windows.Forms.ToolStrip();
			this.TSB_ExportCSV = new global::System.Windows.Forms.ToolStripButton();
			this.panel = new global::System.Windows.Forms.Panel();
			this.helpProvider = new global::System.Windows.Forms.HelpProvider();
			this.toolStrip.SuspendLayout();
			this.panel.SuspendLayout();
			base.SuspendLayout();
			this.textBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textBox.Location = new global::System.Drawing.Point(0, 28);
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.ReadOnly = true;
			this.textBox.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.textBox.Size = new global::System.Drawing.Size(394, 368);
			this.textBox.TabIndex = 0;
			this.toolStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.TSB_ExportCSV
			});
			this.toolStrip.Location = new global::System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new global::System.Drawing.Size(394, 25);
			this.toolStrip.TabIndex = 3;
			this.toolStrip.Text = "toolStrip1";
			this.TSB_ExportCSV.Image = global::LeicaBimLinkGUI.Properties.Resources.CSV;
			this.TSB_ExportCSV.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.TSB_ExportCSV.Name = "TSB_ExportCSV";
			this.TSB_ExportCSV.Size = new global::System.Drawing.Size(84, 22);
			this.TSB_ExportCSV.Text = "Export CSV";
			this.TSB_ExportCSV.Click += new global::System.EventHandler(this.TSB_ExportCSV_Click);
			this.panel.Controls.Add(this.toolStrip);
			this.panel.Controls.Add(this.textBox);
			this.panel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new global::System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new global::System.Drawing.Size(394, 396);
			this.panel.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(394, 396);
			base.Controls.Add(this.panel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.Name = "frm_Report";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Protocol";
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.frm_Report_KeyDown);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400000F RID: 15
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.TextBox textBox;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.ToolStrip toolStrip;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.ToolStripButton TSB_ExportCSV;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Panel panel;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.HelpProvider helpProvider;
	}
}
