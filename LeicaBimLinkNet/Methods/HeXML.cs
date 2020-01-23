using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using LeicaBimLinkNet.Objects;

namespace LeicaBimLinkNet.Methods
{
	// Token: 0x02000014 RID: 20
	public class HeXML
	{
		// Token: 0x060000B9 RID: 185 RVA: 0x00005354 File Offset: 0x00003554
		public void Write(string FullFileName, List<object> List_HeXMLObjects, LandXML_Header LandXML_Header)
		{
			this.nuFoI = new CultureInfo("de-DE", false).NumberFormat;
			this.nuFoI.NumberDecimalSeparator = ".";
			if (LandXML_Header == null)
			{
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement documentElement = xmlDocument.DocumentElement;
			XmlDeclaration newChild = xmlDocument.CreateXmlDeclaration("1.0", null, null);
			xmlDocument.InsertBefore(newChild, documentElement);
			string text = string.Concat(new string[]
			{
				string.Format("{0:D2}", DateTime.Now.Year),
				"-",
				string.Format("{0:D2}", DateTime.Now.Month),
				"-",
				string.Format("{0:D2}", DateTime.Now.Day)
			});
			string text2 = string.Concat(new string[]
			{
				string.Format("{0:D2}", DateTime.Now.Hour),
				":",
				string.Format("{0:D2}", DateTime.Now.Minute),
				":",
				string.Format("{0:D2}", DateTime.Now.Second)
			});
			LandXML_Header.Author_timeStamp = text + "T" + text2;
			XmlNode xmlNode = xmlDocument.CreateNode(XmlNodeType.Element, "LandXML", "");
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("xmlns");
			xmlAttribute.Value = "http://www.landxml.org/schema/LandXML-1.2";
			xmlNode.Attributes.Append(xmlAttribute);
			XmlAttribute xmlAttribute2 = xmlDocument.CreateAttribute("xmlns:xsi");
			xmlAttribute2.Value = "http://www.w3.org/2001/XMLSchema-instance";
			xmlNode.Attributes.Append(xmlAttribute2);
			XmlAttribute xmlAttribute3 = xmlDocument.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
			xmlAttribute3.Value = "http://www.landxml.org/schema/LandXML-1.2 http://www.landxml.org/schema/LandXML-1.2/LandXML-1.2.xsd";
			xmlNode.Attributes.Append(xmlAttribute3);
			XmlAttribute xmlAttribute4 = xmlDocument.CreateAttribute("date");
			xmlAttribute4.Value = text;
			xmlNode.Attributes.Append(xmlAttribute4);
			XmlAttribute xmlAttribute5 = xmlDocument.CreateAttribute("time");
			xmlAttribute5.Value = text2;
			xmlNode.Attributes.Append(xmlAttribute5);
			XmlAttribute xmlAttribute6 = xmlDocument.CreateAttribute("version");
			xmlAttribute6.Value = "1.2";
			xmlNode.Attributes.Append(xmlAttribute6);
			XmlAttribute xmlAttribute7 = xmlDocument.CreateAttribute("language");
			xmlAttribute7.Value = "English";
			xmlNode.Attributes.Append(xmlAttribute7);
			XmlAttribute xmlAttribute8 = xmlDocument.CreateAttribute("readOnly");
			xmlAttribute8.Value = "false";
			xmlNode.Attributes.Append(xmlAttribute8);
			xmlDocument.AppendChild(xmlNode);
			XmlNode xmlNode2 = xmlDocument.CreateNode(XmlNodeType.Element, "Units", "");
			XmlNode xmlNode3 = xmlDocument.CreateNode(XmlNodeType.Element, "Metric", "");
			XmlNode xmlNode4 = xmlDocument.CreateNode(XmlNodeType.Element, "Imperial", "");
			if (LandXML_Header.Units_linearUnit != null)
			{
				if (LandXML_Header.Units_linearUnit.ToLower().Contains("feet") || LandXML_Header.Units_linearUnit.ToLower().Contains("foot") || LandXML_Header.Units_linearUnit.ToLower().Contains("inch"))
				{
					XmlAttribute xmlAttribute9 = xmlDocument.CreateAttribute("areaUnit");
					if (LandXML_Header.Units_areaUnit != null)
					{
						xmlAttribute9.Value = LandXML_Header.Units_areaUnit;
						xmlNode4.Attributes.Append(xmlAttribute9);
					}
					XmlAttribute xmlAttribute10 = xmlDocument.CreateAttribute("linearUnit");
					if (LandXML_Header.Units_linearUnit != null)
					{
						xmlAttribute10.Value = LandXML_Header.Units_linearUnit;
						xmlNode4.Attributes.Append(xmlAttribute10);
					}
					XmlAttribute xmlAttribute11 = xmlDocument.CreateAttribute("volumeUnit");
					if (LandXML_Header.Units_volumeUnit != null)
					{
						xmlAttribute11.Value = LandXML_Header.Units_volumeUnit;
						xmlNode4.Attributes.Append(xmlAttribute11);
					}
					XmlAttribute xmlAttribute12 = xmlDocument.CreateAttribute("angularUnit");
					if (LandXML_Header.Units_angularUnit != null)
					{
						xmlAttribute12.Value = LandXML_Header.Units_angularUnit;
						xmlNode4.Attributes.Append(xmlAttribute12);
					}
					XmlAttribute xmlAttribute13 = xmlDocument.CreateAttribute("directionUnit");
					if (LandXML_Header.Units_directionUnit != null)
					{
						xmlAttribute13.Value = LandXML_Header.Units_directionUnit;
						xmlNode4.Attributes.Append(xmlAttribute13);
					}
					XmlAttribute xmlAttribute14 = xmlDocument.CreateAttribute("temperatureUnit");
					if (LandXML_Header.Units_temperatureUnit != null)
					{
						xmlAttribute14.Value = LandXML_Header.Units_temperatureUnit;
						xmlNode4.Attributes.Append(xmlAttribute14);
					}
					XmlAttribute xmlAttribute15 = xmlDocument.CreateAttribute("pressureUnit");
					if (LandXML_Header.Units_pressureUnit != null)
					{
						xmlAttribute15.Value = LandXML_Header.Units_pressureUnit;
						xmlNode4.Attributes.Append(xmlAttribute15);
					}
					xmlNode2.AppendChild(xmlNode4);
				}
				else if (LandXML_Header.Units_linearUnit.ToLower().Contains("meter"))
				{
					XmlAttribute xmlAttribute16 = xmlDocument.CreateAttribute("areaUnit");
					if (LandXML_Header.Units_areaUnit != null)
					{
						xmlAttribute16.Value = LandXML_Header.Units_areaUnit;
						xmlNode3.Attributes.Append(xmlAttribute16);
					}
					XmlAttribute xmlAttribute17 = xmlDocument.CreateAttribute("linearUnit");
					if (LandXML_Header.Units_linearUnit != null)
					{
						xmlAttribute17.Value = LandXML_Header.Units_linearUnit;
						xmlNode3.Attributes.Append(xmlAttribute17);
					}
					XmlAttribute xmlAttribute18 = xmlDocument.CreateAttribute("volumeUnit");
					if (LandXML_Header.Units_volumeUnit != null)
					{
						xmlAttribute18.Value = LandXML_Header.Units_volumeUnit;
						xmlNode3.Attributes.Append(xmlAttribute18);
					}
					XmlAttribute xmlAttribute19 = xmlDocument.CreateAttribute("angularUnit");
					if (LandXML_Header.Units_angularUnit != null)
					{
						xmlAttribute19.Value = LandXML_Header.Units_angularUnit;
						xmlNode3.Attributes.Append(xmlAttribute19);
					}
					XmlAttribute xmlAttribute20 = xmlDocument.CreateAttribute("directionUnit");
					if (LandXML_Header.Units_directionUnit != null)
					{
						xmlAttribute20.Value = LandXML_Header.Units_directionUnit;
						xmlNode3.Attributes.Append(xmlAttribute20);
					}
					XmlAttribute xmlAttribute21 = xmlDocument.CreateAttribute("temperatureUnit");
					if (LandXML_Header.Units_temperatureUnit != null)
					{
						xmlAttribute21.Value = LandXML_Header.Units_temperatureUnit;
						xmlNode3.Attributes.Append(xmlAttribute21);
					}
					XmlAttribute xmlAttribute22 = xmlDocument.CreateAttribute("pressureUnit");
					if (LandXML_Header.Units_pressureUnit != null)
					{
						xmlAttribute22.Value = LandXML_Header.Units_pressureUnit;
						xmlNode3.Attributes.Append(xmlAttribute22);
					}
					xmlNode2.AppendChild(xmlNode3);
				}
			}
			xmlDocument["LandXML"].AppendChild(xmlNode2);
			XmlNode xmlNode5 = xmlDocument.CreateNode(XmlNodeType.Element, "Application", "");
			XmlAttribute xmlAttribute23 = xmlDocument.CreateAttribute("name");
			if (LandXML_Header.Application_name != null)
			{
				xmlAttribute23.Value = LandXML_Header.Application_name;
				xmlNode5.Attributes.Append(xmlAttribute23);
			}
			xmlAttribute23 = xmlDocument.CreateAttribute("desc");
			if (LandXML_Header.Application_desc != null)
			{
				xmlAttribute23.Value = LandXML_Header.Application_desc;
				xmlNode5.Attributes.Append(xmlAttribute23);
			}
			xmlAttribute23 = xmlDocument.CreateAttribute("manufacturer");
			if (LandXML_Header.Application_manufacturer != null)
			{
				xmlAttribute23.Value = LandXML_Header.Application_manufacturer;
				xmlNode5.Attributes.Append(xmlAttribute23);
			}
			xmlAttribute23 = xmlDocument.CreateAttribute("manufacturerURL");
			if (LandXML_Header.Application_manufacturerURL != null)
			{
				xmlAttribute23.Value = LandXML_Header.Application_manufacturerURL;
				xmlNode5.Attributes.Append(xmlAttribute23);
			}
			xmlAttribute23 = xmlDocument.CreateAttribute("version");
			if (LandXML_Header.Application_version != null)
			{
				xmlAttribute23.Value = LandXML_Header.Application_version;
				xmlNode5.Attributes.Append(xmlAttribute23);
			}
			if (LandXML_Header.Author_company != null || LandXML_Header.Author_companyURL != null || LandXML_Header.Author_timeStamp != null)
			{
				XmlNode xmlNode6 = xmlDocument.CreateNode(XmlNodeType.Element, "Author", "");
				XmlAttribute xmlAttribute24 = xmlDocument.CreateAttribute("company");
				xmlAttribute24.Value = LandXML_Header.Author_company;
				xmlNode6.Attributes.Append(xmlAttribute24);
				XmlAttribute xmlAttribute25 = xmlDocument.CreateAttribute("companyURL");
				xmlAttribute25.Value = LandXML_Header.Author_companyURL;
				xmlNode6.Attributes.Append(xmlAttribute25);
				XmlAttribute xmlAttribute26 = xmlDocument.CreateAttribute("timeStamp");
				xmlAttribute26.Value = LandXML_Header.Author_timeStamp;
				xmlNode6.Attributes.Append(xmlAttribute26);
				xmlNode5.AppendChild(xmlNode6);
			}
			xmlDocument["LandXML"].AppendChild(xmlNode5);
			if (List_HeXMLObjects == null)
			{
				return;
			}
			XmlNode xmlNode7 = xmlDocument.CreateNode(XmlNodeType.Element, "CgPoints", "");
			xmlDocument["LandXML"].AppendChild(xmlNode7);
			foreach (object obj in List_HeXMLObjects)
			{
				if (obj.GetType() == typeof(HeXML_Point))
				{
					HeXML_Point heXML_Point = (HeXML_Point)obj;
					XmlNode xmlNode8 = xmlDocument.CreateNode(XmlNodeType.Element, "CgPoint", "");
					if (heXML_Point.UniqueID != null)
					{
						XmlAttribute xmlAttribute27 = xmlDocument.CreateAttribute("name");
						xmlAttribute27.Value = heXML_Point.UniqueID;
						if (xmlAttribute27.Value != "")
						{
							xmlNode8.Attributes.Append(xmlAttribute27);
						}
					}
					if (heXML_Point.Description_Name != null)
					{
						XmlAttribute xmlAttribute27 = xmlDocument.CreateAttribute("desc");
						xmlAttribute27.Value = heXML_Point.Description_Name;
						if (xmlAttribute27.Value != "")
						{
							xmlNode8.Attributes.Append(xmlAttribute27);
						}
					}
					if (heXML_Point.PointCode != null)
					{
						XmlAttribute xmlAttribute27 = xmlDocument.CreateAttribute("code");
						xmlAttribute27.Value = heXML_Point.PointCode;
						if (xmlAttribute27.Value != "")
						{
							xmlNode8.Attributes.Append(xmlAttribute27);
						}
					}
					if (heXML_Point.UniqueID != null)
					{
						XmlAttribute xmlAttribute27 = xmlDocument.CreateAttribute("oID");
						xmlAttribute27.Value = heXML_Point.UniqueID;
						if (xmlAttribute27.Value != "")
						{
							xmlNode8.Attributes.Append(xmlAttribute27);
						}
					}
					xmlNode7.AppendChild(xmlNode8);
					double num = double.NaN;
					if (heXML_Point.Coordinate_Local_Grid != null)
					{
						num = heXML_Point.Coordinate_Local_Grid.e;
					}
					double num2 = double.NaN;
					if (heXML_Point.Coordinate_Local_Grid != null)
					{
						num2 = heXML_Point.Coordinate_Local_Grid.n;
					}
					double num3 = double.NaN;
					if (heXML_Point.OriginalHeightKind != null || heXML_Point.Coordinate_Local_Grid != null)
					{
						if (heXML_Point.OriginalHeightKind.Equals("ellipsoidal"))
						{
							num3 = heXML_Point.Coordinate_Local_Grid.hghtE;
						}
						else if (heXML_Point.OriginalHeightKind.Equals("orthometric"))
						{
							num3 = heXML_Point.Coordinate_Local_Grid.hghthO;
						}
					}
					string innerText = string.Format("{0} {1} {2}", num2.ToString(this.nuFoI), num.ToString(this.nuFoI), num3.ToString(this.nuFoI));
					xmlNode8.InnerText = innerText;
					xmlNode7.AppendChild(xmlNode8);
				}
			}
			XmlNode xmlNode9 = xmlDocument.CreateNode(XmlNodeType.Element, "HexagonLandXML", "");
			XmlAttribute xmlAttribute28 = xmlDocument.CreateAttribute("xmlns");
			xmlAttribute28.Value = "http://xml.hexagon.com/schema/HeXML-1.3";
			xmlNode9.Attributes.Append(xmlAttribute28);
			XmlAttribute xmlAttribute29 = xmlDocument.CreateAttribute("xsi", "schemaLocation", "http://xml.hexagon.com/schema/HeXML-1.3 http://xml.hexagon.com/schema/HeXML-1.3.xsd");
			xmlAttribute29.Value = "http://xml.hexagon.com/schema/HeXML-1.3 http://xml.hexagon.com/schema/HeXML-1.3.xsd";
			xmlNode9.Attributes.Append(xmlAttribute29);
			XmlAttribute xmlAttribute30 = xmlDocument.CreateAttribute("xmlns:landxml");
			xmlAttribute30.Value = "http://www.landxml.org/schema/LandXML-1.2";
			xmlNode9.Attributes.Append(xmlAttribute30);
			xmlDocument["LandXML"].AppendChild(xmlNode9);
			if (List_HeXMLObjects == null)
			{
				return;
			}
			foreach (object obj2 in List_HeXMLObjects)
			{
				if (obj2.GetType() == typeof(HeXML_Point))
				{
					HeXML_Point heXML_Point2 = (HeXML_Point)obj2;
					XmlNode xmlNode10 = xmlDocument.CreateNode(XmlNodeType.Element, "Point", "");
					if (heXML_Point2.UniqueID != null)
					{
						XmlAttribute xmlAttribute31 = xmlDocument.CreateAttribute("uniqueID");
						xmlAttribute31.Value = heXML_Point2.UniqueID;
						if (xmlAttribute31.Value != "")
						{
							xmlNode10.Attributes.Append(xmlAttribute31);
						}
					}
					if (heXML_Point2.Class != null)
					{
						XmlAttribute xmlAttribute32 = xmlDocument.CreateAttribute("class");
						xmlAttribute32.Value = heXML_Point2.Class;
						if (xmlAttribute32.Value != "")
						{
							xmlNode10.Attributes.Append(xmlAttribute32);
						}
					}
					if (heXML_Point2.Subclass != null)
					{
						XmlAttribute xmlAttribute33 = xmlDocument.CreateAttribute("subclass");
						xmlAttribute33.Value = heXML_Point2.Subclass;
						if (xmlAttribute33.Value != "")
						{
							xmlNode10.Attributes.Append(xmlAttribute33);
						}
					}
					if (heXML_Point2.LineworkFlag != null)
					{
						XmlAttribute xmlAttribute34 = xmlDocument.CreateAttribute("lineworkFlag");
						xmlAttribute34.Value = heXML_Point2.LineworkFlag;
						if (xmlAttribute34.Value != "")
						{
							xmlNode10.Attributes.Append(xmlAttribute34);
						}
					}
					XmlNode xmlNode11 = xmlDocument.CreateNode(XmlNodeType.Element, "Coordinates", "");
					if (heXML_Point2.OriginalCoordSysKind != null)
					{
						XmlAttribute xmlAttribute35 = xmlDocument.CreateAttribute("originalCoordSysKind");
						xmlAttribute35.Value = heXML_Point2.OriginalCoordSysKind;
						if (xmlAttribute35.Value != "")
						{
							xmlNode11.Attributes.Append(xmlAttribute35);
						}
					}
					if (heXML_Point2.OriginalGeodeticDatumKind != null)
					{
						XmlAttribute xmlAttribute36 = xmlDocument.CreateAttribute("originalGeodeticDatumKind");
						xmlAttribute36.Value = heXML_Point2.OriginalGeodeticDatumKind;
						if (xmlAttribute36.Value != "")
						{
							xmlNode11.Attributes.Append(xmlAttribute36);
						}
					}
					if (heXML_Point2.OriginalHeightKind != null)
					{
						XmlAttribute xmlAttribute37 = xmlDocument.CreateAttribute("originalHeightKind");
						xmlAttribute37.Value = heXML_Point2.OriginalHeightKind;
						if (xmlAttribute37.Value != "")
						{
							xmlNode11.Attributes.Append(xmlAttribute37);
						}
					}
					if (heXML_Point2.Coordinate_WGS84_Cartesian != null || heXML_Point2.Coordinate_WGS84_Geodetic != null)
					{
						XmlNode xmlNode12 = xmlDocument.CreateNode(XmlNodeType.Element, "WGS84", "");
						if (heXML_Point2.Coordinate_WGS84_Cartesian != null)
						{
							XmlNode xmlNode13 = xmlDocument.CreateNode(XmlNodeType.Element, "Cartesian", "");
							XmlAttribute xmlAttribute38 = xmlDocument.CreateAttribute("x");
							xmlAttribute38.Value = heXML_Point2.Coordinate_WGS84_Cartesian.x.ToString(this.nuFoI);
							xmlNode13.Attributes.Append(xmlAttribute38);
							XmlAttribute xmlAttribute39 = xmlDocument.CreateAttribute("y");
							xmlAttribute39.Value = heXML_Point2.Coordinate_WGS84_Cartesian.y.ToString(this.nuFoI);
							xmlNode13.Attributes.Append(xmlAttribute39);
							XmlAttribute xmlAttribute40 = xmlDocument.CreateAttribute("z");
							xmlAttribute40.Value = heXML_Point2.Coordinate_WGS84_Cartesian.z.ToString(this.nuFoI);
							xmlNode13.Attributes.Append(xmlAttribute40);
							xmlNode12.AppendChild(xmlNode13);
						}
						if (heXML_Point2.Coordinate_WGS84_Geodetic != null)
						{
							XmlNode xmlNode14 = xmlDocument.CreateNode(XmlNodeType.Element, "Geodetic", "");
							XmlAttribute xmlAttribute41 = xmlDocument.CreateAttribute("hghthO");
							xmlAttribute41.Value = heXML_Point2.Coordinate_WGS84_Geodetic.hghthO.ToString(this.nuFoI);
							xmlNode14.Attributes.Append(xmlAttribute41);
							XmlAttribute xmlAttribute42 = xmlDocument.CreateAttribute("hghtE");
							xmlAttribute42.Value = heXML_Point2.Coordinate_WGS84_Geodetic.hghtE.ToString(this.nuFoI);
							xmlNode14.Attributes.Append(xmlAttribute42);
							XmlAttribute xmlAttribute43 = xmlDocument.CreateAttribute("lon");
							xmlAttribute43.Value = heXML_Point2.Coordinate_WGS84_Geodetic.lon.ToString(this.nuFoI);
							xmlNode14.Attributes.Append(xmlAttribute43);
							XmlAttribute xmlAttribute44 = xmlDocument.CreateAttribute("lat");
							xmlAttribute44.Value = heXML_Point2.Coordinate_WGS84_Geodetic.lat.ToString(this.nuFoI);
							xmlNode14.Attributes.Append(xmlAttribute44);
							xmlNode12.AppendChild(xmlNode14);
						}
						xmlNode11.AppendChild(xmlNode12);
					}
					if (heXML_Point2.Coordinate_Local_Cartesian != null || heXML_Point2.Coordinate_Local_Geodetic != null || heXML_Point2.Coordinate_Local_Grid != null)
					{
						XmlNode xmlNode15 = xmlDocument.CreateNode(XmlNodeType.Element, "Local", "");
						if (heXML_Point2.Coordinate_Local_Cartesian != null)
						{
							XmlNode xmlNode16 = xmlDocument.CreateNode(XmlNodeType.Element, "Cartesian", "");
							XmlAttribute xmlAttribute45 = xmlDocument.CreateAttribute("x");
							xmlAttribute45.Value = heXML_Point2.Coordinate_Local_Cartesian.x.ToString(this.nuFoI);
							xmlNode16.Attributes.Append(xmlAttribute45);
							XmlAttribute xmlAttribute46 = xmlDocument.CreateAttribute("y");
							xmlAttribute46.Value = heXML_Point2.Coordinate_Local_Cartesian.y.ToString(this.nuFoI);
							xmlNode16.Attributes.Append(xmlAttribute46);
							XmlAttribute xmlAttribute47 = xmlDocument.CreateAttribute("z");
							xmlAttribute47.Value = heXML_Point2.Coordinate_Local_Cartesian.z.ToString(this.nuFoI);
							xmlNode16.Attributes.Append(xmlAttribute47);
							xmlNode15.AppendChild(xmlNode16);
						}
						if (heXML_Point2.Coordinate_Local_Geodetic != null)
						{
							XmlNode xmlNode17 = xmlDocument.CreateNode(XmlNodeType.Element, "Geodetic", "");
							XmlAttribute xmlAttribute48 = xmlDocument.CreateAttribute("hghthO");
							xmlAttribute48.Value = heXML_Point2.Coordinate_Local_Geodetic.hghthO.ToString(this.nuFoI);
							xmlNode17.Attributes.Append(xmlAttribute48);
							XmlAttribute xmlAttribute49 = xmlDocument.CreateAttribute("hghtE");
							xmlAttribute49.Value = heXML_Point2.Coordinate_Local_Geodetic.hghtE.ToString(this.nuFoI);
							xmlNode17.Attributes.Append(xmlAttribute49);
							XmlAttribute xmlAttribute50 = xmlDocument.CreateAttribute("lon");
							xmlAttribute50.Value = heXML_Point2.Coordinate_Local_Geodetic.lon.ToString(this.nuFoI);
							xmlNode17.Attributes.Append(xmlAttribute50);
							XmlAttribute xmlAttribute51 = xmlDocument.CreateAttribute("lat");
							xmlAttribute51.Value = heXML_Point2.Coordinate_Local_Geodetic.lat.ToString(this.nuFoI);
							xmlNode17.Attributes.Append(xmlAttribute51);
							xmlNode15.AppendChild(xmlNode17);
						}
						if (heXML_Point2.Coordinate_Local_Grid != null)
						{
							XmlNode xmlNode18 = xmlDocument.CreateNode(XmlNodeType.Element, "Grid", "");
							if (heXML_Point2.Coordinate_Local_Grid.hghthO != -1.7976931348623157E+308)
							{
								XmlAttribute xmlAttribute52 = xmlDocument.CreateAttribute("hghthO");
								xmlAttribute52.Value = heXML_Point2.Coordinate_Local_Grid.hghthO.ToString(this.nuFoI);
								xmlNode18.Attributes.Append(xmlAttribute52);
							}
							if (heXML_Point2.Coordinate_Local_Grid.hghtE != -1.7976931348623157E+308)
							{
								XmlAttribute xmlAttribute53 = xmlDocument.CreateAttribute("hghtE");
								xmlAttribute53.Value = heXML_Point2.Coordinate_Local_Grid.hghtE.ToString(this.nuFoI);
								xmlNode18.Attributes.Append(xmlAttribute53);
							}
							XmlAttribute xmlAttribute54 = xmlDocument.CreateAttribute("n");
							xmlAttribute54.Value = heXML_Point2.Coordinate_Local_Grid.n.ToString(this.nuFoI);
							xmlNode18.Attributes.Append(xmlAttribute54);
							XmlAttribute xmlAttribute55 = xmlDocument.CreateAttribute("e");
							xmlAttribute55.Value = heXML_Point2.Coordinate_Local_Grid.e.ToString(this.nuFoI);
							xmlNode18.Attributes.Append(xmlAttribute55);
							xmlNode15.AppendChild(xmlNode18);
						}
						xmlNode11.AppendChild(xmlNode15);
					}
					xmlNode10.AppendChild(xmlNode11);
					XmlNode xmlNode19 = xmlDocument.CreateNode(XmlNodeType.Element, "PointCode", "");
					XmlAttribute xmlAttribute56 = xmlDocument.CreateAttribute("code");
					if (heXML_Point2.PointCode != null)
					{
						xmlAttribute56.Value = heXML_Point2.PointCode;
						if (xmlAttribute56.Value != "")
						{
							xmlNode19.Attributes.Append(xmlAttribute56);
						}
					}
					xmlAttribute56 = xmlDocument.CreateAttribute("codeDesc");
					if (heXML_Point2.PointCodeDesc != null)
					{
						xmlAttribute56.Value = heXML_Point2.PointCodeDesc;
						if (xmlAttribute56.Value != "")
						{
							xmlNode19.Attributes.Append(xmlAttribute56);
						}
					}
					xmlAttribute56 = xmlDocument.CreateAttribute("codeInformation");
					if (heXML_Point2.PointCodeInformation != null)
					{
						xmlAttribute56.Value = heXML_Point2.PointCodeInformation;
						if (xmlAttribute56.Value != "")
						{
							xmlNode19.Attributes.Append(xmlAttribute56);
						}
					}
					xmlAttribute56 = xmlDocument.CreateAttribute("color");
					if (heXML_Point2.PointCodeColor != null)
					{
						xmlAttribute56.Value = heXML_Point2.PointCodeColor;
						if (xmlAttribute56.Value != "")
						{
							xmlNode19.Attributes.Append(xmlAttribute56);
						}
					}
					xmlAttribute56 = xmlDocument.CreateAttribute("codeGroup");
					if (heXML_Point2.PointCodeGroup != null)
					{
						xmlAttribute56.Value = heXML_Point2.PointCodeGroup;
						if (xmlAttribute56.Value.Equals(""))
						{
							xmlAttribute56.Value = "Default";
						}
						xmlNode19.Attributes.Append(xmlAttribute56);
					}
					else
					{
						xmlAttribute56.Value = "Default";
						xmlNode19.Attributes.Append(xmlAttribute56);
					}
					xmlAttribute56 = xmlDocument.CreateAttribute("codeLineWork");
					if (heXML_Point2.PointCodeLinework != null)
					{
						xmlAttribute56.Value = heXML_Point2.PointCodeLinework;
						if (xmlAttribute56.Value != "")
						{
							xmlNode19.Attributes.Append(xmlAttribute56);
						}
					}
					if (heXML_Point2.ListPointCodeAttributes != null && heXML_Point2.ListPointCodeAttributes.Count != 0)
					{
						char[] separator = new char[]
						{
							'@'
						};
						for (int i = 0; i < heXML_Point2.ListPointCodeAttributes.Count; i++)
						{
							string text3 = heXML_Point2.ListPointCodeAttributes[i];
							if (!string.IsNullOrEmpty(text3))
							{
								string text4 = "";
								string value = "";
								if (text3.Contains('@'))
								{
									string[] array = text3.Split(separator);
									if (array.Length != 0)
									{
										text4 = array[0];
									}
									if (array.Length > 1 && text3.Length >= text4.Length + 1)
									{
										value = text3.Substring(text4.Length + 1, text3.Length - text4.Length - 1);
									}
									if (string.IsNullOrEmpty(text4))
									{
										text4 = "Attrib" + (i + 1).ToString();
									}
								}
								else
								{
									text4 = "Attrib" + (i + 1).ToString();
									value = text3;
								}
								XmlNode xmlNode20 = xmlDocument.CreateNode(XmlNodeType.Element, "Attribute", "");
								XmlAttribute xmlAttribute57 = xmlDocument.CreateAttribute("name");
								xmlAttribute57.Value = text4;
								xmlNode20.Attributes.Append(xmlAttribute57);
								XmlAttribute xmlAttribute58 = xmlDocument.CreateAttribute("value");
								xmlAttribute58.Value = value;
								xmlNode20.Attributes.Append(xmlAttribute58);
								xmlNode19.AppendChild(xmlNode20);
							}
						}
					}
					xmlNode10.AppendChild(xmlNode19);
					XmlNode xmlNode21 = xmlDocument.CreateNode(XmlNodeType.Element, "Annotations", "");
					bool flag = false;
					for (int j = 1; j <= 4; j++)
					{
						xmlAttribute56 = xmlDocument.CreateAttribute("annotation" + j);
						if (j == 1 && heXML_Point2.Annotation1 != null)
						{
							xmlAttribute56.Value = heXML_Point2.Annotation1;
							if (xmlAttribute56.Value != "")
							{
								xmlNode21.Attributes.Append(xmlAttribute56);
								flag = false;
							}
							else
							{
								flag = true;
							}
						}
						else if (j == 2 && heXML_Point2.Annotation2 != null)
						{
							xmlAttribute56.Value = heXML_Point2.Annotation2;
							if (xmlAttribute56.Value != "")
							{
								xmlNode21.Attributes.Append(xmlAttribute56);
								flag = false;
							}
							else
							{
								flag = true;
							}
						}
						else if (j == 3 && heXML_Point2.Annotation3 != null)
						{
							xmlAttribute56.Value = heXML_Point2.Annotation3;
							if (xmlAttribute56.Value != "")
							{
								xmlNode21.Attributes.Append(xmlAttribute56);
								flag = false;
							}
							else
							{
								flag = true;
							}
						}
						else if (j == 4 && heXML_Point2.Annotation4 != null)
						{
							xmlAttribute56.Value = heXML_Point2.Annotation4;
							if (xmlAttribute56.Value != "")
							{
								xmlNode21.Attributes.Append(xmlAttribute56);
							}
							else
							{
								flag = true;
							}
						}
					}
					if (!flag)
					{
						xmlNode10.AppendChild(xmlNode21);
					}
					xmlNode9.AppendChild(xmlNode10);
				}
			}
			xmlDocument.Save(FullFileName);
			StreamReader streamReader = new StreamReader(FullFileName);
			List<string> list = new List<string>();
			bool flag2 = false;
			do
			{
				string text5 = streamReader.ReadLine();
				if (text5.Contains("<HexagonLandXML xmlns"))
				{
					string item = "<HexagonLandXML xmlns=\"http://xml.hexagon.com/schema/HeXML-1.3\" xsi:schemaLocation=\"http://xml.hexagon.com/schema/HeXML-1.3 http://xml.hexagon.com/schema/HeXML-1.3.xsd\" xmlns:landxml=\"http://www.landxml.org/schema/LandXML-1.2\">";
					list.Add(item);
					flag2 = true;
				}
				else
				{
					list.Add(text5);
				}
			}
			while (!streamReader.EndOfStream);
			streamReader.Close();
			if (flag2)
			{
				try
				{
					StreamWriter streamWriter = new StreamWriter(FullFileName);
					foreach (string value2 in list)
					{
						streamWriter.WriteLine(value2);
					}
					streamWriter.Close();
				}
				catch (Exception ex)
				{
					ex.ToString();
				}
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00006CE8 File Offset: 0x00004EE8
		public List<object> Read(string FullFileName, out LandXML_Header LandXML_Header)
		{
			this.nuFoI = new CultureInfo("de-DE", false).NumberFormat;
			this.nuFoI.NumberDecimalSeparator = ".";
			LandXML_Header = new LandXML_Header();
			List<object> list = new List<object>();
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				xmlDocument.Load(FullFileName);
			}
			catch (Exception)
			{
				xmlDocument = null;
			}
			if (xmlDocument == null)
			{
				return list;
			}
			if (xmlDocument.DocumentElement != null)
			{
				if (xmlDocument.DocumentElement.Name.Equals("LandXML"))
				{
					using (IEnumerator enumerator = xmlDocument.DocumentElement.ChildNodes.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							XmlElement xmlElement = (XmlElement)obj;
							if (xmlElement.Name.Equals("HexagonLandXML"))
							{
								using (IEnumerator enumerator2 = xmlElement.ChildNodes.GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										object obj2 = enumerator2.Current;
										XmlElement nodPt = (XmlElement)obj2;
										HeXML_Point heXML_Point = this.Read_Point(nodPt);
										if (heXML_Point != null)
										{
											list.Add(heXML_Point);
										}
									}
									continue;
								}
							}
							if (xmlElement.Name.Equals("Units"))
							{
								using (IEnumerator enumerator2 = xmlElement.ChildNodes.GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										object obj3 = enumerator2.Current;
										XmlNode xmlNode = (XmlNode)obj3;
										if (xmlNode.Name.Equals("Metric"))
										{
											if (xmlNode.Attributes["linearUnit"] != null && xmlNode.Attributes["linearUnit"].Value != null)
											{
												LandXML_Header.Units_linearUnit = xmlNode.Attributes["linearUnit"].Value;
											}
											if (xmlNode.Attributes["areaUnit"] != null && xmlNode.Attributes["areaUnit"].Value != null)
											{
												LandXML_Header.Units_areaUnit = xmlNode.Attributes["areaUnit"].Value;
											}
											if (xmlNode.Attributes["volumeUnit"] != null && xmlNode.Attributes["volumeUnit"].Value != null)
											{
												LandXML_Header.Units_volumeUnit = xmlNode.Attributes["volumeUnit"].Value;
											}
											if (xmlNode.Attributes["temperatureUnit"] != null && xmlNode.Attributes["temperatureUnit"].Value != null)
											{
												LandXML_Header.Units_temperatureUnit = xmlNode.Attributes["temperatureUnit"].Value;
											}
											if (xmlNode.Attributes["pressureUnit"] != null && xmlNode.Attributes["pressureUnit"].Value != null)
											{
												LandXML_Header.Units_pressureUnit = xmlNode.Attributes["pressureUnit"].Value;
											}
											if (xmlNode.Attributes["angularUnit"] != null && xmlNode.Attributes["angularUnit"].Value != null)
											{
												LandXML_Header.Units_angularUnit = xmlNode.Attributes["angularUnit"].Value;
											}
											if (xmlNode.Attributes["directionUnit"] != null && xmlNode.Attributes["directionUnit"].Value != null)
											{
												LandXML_Header.Units_directionUnit = xmlNode.Attributes["directionUnit"].Value;
											}
											if (xmlNode.Attributes["pressureUnit"] != null && xmlNode.Attributes["pressureUnit"].Value != null)
											{
												LandXML_Header.Units_pressureUnit = xmlNode.Attributes["pressureUnit"].Value;
											}
										}
										else if (xmlNode.Name.Equals("Imperial"))
										{
											if (xmlNode.Attributes["linearUnit"] != null && xmlNode.Attributes["linearUnit"].Value != null)
											{
												LandXML_Header.Units_linearUnit = xmlNode.Attributes["linearUnit"].Value;
											}
											if (xmlNode.Attributes["areaUnit"] != null && xmlNode.Attributes["areaUnit"].Value != null)
											{
												LandXML_Header.Units_areaUnit = xmlNode.Attributes["areaUnit"].Value;
											}
											if (xmlNode.Attributes["volumeUnit"] != null && xmlNode.Attributes["volumeUnit"].Value != null)
											{
												LandXML_Header.Units_volumeUnit = xmlNode.Attributes["volumeUnit"].Value;
											}
											if (xmlNode.Attributes["temperatureUnit"] != null && xmlNode.Attributes["temperatureUnit"].Value != null)
											{
												LandXML_Header.Units_temperatureUnit = xmlNode.Attributes["temperatureUnit"].Value;
											}
											if (xmlNode.Attributes["pressureUnit"] != null && xmlNode.Attributes["pressureUnit"].Value != null)
											{
												LandXML_Header.Units_pressureUnit = xmlNode.Attributes["pressureUnit"].Value;
											}
											if (xmlNode.Attributes["angularUnit"] != null && xmlNode.Attributes["angularUnit"].Value != null)
											{
												LandXML_Header.Units_angularUnit = xmlNode.Attributes["angularUnit"].Value;
											}
											if (xmlNode.Attributes["directionUnit"] != null && xmlNode.Attributes["directionUnit"].Value != null)
											{
												LandXML_Header.Units_directionUnit = xmlNode.Attributes["directionUnit"].Value;
											}
											if (xmlNode.Attributes["pressureUnit"] != null && xmlNode.Attributes["pressureUnit"].Value != null)
											{
												LandXML_Header.Units_pressureUnit = xmlNode.Attributes["pressureUnit"].Value;
											}
										}
									}
									continue;
								}
							}
							if (xmlElement.Name.Equals("Application"))
							{
								if (xmlElement.Attributes["name"] != null && xmlElement.Attributes["name"].Value != null)
								{
									LandXML_Header.Application_name = xmlElement.Attributes["name"].Value;
								}
								if (xmlElement.Attributes["desc"] != null && xmlElement.Attributes["desc"].Value != null)
								{
									LandXML_Header.Application_desc = xmlElement.Attributes["desc"].Value;
								}
								if (xmlElement.Attributes["manufacturer"] != null && xmlElement.Attributes["manufacturer"].Value != null)
								{
									LandXML_Header.Application_manufacturer = xmlElement.Attributes["manufacturer"].Value;
								}
								if (xmlElement.Attributes["manufacturerURL"] != null && xmlElement.Attributes["manufacturerURL"].Value != null)
								{
									LandXML_Header.Application_manufacturerURL = xmlElement.Attributes["manufacturerURL"].Value;
								}
								if (xmlElement.Attributes["version"] != null && xmlElement.Attributes["version"].Value != null)
								{
									LandXML_Header.Application_version = xmlElement.Attributes["version"].Value;
								}
							}
						}
						return list;
					}
				}
				if (xmlDocument.DocumentElement.Name.Equals("HexagonLandXML"))
				{
					foreach (object obj4 in xmlDocument.DocumentElement.ChildNodes)
					{
						XmlElement nodPt2 = (XmlElement)obj4;
						HeXML_Point heXML_Point2 = this.Read_Point(nodPt2);
						if (heXML_Point2 != null)
						{
							list.Add(heXML_Point2);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000757C File Offset: 0x0000577C
		private HeXML_Point Read_Point(XmlElement nodPt)
		{
			HeXML_Point heXML_Point = null;
			if (nodPt.Name.Equals("Point"))
			{
				heXML_Point = new HeXML_Point();
				if (nodPt.Attributes["uniqueID"] != null && nodPt.Attributes["uniqueID"].Value != null)
				{
					heXML_Point.UniqueID = nodPt.Attributes["uniqueID"].Value;
				}
				if (nodPt.Attributes["class"] != null && nodPt.Attributes["class"].Value != null)
				{
					heXML_Point.Class = nodPt.Attributes["class"].Value;
				}
				if (nodPt.Attributes["subclass"] != null && nodPt.Attributes["subclass"].Value != null)
				{
					heXML_Point.Subclass = nodPt.Attributes["subclass"].Value;
				}
				if (nodPt.Attributes["lineworkFlag"] != null && nodPt.Attributes["lineworkFlag"].Value != null)
				{
					heXML_Point.LineworkFlag = nodPt.Attributes["lineworkFlag"].Value;
				}
				foreach (object obj in nodPt.ChildNodes)
				{
					XmlElement xmlElement = (XmlElement)obj;
					if (xmlElement.Name.Equals("Coordinates"))
					{
						if (xmlElement.Attributes["originalCoordSysKind"] != null && xmlElement.Attributes["originalCoordSysKind"].Value != null)
						{
							heXML_Point.OriginalCoordSysKind = xmlElement.Attributes["originalCoordSysKind"].Value;
						}
						if (xmlElement.Attributes["originalGeodeticDatumKind"] != null && xmlElement.Attributes["originalGeodeticDatumKind"].Value != null)
						{
							heXML_Point.OriginalGeodeticDatumKind = xmlElement.Attributes["originalGeodeticDatumKind"].Value;
						}
						if (xmlElement.Attributes["originalHeightKind"] != null && xmlElement.Attributes["originalHeightKind"].Value != null)
						{
							heXML_Point.OriginalHeightKind = xmlElement.Attributes["originalHeightKind"].Value;
						}
						using (IEnumerator enumerator2 = xmlElement.ChildNodes.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								object obj2 = enumerator2.Current;
								XmlElement xmlElement2 = (XmlElement)obj2;
								if (xmlElement2.Name.Equals("Local"))
								{
									using (IEnumerator enumerator3 = xmlElement2.ChildNodes.GetEnumerator())
									{
										while (enumerator3.MoveNext())
										{
											object obj3 = enumerator3.Current;
											XmlElement xmlElement3 = (XmlElement)obj3;
											if (xmlElement3.Name.Equals("Cartesian"))
											{
												HeXML_Point_Coordinates_Cartesian heXML_Point_Coordinates_Cartesian = new HeXML_Point_Coordinates_Cartesian();
												if (xmlElement3.Attributes["x"] != null && xmlElement3.Attributes["x"].Value != null)
												{
													heXML_Point_Coordinates_Cartesian.x = double.Parse(xmlElement3.Attributes["x"].Value.Replace(',', '.'), this.nuFoI);
												}
												if (xmlElement3.Attributes["y"] != null && xmlElement3.Attributes["y"].Value != null)
												{
													heXML_Point_Coordinates_Cartesian.y = double.Parse(xmlElement3.Attributes["y"].Value.Replace(',', '.'), this.nuFoI);
												}
												if (xmlElement3.Attributes["z"] != null && xmlElement3.Attributes["z"].Value != null)
												{
													heXML_Point_Coordinates_Cartesian.z = double.Parse(xmlElement3.Attributes["z"].Value.Replace(',', '.'), this.nuFoI);
												}
												heXML_Point.Coordinate_Local_Cartesian = heXML_Point_Coordinates_Cartesian;
											}
											else if (xmlElement3.Name.Equals("Geodetic"))
											{
												HeXML_Point_Coordinates_Geodetic heXML_Point_Coordinates_Geodetic = new HeXML_Point_Coordinates_Geodetic();
												if (xmlElement3.Attributes["lat"] != null && xmlElement3.Attributes["lat"].Value != null)
												{
													heXML_Point_Coordinates_Geodetic.lat = double.Parse(xmlElement3.Attributes["lat"].Value.Replace(',', '.'), this.nuFoI);
												}
												if (xmlElement3.Attributes["lon"] != null && xmlElement3.Attributes["lon"].Value != null)
												{
													heXML_Point_Coordinates_Geodetic.lon = double.Parse(xmlElement3.Attributes["lon"].Value.Replace(',', '.'), this.nuFoI);
												}
												if (xmlElement3.Attributes["hghtE"] != null && xmlElement3.Attributes["hghtE"].Value != null)
												{
													heXML_Point_Coordinates_Geodetic.hghtE = double.Parse(xmlElement3.Attributes["hghtE"].Value.Replace(',', '.'), this.nuFoI);
												}
												if (xmlElement3.Attributes["hghthO"] != null && xmlElement3.Attributes["hghthO"].Value != null)
												{
													heXML_Point_Coordinates_Geodetic.hghthO = double.Parse(xmlElement3.Attributes["hghthO"].Value.Replace(',', '.'), this.nuFoI);
												}
												heXML_Point.Coordinate_Local_Geodetic = heXML_Point_Coordinates_Geodetic;
											}
											else if (xmlElement3.Name.Equals("Grid"))
											{
												HeXML_Point_Coordinates_Grid heXML_Point_Coordinates_Grid = new HeXML_Point_Coordinates_Grid();
												if (xmlElement3.Attributes["e"] != null && xmlElement3.Attributes["e"].Value != null)
												{
													heXML_Point_Coordinates_Grid.e = double.Parse(xmlElement3.Attributes["e"].Value.Replace(',', '.'), this.nuFoI);
												}
												if (xmlElement3.Attributes["n"] != null && xmlElement3.Attributes["n"].Value != null)
												{
													heXML_Point_Coordinates_Grid.n = double.Parse(xmlElement3.Attributes["n"].Value.Replace(',', '.'), this.nuFoI);
												}
												if (xmlElement3.Attributes["hghtE"] != null && xmlElement3.Attributes["hghtE"].Value != null)
												{
													heXML_Point_Coordinates_Grid.hghtE = double.Parse(xmlElement3.Attributes["hghtE"].Value.Replace(',', '.'), this.nuFoI);
												}
												if (xmlElement3.Attributes["hghthO"] != null && xmlElement3.Attributes["hghthO"].Value != null)
												{
													heXML_Point_Coordinates_Grid.hghthO = double.Parse(xmlElement3.Attributes["hghthO"].Value.Replace(',', '.'), this.nuFoI);
												}
												heXML_Point.Coordinate_Local_Grid = heXML_Point_Coordinates_Grid;
											}
										}
										continue;
									}
								}
								if (xmlElement2.Name.Equals("WGS84"))
								{
									foreach (object obj4 in xmlElement2.ChildNodes)
									{
										XmlElement xmlElement4 = (XmlElement)obj4;
										if (xmlElement4.Name.Equals("Cartesian"))
										{
											HeXML_Point_Coordinates_Cartesian heXML_Point_Coordinates_Cartesian2 = new HeXML_Point_Coordinates_Cartesian();
											if (xmlElement4.Attributes["x"] != null && xmlElement4.Attributes["x"].Value != null)
											{
												heXML_Point_Coordinates_Cartesian2.x = double.Parse(xmlElement4.Attributes["x"].Value.Replace(',', '.'), this.nuFoI);
											}
											if (xmlElement4.Attributes["y"] != null && xmlElement4.Attributes["y"].Value != null)
											{
												heXML_Point_Coordinates_Cartesian2.y = double.Parse(xmlElement4.Attributes["y"].Value.Replace(',', '.'), this.nuFoI);
											}
											if (xmlElement4.Attributes["z"] != null && xmlElement4.Attributes["z"].Value != null)
											{
												heXML_Point_Coordinates_Cartesian2.z = double.Parse(xmlElement4.Attributes["z"].Value.Replace(',', '.'), this.nuFoI);
											}
											heXML_Point.Coordinate_WGS84_Cartesian = heXML_Point_Coordinates_Cartesian2;
										}
										else if (xmlElement4.Name.Equals("Geodetic"))
										{
											HeXML_Point_Coordinates_Geodetic heXML_Point_Coordinates_Geodetic2 = new HeXML_Point_Coordinates_Geodetic();
											if (xmlElement4.Attributes["lat"] != null && xmlElement4.Attributes["lat"].Value != null)
											{
												heXML_Point_Coordinates_Geodetic2.lat = double.Parse(xmlElement4.Attributes["lat"].Value.Replace(',', '.'), this.nuFoI);
											}
											if (xmlElement4.Attributes["lon"] != null && xmlElement4.Attributes["lon"].Value != null)
											{
												heXML_Point_Coordinates_Geodetic2.lon = double.Parse(xmlElement4.Attributes["lon"].Value.Replace(',', '.'), this.nuFoI);
											}
											if (xmlElement4.Attributes["hghtE"] != null && xmlElement4.Attributes["hghtE"].Value != null)
											{
												heXML_Point_Coordinates_Geodetic2.hghtE = double.Parse(xmlElement4.Attributes["hghtE"].Value.Replace(',', '.'), this.nuFoI);
											}
											if (xmlElement4.Attributes["hghthO"] != null && xmlElement4.Attributes["hghthO"].Value != null)
											{
												heXML_Point_Coordinates_Geodetic2.hghthO = double.Parse(xmlElement4.Attributes["hghthO"].Value.Replace(',', '.'), this.nuFoI);
											}
											heXML_Point.Coordinate_WGS84_Geodetic = heXML_Point_Coordinates_Geodetic2;
										}
									}
								}
							}
							continue;
						}
					}
					if (xmlElement.Name.Equals("PointCode"))
					{
						if (xmlElement.Attributes["code"] != null && xmlElement.Attributes["code"].Value != null)
						{
							heXML_Point.PointCode = xmlElement.Attributes["code"].Value;
						}
						if (xmlElement.Attributes["codeDesc"] != null && xmlElement.Attributes["codeDesc"].Value != null)
						{
							heXML_Point.PointCodeDesc = xmlElement.Attributes["codeDesc"].Value;
						}
						if (xmlElement.Attributes["codeInformation"] != null && xmlElement.Attributes["codeInformation"].Value != null)
						{
							heXML_Point.PointCodeInformation = xmlElement.Attributes["codeInformation"].Value;
						}
						if (xmlElement.Attributes["color"] != null && xmlElement.Attributes["color"].Value != null)
						{
							heXML_Point.PointCodeColor = xmlElement.Attributes["color"].Value;
						}
						if (xmlElement.Attributes["codeGroup"] != null && xmlElement.Attributes["codeGroup"].Value != null)
						{
							heXML_Point.PointCodeGroup = xmlElement.Attributes["codeGroup"].Value;
						}
						if (xmlElement.Attributes["codeLineWork"] != null && xmlElement.Attributes["codeLineWork"].Value != null)
						{
							heXML_Point.PointCodeLinework = xmlElement.Attributes["codeLineWork"].Value;
						}
						heXML_Point.ListPointCodeAttributes = new List<string>();
						using (IEnumerator enumerator2 = xmlElement.ChildNodes.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								object obj5 = enumerator2.Current;
								XmlNode xmlNode = (XmlNode)obj5;
								if (xmlNode.Name.ToLower() == "attribute" && xmlNode.Attributes["name"] != null && xmlNode.Attributes["name"].Value != null)
								{
									string value = xmlNode.Attributes["name"].Value;
									string str = "";
									if (xmlNode.Attributes["value"] != null && xmlNode.Attributes["value"].Value != null)
									{
										str = xmlNode.Attributes["value"].Value;
									}
									string item = value + "@" + str;
									heXML_Point.ListPointCodeAttributes.Add(item);
								}
							}
							continue;
						}
					}
					if (xmlElement.Name.Equals("OnboardImages"))
					{
						heXML_Point.OnboardImages = "";
					}
					else if (xmlElement.Name.Equals("Annotations"))
					{
						if (xmlElement.Attributes["annotation1"] != null && xmlElement.Attributes["annotation1"].Value != null)
						{
							heXML_Point.Annotation1 = xmlElement.Attributes["annotation1"].Value;
						}
						if (xmlElement.Attributes["annotation2"] != null && xmlElement.Attributes["annotation2"].Value != null)
						{
							heXML_Point.Annotation2 = xmlElement.Attributes["annotation2"].Value;
						}
						if (xmlElement.Attributes["annotation3"] != null && xmlElement.Attributes["annotation3"].Value != null)
						{
							heXML_Point.Annotation3 = xmlElement.Attributes["annotation3"].Value;
						}
						if (xmlElement.Attributes["annotation4"] != null && xmlElement.Attributes["annotation4"].Value != null)
						{
							heXML_Point.Annotation4 = xmlElement.Attributes["annotation4"].Value;
						}
					}
				}
			}
			return heXML_Point;
		}

		// Token: 0x040000A7 RID: 167
		private NumberFormatInfo nuFoI;
	}
}
