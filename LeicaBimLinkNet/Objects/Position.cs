using System;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000013 RID: 19
	public class Position
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000530D File Offset: 0x0000350D
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x00005315 File Offset: 0x00003515
		public double x { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x0000531E File Offset: 0x0000351E
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x00005326 File Offset: 0x00003526
		public double y { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x0000532F File Offset: 0x0000352F
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00005337 File Offset: 0x00003537
		public double z { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00005340 File Offset: 0x00003540
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00005348 File Offset: 0x00003548
		public double Rotation { get; set; }
	}
}
