using System;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x0200000A RID: 10
	public class HeXML_Point_Coordinates_Cartesian
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00004C74 File Offset: 0x00002E74
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00004C7C File Offset: 0x00002E7C
		public double x
		{
			get
			{
				return this._x;
			}
			set
			{
				this._x = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00004C85 File Offset: 0x00002E85
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00004C8D File Offset: 0x00002E8D
		public double y
		{
			get
			{
				return this._y;
			}
			set
			{
				this._y = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00004C96 File Offset: 0x00002E96
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00004C9E File Offset: 0x00002E9E
		public double z
		{
			get
			{
				return this._z;
			}
			set
			{
				this._z = value;
			}
		}

		// Token: 0x0400003A RID: 58
		private double _x = double.MinValue;

		// Token: 0x0400003B RID: 59
		private double _y = double.MinValue;

		// Token: 0x0400003C RID: 60
		private double _z = double.MinValue;
	}
}
