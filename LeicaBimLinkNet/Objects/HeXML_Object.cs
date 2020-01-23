using System;
using System.Collections.Generic;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000008 RID: 8
	public class HeXML_Object
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00004A57 File Offset: 0x00002C57
		// (set) Token: 0x06000023 RID: 35 RVA: 0x00004A5F File Offset: 0x00002C5F
		public string Description_Name
		{
			get
			{
				return this._Description_Name;
			}
			set
			{
				this._Description_Name = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00004A68 File Offset: 0x00002C68
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00004A70 File Offset: 0x00002C70
		public string Intern_Name
		{
			get
			{
				return this._Intern_Name;
			}
			set
			{
				this._Intern_Name = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00004A79 File Offset: 0x00002C79
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00004A81 File Offset: 0x00002C81
		public string Intern_String
		{
			get
			{
				return this._Intern_String;
			}
			set
			{
				this._Intern_String = value;
			}
		}

		// Token: 0x0400001D RID: 29
		private string _Description_Name = "";

		// Token: 0x0400001E RID: 30
		private string _Intern_Name = "";

		// Token: 0x0400001F RID: 31
		private string _Intern_String = "";

		// Token: 0x04000020 RID: 32
		public List<string> Additional_Description = new List<string>();
	}
}
