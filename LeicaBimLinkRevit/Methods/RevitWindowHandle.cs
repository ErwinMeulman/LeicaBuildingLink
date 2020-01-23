using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LeicaBimLinkRevit.Methods
{
	// Token: 0x02000006 RID: 6
	public class RevitWindowHandle : IWin32Window
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00004CC1 File Offset: 0x00002EC1
		public IntPtr Handle
		{
			get
			{
				return this._handle;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00004CCC File Offset: 0x00002ECC
		public RevitWindowHandle()
		{
			Process currentProcess = Process.GetCurrentProcess();
			this._handle = currentProcess.MainWindowHandle;
		}

		// Token: 0x0400000A RID: 10
		private IntPtr _handle;
	}
}
