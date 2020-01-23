using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LeicaBimLinkNet.Objects;

namespace LeicaBimLinkGUI.UserControls
{
	// Token: 0x02000002 RID: 2
	public class uc_HeXML_DetailTreeview : UserControl
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000001 RID: 1 RVA: 0x00002048 File Offset: 0x00000248
		// (remove) Token: 0x06000002 RID: 2 RVA: 0x00002080 File Offset: 0x00000280
		public event uc_HeXML_DetailTreeview.OnCheckChanged OnTreeNodeCheckChanged;

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020B5 File Offset: 0x000002B5
		// (set) Token: 0x06000004 RID: 4 RVA: 0x000020BD File Offset: 0x000002BD
		public bool CheckBoxes
		{
			get
			{
				return this._CheckBoxes;
			}
			set
			{
				this._CheckBoxes = value;
				this.treeView.CheckBoxes = this._CheckBoxes;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020D7 File Offset: 0x000002D7
		public int NodesCount
		{
			get
			{
				return this.treeView.Nodes.Count;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020E9 File Offset: 0x000002E9
		public uc_HeXML_DetailTreeview()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002110 File Offset: 0x00000310
		public new void Load(List<object> List_HeXMLObjects)
		{
			NumberFormatInfo numberFormat = new CultureInfo("de-DE", false).NumberFormat;
			numberFormat.NumberDecimalSeparator = ".";
			this._List_HeXMLObjects = List_HeXMLObjects;
			this.Clear();
			if (List_HeXMLObjects.Count != 0)
			{
				TreeNode treeNode = new TreeNode();
				treeNode.Text = "HeXML";
				treeNode.Name = "HeXML";
				TreeNode treeNode2 = new TreeNode();
				treeNode2.Text = "Alignments";
				treeNode2.Name = "Alignments";
				if (this._CheckBoxes)
				{
					treeNode2.Checked = true;
				}
				TreeNode treeNode3 = new TreeNode();
				treeNode3.Text = "Areas";
				treeNode3.Name = "Areas";
				if (this._CheckBoxes)
				{
					treeNode3.Checked = true;
				}
				TreeNode treeNode4 = new TreeNode();
				treeNode4.Text = "Corridors";
				treeNode4.Name = "Corridors";
				if (this._CheckBoxes)
				{
					treeNode4.Checked = true;
				}
				TreeNode treeNode5 = new TreeNode();
				treeNode5.Text = "Gradients";
				treeNode5.Name = "Gradients";
				if (this._CheckBoxes)
				{
					treeNode5.Checked = true;
				}
				TreeNode treeNode6 = new TreeNode();
				treeNode6.Text = "Lines";
				treeNode6.Name = "Lines";
				if (this._CheckBoxes)
				{
					treeNode6.Checked = true;
				}
				TreeNode treeNode7 = new TreeNode();
				treeNode7.Text = "Points";
				treeNode7.Name = "Points";
				if (this._CheckBoxes)
				{
					treeNode7.Checked = true;
				}
				TreeNode treeNode8 = new TreeNode();
				treeNode8.Text = "Point group";
				treeNode8.Name = "PointGroup";
				if (this._CheckBoxes)
				{
					treeNode8.Checked = true;
				}
				TreeNode treeNode9 = new TreeNode();
				treeNode9.Text = "Surfaces";
				treeNode9.Name = "Surfaces";
				if (this._CheckBoxes)
				{
					treeNode9.Checked = true;
				}
				TreeNode treeNode10 = new TreeNode();
				treeNode10.Text = "Surveys";
				treeNode10.Name = "Surveys";
				if (this._CheckBoxes)
				{
					treeNode10.Checked = true;
				}
				foreach (object obj in List_HeXMLObjects)
				{
					Type type = obj.GetType();
					if (type == typeof(HeXML_Alignment))
					{
						HeXML_Alignment heXML_Alignment = (HeXML_Alignment)obj;
						TreeNode treeNode11 = new TreeNode();
						treeNode11.Text = heXML_Alignment.Description_Name;
						heXML_Alignment.Intern_Name = "Alignment_" + Convert.ToString(treeNode2.Nodes.Count);
						treeNode11.Name = heXML_Alignment.Intern_Name;
						if (this._CheckBoxes)
						{
							treeNode11.Checked = true;
						}
						foreach (HeXML_Profile heXML_Profile in heXML_Alignment.Profiles)
						{
							TreeNode treeNode12 = new TreeNode();
							treeNode12.Text = heXML_Profile.Description_Name;
							heXML_Profile.Intern_Name = "Profile_" + Convert.ToString(treeNode11.Nodes.Count);
							treeNode12.Name = heXML_Profile.Intern_Name;
							if (this._CheckBoxes)
							{
								treeNode12.Checked = true;
							}
							treeNode11.Nodes.Add(treeNode12);
						}
						foreach (string text in heXML_Alignment.Additional_Description)
						{
							TreeNode treeNode13 = new TreeNode();
							treeNode13.Text = text;
							treeNode13.Name = "Description";
							treeNode11.Nodes.Add(treeNode13);
						}
						treeNode2.Nodes.Add(treeNode11);
					}
					else if (type == typeof(HeXML_Area))
					{
						HeXML_Area heXML_Area = (HeXML_Area)obj;
						TreeNode treeNode14 = new TreeNode();
						treeNode14.Text = heXML_Area.Description_Name;
						heXML_Area.Intern_Name = "Area_" + Convert.ToString(treeNode3.Nodes.Count);
						treeNode14.Name = heXML_Area.Intern_Name;
						if (this._CheckBoxes)
						{
							treeNode14.Checked = true;
						}
						foreach (string text2 in heXML_Area.Additional_Description)
						{
							TreeNode treeNode15 = new TreeNode();
							treeNode15.Text = text2;
							treeNode15.Name = "Description";
							treeNode14.Nodes.Add(treeNode15);
						}
						treeNode3.Nodes.Add(treeNode14);
					}
					else if (type == typeof(HeXML_Corridor))
					{
						HeXML_Corridor heXML_Corridor = (HeXML_Corridor)obj;
						TreeNode treeNode16 = new TreeNode();
						treeNode16.Text = heXML_Corridor.Description_Name;
						heXML_Corridor.Intern_Name = "Corridor_" + Convert.ToString(treeNode4.Nodes.Count);
						treeNode16.Name = heXML_Corridor.Intern_Name;
						if (this._CheckBoxes)
						{
							treeNode16.Checked = true;
						}
						foreach (string text3 in heXML_Corridor.Additional_Description)
						{
							TreeNode treeNode17 = new TreeNode();
							treeNode17.Text = text3;
							treeNode17.Name = "Description";
							treeNode16.Nodes.Add(treeNode17);
						}
						treeNode4.Nodes.Add(treeNode16);
					}
					else if (type == typeof(HeXML_Gradient))
					{
						HeXML_Gradient heXML_Gradient = (HeXML_Gradient)obj;
						TreeNode treeNode18 = new TreeNode();
						treeNode18.Text = heXML_Gradient.Description_Name;
						foreach (string text4 in heXML_Gradient.Additional_Description)
						{
							TreeNode treeNode19 = new TreeNode();
							treeNode19.Text = text4;
							treeNode19.Name = "Description";
							treeNode18.Nodes.Add(treeNode19);
						}
						treeNode5.Nodes.Add(treeNode18);
					}
					else if (type == typeof(HeXML_Line))
					{
						HeXML_Line heXML_Line = (HeXML_Line)obj;
						TreeNode treeNode20 = new TreeNode();
						treeNode20.Text = heXML_Line.Description_Name;
						foreach (string text5 in heXML_Line.Additional_Description)
						{
							TreeNode treeNode21 = new TreeNode();
							treeNode21.Text = text5;
							treeNode21.Name = "Description";
							treeNode20.Nodes.Add(treeNode21);
						}
						treeNode6.Nodes.Add(treeNode20);
					}
					else if (type == typeof(HeXML_Point))
					{
						HeXML_Point heXML_Point = (HeXML_Point)obj;
						TreeNode treeNode22 = new TreeNode();
						treeNode22.Text = "Point";
						if (heXML_Point.UniqueID != null)
						{
							TreeNode treeNode23 = treeNode22;
							treeNode23.Text = treeNode23.Text + " (" + heXML_Point.UniqueID + ")";
						}
						foreach (string text6 in heXML_Point.Additional_Description)
						{
							TreeNode treeNode24 = new TreeNode();
							treeNode24.Text = text6;
							treeNode24.Name = "Description";
							treeNode22.Nodes.Add(treeNode24);
						}
						TreeNode treeNode25 = new TreeNode(HeXML_Point_Strings.Description_UniqueID + ": ");
						if (heXML_Point.UniqueID != null)
						{
							TreeNode treeNode26 = treeNode25;
							treeNode26.Text += heXML_Point.UniqueID;
						}
						else
						{
							TreeNode treeNode27 = treeNode25;
							treeNode27.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode25);
						TreeNode treeNode28 = new TreeNode(HeXML_Point_Strings.Description_Class + ": ");
						if (heXML_Point.Class != null)
						{
							TreeNode treeNode29 = treeNode28;
							treeNode29.Text += heXML_Point.Class;
						}
						else
						{
							TreeNode treeNode30 = treeNode28;
							treeNode30.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode28);
						TreeNode treeNode31 = new TreeNode(HeXML_Point_Strings.Description_SubClass + ": ");
						if (heXML_Point.Subclass != null)
						{
							TreeNode treeNode32 = treeNode31;
							treeNode32.Text += heXML_Point.Subclass;
						}
						else
						{
							TreeNode treeNode33 = treeNode31;
							treeNode33.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode31);
						TreeNode treeNode34 = new TreeNode(HeXML_Point_Strings.Description_LineworkFlag + ": ");
						if (heXML_Point.LineworkFlag != null)
						{
							TreeNode treeNode35 = treeNode34;
							treeNode35.Text += heXML_Point.LineworkFlag;
						}
						else
						{
							TreeNode treeNode36 = treeNode34;
							treeNode36.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode34);
						TreeNode treeNode37 = new TreeNode(HeXML_Point_Strings.Description_OriginalCoordSysKind + ": ");
						if (heXML_Point.OriginalCoordSysKind != null)
						{
							TreeNode treeNode38 = treeNode37;
							treeNode38.Text += heXML_Point.OriginalCoordSysKind;
						}
						else
						{
							TreeNode treeNode39 = treeNode37;
							treeNode39.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode37);
						TreeNode treeNode40 = new TreeNode(HeXML_Point_Strings.Description_OriginalGeodeticDatumKind + ": ");
						if (heXML_Point.OriginalGeodeticDatumKind != null)
						{
							TreeNode treeNode41 = treeNode40;
							treeNode41.Text += heXML_Point.OriginalGeodeticDatumKind;
						}
						else
						{
							TreeNode treeNode42 = treeNode40;
							treeNode42.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode40);
						TreeNode treeNode43 = new TreeNode(HeXML_Point_Strings.Description_OriginalHeightKind + ": ");
						if (heXML_Point.OriginalHeightKind != null)
						{
							TreeNode treeNode44 = treeNode43;
							treeNode44.Text += heXML_Point.OriginalHeightKind;
						}
						else
						{
							TreeNode treeNode45 = treeNode43;
							treeNode45.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode43);
						TreeNode treeNode46 = new TreeNode(HeXML_Point_Strings.Description_WGS84_Cartesian + ": ");
						if (heXML_Point.Coordinate_WGS84_Cartesian != null)
						{
							TreeNode node = new TreeNode("x: " + Math.Round(heXML_Point.Coordinate_WGS84_Cartesian.x, 3).ToString(numberFormat));
							treeNode46.Nodes.Add(node);
							TreeNode node2 = new TreeNode("y: " + Math.Round(heXML_Point.Coordinate_WGS84_Cartesian.y, 3).ToString(numberFormat));
							treeNode46.Nodes.Add(node2);
							TreeNode node3 = new TreeNode("z: " + Math.Round(heXML_Point.Coordinate_WGS84_Cartesian.z, 3).ToString(numberFormat));
							treeNode46.Nodes.Add(node3);
						}
						treeNode22.Nodes.Add(treeNode46);
						TreeNode treeNode47 = new TreeNode(HeXML_Point_Strings.Description_WGS84Geodetic + ": ");
						if (heXML_Point.Coordinate_WGS84_Geodetic != null)
						{
							TreeNode node4 = new TreeNode("lat: " + Math.Round(heXML_Point.Coordinate_WGS84_Geodetic.lat, 3).ToString(numberFormat));
							treeNode47.Nodes.Add(node4);
							TreeNode node5 = new TreeNode("lon: " + Math.Round(heXML_Point.Coordinate_WGS84_Geodetic.lon, 3).ToString(numberFormat));
							treeNode47.Nodes.Add(node5);
							TreeNode node6 = new TreeNode("hghtE: " + Math.Round(heXML_Point.Coordinate_WGS84_Geodetic.hghtE, 3).ToString(numberFormat));
							treeNode47.Nodes.Add(node6);
							TreeNode node7 = new TreeNode("hghtO: " + Math.Round(heXML_Point.Coordinate_WGS84_Geodetic.hghthO, 3).ToString(numberFormat));
							treeNode47.Nodes.Add(node7);
						}
						treeNode22.Nodes.Add(treeNode47);
						TreeNode treeNode48 = new TreeNode(HeXML_Point_Strings.Description_WGS84Local + ": ");
						if (heXML_Point.Coordinate_Local_Cartesian != null)
						{
							TreeNode node8 = new TreeNode("x: " + Math.Round(heXML_Point.Coordinate_Local_Cartesian.x, 3).ToString(numberFormat));
							treeNode48.Nodes.Add(node8);
							TreeNode node9 = new TreeNode("y: " + Math.Round(heXML_Point.Coordinate_Local_Cartesian.y, 3).ToString(numberFormat));
							treeNode48.Nodes.Add(node9);
							TreeNode node10 = new TreeNode("z: " + Math.Round(heXML_Point.Coordinate_Local_Cartesian.z, 3).ToString(numberFormat));
							treeNode48.Nodes.Add(node10);
						}
						treeNode22.Nodes.Add(treeNode48);
						TreeNode treeNode49 = new TreeNode(HeXML_Point_Strings.Description_GeodeticLocal + ": ");
						if (heXML_Point.Coordinate_Local_Geodetic != null)
						{
							TreeNode node11 = new TreeNode("lat: " + Math.Round(heXML_Point.Coordinate_Local_Geodetic.lat, 3).ToString(numberFormat));
							treeNode49.Nodes.Add(node11);
							TreeNode node12 = new TreeNode("lon: " + Math.Round(heXML_Point.Coordinate_Local_Geodetic.lon, 3).ToString(numberFormat));
							treeNode49.Nodes.Add(node12);
							TreeNode node13 = new TreeNode("hghtE: " + Math.Round(heXML_Point.Coordinate_Local_Geodetic.hghtE, 3).ToString(numberFormat));
							treeNode49.Nodes.Add(node13);
							TreeNode node14 = new TreeNode("hghtO: " + Math.Round(heXML_Point.Coordinate_Local_Geodetic.hghthO, 3).ToString(numberFormat));
							treeNode49.Nodes.Add(node14);
						}
						treeNode22.Nodes.Add(treeNode49);
						TreeNode treeNode50 = new TreeNode(HeXML_Point_Strings.Description_GridLocal + ": ");
						if (heXML_Point.Coordinate_Local_Grid != null)
						{
							TreeNode node15 = new TreeNode("e: " + Math.Round(heXML_Point.Coordinate_Local_Grid.e, 3).ToString(numberFormat));
							treeNode50.Nodes.Add(node15);
							TreeNode node16 = new TreeNode("n: " + Math.Round(heXML_Point.Coordinate_Local_Grid.n, 3).ToString(numberFormat));
							treeNode50.Nodes.Add(node16);
							TreeNode node17 = new TreeNode("hghtE: " + Math.Round(heXML_Point.Coordinate_Local_Grid.hghtE, 3).ToString(numberFormat));
							treeNode50.Nodes.Add(node17);
							TreeNode node18 = new TreeNode("hghtO: " + Math.Round(heXML_Point.Coordinate_Local_Grid.hghthO, 3).ToString(numberFormat));
							treeNode50.Nodes.Add(node18);
						}
						treeNode22.Nodes.Add(treeNode50);
						TreeNode treeNode51 = new TreeNode(HeXML_Point_Strings.Description_PointCode + ": ");
						if (heXML_Point.PointCode != null)
						{
							TreeNode treeNode52 = treeNode51;
							treeNode52.Text += heXML_Point.PointCode;
						}
						else
						{
							TreeNode treeNode53 = treeNode51;
							treeNode53.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode51);
						TreeNode treeNode54 = new TreeNode(HeXML_Point_Strings.Description_PointCodeDesc + ": ");
						if (heXML_Point.PointCodeDesc != null)
						{
							TreeNode treeNode55 = treeNode54;
							treeNode55.Text += heXML_Point.PointCodeDesc;
						}
						else
						{
							TreeNode treeNode56 = treeNode54;
							treeNode56.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode54);
						TreeNode treeNode57 = new TreeNode(HeXML_Point_Strings.Description_PointCodeInformation + ": ");
						if (heXML_Point.PointCodeInformation != null)
						{
							TreeNode treeNode58 = treeNode57;
							treeNode58.Text += heXML_Point.PointCodeInformation;
						}
						else
						{
							TreeNode treeNode59 = treeNode57;
							treeNode59.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode57);
						TreeNode treeNode60 = new TreeNode(HeXML_Point_Strings.Description_PointCodeColor + ": ");
						if (heXML_Point.PointCodeColor != null)
						{
							TreeNode treeNode61 = treeNode60;
							treeNode61.Text += heXML_Point.PointCodeColor;
						}
						else
						{
							TreeNode treeNode62 = treeNode60;
							treeNode62.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode60);
						TreeNode treeNode63 = new TreeNode(HeXML_Point_Strings.Description_PointCodeGroup + ": ");
						if (heXML_Point.PointCodeGroup != null)
						{
							TreeNode treeNode64 = treeNode63;
							treeNode64.Text += heXML_Point.PointCodeGroup;
						}
						else
						{
							TreeNode treeNode65 = treeNode63;
							treeNode65.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode63);
						TreeNode treeNode66 = new TreeNode(HeXML_Point_Strings.Description_PointCodeLinework + ": ");
						if (heXML_Point.PointCodeLinework != null)
						{
							TreeNode treeNode67 = treeNode66;
							treeNode67.Text += heXML_Point.PointCodeLinework;
						}
						else
						{
							TreeNode treeNode68 = treeNode66;
							treeNode68.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode66);
						TreeNode treeNode69 = new TreeNode(HeXML_Point_Strings.Description_PointCodeAttributes);
						if (heXML_Point.ListPointCodeAttributes != null && heXML_Point.ListPointCodeAttributes.Count != 0)
						{
							for (int i = 0; i < heXML_Point.ListPointCodeAttributes.Count; i++)
							{
								string text7 = heXML_Point.ListPointCodeAttributes[i];
								TreeNode treeNode70 = new TreeNode(HeXML_Point_Strings.Description_PointCodeAttribute + (i + 1).ToString() + ": ");
								if (text7 != null)
								{
									TreeNode treeNode71 = treeNode70;
									treeNode71.Text += text7;
								}
								else
								{
									TreeNode treeNode72 = treeNode70;
									treeNode72.Text += "-";
								}
								treeNode69.Nodes.Add(treeNode70);
							}
						}
						else
						{
							TreeNode treeNode73 = treeNode69;
							treeNode73.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode69);
						TreeNode treeNode74 = new TreeNode(HeXML_Point_Strings.Description_OnboardImages + ": ");
						if (heXML_Point.OnboardImages != null)
						{
							TreeNode treeNode75 = treeNode74;
							treeNode75.Text += heXML_Point.OnboardImages;
						}
						else
						{
							TreeNode treeNode76 = treeNode74;
							treeNode76.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode74);
						TreeNode treeNode77 = new TreeNode(HeXML_Point_Strings.Description_Annotation1 + ": ");
						if (heXML_Point.Annotation1 != null)
						{
							TreeNode treeNode78 = treeNode77;
							treeNode78.Text += heXML_Point.Annotation1;
						}
						else
						{
							TreeNode treeNode79 = treeNode77;
							treeNode79.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode77);
						TreeNode treeNode80 = new TreeNode(HeXML_Point_Strings.Description_Annotation2 + ": ");
						if (heXML_Point.Annotation2 != null)
						{
							TreeNode treeNode81 = treeNode80;
							treeNode81.Text += heXML_Point.Annotation2;
						}
						else
						{
							TreeNode treeNode82 = treeNode80;
							treeNode82.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode80);
						TreeNode treeNode83 = new TreeNode(HeXML_Point_Strings.Description_Annotation3 + ": ");
						if (heXML_Point.Annotation3 != null)
						{
							TreeNode treeNode84 = treeNode83;
							treeNode84.Text += heXML_Point.Annotation3;
						}
						else
						{
							TreeNode treeNode85 = treeNode83;
							treeNode85.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode83);
						TreeNode treeNode86 = new TreeNode(HeXML_Point_Strings.Description_Annotation4 + ": ");
						if (heXML_Point.Annotation4 != null)
						{
							TreeNode treeNode87 = treeNode86;
							treeNode87.Text += heXML_Point.Annotation4;
						}
						else
						{
							TreeNode treeNode88 = treeNode86;
							treeNode88.Text += "-";
						}
						treeNode22.Nodes.Add(treeNode86);
						treeNode7.Nodes.Add(treeNode22);
					}
					else if (type == typeof(HeXML_PointGroup))
					{
						HeXML_PointGroup heXML_PointGroup = (HeXML_PointGroup)obj;
						TreeNode treeNode89 = new TreeNode();
						treeNode89.Text = heXML_PointGroup.Description_Name;
						heXML_PointGroup.Intern_Name = "PointGroup_" + Convert.ToString(treeNode8.Nodes.Count);
						treeNode89.Name = heXML_PointGroup.Intern_Name;
						if (this._CheckBoxes)
						{
							treeNode89.Checked = true;
						}
						foreach (string text8 in heXML_PointGroup.Additional_Description)
						{
							TreeNode treeNode90 = new TreeNode();
							treeNode90.Text = text8;
							treeNode90.Name = "Description";
							treeNode89.Nodes.Add(treeNode90);
						}
						treeNode8.Nodes.Add(treeNode89);
					}
					else if (type == typeof(HeXML_Surface))
					{
						HeXML_Surface heXML_Surface = (HeXML_Surface)obj;
						TreeNode treeNode91 = new TreeNode();
						treeNode91.Text = heXML_Surface.Description_Name;
						heXML_Surface.Intern_Name = "Surface_" + Convert.ToString(treeNode9.Nodes.Count);
						treeNode91.Name = heXML_Surface.Intern_Name;
						if (this._CheckBoxes)
						{
							treeNode91.Checked = true;
						}
						foreach (string text9 in heXML_Surface.Additional_Description)
						{
							TreeNode treeNode92 = new TreeNode();
							treeNode92.Text = text9;
							treeNode92.Name = "Description";
							treeNode91.Nodes.Add(treeNode92);
						}
						treeNode9.Nodes.Add(treeNode91);
					}
					else if (type == typeof(HeXML_Survey))
					{
						HeXML_Survey heXML_Survey = (HeXML_Survey)obj;
						TreeNode treeNode93 = new TreeNode();
						treeNode93.Text = heXML_Survey.Description_Name;
						foreach (string text10 in heXML_Survey.Additional_Description)
						{
							TreeNode treeNode94 = new TreeNode();
							treeNode94.Text = text10;
							treeNode94.Name = "Description";
							treeNode93.Nodes.Add(treeNode94);
						}
						treeNode10.Nodes.Add(treeNode93);
					}
				}
				if (treeNode2.Nodes.Count != 0)
				{
					treeNode.Nodes.Add(treeNode2);
					treeNode2.Expand();
				}
				if (treeNode3.Nodes.Count != 0)
				{
					treeNode.Nodes.Add(treeNode3);
					treeNode3.Expand();
				}
				if (treeNode4.Nodes.Count != 0)
				{
					treeNode.Nodes.Add(treeNode4);
					treeNode4.Expand();
				}
				if (treeNode5.Nodes.Count != 0)
				{
					treeNode.Nodes.Add(treeNode5);
					treeNode5.Expand();
				}
				if (treeNode6.Nodes.Count != 0)
				{
					treeNode.Nodes.Add(treeNode6);
					treeNode6.Expand();
				}
				if (treeNode7.Nodes.Count != 0)
				{
					treeNode7.Text = treeNode7.Text + " (" + treeNode7.Nodes.Count.ToString() + ")";
					treeNode.Nodes.Add(treeNode7);
					treeNode7.Expand();
				}
				if (treeNode8.Nodes.Count != 0)
				{
					treeNode.Nodes.Add(treeNode8);
					treeNode8.Expand();
				}
				if (treeNode9.Nodes.Count != 0)
				{
					treeNode.Nodes.Add(treeNode9);
					treeNode9.Expand();
				}
				if (treeNode10.Nodes.Count != 0)
				{
					treeNode.Nodes.Add(treeNode10);
					treeNode10.Expand();
				}
				this.treeView.Nodes.Add(treeNode);
				treeNode.Expand();
				this.Remove_CheckBox();
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00003A6C File Offset: 0x00001C6C
		public void Clear()
		{
			this.treeView.Nodes.Clear();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00003A80 File Offset: 0x00001C80
		public List<object> Get_CheckedHeXMLObjects()
		{
			List<object> list = new List<object>();
			if (this._CheckBoxes)
			{
				if (this.treeView.Nodes.Count != 0)
				{
					bool flag = false;
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					bool flag6 = false;
					bool flag7 = false;
					bool flag8 = false;
					bool flag9 = false;
					TreeNode node = null;
					TreeNode node2 = null;
					TreeNode node3 = null;
					TreeNode node4 = null;
					TreeNode node5 = null;
					foreach (object obj in this.treeView.Nodes[0].Nodes)
					{
						TreeNode treeNode = (TreeNode)obj;
						if (treeNode.Checked)
						{
							if (treeNode.Text == "Alignments")
							{
								node = treeNode;
								if (treeNode.Checked)
								{
									flag = true;
								}
							}
							else if (treeNode.Text == "Areas")
							{
								node5 = treeNode;
								if (treeNode.Checked)
								{
									flag2 = true;
								}
							}
							else if (treeNode.Text == "Corridors")
							{
								node2 = treeNode;
								if (treeNode.Checked)
								{
									flag3 = true;
								}
							}
							else if (treeNode.Text == "Gradients")
							{
								if (treeNode.Checked)
								{
									flag4 = true;
								}
							}
							else if (treeNode.Text == "Lines")
							{
								if (treeNode.Checked)
								{
									flag5 = true;
								}
							}
							else if (treeNode.Text.StartsWith("Points"))
							{
								if (treeNode.Checked)
								{
									flag6 = true;
								}
							}
							else if (treeNode.Text.StartsWith("Point group"))
							{
								node3 = treeNode;
								if (treeNode.Checked)
								{
									flag7 = true;
								}
							}
							else if (treeNode.Text == "Surfaces")
							{
								node4 = treeNode;
								if (treeNode.Checked)
								{
									flag8 = true;
								}
							}
							else if (treeNode.Text == "Surveys" && treeNode.Checked)
							{
								flag9 = true;
							}
						}
					}
					for (int i = 0; i < this._List_HeXMLObjects.Count; i++)
					{
						TreeNode treeNode2 = null;
						object obj2 = this._List_HeXMLObjects[i];
						Type type = obj2.GetType();
						if (type == typeof(HeXML_Alignment) && flag)
						{
							HeXML_Alignment heXML_Alignment = (HeXML_Alignment)obj2;
							if (this.ChildNode_IsChecked(node, heXML_Alignment.Intern_Name, out treeNode2))
							{
								if (treeNode2 != null)
								{
									foreach (HeXML_Profile heXML_Profile in heXML_Alignment.Profiles)
									{
										TreeNode treeNode3 = null;
										heXML_Profile.IsSelected = this.ChildNode_IsChecked(treeNode2, heXML_Profile.Intern_Name, out treeNode3);
									}
								}
								list.Add(obj2);
							}
						}
						else if (type == typeof(HeXML_Area) && flag2)
						{
							HeXML_Area heXML_Area = (HeXML_Area)obj2;
							if (this.ChildNode_IsChecked(node5, heXML_Area.Intern_Name, out treeNode2))
							{
								list.Add(obj2);
							}
						}
						else if (type == typeof(HeXML_Corridor) && flag3)
						{
							HeXML_Corridor heXML_Corridor = (HeXML_Corridor)obj2;
							if (this.ChildNode_IsChecked(node2, heXML_Corridor.Intern_Name, out treeNode2))
							{
								list.Add(obj2);
							}
						}
						else if (type == typeof(HeXML_Gradient) && flag4)
						{
							list.Add(obj2);
						}
						else if (type == typeof(HeXML_Line) && flag5)
						{
							list.Add(obj2);
						}
						else if (type == typeof(HeXML_Point) && flag6)
						{
							list.Add(obj2);
						}
						else if (type == typeof(HeXML_PointGroup) && flag7)
						{
							HeXML_PointGroup heXML_PointGroup = (HeXML_PointGroup)obj2;
							if (this.ChildNode_IsChecked(node3, heXML_PointGroup.Intern_Name, out treeNode2))
							{
								list.Add(obj2);
							}
						}
						else if (type == typeof(HeXML_Surface) && flag8)
						{
							HeXML_Surface heXML_Surface = (HeXML_Surface)obj2;
							if (this.ChildNode_IsChecked(node4, heXML_Surface.Intern_Name, out treeNode2))
							{
								list.Add(obj2);
							}
						}
						else if (type == typeof(HeXML_Survey) && flag9)
						{
							list.Add(obj2);
						}
					}
				}
			}
			else
			{
				list = this._List_HeXMLObjects;
			}
			return list;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00003F28 File Offset: 0x00002128
		private bool ChildNode_IsChecked(TreeNode Node, string SearchName, out TreeNode SearchedChildNode)
		{
			SearchedChildNode = null;
			if (Node != null)
			{
				foreach (object obj in Node.Nodes)
				{
					TreeNode treeNode = (TreeNode)obj;
					if (treeNode.Name == SearchName)
					{
						SearchedChildNode = treeNode;
						if (treeNode.Checked)
						{
							return true;
						}
						return false;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00003FA4 File Offset: 0x000021A4
		private void CheckChange_Event()
		{
			if (this.OnTreeNodeCheckChanged != null)
			{
				bool @checked = false;
				if (this.treeView.Nodes.Count != 0)
				{
					using (IEnumerator enumerator = this.treeView.Nodes[0].Nodes.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (((TreeNode)enumerator.Current).Checked)
							{
								@checked = true;
								break;
							}
						}
					}
				}
				this.OnTreeNodeCheckChanged(@checked);
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00004038 File Offset: 0x00002238
		private void Remove_CheckBox()
		{
			this._List_DontRemoveCheckBox.Clear();
			this._List_DontRemoveCheckBox.Add("Alignment");
			this._List_DontRemoveCheckBox.Add("Profile");
			this._List_DontRemoveCheckBox.Add("Corridor");
			this._List_DontRemoveCheckBox.Add("PointGroup");
			this._List_DontRemoveCheckBox.Add("Surface");
			this._List_DontRemoveCheckBox.Add("Points");
			this._List_DontRemoveCheckBox.Add("Lines");
			this._List_DontRemoveCheckBox.Add("Area");
			foreach (object obj in this.treeView.Nodes)
			{
				TreeNode node = (TreeNode)obj;
				this.Remove_CheckBoxRek(node);
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00004124 File Offset: 0x00002324
		private void Remove_CheckBoxRek(TreeNode node)
		{
			bool flag = true;
			foreach (string value in this._List_DontRemoveCheckBox)
			{
				if (node.Name.Contains(value))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				this.Remove_CheckBox(this.treeView, node);
			}
			foreach (object obj in node.Nodes)
			{
				TreeNode node2 = (TreeNode)obj;
				this.Remove_CheckBoxRek(node2);
			}
		}

		// Token: 0x0600000E RID: 14
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Messsge, IntPtr Parameter, ref uc_HeXML_DetailTreeview.Item lParameter);

		// Token: 0x0600000F RID: 15 RVA: 0x000041E4 File Offset: 0x000023E4
		private void Remove_CheckBox(TreeView TreeView, TreeNode TreeNode)
		{
			uc_HeXML_DetailTreeview.Item item = default(uc_HeXML_DetailTreeview.Item);
			item.hItem = TreeNode.Handle;
			item.mask = 8;
			item.stateMask = 61440;
			item.state = 0;
			uc_HeXML_DetailTreeview.SendMessage(TreeView.Handle, 4415, IntPtr.Zero, ref item);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000423C File Offset: 0x0000243C
		private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (!this.StopCheckedEvent)
			{
				this.StopCheckedEvent = true;
				try
				{
					if (e.Node != null)
					{
						foreach (object obj in e.Node.Nodes)
						{
							TreeNode treeNode = (TreeNode)obj;
							treeNode.Checked = e.Node.Checked;
							foreach (object obj2 in treeNode.Nodes)
							{
								((TreeNode)obj2).Checked = treeNode.Checked;
							}
						}
						if (e.Node.Parent != null)
						{
							bool flag = false;
							using (IEnumerator enumerator = e.Node.Parent.Nodes.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									if (((TreeNode)enumerator.Current).Checked)
									{
										flag = true;
										break;
									}
								}
							}
							if (flag != e.Node.Parent.Checked)
							{
								e.Node.Parent.Checked = flag;
							}
						}
						if (e.Node.Parent.Parent != null)
						{
							bool flag2 = false;
							using (IEnumerator enumerator = e.Node.Parent.Parent.Nodes.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									if (((TreeNode)enumerator.Current).Checked)
									{
										flag2 = true;
										break;
									}
								}
							}
							if (flag2 != e.Node.Parent.Parent.Checked)
							{
								e.Node.Parent.Parent.Checked = flag2;
							}
						}
						this.Remove_CheckBox();
					}
				}
				catch (Exception ex)
				{
					ex.ToString();
				}
				this.StopCheckedEvent = false;
				this.CheckChange_Event();
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000044A0 File Offset: 0x000026A0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000044C0 File Offset: 0x000026C0
		private void InitializeComponent()
		{
			this.treeView = new TreeView();
			base.SuspendLayout();
			this.treeView.Dock = DockStyle.Fill;
			this.treeView.Location = new Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.Size = new Size(311, 257);
			this.treeView.TabIndex = 0;
			this.treeView.AfterCheck += this.treeView_AfterCheck;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.treeView);
			base.Name = "uc_HeXML_DetailTreeview";
			base.Size = new Size(311, 257);
			base.ResumeLayout(false);
		}

		// Token: 0x04000002 RID: 2
		private bool StopCheckedEvent;

		// Token: 0x04000003 RID: 3
		private bool _CheckBoxes;

		// Token: 0x04000004 RID: 4
		private List<object> _List_HeXMLObjects = new List<object>();

		// Token: 0x04000005 RID: 5
		private List<string> _List_DontRemoveCheckBox = new List<string>();

		// Token: 0x04000006 RID: 6
		private const int State = 8;

		// Token: 0x04000007 RID: 7
		private const int StateImgMask = 61440;

		// Token: 0x04000008 RID: 8
		private const int First = 4352;

		// Token: 0x04000009 RID: 9
		private const int FirstItem = 4415;

		// Token: 0x0400000A RID: 10
		private IContainer components;

		// Token: 0x0400000B RID: 11
		private TreeView treeView;

		// Token: 0x02000005 RID: 5
		// (Invoke) Token: 0x06000022 RID: 34
		public delegate void OnCheckChanged(bool Checked);

		// Token: 0x02000006 RID: 6
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 8)]
		private struct Item
		{
			// Token: 0x04000015 RID: 21
			public int mask;

			// Token: 0x04000016 RID: 22
			public IntPtr hItem;

			// Token: 0x04000017 RID: 23
			public int state;

			// Token: 0x04000018 RID: 24
			public int stateMask;

			// Token: 0x04000019 RID: 25
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszText;

			// Token: 0x0400001A RID: 26
			public int cchTextMax;

			// Token: 0x0400001B RID: 27
			public int iImage;

			// Token: 0x0400001C RID: 28
			public int iSelectedImage;

			// Token: 0x0400001D RID: 29
			public int cChildren;

			// Token: 0x0400001E RID: 30
			public IntPtr lParam;
		}
	}
}
