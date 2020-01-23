namespace LeicaBimLinkRevit.Forms
{
	// Token: 0x02000007 RID: 7
	public partial class frm_HeXML_Import : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002D RID: 45 RVA: 0x000051AC File Offset: 0x000033AC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000051CC File Offset: 0x000033CC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::LeicaBimLinkRevit.Forms.frm_HeXML_Import));
			this.uc_HeXML_DetailTreeview = new global::LeicaBimLinkGUI.UserControls.uc_HeXML_DetailTreeview();
			this.toolStrip = new global::System.Windows.Forms.ToolStrip();
			this.TSB_OpenHeXML = new global::System.Windows.Forms.ToolStripButton();
			this.TSB_ImportHeXML = new global::System.Windows.Forms.ToolStripButton();
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
				this.TSB_OpenHeXML,
				this.TSB_ImportHeXML
			});
			this.toolStrip.Location = new global::System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new global::System.Drawing.Size(404, 25);
			this.toolStrip.TabIndex = 2;
			this.toolStrip.Text = "toolStrip1";
			this.TSB_OpenHeXML.Image = global::LeicaBimLinkRevit.Properties.Resources.open;
			this.TSB_OpenHeXML.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.TSB_OpenHeXML.Name = "TSB_OpenHeXML";
			this.TSB_OpenHeXML.Size = new global::System.Drawing.Size(98, 22);
			this.TSB_OpenHeXML.Text = "Open HeXML";
			this.TSB_OpenHeXML.Click += new global::System.EventHandler(this.TSB_OpenHeXML_Click);
			this.TSB_ImportHeXML.Image = global::LeicaBimLinkRevit.Properties.Resources.Import_HeXML;
			this.TSB_ImportHeXML.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.TSB_ImportHeXML.Name = "TSB_ImportHeXML";
			this.TSB_ImportHeXML.Size = new global::System.Drawing.Size(105, 22);
			this.TSB_ImportHeXML.Text = "Import HeXML";
			this.TSB_ImportHeXML.Click += new global::System.EventHandler(this.TSB_ImportHeXML_Click);
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripStatus,
				this.toolStripProgressBar
			});
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 490);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new global::System.Drawing.Size(404, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 3;
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
			this.btnOK.TabIndex = 6;
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
			base.Name = "frm_HeXML_Import";
			this.Text = "Leica HeXML Import";
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.frm_HeXML_Import_KeyDown);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000011 RID: 17
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000012 RID: 18
		private global::LeicaBimLinkGUI.UserControls.uc_HeXML_DetailTreeview uc_HeXML_DetailTreeview;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.ToolStrip toolStrip;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.ToolStripButton TSB_OpenHeXML;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.ToolStripButton TSB_ImportHeXML;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatus;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.HelpProvider helpProvider;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Button btnOK;
	}
}
