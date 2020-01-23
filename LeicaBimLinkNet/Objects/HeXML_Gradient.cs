using System;
using System.Data;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000006 RID: 6
	public class HeXML_Gradient : HeXML_Object
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00004A0F File Offset: 0x00002C0F
		// (set) Token: 0x0600001D RID: 29 RVA: 0x00004A17 File Offset: 0x00002C17
		public DataSet Content { get; set; }

		// Token: 0x0600001E RID: 30 RVA: 0x00004A20 File Offset: 0x00002C20
		public HeXML_Gradient()
		{
			base.Description_Name = "Gradient";
		}
	}
}
