using System;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000012 RID: 18
	public class LandXML_Header
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00005158 File Offset: 0x00003358
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00005160 File Offset: 0x00003360
		public string Units_linearUnit { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00005169 File Offset: 0x00003369
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00005171 File Offset: 0x00003371
		public string Units_areaUnit { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000087 RID: 135 RVA: 0x0000517A File Offset: 0x0000337A
		// (set) Token: 0x06000088 RID: 136 RVA: 0x00005182 File Offset: 0x00003382
		public string Units_volumeUnit { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000089 RID: 137 RVA: 0x0000518B File Offset: 0x0000338B
		// (set) Token: 0x0600008A RID: 138 RVA: 0x00005193 File Offset: 0x00003393
		public string Units_angularUnit { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600008B RID: 139 RVA: 0x0000519C File Offset: 0x0000339C
		// (set) Token: 0x0600008C RID: 140 RVA: 0x000051A4 File Offset: 0x000033A4
		public string Units_latLongAngularUnit { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000051AD File Offset: 0x000033AD
		// (set) Token: 0x0600008E RID: 142 RVA: 0x000051B5 File Offset: 0x000033B5
		public string Units_temperatureUnit { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600008F RID: 143 RVA: 0x000051BE File Offset: 0x000033BE
		// (set) Token: 0x06000090 RID: 144 RVA: 0x000051C6 File Offset: 0x000033C6
		public string Units_pressureUnit { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000091 RID: 145 RVA: 0x000051CF File Offset: 0x000033CF
		// (set) Token: 0x06000092 RID: 146 RVA: 0x000051D7 File Offset: 0x000033D7
		public string Units_directionUnit { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000093 RID: 147 RVA: 0x000051E0 File Offset: 0x000033E0
		// (set) Token: 0x06000094 RID: 148 RVA: 0x000051E8 File Offset: 0x000033E8
		public string CoordinateSystem_name { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000095 RID: 149 RVA: 0x000051F1 File Offset: 0x000033F1
		// (set) Token: 0x06000096 RID: 150 RVA: 0x000051F9 File Offset: 0x000033F9
		public string CoordinateSystem_horizontalDatum { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00005202 File Offset: 0x00003402
		// (set) Token: 0x06000098 RID: 152 RVA: 0x0000520A File Offset: 0x0000340A
		public string CoordinateSystem_verticalDatum { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00005213 File Offset: 0x00003413
		// (set) Token: 0x0600009A RID: 154 RVA: 0x0000521B File Offset: 0x0000341B
		public string CoordinateSystem_ellipsoidName { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00005224 File Offset: 0x00003424
		// (set) Token: 0x0600009C RID: 156 RVA: 0x0000522C File Offset: 0x0000342C
		public string CoordinateSystem_projectedCoordinateSystemName { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00005235 File Offset: 0x00003435
		// (set) Token: 0x0600009E RID: 158 RVA: 0x0000523D File Offset: 0x0000343D
		public string CoordinateSystem_fileLocation { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00005246 File Offset: 0x00003446
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x0000524E File Offset: 0x0000344E
		public string Application_name
		{
			get
			{
				return this._application_Name;
			}
			set
			{
				this._application_Name = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00005257 File Offset: 0x00003457
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x0000525F File Offset: 0x0000345F
		public string Application_desc { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00005268 File Offset: 0x00003468
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00005270 File Offset: 0x00003470
		public string Application_manufacturer
		{
			get
			{
				return this._application_manufacturer;
			}
			set
			{
				this._application_manufacturer = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00005279 File Offset: 0x00003479
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00005281 File Offset: 0x00003481
		public string Application_version { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x0000528A File Offset: 0x0000348A
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x00005292 File Offset: 0x00003492
		public string Application_manufacturerURL
		{
			get
			{
				return this._application_manufacturerURL;
			}
			set
			{
				this._application_manufacturerURL = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x0000529B File Offset: 0x0000349B
		// (set) Token: 0x060000AA RID: 170 RVA: 0x000052A3 File Offset: 0x000034A3
		public string Author_company
		{
			get
			{
				return this._Author_company;
			}
			set
			{
				this._Author_company = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000AB RID: 171 RVA: 0x000052AC File Offset: 0x000034AC
		// (set) Token: 0x060000AC RID: 172 RVA: 0x000052B4 File Offset: 0x000034B4
		public string Author_companyURL
		{
			get
			{
				return this._Author_companyURL;
			}
			set
			{
				this._Author_companyURL = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000AD RID: 173 RVA: 0x000052BD File Offset: 0x000034BD
		// (set) Token: 0x060000AE RID: 174 RVA: 0x000052C5 File Offset: 0x000034C5
		public string Author_timeStamp { get; set; }

		// Token: 0x0400009B RID: 155
		private string _application_Name = "Leica BIM Link";

		// Token: 0x0400009D RID: 157
		private string _application_manufacturer = "Leica Geosystems AG";

		// Token: 0x0400009F RID: 159
		private string _application_manufacturerURL = "www.leica-geosystems.com";

		// Token: 0x040000A0 RID: 160
		private string _Author_company = "Leica Geosystems AG";

		// Token: 0x040000A1 RID: 161
		private string _Author_companyURL = "www.leica-geosystems.com";
	}
}
