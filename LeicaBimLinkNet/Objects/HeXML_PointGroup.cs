using System;
using System.Data;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000011 RID: 17
	public class HeXML_PointGroup : HeXML_Object
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00005134 File Offset: 0x00003334
		// (set) Token: 0x06000081 RID: 129 RVA: 0x0000513C File Offset: 0x0000333C
		public DataSet Content { get; set; }

		// Token: 0x06000082 RID: 130 RVA: 0x00005145 File Offset: 0x00003345
		public HeXML_PointGroup()
		{
			base.Description_Name = "PointGroup";
		}
	}
}
