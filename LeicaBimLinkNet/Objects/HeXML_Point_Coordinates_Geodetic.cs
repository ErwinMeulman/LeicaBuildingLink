using System;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x0200000B RID: 11
	public class HeXML_Point_Coordinates_Geodetic
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00004CDC File Offset: 0x00002EDC
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00004CE4 File Offset: 0x00002EE4
		public double lat
		{
			get
			{
				return this._lat;
			}
			set
			{
				this._lat = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00004CED File Offset: 0x00002EED
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00004CF5 File Offset: 0x00002EF5
		public double lon
		{
			get
			{
				return this._lon;
			}
			set
			{
				this._lon = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00004CFE File Offset: 0x00002EFE
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00004D06 File Offset: 0x00002F06
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

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00004D0F File Offset: 0x00002F0F
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00004D17 File Offset: 0x00002F17
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

		// Token: 0x0400003D RID: 61
		private double _lat = double.MinValue;

		// Token: 0x0400003E RID: 62
		private double _lon = double.MinValue;

		// Token: 0x0400003F RID: 63
		private double _hghtE = double.MinValue;

		// Token: 0x04000040 RID: 64
		private double _hghthO = double.MinValue;
	}
}
