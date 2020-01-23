using System;
using System.Data;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000007 RID: 7
	public class HeXML_Line : HeXML_Object
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00004A33 File Offset: 0x00002C33
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00004A3B File Offset: 0x00002C3B
		public DataSet Content { get; set; }

		// Token: 0x06000021 RID: 33 RVA: 0x00004A44 File Offset: 0x00002C44
		public HeXML_Line()
		{
			base.Description_Name = "Line";
		}
	}
}
