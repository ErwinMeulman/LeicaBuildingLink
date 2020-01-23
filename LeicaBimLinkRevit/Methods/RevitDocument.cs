using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using LeicaBimLinkNet.Objects;
using LeicaBimLinkRevit.Extensions;

namespace LeicaBimLinkRevit.Methods
{
	// Token: 0x02000005 RID: 5
	[Transaction(1)]
	[Regeneration(0)]
	[Journaling(1)]
	public class RevitDocument : IExternalApplication
	{
		// Token: 0x0600000F RID: 15 RVA: 0x000021D0 File Offset: 0x000003D0
		public Result OnStartup(UIControlledApplication application)
		{
			return 0;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000021D0 File Offset: 0x000003D0
		public Result OnShutdown(UIControlledApplication application)
		{
			return 0;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000022B8 File Offset: 0x000004B8
		public Family Load_Family(string FamilyPath, Document doc)
		{
			Family result = null;
			try
			{
				if (!string.IsNullOrEmpty(FamilyPath) && doc != null)
				{
					Transaction transaction = new Transaction(doc);
					transaction.Start("Leica_LoadFamily");
					if (File.Exists(FamilyPath))
					{
						doc.LoadFamily(FamilyPath, ref result);
					}
					transaction.Commit();
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002318 File Offset: 0x00000518
		public Family Get_Family(string FamilyName, Document doc)
		{
			Family result = null;
			FilteredElementCollector source = new FilteredElementCollector(doc).OfClass(typeof(Family));
			for (int i = source.Count<Element>() - 1; i >= 0; i--)
			{
				if (source.ElementAt(i).Name == FamilyName)
				{
					result = (Family)source.ElementAt(i);
					break;
				}
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002374 File Offset: 0x00000574
		public void Place_MeasurementPointFamilyInFamily(UIDocument uidoc)
		{
			if (uidoc.Document.IsFamilyDocument)
			{
				string familyPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(RevitDocument)).Location) + "\\" + this.MeasurementFamilyPointPath;
				Family family = this.Load_Family(familyPath, uidoc.Document);
				if (family == null)
				{
					family = this.Get_Family(this.MeasurementFamilyPointName, uidoc.Document);
				}
				this.Place_Family(family, uidoc);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000023E4 File Offset: 0x000005E4
		public void Place_MeasurementPointFamily(UIDocument uidoc)
		{
			if (!uidoc.Document.IsFamilyDocument)
			{
				string familyPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(RevitDocument)).Location) + "\\" + this.MeasurementFamilyPointPath;
				Family family = this.Load_Family(familyPath, uidoc.Document);
				if (family == null)
				{
					family = this.Get_Family(this.MeasurementFamilyPointName, uidoc.Document);
				}
				List<FamilyInstance> list = this.Get_FamilyInstances(this.MeasurementFamilyPointTypName, family, uidoc.Document);
				this.Place_Family(family, uidoc);
				List<FamilyInstance> list2 = this.Get_FamilyInstances(this.MeasurementFamilyPointTypName, family, uidoc.Document);
				if (list.Count != list2.Count)
				{
					Transaction transaction = new Transaction(uidoc.Document);
					transaction.Start("Leica_PlaceMeasurementPointFamily");
					List<string> list3 = this.Get_FamilyParameterValue(this.MeasurementFamilyPointTypName, HeXML_Point_Strings.FamilyParameterName_UniqueID, uidoc.Document);
					for (int i = list2.Count - list.Count - 1; i >= 0; i--)
					{
						FamilyInstance familyInstance = list2[i];
						string text = this.Get_NextMeasurementPointUniqueID(list3);
						Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_UniqueID);
						if (parameter != null)
						{
							parameter.Set(text);
							list3.Add(text);
						}
						LocationPoint locationPoint = (LocationPoint)familyInstance.Location;
						double num = locationPoint.Point.X;
						double num2 = locationPoint.Point.Y;
						double num3 = locationPoint.Point.Z;
						if (this.Detect_UnitType(uidoc.Document, 0).ToString().ToLower().Contains("meter"))
						{
							num = HeXML_Details.Math_Unit(num, HeXML_Details.UnitConverter.FeetToMeter);
							num2 = HeXML_Details.Math_Unit(num2, HeXML_Details.UnitConverter.FeetToMeter);
							num3 = HeXML_Details.Math_Unit(num3, HeXML_Details.UnitConverter.FeetToMeter);
							num = Math.Round(num, 4);
							num2 = Math.Round(num2, 4);
							num3 = Math.Round(num3, 4);
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e);
						if (parameter != null)
						{
							parameter.Set(num);
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n);
						if (parameter != null)
						{
							parameter.Set(num2);
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO);
						if (parameter != null)
						{
							parameter.Set(num3);
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_OriginalCoordSysKind);
						if (parameter != null)
						{
							parameter.Set("Grid");
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_OriginalGeodeticDatumKind);
						if (parameter != null)
						{
							parameter.Set("Local");
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_OriginalHeightKind);
						if (parameter != null)
						{
							parameter.Set("orthometric");
						}
					}
					transaction.Commit();
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000266C File Offset: 0x0000086C
		public void Place_Family(Family family, UIDocument uidoc)
		{
			try
			{
				FamilySymbol familySymbol = null;
				ISet<ElementId> familySymbolIds = family.GetFamilySymbolIds();
				if (familySymbolIds.Count != 0)
				{
					familySymbol = (FamilySymbol)uidoc.Document.GetElement(familySymbolIds.ElementAt(0));
				}
				uidoc.PromptForFamilyInstancePlacement(familySymbol);
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000026C4 File Offset: 0x000008C4
		public void FixDuplicatedIds(Document doc)
		{
			List<string> list = this.Get_FamilyParameterValue(this.MeasurementFamilyPointTypName, HeXML_Point_Strings.FamilyParameterName_UniqueID, doc);
			list.Sort();
			if (list.Count > 1 && list.Distinct<string>().Count<string>() != list.Count)
			{
				List<string> list2 = new List<string>();
				for (int i = 1; i < list.Count; i++)
				{
					if (list[i - 1] == list[i] && !list2.Contains(list[i]))
					{
						list2.Add(list[i]);
					}
				}
				Transaction transaction = new Transaction(doc);
				transaction.Start("Leica_updateIDs");
				List<string> list3 = new List<string>();
				List<Element> list4 = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance)).ToList<Element>();
				for (int j = 0; j < list4.Count; j++)
				{
					Element element = list4[j];
					if (element.Name == this.MeasurementFamilyPointTypName)
					{
						Parameter parameter = element.LookupParameter(HeXML_Point_Strings.FamilyParameterName_UniqueID);
						if (parameter != null)
						{
							string text = parameter.AsString();
							if (!string.IsNullOrEmpty(text))
							{
								if (list2.Contains(text))
								{
									LocationPoint locationPoint = (LocationPoint)element.Location;
									double num = locationPoint.Point.X;
									double num2 = locationPoint.Point.Y;
									double num3 = locationPoint.Point.Z;
									if (this.Detect_UnitType(doc, 0).ToString().ToLower().Contains("meter"))
									{
										num = HeXML_Details.Math_Unit(num, HeXML_Details.UnitConverter.FeetToMeter);
										num2 = HeXML_Details.Math_Unit(num2, HeXML_Details.UnitConverter.FeetToMeter);
										num3 = HeXML_Details.Math_Unit(num3, HeXML_Details.UnitConverter.FeetToMeter);
										num = Math.Round(num, 4);
										num2 = Math.Round(num2, 4);
										num3 = Math.Round(num3, 4);
									}
									Parameter parameter2 = element.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e);
									if (parameter2 != null)
									{
										parameter2.Set(num);
									}
									Parameter parameter3 = element.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n);
									if (parameter3 != null)
									{
										parameter3.Set(num2);
									}
									Parameter parameter4 = element.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO);
									if (parameter4 != null)
									{
										parameter4.Set(num3);
									}
								}
								if (list3.Contains(text))
								{
									string text2 = this.Get_NextMeasurementPointUniqueID(list);
									parameter.Set(text2);
									list.Add(text2);
								}
								else
								{
									list3.Add(text);
								}
							}
						}
					}
				}
				transaction.Commit();
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002928 File Offset: 0x00000B28
		public List<string> Get_FamilyParameterValue(string FamilyName, string ParameterName, Document doc)
		{
			List<string> list = new List<string>();
			List<Element> list2 = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance)).ToList<Element>();
			for (int i = list2.Count - 1; i >= 0; i--)
			{
				Element element = list2[i];
				if (element.Name == FamilyName)
				{
					Parameter parameter = element.LookupParameter(ParameterName);
					if (parameter != null)
					{
						string text = parameter.AsString();
						if (!string.IsNullOrEmpty(text))
						{
							list.Add(text);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000029A8 File Offset: 0x00000BA8
		public List<FamilyInstance> Get_FamilyInstances(string FamilyName, Family family, Document doc)
		{
			List<FamilyInstance> list = new List<FamilyInstance>();
			List<Element> list2 = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance)).ToList<Element>();
			for (int i = list2.Count - 1; i >= 0; i--)
			{
				Element element = list2[i];
				if (element.Name == FamilyName)
				{
					FamilyInstance item = (FamilyInstance)element;
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002A10 File Offset: 0x00000C10
		public List<FamilyInstance> Get_FamilyInstancesNested(string FamilyName, Family family, Document doc)
		{
			List<FamilyInstance> list = new List<FamilyInstance>();
			new ElementSet();
			FilteredElementIterator elementIterator = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance)).GetElementIterator();
			elementIterator.Reset();
			do
			{
				FamilyInstance familyInstance = elementIterator.Current as FamilyInstance;
				ICollection<ElementId> subComponentIds = familyInstance.GetSubComponentIds();
				if (subComponentIds != null)
				{
					foreach (ElementId elementId in subComponentIds)
					{
						FamilyInstance familyInstance2 = doc.GetElement(elementId) as FamilyInstance;
						if (familyInstance2.Name == this.MeasurementFamilyPointTypName)
						{
							list.Add(familyInstance2);
						}
					}
				}
				Element superComponent = familyInstance.SuperComponent;
				if (superComponent != null)
				{
					FamilyInstance familyInstance3 = superComponent as FamilyInstance;
					if (familyInstance3.Name == FamilyName)
					{
						list.Add(familyInstance3);
					}
				}
			}
			while (elementIterator.MoveNext());
			return list;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002B00 File Offset: 0x00000D00
		public string Get_NextMeasurementPointUniqueID(Document doc)
		{
			List<string> list_ExistingUniqueID = this.Get_FamilyParameterValue(this.MeasurementFamilyPointTypName, HeXML_Point_Strings.Description_UniqueID, doc);
			return this.Get_NextMeasurementPointUniqueID(list_ExistingUniqueID);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002B28 File Offset: 0x00000D28
		public string Get_NextMeasurementPointUniqueID(List<string> List_ExistingUniqueID)
		{
			int num = 1;
			foreach (string s in List_ExistingUniqueID)
			{
				int num2 = 0;
				if (int.TryParse(s, out num2) && num2 > num)
				{
					num = num2;
				}
			}
			string text = num.ToString();
			bool flag = true;
			do
			{
				flag = false;
				text = num.ToString();
				using (List<string>.Enumerator enumerator = List_ExistingUniqueID.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == text)
						{
							flag = true;
							num++;
							break;
						}
					}
				}
			}
			while (flag);
			return text;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002BE4 File Offset: 0x00000DE4
		public void Set_HeXMLPoints(Family family, List<HeXML_Point> List_HeXMLPoints, Document Doc, HeXML_Import HeXML_Import)
		{
			try
			{
				if (family != null && Doc != null && List_HeXMLPoints.Count != 0)
				{
					Transform inverse = this.GetTransformationMatrix(Doc).Inverse;
					FamilySymbol familySymbol = null;
					ISet<ElementId> familySymbolIds = family.GetFamilySymbolIds();
					if (familySymbolIds.Count != 0)
					{
						familySymbol = (FamilySymbol)Doc.GetElement(familySymbolIds.ElementAt(0));
						if (!familySymbol.IsActive)
						{
							familySymbol.Activate();
							Doc.Regenerate();
						}
					}
					if (this.ToolStripProgressBar != null)
					{
						this.ToolStripProgressBar.Minimum = 0;
						this.ToolStripProgressBar.Maximum = List_HeXMLPoints.Count;
						this.ToolStripProgressBar.Value = 0;
					}
					this.Detect_UnitType(Doc, 0);
					DisplayUnitType displayUnitType = this.Detect_UnitType(Doc, 0);
					bool flag = false;
					if (displayUnitType.ToString().ToLower().Contains("meter"))
					{
						flag = true;
					}
					for (int i = 0; i < List_HeXMLPoints.Count; i++)
					{
						HeXML_Point heXML_Point = List_HeXMLPoints[i];
						if (this.ToolStripProgressBar != null)
						{
							this.ToolStripProgressBar.Value = this.ToolStripProgressBar.Value + 1;
						}
						if (this.ToolStripStatusLabel != null)
						{
							this.ToolStripStatusLabel.Text = string.Concat(new string[]
							{
								"Status: Import (",
								this.ToolStripProgressBar.Value.ToString(),
								"/",
								this.ToolStripProgressBar.Maximum.ToString(),
								")"
							});
							Application.DoEvents();
						}
						if (heXML_Point.Coordinate_Local_Grid != null && heXML_Point.Coordinate_Local_Grid.e != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.e != 1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.n != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.n != 1.7976931348623157E+308)
						{
							RevitDocument.usedHeight usedHeight;
							if (heXML_Point.Coordinate_Local_Grid.hghthO != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.hghthO != 1.7976931348623157E+308)
							{
								usedHeight = RevitDocument.usedHeight.orthometric;
							}
							else if (heXML_Point.Coordinate_Local_Grid.hghtE != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.hghtE != 1.7976931348623157E+308)
							{
								usedHeight = RevitDocument.usedHeight.ellipsoidal;
							}
							else
							{
								usedHeight = RevitDocument.usedHeight.none;
							}
							FamilyInstance familyInstance = null;
							if (usedHeight == RevitDocument.usedHeight.ellipsoidal)
							{
								XYZ xyz = inverse.OfPoint(new XYZ(heXML_Point.Coordinate_Local_Grid.e, heXML_Point.Coordinate_Local_Grid.n, heXML_Point.Coordinate_Local_Grid.hghtE));
								familyInstance = Doc.Create.NewFamilyInstance(new XYZ(xyz.X, xyz.Y, xyz.Z), familySymbol, 0);
								if (heXML_Point.Coordinate_Local_Grid != null)
								{
									if (flag)
									{
										Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e);
										parameter.Set(Math.Round(HeXML_Details.Math_Unit(xyz.X, HeXML_Details.UnitConverter.FeetToMeter), 4));
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n);
										parameter.Set(Math.Round(HeXML_Details.Math_Unit(xyz.Y, HeXML_Details.UnitConverter.FeetToMeter), 4));
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_hghtE);
										parameter.Set(Math.Round(HeXML_Details.Math_Unit(xyz.Z, HeXML_Details.UnitConverter.FeetToMeter), 4));
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO);
										if (heXML_Point.Coordinate_Local_Grid.hghthO != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.hghthO != 1.7976931348623157E+308)
										{
											parameter.Set(Math.Round(HeXML_Details.Math_Unit(heXML_Point.Coordinate_Local_Grid.hghthO, HeXML_Details.UnitConverter.FeetToMeter), 4));
										}
										else
										{
											parameter.Set(-999999);
										}
									}
									else
									{
										Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e);
										parameter.Set(xyz.X);
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n);
										parameter.Set(xyz.Y);
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_hghtE);
										parameter.Set(xyz.Z);
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO);
										if (heXML_Point.Coordinate_Local_Grid.hghthO != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.hghthO != 1.7976931348623157E+308)
										{
											parameter.Set(heXML_Point.Coordinate_Local_Grid.hghthO);
										}
										else
										{
											parameter.Set(-999999);
										}
									}
								}
							}
							else if (usedHeight == RevitDocument.usedHeight.none)
							{
								XYZ xyz2 = inverse.OfPoint(new XYZ(heXML_Point.Coordinate_Local_Grid.e, heXML_Point.Coordinate_Local_Grid.n, 0.0));
								familyInstance = Doc.Create.NewFamilyInstance(new XYZ(xyz2.X, xyz2.Y, xyz2.Z), familySymbol, 0);
								if (heXML_Point.Coordinate_Local_Grid != null)
								{
									if (flag)
									{
										Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e);
										parameter.Set(Math.Round(HeXML_Details.Math_Unit(xyz2.X, HeXML_Details.UnitConverter.FeetToMeter), 4));
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n);
										parameter.Set(Math.Round(HeXML_Details.Math_Unit(xyz2.Y, HeXML_Details.UnitConverter.FeetToMeter), 4));
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_hghtE);
										if (heXML_Point.Coordinate_Local_Grid.hghtE != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.hghtE != 1.7976931348623157E+308)
										{
											parameter.Set(Math.Round(HeXML_Details.Math_Unit(heXML_Point.Coordinate_Local_Grid.hghtE, HeXML_Details.UnitConverter.FeetToMeter), 4));
										}
										else
										{
											parameter.Set(-999999);
										}
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO);
										if (heXML_Point.Coordinate_Local_Grid.hghthO != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.hghthO != 1.7976931348623157E+308)
										{
											parameter.Set(Math.Round(HeXML_Details.Math_Unit(heXML_Point.Coordinate_Local_Grid.hghthO, HeXML_Details.UnitConverter.FeetToMeter), 4));
										}
										else
										{
											parameter.Set(-999999);
										}
									}
									else
									{
										Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e);
										parameter.Set(xyz2.X);
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n);
										parameter.Set(xyz2.Y);
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_hghtE);
										if (heXML_Point.Coordinate_Local_Grid.hghtE != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.hghtE != 1.7976931348623157E+308)
										{
											parameter.Set(heXML_Point.Coordinate_Local_Grid.hghtE);
										}
										else
										{
											parameter.Set(-999999);
										}
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO);
										if (heXML_Point.Coordinate_Local_Grid.hghthO != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.hghthO != 1.7976931348623157E+308)
										{
											parameter.Set(heXML_Point.Coordinate_Local_Grid.hghthO);
										}
										else
										{
											parameter.Set(-999999);
										}
									}
								}
							}
							else if (usedHeight == RevitDocument.usedHeight.orthometric)
							{
								XYZ xyz3 = inverse.OfPoint(new XYZ(heXML_Point.Coordinate_Local_Grid.e, heXML_Point.Coordinate_Local_Grid.n, heXML_Point.Coordinate_Local_Grid.hghthO));
								familyInstance = Doc.Create.NewFamilyInstance(new XYZ(xyz3.X, xyz3.Y, xyz3.Z), familySymbol, 0);
								if (heXML_Point.Coordinate_Local_Grid != null)
								{
									if (flag)
									{
										Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e);
										parameter.Set(Math.Round(HeXML_Details.Math_Unit(xyz3.X, HeXML_Details.UnitConverter.FeetToMeter), 4));
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n);
										parameter.Set(Math.Round(HeXML_Details.Math_Unit(xyz3.Y, HeXML_Details.UnitConverter.FeetToMeter), 4));
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO);
										parameter.Set(Math.Round(HeXML_Details.Math_Unit(xyz3.Z, HeXML_Details.UnitConverter.FeetToMeter), 4));
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_hghtE);
										if (heXML_Point.Coordinate_Local_Grid.hghtE != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.hghtE != 1.7976931348623157E+308)
										{
											parameter.Set(Math.Round(HeXML_Details.Math_Unit(heXML_Point.Coordinate_Local_Grid.hghtE, HeXML_Details.UnitConverter.FeetToMeter), 4));
										}
										else
										{
											parameter.Set(-999999);
										}
									}
									else
									{
										Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_e);
										parameter.Set(xyz3.X);
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_n);
										parameter.Set(xyz3.Y);
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO);
										parameter.Set(xyz3.Z);
										parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_hghtE);
										if (heXML_Point.Coordinate_Local_Grid.hghtE != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Grid.hghtE != 1.7976931348623157E+308)
										{
											parameter.Set(heXML_Point.Coordinate_Local_Grid.hghtE);
										}
										else
										{
											parameter.Set(-999999);
										}
									}
								}
							}
							if (heXML_Point.UniqueID != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_UniqueID);
								parameter.Set(heXML_Point.UniqueID);
							}
							if (heXML_Point.Class != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_Class);
								parameter.Set(heXML_Point.Class);
							}
							if (heXML_Point.Subclass != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_SubClass);
								parameter.Set(heXML_Point.Subclass);
							}
							if (heXML_Point.LineworkFlag != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LineworkFlag);
								parameter.Set(heXML_Point.LineworkFlag);
							}
							if (heXML_Point.OriginalCoordSysKind != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_OriginalCoordSysKind);
								parameter.Set(heXML_Point.OriginalCoordSysKind);
							}
							if (heXML_Point.OriginalGeodeticDatumKind != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_OriginalGeodeticDatumKind);
								parameter.Set(heXML_Point.OriginalGeodeticDatumKind);
							}
							if (heXML_Point.OriginalHeightKind != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_OriginalHeightKind);
								parameter.Set(heXML_Point.OriginalHeightKind);
							}
							if (heXML_Point.Coordinate_WGS84_Cartesian != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_x);
								if (heXML_Point.Coordinate_WGS84_Cartesian.x != -1.7976931348623157E+308 && heXML_Point.Coordinate_WGS84_Cartesian.x != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_WGS84_Cartesian.x);
								}
								else
								{
									parameter.Set(-999999);
								}
								parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_y);
								if (heXML_Point.Coordinate_WGS84_Cartesian.y != -1.7976931348623157E+308 && heXML_Point.Coordinate_WGS84_Cartesian.y != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_WGS84_Cartesian.y);
								}
								else
								{
									parameter.Set(-999999);
								}
								parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_z);
								if (heXML_Point.Coordinate_WGS84_Cartesian.z != -1.7976931348623157E+308 && heXML_Point.Coordinate_WGS84_Cartesian.z != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_WGS84_Cartesian.z);
								}
								else
								{
									parameter.Set(-999999);
								}
							}
							if (heXML_Point.Coordinate_WGS84_Geodetic != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_lat);
								if (heXML_Point.Coordinate_WGS84_Geodetic.lat != -1.7976931348623157E+308 && heXML_Point.Coordinate_WGS84_Geodetic.lat != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_WGS84_Geodetic.lat);
								}
								else
								{
									parameter.Set(-999999);
								}
								parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_lon);
								if (heXML_Point.Coordinate_WGS84_Geodetic.lon != -1.7976931348623157E+308 && heXML_Point.Coordinate_WGS84_Geodetic.lon != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_WGS84_Geodetic.lon);
								}
								else
								{
									parameter.Set(-999999);
								}
								parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_hghtO);
								if (heXML_Point.Coordinate_WGS84_Geodetic.hghthO != -1.7976931348623157E+308 && heXML_Point.Coordinate_WGS84_Geodetic.hghthO != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_WGS84_Geodetic.hghthO);
								}
								else
								{
									parameter.Set(-999999);
								}
								parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_hghtE);
								if (heXML_Point.Coordinate_WGS84_Geodetic.hghtE != -1.7976931348623157E+308 && heXML_Point.Coordinate_WGS84_Geodetic.hghtE != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_WGS84_Geodetic.hghtE);
								}
								else
								{
									parameter.Set(-999999);
								}
							}
							if (heXML_Point.Coordinate_Local_Cartesian != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_x);
								if (heXML_Point.Coordinate_Local_Cartesian.x != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Cartesian.x != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_Local_Cartesian.x);
								}
								else
								{
									parameter.Set(-999999);
								}
								parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_y);
								if (heXML_Point.Coordinate_Local_Cartesian.y != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Cartesian.y != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_Local_Cartesian.y);
								}
								else
								{
									parameter.Set(-999999);
								}
								parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_z);
								if (heXML_Point.Coordinate_Local_Cartesian.z != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Cartesian.z != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_Local_Cartesian.z);
								}
								else
								{
									parameter.Set(-999999);
								}
							}
							if (heXML_Point.Coordinate_Local_Geodetic != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_lat);
								if (heXML_Point.Coordinate_Local_Geodetic.lat != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Geodetic.lat != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_Local_Geodetic.lat);
								}
								else
								{
									parameter.Set(-999999);
								}
								parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_lon);
								if (heXML_Point.Coordinate_Local_Geodetic.lon != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Geodetic.lon != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_Local_Geodetic.lon);
								}
								else
								{
									parameter.Set(-999999);
								}
								parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_hghtO);
								if (heXML_Point.Coordinate_Local_Geodetic.hghthO != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Geodetic.hghthO != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_Local_Geodetic.hghthO);
								}
								else
								{
									parameter.Set(-999999);
								}
								parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_hghtE);
								if (heXML_Point.Coordinate_Local_Geodetic.hghtE != -1.7976931348623157E+308 && heXML_Point.Coordinate_Local_Geodetic.hghtE != 1.7976931348623157E+308)
								{
									parameter.Set(heXML_Point.Coordinate_Local_Geodetic.hghtE);
								}
								else
								{
									parameter.Set(-999999);
								}
							}
							if (heXML_Point.PointCode != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCode);
								parameter.Set(heXML_Point.PointCode);
							}
							if (heXML_Point.PointCodeDesc != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeDesc);
								parameter.Set(heXML_Point.PointCodeDesc);
							}
							if (heXML_Point.PointCodeInformation != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeInformation);
								parameter.Set(heXML_Point.PointCodeInformation);
							}
							if (heXML_Point.PointCodeColor != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeColor);
								parameter.Set(heXML_Point.PointCodeColor);
							}
							if (heXML_Point.PointCodeGroup != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeGroup);
								parameter.Set(heXML_Point.PointCodeGroup);
							}
							if (heXML_Point.PointCodeLinework != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeLinework);
								parameter.Set(heXML_Point.PointCodeLinework);
							}
							if (heXML_Point.ListPointCodeAttributes != null && heXML_Point.ListPointCodeAttributes.Count != 0)
							{
								for (int j = 0; j < heXML_Point.ListPointCodeAttributes.Count; j++)
								{
									Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeAttribute + (j + 1).ToString());
									parameter.Set(heXML_Point.ListPointCodeAttributes[j]);
								}
							}
							if (heXML_Point.OnboardImages != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_OnboardImages);
								parameter.Set(heXML_Point.OnboardImages);
							}
							if (heXML_Point.Annotation1 != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_Annotation1);
								parameter.Set(heXML_Point.Annotation1);
							}
							if (heXML_Point.Annotation2 != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_Annotation2);
								parameter.Set(heXML_Point.Annotation2);
							}
							if (heXML_Point.Annotation3 != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_Annotation3);
								parameter.Set(heXML_Point.Annotation3);
							}
							if (heXML_Point.Annotation4 != null)
							{
								Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_Annotation4);
								parameter.Set(heXML_Point.Annotation4);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003DC0 File Offset: 0x00001FC0
		public List<HeXML_Point> Select_HeXMLPoints(UIApplication uiApp, Document doc)
		{
			Selection selection = uiApp.ActiveUIDocument.Selection;
			List<HeXML_Point> list = new List<HeXML_Point>();
			IList<Reference> list2 = new List<Reference>();
			try
			{
				list2 = selection.PickObjects(1, "Please select the measurement points");
				if (list2 != null)
				{
					List<FamilyInstance> list3 = new List<FamilyInstance>();
					List<FamilyInstance> list4 = new List<FamilyInstance>();
					foreach (Reference reference in list2)
					{
						FamilyInstance familyInstance = doc.GetElement(reference.ElementId) as FamilyInstance;
						if (familyInstance != null)
						{
							if (familyInstance.Name == this.MeasurementFamilyPointTypName)
							{
								list3.Add(familyInstance);
							}
							ICollection<ElementId> subComponentIds = familyInstance.GetSubComponentIds();
							if (subComponentIds != null)
							{
								foreach (ElementId elementId in subComponentIds)
								{
									FamilyInstance familyInstance2 = doc.GetElement(elementId) as FamilyInstance;
									if (familyInstance2.Name == this.MeasurementFamilyPointTypName)
									{
										list4.Add(familyInstance2);
									}
								}
							}
							Element superComponent = familyInstance.SuperComponent;
							if (superComponent != null)
							{
								FamilyInstance familyInstance3 = superComponent as FamilyInstance;
								if (familyInstance3.Name == this.MeasurementFamilyPointTypName)
								{
									list4.Add(familyInstance3);
								}
							}
						}
					}
					if (list3.Count != 0)
					{
						foreach (HeXML_Point item in this.FamilyInstanceToHeXMLPoints(uiApp.ActiveUIDocument, list3))
						{
							list.Add(item);
						}
					}
					if (list4.Count != 0)
					{
						List<HeXML_Point> list5 = this.FamilyInstanceToHeXMLPoints(uiApp.ActiveUIDocument, list4);
						List<string> list6 = this.Get_FamilyParameterValue(this.MeasurementFamilyPointTypName, HeXML_Point_Strings.FamilyParameterName_UniqueID, doc);
						foreach (HeXML_Point heXML_Point in list5)
						{
							string text = this.Get_NextMeasurementPointUniqueID(list6);
							heXML_Point.UniqueID = text;
							list6.Add(text);
							heXML_Point.OriginalCoordSysKind = "Grid";
							heXML_Point.OriginalGeodeticDatumKind = "Local";
							heXML_Point.OriginalHeightKind = "orthometric";
							list.Add(heXML_Point);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
			return list;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00004074 File Offset: 0x00002274
		private List<HeXML_Point> FamilyInstanceToHeXMLPoints(UIDocument uidoc, List<FamilyInstance> List_FamilyInstance)
		{
			List<HeXML_Point> list = new List<HeXML_Point>();
			if (List_FamilyInstance != null && List_FamilyInstance.Count != 0)
			{
				Transform transformationMatrix = this.GetTransformationMatrix(uidoc.Document);
				foreach (FamilyInstance familyInstance in List_FamilyInstance)
				{
					if (familyInstance.Name == this.MeasurementFamilyPointTypName)
					{
						HeXML_Point heXML_Point = new HeXML_Point();
						Parameter parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_UniqueID);
						if (parameter != null)
						{
							heXML_Point.UniqueID = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_Class);
						if (parameter != null)
						{
							heXML_Point.Class = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_SubClass);
						if (parameter != null)
						{
							heXML_Point.Subclass = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LineworkFlag);
						if (parameter != null)
						{
							heXML_Point.LineworkFlag = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.Description_OriginalCoordSysKind);
						if (parameter != null)
						{
							heXML_Point.OriginalCoordSysKind = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_OriginalGeodeticDatumKind);
						if (parameter != null)
						{
							heXML_Point.OriginalGeodeticDatumKind = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_OriginalHeightKind);
						if (parameter != null)
						{
							heXML_Point.OriginalHeightKind = parameter.AsString();
						}
						Parameter parameter2 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_x);
						Parameter parameter3 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_y);
						Parameter parameter4 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84_Cartesian_z);
						if (parameter2 != null || parameter3 != null || parameter4 != null)
						{
							heXML_Point.Coordinate_WGS84_Cartesian = new HeXML_Point_Coordinates_Cartesian();
						}
						if (parameter2 != null)
						{
							double num = parameter2.AsDouble();
							if (num != -999999.0)
							{
								heXML_Point.Coordinate_WGS84_Cartesian.x = num;
							}
							else
							{
								heXML_Point.Coordinate_WGS84_Cartesian.x = double.MinValue;
							}
						}
						if (parameter3 != null)
						{
							double num2 = parameter3.AsDouble();
							if (num2 != -999999.0)
							{
								heXML_Point.Coordinate_WGS84_Cartesian.y = num2;
							}
							else
							{
								heXML_Point.Coordinate_WGS84_Cartesian.y = double.MinValue;
							}
						}
						if (parameter4 != null)
						{
							double num3 = parameter4.AsDouble();
							if (num3 != -999999.0)
							{
								heXML_Point.Coordinate_WGS84_Cartesian.z = num3;
							}
							else
							{
								heXML_Point.Coordinate_WGS84_Cartesian.z = double.MinValue;
							}
						}
						Parameter parameter5 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_lat);
						Parameter parameter6 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_lon);
						Parameter parameter7 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_hghtO);
						Parameter parameter8 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_WGS84Geodetic_hghtE);
						if (parameter5 != null || parameter6 != null || parameter7 != null || parameter8 != null)
						{
							heXML_Point.Coordinate_WGS84_Geodetic = new HeXML_Point_Coordinates_Geodetic();
						}
						if (parameter5 != null)
						{
							double num4 = parameter5.AsDouble();
							if (num4 != -999999.0)
							{
								heXML_Point.Coordinate_WGS84_Geodetic.lat = num4;
							}
							else
							{
								heXML_Point.Coordinate_WGS84_Geodetic.lat = double.MinValue;
							}
						}
						if (parameter6 != null)
						{
							double num5 = parameter6.AsDouble();
							if (num5 != -999999.0)
							{
								heXML_Point.Coordinate_WGS84_Geodetic.lon = num5;
							}
							else
							{
								heXML_Point.Coordinate_WGS84_Geodetic.lon = double.MinValue;
							}
						}
						if (parameter7 != null)
						{
							double num6 = parameter7.AsDouble();
							if (num6 != -999999.0)
							{
								heXML_Point.Coordinate_WGS84_Geodetic.hghthO = num6;
							}
							else
							{
								heXML_Point.Coordinate_WGS84_Geodetic.hghthO = double.MinValue;
							}
						}
						if (parameter8 != null)
						{
							double num7 = parameter8.AsDouble();
							if (num7 != -999999.0)
							{
								heXML_Point.Coordinate_WGS84_Geodetic.hghtE = num7;
							}
							else
							{
								heXML_Point.Coordinate_WGS84_Geodetic.hghtE = double.MinValue;
							}
						}
						Parameter parameter9 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_x);
						Parameter parameter10 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_y);
						Parameter parameter11 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalCartesian_z);
						if (parameter9 != null || parameter10 != null || parameter11 != null)
						{
							heXML_Point.Coordinate_Local_Cartesian = new HeXML_Point_Coordinates_Cartesian();
						}
						if (parameter9 != null)
						{
							double num8 = parameter9.AsDouble();
							if (num8 != -999999.0)
							{
								heXML_Point.Coordinate_Local_Cartesian.x = num8;
							}
							else
							{
								heXML_Point.Coordinate_Local_Cartesian.x = double.MinValue;
							}
						}
						if (parameter10 != null)
						{
							double num9 = parameter10.AsDouble();
							if (num9 != -999999.0)
							{
								heXML_Point.Coordinate_Local_Cartesian.y = num9;
							}
							else
							{
								heXML_Point.Coordinate_Local_Cartesian.y = double.MinValue;
							}
						}
						if (parameter11 != null)
						{
							double num10 = parameter11.AsDouble();
							if (num10 != -999999.0)
							{
								heXML_Point.Coordinate_Local_Cartesian.z = num10;
							}
							else
							{
								heXML_Point.Coordinate_Local_Cartesian.z = double.MinValue;
							}
						}
						Parameter parameter12 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_lat);
						Parameter parameter13 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_lon);
						Parameter parameter14 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_hghtO);
						Parameter parameter15 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGeodetic_hghtE);
						if (parameter12 != null || parameter13 != null || parameter14 != null || parameter15 != null)
						{
							heXML_Point.Coordinate_Local_Geodetic = new HeXML_Point_Coordinates_Geodetic();
						}
						if (parameter12 != null)
						{
							double num11 = parameter12.AsDouble();
							if (num11 != -999999.0)
							{
								heXML_Point.Coordinate_Local_Geodetic.lat = num11;
							}
							else
							{
								heXML_Point.Coordinate_Local_Geodetic.lat = double.MinValue;
							}
						}
						if (parameter13 != null)
						{
							double num12 = parameter13.AsDouble();
							if (num12 != -999999.0)
							{
								heXML_Point.Coordinate_Local_Geodetic.lon = num12;
							}
							else
							{
								heXML_Point.Coordinate_Local_Geodetic.lon = double.MinValue;
							}
						}
						if (parameter14 != null)
						{
							double num13 = parameter14.AsDouble();
							if (num13 != -999999.0)
							{
								heXML_Point.Coordinate_Local_Geodetic.hghthO = num13;
							}
							else
							{
								heXML_Point.Coordinate_Local_Geodetic.hghthO = double.MinValue;
							}
						}
						if (parameter15 != null)
						{
							double num14 = parameter15.AsDouble();
							if (num14 != -999999.0)
							{
								heXML_Point.Coordinate_Local_Geodetic.hghtE = num14;
							}
							else
							{
								heXML_Point.Coordinate_Local_Geodetic.hghtE = double.MinValue;
							}
						}
						heXML_Point.Coordinate_Local_Grid = new HeXML_Point_Coordinates_Grid();
						LocationPoint locationPoint = (LocationPoint)familyInstance.Location;
						double num15 = locationPoint.Point.X;
						double num16 = locationPoint.Point.Y;
						double num17 = locationPoint.Point.Z;
						XYZ xyz = transformationMatrix.OfPoint(new XYZ(num15, num16, num17));
						num15 = xyz.X;
						num16 = xyz.Y;
						num17 = xyz.Z;
						if (this.Detect_UnitType(uidoc.Document, 0).ToString().ToLower().Contains("meter"))
						{
							num15 = HeXML_Details.Math_Unit(num15, HeXML_Details.UnitConverter.FeetToMeter);
							num16 = HeXML_Details.Math_Unit(num16, HeXML_Details.UnitConverter.FeetToMeter);
							num17 = HeXML_Details.Math_Unit(num17, HeXML_Details.UnitConverter.FeetToMeter);
							num15 = Math.Round(num15, 4);
							num16 = Math.Round(num16, 4);
							num17 = Math.Round(num17, 4);
						}
						heXML_Point.Coordinate_Local_Grid.e = num15;
						heXML_Point.Coordinate_Local_Grid.n = num16;
						if (heXML_Point.OriginalHeightKind == "ellipsoidal")
						{
							if (locationPoint.Point.Z != -999999.0)
							{
								heXML_Point.Coordinate_Local_Grid.hghtE = num17;
							}
							else
							{
								heXML_Point.Coordinate_Local_Grid.hghtE = double.MinValue;
							}
							Parameter parameter16 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGird_hghtO);
							if (parameter16 != null)
							{
								double num18 = parameter16.AsDouble();
								if (num18 != -999999.0)
								{
									heXML_Point.Coordinate_Local_Grid.hghthO = num18;
								}
								else
								{
									heXML_Point.Coordinate_Local_Grid.hghthO = double.MinValue;
								}
							}
						}
						else if (heXML_Point.OriginalHeightKind == "undefined")
						{
							if (locationPoint.Point.Z != -999999.0)
							{
								heXML_Point.Coordinate_Local_Grid.hghtE = 0.0;
								heXML_Point.Coordinate_Local_Grid.hghthO = 0.0;
							}
						}
						else
						{
							if (locationPoint.Point.Z != -999999.0)
							{
								heXML_Point.Coordinate_Local_Grid.hghthO = num17;
							}
							else
							{
								heXML_Point.Coordinate_Local_Grid.hghthO = double.MinValue;
							}
							Parameter parameter17 = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_LocalGrid_hghtE);
							if (parameter17 != null)
							{
								double num19 = parameter17.AsDouble();
								if (num19 != -999999.0)
								{
									heXML_Point.Coordinate_Local_Grid.hghtE = num19;
								}
								else
								{
									heXML_Point.Coordinate_Local_Grid.hghtE = double.MinValue;
								}
							}
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCode);
						if (parameter != null)
						{
							heXML_Point.PointCode = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeDesc);
						if (parameter != null)
						{
							heXML_Point.PointCodeDesc = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeInformation);
						if (parameter != null)
						{
							heXML_Point.PointCodeInformation = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeColor);
						if (parameter != null)
						{
							heXML_Point.PointCodeColor = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeGroup);
						if (parameter != null)
						{
							heXML_Point.PointCodeGroup = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeLinework);
						if (parameter != null)
						{
							heXML_Point.PointCodeLinework = parameter.AsString();
						}
						for (int i = 1; i < 21; i++)
						{
							parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_PointCodeAttribute + i.ToString());
							if (parameter != null)
							{
								heXML_Point.ListPointCodeAttributes.Add(parameter.AsString());
							}
							else
							{
								heXML_Point.ListPointCodeAttributes.Add("");
							}
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_OnboardImages);
						if (parameter != null)
						{
							heXML_Point.OnboardImages = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_Annotation1);
						if (parameter != null)
						{
							heXML_Point.Annotation1 = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_Annotation2);
						if (parameter != null)
						{
							heXML_Point.Annotation2 = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_Annotation3);
						if (parameter != null)
						{
							heXML_Point.Annotation3 = parameter.AsString();
						}
						parameter = familyInstance.LookupParameter(HeXML_Point_Strings.FamilyParameterName_Annotation4);
						if (parameter != null)
						{
							heXML_Point.Annotation4 = parameter.AsString();
						}
						list.Add(heXML_Point);
					}
				}
			}
			return list;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00004AA8 File Offset: 0x00002CA8
		public Transform GetTransformationMatrix(Document document)
		{
			XYZ xyz = new XYZ(0.0, 0.0, 0.0);
			ProjectPosition projectPosition = document.ActiveProjectLocation.GetProjectPosition(xyz);
			return Transform.CreateTranslation(new XYZ(projectPosition.EastWest, projectPosition.NorthSouth, projectPosition.Elevation)).Multiply(Transform.CreateRotationAtPoint(new XYZ(0.0, 0.0, 1.0), projectPosition.Angle, xyz));
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00004B30 File Offset: 0x00002D30
		public DisplayUnitType Detect_UnitType(Document doc, UnitType UnitType)
		{
			return doc.GetUnits().GetFormatOptions(UnitType).DisplayUnits;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00004B44 File Offset: 0x00002D44
		public RevitDocument.UnitConverter Test_LinearUnitType_Agreement(Document doc, string LinearUnit_Import)
		{
			RevitDocument.UnitConverter result = RevitDocument.UnitConverter.None;
			if (LinearUnit_Import != null && LinearUnit_Import != "")
			{
				string text = this.Detect_UnitType(doc, 0).ToString().ToLower();
				string text2 = LinearUnit_Import.ToLower();
				if ((text2.Contains("feet") || text2.Contains("foot") || text2.Contains("inches")) && text.Contains("meter"))
				{
					result = RevitDocument.UnitConverter.FeetToMeter;
				}
				if (text2.Contains("meter") && (text.Contains("feet") || text.Contains("foot") || text.Contains("inches")))
				{
					result = RevitDocument.UnitConverter.MeterToFeet;
				}
			}
			return result;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00004BFC File Offset: 0x00002DFC
		public RevitDocument.UnitConverter Test_LinearUnitType_AgreementIntern(string LinearUnit_Import)
		{
			RevitDocument.UnitConverter result = RevitDocument.UnitConverter.None;
			if (LinearUnit_Import != null && LinearUnit_Import != "")
			{
				string text = "feet";
				string text2 = LinearUnit_Import.ToLower();
				if ((text2.Contains("feet") || text2.Contains("foot") || text2.Contains("inches")) && text.Contains("meter"))
				{
					result = RevitDocument.UnitConverter.FeetToMeter;
				}
				if (text2.Contains("meter") && (text.Contains("feet") || text.Contains("foot") || text.Contains("inches")))
				{
					result = RevitDocument.UnitConverter.MeterToFeet;
				}
			}
			return result;
		}

		// Token: 0x04000005 RID: 5
		public ToolStripProgressBar ToolStripProgressBar;

		// Token: 0x04000006 RID: 6
		public ToolStripStatusLabel ToolStripStatusLabel;

		// Token: 0x04000007 RID: 7
		public string MeasurementFamilyPointTypName = "Leica Measurement Point";

		// Token: 0x04000008 RID: 8
		public string MeasurementFamilyPointPath = "Leica Measurement Point Family.rfa";

		// Token: 0x04000009 RID: 9
		public string MeasurementFamilyPointName = "Leica Measurement Point Family";

		// Token: 0x0200000D RID: 13
		private enum usedHeight
		{
			// Token: 0x0400002B RID: 43
			orthometric,
			// Token: 0x0400002C RID: 44
			ellipsoidal,
			// Token: 0x0400002D RID: 45
			none
		}

		// Token: 0x0200000E RID: 14
		public enum UnitConverter
		{
			// Token: 0x0400002F RID: 47
			FeetToMeter,
			// Token: 0x04000030 RID: 48
			MeterToFeet,
			// Token: 0x04000031 RID: 49
			None
		}
	}
}
