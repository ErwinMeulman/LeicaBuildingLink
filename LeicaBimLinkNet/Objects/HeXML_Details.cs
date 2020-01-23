using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;

namespace LeicaBimLinkNet.Objects
{
	// Token: 0x02000005 RID: 5
	public class HeXML_Details
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020BF File Offset: 0x000002BF
		public double Point_Max_n
		{
			get
			{
				return this._Point_Max_n;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020C7 File Offset: 0x000002C7
		public double Point_Min_n
		{
			get
			{
				return this._Point_Min_n;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020CF File Offset: 0x000002CF
		public double Point_Max_e
		{
			get
			{
				return this._Point_Max_e;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020D7 File Offset: 0x000002D7
		public double Point_Min_e
		{
			get
			{
				return this._Point_Min_e;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020DF File Offset: 0x000002DF
		public double Point_Max_hghgthO
		{
			get
			{
				return this._Point_Max_hghgthO;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000020E7 File Offset: 0x000002E7
		public double Point_Min_hghgthO
		{
			get
			{
				return this._Point_Min_hghgthO;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000020EF File Offset: 0x000002EF
		public double Point_Max_hghtE
		{
			get
			{
				return this._Point_Max_hghtE;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000020F7 File Offset: 0x000002F7
		public double Point_Min_hghtE
		{
			get
			{
				return this._Point_Min_hghtE;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000020FF File Offset: 0x000002FF
		// (set) Token: 0x06000013 RID: 19 RVA: 0x00002107 File Offset: 0x00000307
		public HeXML_Details.UnitConverter UConverter
		{
			get
			{
				return this._UnitConverter;
			}
			set
			{
				this._UnitConverter = value;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002110 File Offset: 0x00000310
		public HeXML_Details(HeXML_Details.UnitConverter UnitConverter)
		{
			this._UnitConverter = UnitConverter;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002238 File Offset: 0x00000438
		public void Detect_Details(List<object> List_HeXMLObjects, List<string> ListExisting_UniqueIDs)
		{
			this.Clear();
			this.List_HeXML_Objects = List_HeXMLObjects;
			this.List_Existing_UniqueIDs = ListExisting_UniqueIDs;
			if (this.List_HeXML_Objects != null)
			{
				for (int i = 0; i < this.List_HeXML_Objects.Count; i++)
				{
					Type type = this.List_HeXML_Objects[i].GetType();
					if (type == typeof(HeXML_Alignment))
					{
						this.List_HeXML_Alignment_Index.Add(i);
					}
					else if (type == typeof(HeXML_Area))
					{
						this.List_HeXML_Area_Index.Add(i);
					}
					else if (type == typeof(HeXML_Corridor))
					{
						this.List_HeXML_Corridor_Index.Add(i);
					}
					else if (type == typeof(HeXML_Gradient))
					{
						this.List_HeXML_Gradient_Index.Add(i);
					}
					else if (type == typeof(HeXML_Line))
					{
						this.List_HeXML_Line_Index.Add(i);
					}
					else if (type == typeof(HeXML_Point))
					{
						bool flag = false;
						HeXML_Point heXML_Point = (HeXML_Point)this.List_HeXML_Objects[i];
						if (heXML_Point.OriginalHeightKind == "ellipsoidal")
						{
							if (heXML_Point.Coordinate_Local_Grid == null || heXML_Point.Coordinate_Local_Grid.e == -1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.e == 1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.n == -1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.n == 1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.hghtE == -1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.hghtE == 1.7976931348623157E+308)
							{
								this.List_HeXML_Point_Index_Fail.Add(i);
								this.List_HeXML_Point_ErrorMessage.Add("The coordinates could not be determined");
								flag = true;
							}
						}
						else if (heXML_Point.OriginalHeightKind == "undefined")
						{
							if (heXML_Point.Coordinate_Local_Grid == null || heXML_Point.Coordinate_Local_Grid.e == -1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.e == 1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.n == -1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.n == 1.7976931348623157E+308)
							{
								this.List_HeXML_Point_Index_Fail.Add(i);
								this.List_HeXML_Point_ErrorMessage.Add("The coordinates could not be determined");
								flag = true;
							}
						}
						else if (heXML_Point.Coordinate_Local_Grid == null || heXML_Point.Coordinate_Local_Grid.e == -1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.e == 1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.n == -1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.n == 1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.hghthO == -1.7976931348623157E+308 || heXML_Point.Coordinate_Local_Grid.hghthO == 1.7976931348623157E+308)
						{
							this.List_HeXML_Point_Index_Fail.Add(i);
							this.List_HeXML_Point_ErrorMessage.Add("The coordinates could not be determined");
							flag = true;
						}
						if (!flag && ListExisting_UniqueIDs.Contains(heXML_Point.UniqueID))
						{
							this.List_HeXML_Point_Index_Fail.Add(i);
							this.List_HeXML_Point_ErrorMessage.Add("The uniqueID \"" + heXML_Point.UniqueID + "\" is already existing");
							flag = true;
						}
						if (!flag)
						{
							this.List_HeXML_Point_Index.Add(i);
							this.List_Existing_UniqueIDs.Add(heXML_Point.UniqueID);
						}
					}
					else if (type == typeof(HeXML_PointGroup))
					{
						this.List_HeXML_PointGroup_Index.Add(i);
					}
					else if (type == typeof(HeXML_Surface))
					{
						this.List_HeXML_Surface_Index.Add(i);
					}
					else if (type == typeof(HeXML_Survey))
					{
						this.List_HeXML_Survey_Index.Add(i);
					}
				}
			}
			if (this.List_HeXML_Point_Index.Count != 0)
			{
				foreach (int index in this.List_HeXML_Point_Index)
				{
					HeXML_Point heXML_Point2 = (HeXML_Point)List_HeXMLObjects[index];
					double num = this.Math_Unit(heXML_Point2.Coordinate_Local_Grid.n);
					if (num > this._Point_Max_n)
					{
						this._Point_Max_n = num;
					}
					if (num < this._Point_Min_n)
					{
						this._Point_Min_n = num;
					}
					double num2 = this.Math_Unit(heXML_Point2.Coordinate_Local_Grid.e);
					if (num2 > this._Point_Max_e)
					{
						this._Point_Max_e = num2;
					}
					if (num2 < this._Point_Min_e)
					{
						this._Point_Min_e = num2;
					}
					double num3 = this.Math_Unit(heXML_Point2.Coordinate_Local_Grid.hghthO);
					if (num3 > this._Point_Max_hghgthO)
					{
						this._Point_Max_hghgthO = num3;
					}
					if (num3 < this._Point_Min_hghgthO)
					{
						this._Point_Min_hghgthO = num3;
					}
					double num4 = this.Math_Unit(heXML_Point2.Coordinate_Local_Grid.hghtE);
					if (num4 > this._Point_Max_hghtE)
					{
						this._Point_Max_hghtE = num4;
					}
					if (num4 < this._Point_Min_hghtE)
					{
						this._Point_Min_hghtE = num4;
					}
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002790 File Offset: 0x00000990
		public void Clear()
		{
			this.List_HeXML_Objects = new List<object>();
			this.List_HeXML_Alignment_Index = new List<int>();
			this.List_HeXML_Area_Index = new List<int>();
			this.List_HeXML_Corridor_Index = new List<int>();
			this.List_HeXML_Gradient_Index = new List<int>();
			this.List_HeXML_Line_Index = new List<int>();
			this.List_HeXML_Point_Index = new List<int>();
			this.List_HeXML_PointGroup_Index = new List<int>();
			this.List_HeXML_Surface_Index = new List<int>();
			this.List_HeXML_Survey_Index = new List<int>();
			this._Point_Max_n = double.MinValue;
			this._Point_Min_n = double.MaxValue;
			this._Point_Max_e = double.MinValue;
			this._Point_Min_e = double.MaxValue;
			this._Point_Max_hghgthO = double.MinValue;
			this._Point_Min_hghgthO = double.MaxValue;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002868 File Offset: 0x00000A68
		public List<HeXML_Point> Get_HeXMLPoints()
		{
			List<HeXML_Point> list = new List<HeXML_Point>();
			foreach (int index in this.List_HeXML_Point_Index)
			{
				if (this._UnitConverter == HeXML_Details.UnitConverter.None)
				{
					list.Add((HeXML_Point)this.List_HeXML_Objects[index]);
				}
				else
				{
					HeXML_Point heXML_Point = (HeXML_Point)this.List_HeXML_Objects[index];
					HeXML_Point heXML_Point2 = new HeXML_Point();
					heXML_Point2.Additional_Description = heXML_Point.Additional_Description;
					heXML_Point2.Annotation1 = heXML_Point.Annotation1;
					heXML_Point2.Annotation2 = heXML_Point.Annotation2;
					heXML_Point2.Annotation3 = heXML_Point.Annotation3;
					heXML_Point2.Annotation4 = heXML_Point.Annotation4;
					heXML_Point2.Class = heXML_Point.Class;
					heXML_Point2.Content = heXML_Point.Content;
					heXML_Point2.Coordinate_Local_Cartesian = heXML_Point.Coordinate_Local_Cartesian;
					heXML_Point2.Coordinate_Local_Geodetic = heXML_Point.Coordinate_Local_Geodetic;
					heXML_Point2.Coordinate_Local_Grid = new HeXML_Point_Coordinates_Grid();
					heXML_Point2.Coordinate_Local_Grid.e = this.Math_Unit(heXML_Point.Coordinate_Local_Grid.e);
					heXML_Point2.Coordinate_Local_Grid.hghtE = this.Math_Unit(heXML_Point.Coordinate_Local_Grid.hghtE);
					heXML_Point2.Coordinate_Local_Grid.hghthO = this.Math_Unit(heXML_Point.Coordinate_Local_Grid.hghthO);
					heXML_Point2.Coordinate_Local_Grid.n = this.Math_Unit(heXML_Point.Coordinate_Local_Grid.n);
					heXML_Point2.Coordinate_WGS84_Cartesian = heXML_Point.Coordinate_WGS84_Cartesian;
					heXML_Point2.Coordinate_WGS84_Geodetic = heXML_Point.Coordinate_WGS84_Geodetic;
					heXML_Point2.Description_Name = heXML_Point.Description_Name;
					heXML_Point2.LineworkFlag = heXML_Point.LineworkFlag;
					heXML_Point2.OnboardImages = heXML_Point.OnboardImages;
					heXML_Point2.OriginalCoordSysKind = heXML_Point.OriginalCoordSysKind;
					heXML_Point2.OriginalGeodeticDatumKind = heXML_Point.OriginalGeodeticDatumKind;
					heXML_Point2.OriginalHeightKind = heXML_Point.OriginalHeightKind;
					heXML_Point2.PointCode = heXML_Point.PointCode;
					heXML_Point2.ListPointCodeAttributes = new List<string>();
					foreach (string item in heXML_Point.ListPointCodeAttributes)
					{
						heXML_Point2.ListPointCodeAttributes.Add(item);
					}
					heXML_Point2.PointCodeColor = heXML_Point.PointCodeColor;
					heXML_Point2.PointCodeDesc = heXML_Point.PointCodeDesc;
					heXML_Point2.PointCodeGroup = heXML_Point.PointCodeGroup;
					heXML_Point2.PointCodeInformation = heXML_Point.PointCodeInformation;
					heXML_Point2.PointCodeLinework = heXML_Point.PointCodeLinework;
					heXML_Point2.Subclass = heXML_Point.Subclass;
					heXML_Point2.UniqueID = heXML_Point.UniqueID;
					list.Add(heXML_Point2);
				}
			}
			return list;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002B3C File Offset: 0x00000D3C
		public List<string> Get_Protocol(string Title)
		{
			NumberFormatInfo numberFormat = new CultureInfo("de-DE", false).NumberFormat;
			numberFormat.NumberDecimalSeparator = ".";
			List<string> list = new List<string>();
			list.Add(Title);
			if (this.List_HeXML_Objects.Count != 0)
			{
				list.Add("");
				list.Add("");
				if (this.List_HeXML_Alignment_Index.Count != 0)
				{
					list.Add("Alignments:");
					list.Add("\tNumber:\t\t\t" + this.List_HeXML_Alignment_Index.Count.ToString());
					list.Add("");
				}
				if (this.List_HeXML_Area_Index.Count != 0)
				{
					list.Add("Areas: ");
					list.Add("\tNumber:\t\t\t" + this.List_HeXML_Area_Index.Count.ToString());
					list.Add("");
				}
				if (this.List_HeXML_Corridor_Index.Count != 0)
				{
					list.Add("Corridors: ");
					list.Add("\tNumber:\t\t\t" + this.List_HeXML_Corridor_Index.Count.ToString());
					list.Add("");
				}
				if (this.List_HeXML_Gradient_Index.Count != 0)
				{
					list.Add("Gradients: ");
					list.Add("\tNumber:\t\t\t" + this.List_HeXML_Gradient_Index.Count.ToString());
					list.Add("");
				}
				if (this.List_HeXML_Line_Index.Count != 0)
				{
					list.Add("Lines: ");
					list.Add("\tNumber:\t\t\t" + this.List_HeXML_Line_Index.Count.ToString());
					list.Add("");
				}
				if (this.List_HeXML_Point_Index.Count != 0)
				{
					list.Add("Points:");
					list.Add("\tNumber:\t\t\t" + this.List_HeXML_Point_Index.Count.ToString());
					list.Add("\tMaximum (n):\t\t" + Math.Round(this.Point_Max_n, 3).ToString(numberFormat));
					list.Add("\tMinimum (n):\t\t" + Math.Round(this.Point_Min_n, 3).ToString(numberFormat));
					list.Add("\tMaximum (e):\t\t" + Math.Round(this.Point_Max_e, 3).ToString(numberFormat));
					list.Add("\tMinimum (e):\t\t" + Math.Round(this.Point_Min_e, 3).ToString(numberFormat));
					list.Add("\tMaximum (hghthO):\t\t" + Math.Round(this.Point_Max_hghgthO, 3).ToString(numberFormat));
					list.Add("\tMinimum (hghthO):\t\t" + Math.Round(this.Point_Min_hghgthO, 3).ToString(numberFormat));
					list.Add("\tMaximum (hghtE):\t\t" + Math.Round(this.Point_Max_hghtE, 3).ToString(numberFormat));
					list.Add("\tMinimum (hghtE):\t\t" + Math.Round(this.Point_Min_hghtE, 3).ToString(numberFormat));
					list.Add("");
				}
				if (this.List_HeXML_Point_Index_Fail.Count != 0)
				{
					list.Add("Points with errors:");
					list.Add("\tNumber:\t\t\t" + this.List_HeXML_Point_Index_Fail.Count.ToString());
					List<string> list2 = new List<string>();
					foreach (string item in this.List_HeXML_Point_ErrorMessage)
					{
						if (!list2.Contains(item))
						{
							list2.Add(item);
						}
					}
					for (int i = 0; i < list2.Count; i++)
					{
						if (i == 0)
						{
							list.Add("\tErrors:\t" + list2[i]);
						}
						else
						{
							list.Add("\t\t" + list2[i]);
						}
					}
					list.Add("");
				}
				if (this.List_HeXML_PointGroup_Index.Count != 0)
				{
					list.Add("Point groups: ");
					list.Add("\tNumber:\t\t\t" + this.List_HeXML_PointGroup_Index.Count.ToString());
					list.Add("");
				}
				if (this.List_HeXML_Surface_Index.Count != 0)
				{
					list.Add("Surfaces: ");
					list.Add("\tNumber:\t\t\t" + this.List_HeXML_Surface_Index.Count.ToString());
					list.Add("");
				}
				if (this.List_HeXML_Survey_Index.Count != 0)
				{
					list.Add("Surveys: ");
					list.Add("\tNumber:\t\t\t" + this.List_HeXML_Survey_Index.Count.ToString());
					list.Add("");
				}
			}
			return list;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003030 File Offset: 0x00001230
		public bool Write_CSV(string FileName)
		{
			NumberFormatInfo numberFormat = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name, false).NumberFormat;
			if (Thread.CurrentThread.CurrentCulture.Name == "de-DE")
			{
				numberFormat.NumberDecimalSeparator = ",";
			}
			else
			{
				numberFormat.NumberDecimalSeparator = ".";
			}
			bool result = false;
			try
			{
				if (this.List_HeXML_Objects.Count != 0)
				{
					StreamWriter streamWriter = new StreamWriter(FileName);
					if (this.List_HeXML_Alignment_Index.Count != 0)
					{
						streamWriter.WriteLine("Alignments");
						streamWriter.WriteLine("Number:;" + this.List_HeXML_Alignment_Index.Count.ToString());
						streamWriter.WriteLine("");
					}
					if (this.List_HeXML_Area_Index.Count != 0)
					{
						streamWriter.WriteLine("Areas");
						streamWriter.WriteLine("Number:;" + this.List_HeXML_Area_Index.Count.ToString());
						streamWriter.WriteLine("");
					}
					if (this.List_HeXML_Corridor_Index.Count != 0)
					{
						streamWriter.WriteLine("Corridors");
						streamWriter.WriteLine("Number:;" + this.List_HeXML_Corridor_Index.Count.ToString());
						streamWriter.WriteLine("");
					}
					if (this.List_HeXML_Gradient_Index.Count != 0)
					{
						streamWriter.WriteLine("Gradients");
						streamWriter.WriteLine("Number:;" + this.List_HeXML_Gradient_Index.Count.ToString());
						streamWriter.WriteLine("");
					}
					if (this.List_HeXML_Line_Index.Count != 0)
					{
						streamWriter.WriteLine("Lines");
						streamWriter.WriteLine("Number:;" + this.List_HeXML_Line_Index.Count.ToString());
						streamWriter.WriteLine("");
					}
					if (this.List_HeXML_Point_Index.Count != 0)
					{
						streamWriter.WriteLine("Points");
						streamWriter.WriteLine("Number:;" + this.List_HeXML_Point_Index.Count.ToString());
						streamWriter.WriteLine("Maximum (n):;" + this.Point_Max_n.ToString(numberFormat));
						streamWriter.WriteLine("Minimum (n):;" + this.Point_Min_n.ToString(numberFormat));
						streamWriter.WriteLine("Maximum (e):;" + this.Point_Max_e.ToString(numberFormat));
						streamWriter.WriteLine("Minimum (e):;" + this.Point_Min_e.ToString(numberFormat));
						streamWriter.WriteLine("Maximum (hghthO):;" + this.Point_Max_hghgthO.ToString(numberFormat));
						streamWriter.WriteLine("Minimum (hghthO):;" + this.Point_Min_hghgthO.ToString(numberFormat));
						streamWriter.WriteLine("Maximum (hghtE):;" + this.Point_Max_hghtE.ToString(numberFormat));
						streamWriter.WriteLine("Minimum (hghtE):;" + this.Point_Min_hghtE.ToString(numberFormat));
						streamWriter.WriteLine("");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_UniqueID + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_Class + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_SubClass + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LineworkFlag + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_OriginalCoordSysKind + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_OriginalGeodeticDatumKind + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_OriginalHeightKind + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_x + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_y + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_z + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_lat + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_lon + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_hghtO + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_hghtE + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_x + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_y + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_z + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_lat + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_lon + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_hghtO + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_hghtE + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_hghtE + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e_converted + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n_converted + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO_converted + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_hghtE_converted + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCode + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeDesc + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeInformation + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeColor + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeGroup + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeLinework + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeAttributes + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_OnboardImages + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_Annotation1 + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_Annotation2 + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_Annotation3 + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_Annotation4);
						streamWriter.WriteLine("");
						foreach (int index in this.List_HeXML_Point_Index)
						{
							HeXML_Point heXML_Point = (HeXML_Point)this.List_HeXML_Objects[index];
							if (heXML_Point.UniqueID != null)
							{
								streamWriter.Write(heXML_Point.UniqueID);
							}
							streamWriter.Write(";");
							if (heXML_Point.Class != null)
							{
								streamWriter.Write(heXML_Point.Class);
							}
							streamWriter.Write(";");
							if (heXML_Point.Subclass != null)
							{
								streamWriter.Write(heXML_Point.Subclass);
							}
							streamWriter.Write(";");
							if (heXML_Point.LineworkFlag != null)
							{
								streamWriter.Write(heXML_Point.LineworkFlag);
							}
							streamWriter.Write(";");
							if (heXML_Point.OriginalCoordSysKind != null)
							{
								streamWriter.Write(heXML_Point.OriginalCoordSysKind);
							}
							streamWriter.Write(";");
							if (heXML_Point.OriginalGeodeticDatumKind != null)
							{
								streamWriter.Write(heXML_Point.OriginalGeodeticDatumKind);
							}
							streamWriter.Write(";");
							if (heXML_Point.OriginalHeightKind != null)
							{
								streamWriter.Write(heXML_Point.OriginalHeightKind);
							}
							streamWriter.Write(";");
							if (heXML_Point.Coordinate_WGS84_Cartesian != null)
							{
								streamWriter.Write(heXML_Point.Coordinate_WGS84_Cartesian.x.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_WGS84_Cartesian.y.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_WGS84_Cartesian.z.ToString(numberFormat) + ";");
							}
							else
							{
								streamWriter.Write(";;;");
							}
							if (heXML_Point.Coordinate_WGS84_Geodetic != null)
							{
								streamWriter.Write(heXML_Point.Coordinate_WGS84_Geodetic.lat.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_WGS84_Geodetic.lon.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_WGS84_Geodetic.hghthO.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_WGS84_Geodetic.hghtE.ToString(numberFormat) + ";");
							}
							else
							{
								streamWriter.Write(";;;;");
							}
							if (heXML_Point.Coordinate_Local_Cartesian != null)
							{
								streamWriter.Write(heXML_Point.Coordinate_Local_Cartesian.x.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_Local_Cartesian.y.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_Local_Cartesian.z.ToString(numberFormat) + ";");
							}
							else
							{
								streamWriter.Write(";;;");
							}
							if (heXML_Point.Coordinate_Local_Geodetic != null)
							{
								streamWriter.Write(heXML_Point.Coordinate_Local_Geodetic.lat.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_Local_Geodetic.lon.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_Local_Geodetic.hghthO.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_Local_Geodetic.hghtE.ToString(numberFormat) + ";");
							}
							else
							{
								streamWriter.Write(";;;;");
							}
							if (heXML_Point.Coordinate_Local_Grid != null)
							{
								streamWriter.Write(heXML_Point.Coordinate_Local_Grid.e.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_Local_Grid.n.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_Local_Grid.hghthO.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point.Coordinate_Local_Grid.hghtE.ToString(numberFormat) + ";");
								streamWriter.Write(this.Math_Unit(heXML_Point.Coordinate_Local_Grid.e).ToString(numberFormat) + ";");
								streamWriter.Write(this.Math_Unit(heXML_Point.Coordinate_Local_Grid.n).ToString(numberFormat) + ";");
								streamWriter.Write(this.Math_Unit(heXML_Point.Coordinate_Local_Grid.hghthO).ToString(numberFormat) + ";");
								streamWriter.Write(this.Math_Unit(heXML_Point.Coordinate_Local_Grid.hghtE).ToString(numberFormat) + ";");
							}
							else
							{
								streamWriter.Write(";;;;;;;;");
							}
							if (heXML_Point.PointCode != null)
							{
								streamWriter.Write(heXML_Point.PointCode);
							}
							streamWriter.Write(";");
							if (heXML_Point.PointCodeDesc != null)
							{
								streamWriter.Write(heXML_Point.PointCodeDesc);
							}
							streamWriter.Write(";");
							if (heXML_Point.PointCodeInformation != null)
							{
								streamWriter.Write(heXML_Point.PointCodeInformation);
							}
							streamWriter.Write(";");
							if (heXML_Point.PointCodeColor != null)
							{
								streamWriter.Write(heXML_Point.PointCodeColor);
							}
							streamWriter.Write(";");
							if (heXML_Point.PointCodeGroup != null)
							{
								streamWriter.Write(heXML_Point.PointCodeGroup);
							}
							streamWriter.Write(";");
							if (heXML_Point.PointCodeLinework != null)
							{
								streamWriter.Write(heXML_Point.PointCodeLinework);
							}
							streamWriter.Write(";");
							for (int i = 0; i < heXML_Point.ListPointCodeAttributes.Count; i++)
							{
								string text = heXML_Point.ListPointCodeAttributes[i];
								if (i < heXML_Point.ListPointCodeAttributes.Count - 1)
								{
									text += ", ";
								}
								streamWriter.Write(text);
							}
							streamWriter.Write(";");
							if (heXML_Point.OnboardImages != null)
							{
								streamWriter.Write(heXML_Point.OnboardImages);
							}
							streamWriter.Write(";");
							if (heXML_Point.Annotation1 != null)
							{
								streamWriter.Write(heXML_Point.Annotation1);
							}
							streamWriter.Write(";");
							if (heXML_Point.Annotation2 != null)
							{
								streamWriter.Write(heXML_Point.Annotation2);
							}
							streamWriter.Write(";");
							if (heXML_Point.Annotation3 != null)
							{
								streamWriter.Write(heXML_Point.Annotation3);
							}
							streamWriter.Write(";");
							if (heXML_Point.Annotation4 != null)
							{
								streamWriter.Write(heXML_Point.Annotation4);
							}
							streamWriter.Write(";");
							streamWriter.WriteLine("");
						}
					}
					if (this.List_HeXML_Point_Index_Fail.Count != 0)
					{
						streamWriter.WriteLine("");
						streamWriter.WriteLine("Points with errors:");
						streamWriter.WriteLine("Number:;" + this.List_HeXML_Point_Index_Fail.Count.ToString());
						streamWriter.WriteLine("");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_UniqueID + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_Class + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_SubClass + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LineworkFlag + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_OriginalCoordSysKind + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_OriginalGeodeticDatumKind + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_OriginalHeightKind + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_x + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_y + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_z + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_lat + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_lon + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_hghtO + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_hghtE + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_x + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_y + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_z + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_lat + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_lon + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_hghtO + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_hghtE + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_hghtE + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e_converted + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n_converted + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO_converted + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_LocalGrid_hghtE_converted + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCode + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeDesc + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeInformation + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeColor + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeGroup + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeLinework + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_PointCodeAttributes + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_OnboardImages + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_Annotation1 + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_Annotation2 + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_Annotation3 + ";");
						streamWriter.Write(HeXML_Point_Strings.FamilyParameterName_Annotation4 + ";");
						streamWriter.Write("Error message");
						streamWriter.WriteLine("");
						int num = 0;
						foreach (int index2 in this.List_HeXML_Point_Index_Fail)
						{
							HeXML_Point heXML_Point2 = (HeXML_Point)this.List_HeXML_Objects[index2];
							if (heXML_Point2.UniqueID != null)
							{
								streamWriter.Write(heXML_Point2.UniqueID);
							}
							streamWriter.Write(";");
							if (heXML_Point2.Class != null)
							{
								streamWriter.Write(heXML_Point2.Class);
							}
							streamWriter.Write(";");
							if (heXML_Point2.Subclass != null)
							{
								streamWriter.Write(heXML_Point2.Subclass);
							}
							streamWriter.Write(";");
							if (heXML_Point2.LineworkFlag != null)
							{
								streamWriter.Write(heXML_Point2.LineworkFlag);
							}
							streamWriter.Write(";");
							if (heXML_Point2.OriginalCoordSysKind != null)
							{
								streamWriter.Write(heXML_Point2.OriginalCoordSysKind);
							}
							streamWriter.Write(";");
							if (heXML_Point2.OriginalGeodeticDatumKind != null)
							{
								streamWriter.Write(heXML_Point2.OriginalGeodeticDatumKind);
							}
							streamWriter.Write(";");
							if (heXML_Point2.OriginalHeightKind != null)
							{
								streamWriter.Write(heXML_Point2.OriginalHeightKind);
							}
							streamWriter.Write(";");
							if (heXML_Point2.Coordinate_WGS84_Cartesian != null)
							{
								streamWriter.Write(heXML_Point2.Coordinate_WGS84_Cartesian.x.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_WGS84_Cartesian.y.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_WGS84_Cartesian.z.ToString(numberFormat) + ";");
							}
							else
							{
								streamWriter.Write(";;;");
							}
							if (heXML_Point2.Coordinate_WGS84_Geodetic != null)
							{
								streamWriter.Write(heXML_Point2.Coordinate_WGS84_Geodetic.lat.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_WGS84_Geodetic.lon.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_WGS84_Geodetic.hghthO.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_WGS84_Geodetic.hghtE.ToString(numberFormat) + ";");
							}
							else
							{
								streamWriter.Write(";;;;");
							}
							if (heXML_Point2.Coordinate_Local_Cartesian != null)
							{
								streamWriter.Write(heXML_Point2.Coordinate_Local_Cartesian.x.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_Local_Cartesian.y.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_Local_Cartesian.z.ToString(numberFormat) + ";");
							}
							else
							{
								streamWriter.Write(";;;");
							}
							if (heXML_Point2.Coordinate_Local_Geodetic != null)
							{
								streamWriter.Write(heXML_Point2.Coordinate_Local_Geodetic.lat.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_Local_Geodetic.lon.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_Local_Geodetic.hghthO.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_Local_Geodetic.hghtE.ToString(numberFormat) + ";");
							}
							else
							{
								streamWriter.Write(";;;;");
							}
							if (heXML_Point2.Coordinate_Local_Grid != null)
							{
								streamWriter.Write(heXML_Point2.Coordinate_Local_Grid.e.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_Local_Grid.n.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_Local_Grid.hghthO.ToString(numberFormat) + ";");
								streamWriter.Write(heXML_Point2.Coordinate_Local_Grid.hghtE.ToString(numberFormat) + ";");
								streamWriter.Write(this.Math_Unit(heXML_Point2.Coordinate_Local_Grid.e).ToString(numberFormat) + ";");
								streamWriter.Write(this.Math_Unit(heXML_Point2.Coordinate_Local_Grid.n).ToString(numberFormat) + ";");
								streamWriter.Write(this.Math_Unit(heXML_Point2.Coordinate_Local_Grid.hghthO).ToString(numberFormat) + ";");
								streamWriter.Write(this.Math_Unit(heXML_Point2.Coordinate_Local_Grid.hghtE).ToString(numberFormat) + ";");
							}
							else
							{
								streamWriter.Write(";;;;;;;;");
							}
							if (heXML_Point2.PointCode != null)
							{
								streamWriter.Write(heXML_Point2.PointCode);
							}
							streamWriter.Write(";");
							if (heXML_Point2.PointCodeDesc != null)
							{
								streamWriter.Write(heXML_Point2.PointCodeDesc);
							}
							streamWriter.Write(";");
							if (heXML_Point2.PointCodeInformation != null)
							{
								streamWriter.Write(heXML_Point2.PointCodeInformation);
							}
							streamWriter.Write(";");
							if (heXML_Point2.PointCodeColor != null)
							{
								streamWriter.Write(heXML_Point2.PointCodeColor);
							}
							streamWriter.Write(";");
							if (heXML_Point2.PointCodeGroup != null)
							{
								streamWriter.Write(heXML_Point2.PointCodeGroup);
							}
							streamWriter.Write(";");
							if (heXML_Point2.PointCodeLinework != null)
							{
								streamWriter.Write(heXML_Point2.PointCodeLinework);
							}
							streamWriter.Write(";");
							for (int j = 0; j < heXML_Point2.ListPointCodeAttributes.Count; j++)
							{
								string text2 = heXML_Point2.ListPointCodeAttributes[j];
								if (j < heXML_Point2.ListPointCodeAttributes.Count - 1)
								{
									text2 += ", ";
								}
								streamWriter.Write(text2);
							}
							streamWriter.Write(";");
							if (heXML_Point2.OnboardImages != null)
							{
								streamWriter.Write(heXML_Point2.OnboardImages);
							}
							streamWriter.Write(";");
							if (heXML_Point2.Annotation1 != null)
							{
								streamWriter.Write(heXML_Point2.Annotation1);
							}
							streamWriter.Write(";");
							if (heXML_Point2.Annotation2 != null)
							{
								streamWriter.Write(heXML_Point2.Annotation2);
							}
							streamWriter.Write(";");
							if (heXML_Point2.Annotation3 != null)
							{
								streamWriter.Write(heXML_Point2.Annotation3);
							}
							streamWriter.Write(";");
							if (heXML_Point2.Annotation4 != null)
							{
								streamWriter.Write(heXML_Point2.Annotation4);
							}
							streamWriter.Write(";");
							streamWriter.Write(this.List_HeXML_Point_ErrorMessage[num]);
							streamWriter.Write(";");
							streamWriter.WriteLine("");
							num++;
						}
					}
					if (this.List_HeXML_PointGroup_Index.Count != 0)
					{
						streamWriter.WriteLine("Point groups");
						streamWriter.WriteLine("Number:;" + this.List_HeXML_PointGroup_Index.Count.ToString());
						streamWriter.WriteLine("");
					}
					if (this.List_HeXML_Surface_Index.Count != 0)
					{
						streamWriter.WriteLine("Surfaces");
						streamWriter.WriteLine("Number:;" + this.List_HeXML_Surface_Index.Count.ToString());
						streamWriter.WriteLine("");
					}
					if (this.List_HeXML_Survey_Index.Count != 0)
					{
						streamWriter.WriteLine("Surveys");
						streamWriter.WriteLine("Number:;" + this.List_HeXML_Survey_Index.Count.ToString());
						streamWriter.WriteLine("");
					}
					streamWriter.Close();
				}
				result = true;
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
			return result;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000497C File Offset: 0x00002B7C
		public double Math_Unit(double value)
		{
			if (this._UnitConverter != HeXML_Details.UnitConverter.None && value != -1.7976931348623157E+308 && value != 1.7976931348623157E+308 && value != 0.0)
			{
				value = HeXML_Details.Math_Unit(value, this._UnitConverter);
			}
			return value;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000049BC File Offset: 0x00002BBC
		public static double Math_Unit(double value, HeXML_Details.UnitConverter UnitConverter)
		{
			if (UnitConverter != HeXML_Details.UnitConverter.None && value != -1.7976931348623157E+308 && value != 1.7976931348623157E+308 && value != 0.0)
			{
				double num = 0.3048;
				if (UnitConverter == HeXML_Details.UnitConverter.FeetToMeter)
				{
					value *= num;
				}
				else if (UnitConverter == HeXML_Details.UnitConverter.MeterToFeet)
				{
					value /= num;
				}
			}
			return value;
		}

		// Token: 0x04000005 RID: 5
		public List<object> List_HeXML_Objects = new List<object>();

		// Token: 0x04000006 RID: 6
		public List<string> List_Existing_UniqueIDs = new List<string>();

		// Token: 0x04000007 RID: 7
		public List<int> List_HeXML_Alignment_Index = new List<int>();

		// Token: 0x04000008 RID: 8
		public List<int> List_HeXML_Area_Index = new List<int>();

		// Token: 0x04000009 RID: 9
		public List<int> List_HeXML_Corridor_Index = new List<int>();

		// Token: 0x0400000A RID: 10
		public List<int> List_HeXML_Gradient_Index = new List<int>();

		// Token: 0x0400000B RID: 11
		public List<int> List_HeXML_Line_Index = new List<int>();

		// Token: 0x0400000C RID: 12
		public List<int> List_HeXML_Point_Index = new List<int>();

		// Token: 0x0400000D RID: 13
		public List<int> List_HeXML_Point_Index_Fail = new List<int>();

		// Token: 0x0400000E RID: 14
		public List<string> List_HeXML_Point_ErrorMessage = new List<string>();

		// Token: 0x0400000F RID: 15
		public List<int> List_HeXML_Surface_Index = new List<int>();

		// Token: 0x04000010 RID: 16
		public List<int> List_HeXML_Survey_Index = new List<int>();

		// Token: 0x04000011 RID: 17
		public List<int> List_HeXML_PointGroup_Index = new List<int>();

		// Token: 0x04000012 RID: 18
		private double _Point_Max_n = double.MinValue;

		// Token: 0x04000013 RID: 19
		private double _Point_Min_n = double.MaxValue;

		// Token: 0x04000014 RID: 20
		private double _Point_Max_e = double.MinValue;

		// Token: 0x04000015 RID: 21
		private double _Point_Min_e = double.MaxValue;

		// Token: 0x04000016 RID: 22
		private double _Point_Max_hghgthO = double.MinValue;

		// Token: 0x04000017 RID: 23
		private double _Point_Min_hghgthO = double.MaxValue;

		// Token: 0x04000018 RID: 24
		private double _Point_Max_hghtE = double.MinValue;

		// Token: 0x04000019 RID: 25
		private double _Point_Min_hghtE = double.MaxValue;

		// Token: 0x0400001A RID: 26
		private HeXML_Details.UnitConverter _UnitConverter = HeXML_Details.UnitConverter.None;

		// Token: 0x02000015 RID: 21
		public enum UnitConverter
		{
			// Token: 0x040000A9 RID: 169
			FeetToMeter,
			// Token: 0x040000AA RID: 170
			MeterToFeet,
			// Token: 0x040000AB RID: 171
			None
		}
	}
}
