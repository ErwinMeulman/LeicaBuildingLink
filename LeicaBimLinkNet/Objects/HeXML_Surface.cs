using System;
using System.Data;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x0200000F RID: 15
	public class HeXML_Surface : HeXML_Object
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600007A RID: 122 RVA: 0x000050EC File Offset: 0x000032EC
		// (set) Token: 0x0600007B RID: 123 RVA: 0x000050F4 File Offset: 0x000032F4
		public DataSet Content { get; set; }

		// Token: 0x0600007C RID: 124 RVA: 0x000050FD File Offset: 0x000032FD
		public HeXML_Surface()
		{
			base.Description_Name = "Surface";
		}
	}
}
