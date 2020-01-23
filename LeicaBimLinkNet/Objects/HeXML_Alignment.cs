using System;
using System.Collections.Generic;
using System.Data;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000002 RID: 2
	public class HeXML_Alignment : HeXML_Object
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002048 File Offset: 0x00000248
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
		public DataSet Content { get; set; }

		// Token: 0x06000003 RID: 3 RVA: 0x00002059 File Offset: 0x00000259
		public HeXML_Alignment()
		{
			base.Description_Name = "Alignment";
		}

		// Token: 0x04000002 RID: 2
		public List<HeXML_Profile> Profiles = new List<HeXML_Profile>();
	}
}
