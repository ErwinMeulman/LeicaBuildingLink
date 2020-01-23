using System;
using System.Data;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000004 RID: 4
	public class HeXML_Corridor : HeXML_Object
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000209B File Offset: 0x0000029B
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020A3 File Offset: 0x000002A3
		public DataSet Content { get; set; }

		// Token: 0x06000009 RID: 9 RVA: 0x000020AC File Offset: 0x000002AC
		public HeXML_Corridor()
		{
			base.Description_Name = "Corridor";
		}
	}
}
