using System;
using System.Collections.Generic;
using System.Data;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000009 RID: 9
	public class HeXML_Point : HeXML_Object
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00004ABE File Offset: 0x00002CBE
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00004AC6 File Offset: 0x00002CC6
		public DataSet Content { get; set; }

		// Token: 0x0600002B RID: 43 RVA: 0x00004ACF File Offset: 0x00002CCF
		public HeXML_Point()
		{
			base.Description_Name = "Point";
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00004AED File Offset: 0x00002CED
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00004AF5 File Offset: 0x00002CF5
		public string UniqueID { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00004AFE File Offset: 0x00002CFE
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00004B06 File Offset: 0x00002D06
		public string Class { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00004B0F File Offset: 0x00002D0F
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00004B17 File Offset: 0x00002D17
		public string Subclass { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00004B20 File Offset: 0x00002D20
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00004B28 File Offset: 0x00002D28
		public string LineworkFlag { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00004B31 File Offset: 0x00002D31
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00004B39 File Offset: 0x00002D39
		public string OriginalCoordSysKind { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00004B42 File Offset: 0x00002D42
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00004B4A File Offset: 0x00002D4A
		public string OriginalGeodeticDatumKind { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00004B53 File Offset: 0x00002D53
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00004B5B File Offset: 0x00002D5B
		public string OriginalHeightKind { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00004B64 File Offset: 0x00002D64
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00004B6C File Offset: 0x00002D6C
		public HeXML_Point_Coordinates_Cartesian Coordinate_WGS84_Cartesian
		{
			get
			{
				return this._Coordinate_WGS84_Cartesian;
			}
			set
			{
				this._Coordinate_WGS84_Cartesian = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00004B75 File Offset: 0x00002D75
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00004B7D File Offset: 0x00002D7D
		public HeXML_Point_Coordinates_Geodetic Coordinate_WGS84_Geodetic
		{
			get
			{
				return this._Coordinate_WGS84_Geodetic;
			}
			set
			{
				this._Coordinate_WGS84_Geodetic = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00004B86 File Offset: 0x00002D86
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00004B8E File Offset: 0x00002D8E
		public HeXML_Point_Coordinates_Cartesian Coordinate_Local_Cartesian
		{
			get
			{
				return this._Coordinate_Local_Cartesian;
			}
			set
			{
				this._Coordinate_Local_Cartesian = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00004B97 File Offset: 0x00002D97
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00004B9F File Offset: 0x00002D9F
		public HeXML_Point_Coordinates_Geodetic Coordinate_Local_Geodetic
		{
			get
			{
				return this._Coordinate_Local_Geodetic;
			}
			set
			{
				this._Coordinate_Local_Geodetic = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00004BA8 File Offset: 0x00002DA8
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00004BB0 File Offset: 0x00002DB0
		public HeXML_Point_Coordinates_Grid Coordinate_Local_Grid
		{
			get
			{
				return this._Coordinate_Local_Grid;
			}
			set
			{
				this._Coordinate_Local_Grid = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00004BB9 File Offset: 0x00002DB9
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00004BC1 File Offset: 0x00002DC1
		public string PointCode { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00004BCA File Offset: 0x00002DCA
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00004BD2 File Offset: 0x00002DD2
		public string PointCodeDesc { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00004BDB File Offset: 0x00002DDB
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00004BE3 File Offset: 0x00002DE3
		public string PointCodeInformation { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00004BEC File Offset: 0x00002DEC
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00004BF4 File Offset: 0x00002DF4
		public string PointCodeColor { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00004BFD File Offset: 0x00002DFD
		// (set) Token: 0x0600004D RID: 77 RVA: 0x00004C05 File Offset: 0x00002E05
		public string PointCodeGroup { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00004C0E File Offset: 0x00002E0E
		// (set) Token: 0x0600004F RID: 79 RVA: 0x00004C16 File Offset: 0x00002E16
		public string PointCodeLinework { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00004C1F File Offset: 0x00002E1F
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00004C27 File Offset: 0x00002E27
		public string OnboardImages { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00004C30 File Offset: 0x00002E30
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00004C38 File Offset: 0x00002E38
		public string Annotation1 { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00004C41 File Offset: 0x00002E41
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00004C49 File Offset: 0x00002E49
		public string Annotation2 { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00004C52 File Offset: 0x00002E52
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00004C5A File Offset: 0x00002E5A
		public string Annotation3 { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00004C63 File Offset: 0x00002E63
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00004C6B File Offset: 0x00002E6B
		public string Annotation4 { get; set; }

		// Token: 0x04000029 RID: 41
		private HeXML_Point_Coordinates_Cartesian _Coordinate_WGS84_Cartesian;

		// Token: 0x0400002A RID: 42
		private HeXML_Point_Coordinates_Geodetic _Coordinate_WGS84_Geodetic;

		// Token: 0x0400002B RID: 43
		private HeXML_Point_Coordinates_Cartesian _Coordinate_Local_Cartesian;

		// Token: 0x0400002C RID: 44
		private HeXML_Point_Coordinates_Geodetic _Coordinate_Local_Geodetic;

		// Token: 0x0400002D RID: 45
		private HeXML_Point_Coordinates_Grid _Coordinate_Local_Grid;

		// Token: 0x04000034 RID: 52
		public List<string> ListPointCodeAttributes = new List<string>();
	}
}
