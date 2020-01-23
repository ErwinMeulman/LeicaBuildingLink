using System;
using System.Data;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000003 RID: 3
	public class HeXML_Area : HeXML_Object
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002077 File Offset: 0x00000277
		// (set) Token: 0x06000005 RID: 5 RVA: 0x0000207F File Offset: 0x0000027F
		public DataSet Content { get; set; }

		// Token: 0x06000006 RID: 6 RVA: 0x00002088 File Offset: 0x00000288
		public HeXML_Area()
		{
			base.Description_Name = "Area";
		}
	}
}
