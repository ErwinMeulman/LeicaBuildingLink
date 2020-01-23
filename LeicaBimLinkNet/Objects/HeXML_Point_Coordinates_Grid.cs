using System;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x0200000C RID: 12
	public class HeXML_Point_Coordinates_Grid
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00004D6F File Offset: 0x00002F6F
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00004D77 File Offset: 0x00002F77
		public double e
		{
			get
			{
				return this._e;
			}
			set
			{
				this._e = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00004D80 File Offset: 0x00002F80
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00004D88 File Offset: 0x00002F88
		public double n
		{
			get
			{
				return this._n;
			}
			set
			{
				this._n = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00004D91 File Offset: 0x00002F91
		// (set) Token: 0x0600006F RID: 111 RVA: 0x00004D99 File Offset: 0x00002F99
		public double hghtE
		{
			get
			{
				return this._hghtE;
			}
			set
			{
				this._hghtE = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00004DA2 File Offset: 0x00002FA2
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00004DAA File Offset: 0x00002FAA
		public double hghthO
		{
			get
			{
				return this._hghthO;
			}
			set
			{
				this._hghthO = value;
			}
		}

		// Token: 0x04000041 RID: 65
		private double _e = double.MinValue;

		// Token: 0x04000042 RID: 66
		private double _n = double.MinValue;

		// Token: 0x04000043 RID: 67
		private double _hghtE = double.MinValue;

		// Token: 0x04000044 RID: 68
		private double _hghthO = double.MinValue;
	}
}
