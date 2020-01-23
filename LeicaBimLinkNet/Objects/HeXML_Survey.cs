using System;
using System.Data;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000010 RID: 16
	public class HeXML_Survey : HeXML_Object
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00005110 File Offset: 0x00003310
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00005118 File Offset: 0x00003318
		public DataSet Content { get; set; }

		// Token: 0x0600007F RID: 127 RVA: 0x00005121 File Offset: 0x00003321
		public HeXML_Survey()
		{
			base.Description_Name = "Survey";
		}
	}
}
