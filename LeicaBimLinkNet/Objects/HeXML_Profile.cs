using System;
using System.Data;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x0200000E RID: 14
	public class HeXML_Profile : HeXML_Object
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000075 RID: 117 RVA: 0x000050B7 File Offset: 0x000032B7
		// (set) Token: 0x06000076 RID: 118 RVA: 0x000050BF File Offset: 0x000032BF
		public bool IsSelected
		{
			get
			{
				return this._IsSelected;
			}
			set
			{
				this._IsSelected = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000077 RID: 119 RVA: 0x000050C8 File Offset: 0x000032C8
		// (set) Token: 0x06000078 RID: 120 RVA: 0x000050D0 File Offset: 0x000032D0
		public DataSet Content { get; set; }

		// Token: 0x06000079 RID: 121 RVA: 0x000050D9 File Offset: 0x000032D9
		public HeXML_Profile()
		{
			base.Description_Name = "Profile";
		}

		// Token: 0x04000088 RID: 136
		private bool _IsSelected;
	}
}
