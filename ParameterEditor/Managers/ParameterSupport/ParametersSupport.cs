#region + Using Directives

using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit.DB;
using ParameterEditor.DebugWin.DebugWinSupport;

#endregion


// projname: ParameterEditor.Support
// itemname: Elements
// username: jeffs
// created:  9/21/2019 3:51:27 PM


namespace ParameterEditor.Managers.ParameterSupport
{
	// parameterdetails
	// parameterinfo
	// parameterdata
	// parameterfacts
	// parametermanagement
	// parameterdescription
	// parameteradmin
	// parametercontrol
	// parametermanager


	// gets and organizes the parameters for a element type group from revit
	public class ParametersSupport
	{

		public static Dictionary<string, IList<Parameter>> GetAllTypes(ElementTypeGroup type)
		{
			Dictionary<string, IList<Parameter>> Types = new Dictionary<string, IList<Parameter>>();

			IList<Element> elements = GetElementsOfType(type);

			foreach (Element el in elements)
			{
				IList<Parameter> p = new List<Parameter>(GetParameterList(el));

				Types.Add(el.Name, p);
			}
			return Types;
		}

		private static IList<Parameter> GetParameterList(Element el)
		{
			ParameterMap pm = el.ParametersMap;
			return el.GetOrderedParameters();
		}

		//types:
		// *** see element type group enum in revit documentation
		// Text Note Types: TextNoteType
		// dimension type:  LinearDimensionType, RadialDimensionType, AngularDimensionType, ArcLengthDimensionType, DiameterDimensionType
		// filled region type:  FilledRegionType
		// fill pattern element: ??
		// wall type:  WallType
		// spot dimension: SpotElevationType, SpotCoordinateType, SpotSlopeType

		public static IList<Element> GetElementsOfType(ElementTypeGroup type = ElementTypeGroup.TextNoteType)
		{
			FilteredElementCollector elemCollector =
				new FilteredElementCollector(ParameterEdit.Doc).OfClass(GetElementType(type));

			return elemCollector.ToElements();
		}


		private static Type GetElementType(ElementTypeGroup eType)
		{
			Type type;

			switch (eType)
			{
			case ElementTypeGroup.TextNoteType:
				{
					type = typeof(TextNoteType);
					break;
				}
			case ElementTypeGroup.LinearDimensionType:
				{
					type = typeof(DimensionType);
					break;
				}
			case ElementTypeGroup.FilledRegionType:
				{
					type = typeof(FilledRegionType);
					break;
				}
			case ElementTypeGroup.WallType:
				{
					type = typeof(WallType);
					break;
				}
			case ElementTypeGroup.SpotCoordinateType:
				{
					type = typeof(SpotDimensionType);
					break;
				}
			default:
				{
					type = typeof(TextNoteType);
					break;
				}
			}

			return type;
		}


	#if DEBUG
		public static StringBuilder GetAllElements(ElementTypeGroup type = ElementTypeGroup.TextNoteType)
		{
			return ParameterDebugSupport.GetAllElements(type);
		}
	#endif

		public static string GetParameterValue(Parameter p)
		{
			string result = (p.AsValueString() ?? "").Trim();

			if (String.IsNullOrWhiteSpace(result))
			{
				switch (p.StorageType)
				{
				case StorageType.Double:
					{
						result = p.AsValueString();
						break;
					}
				case StorageType.ElementId:
					{
						ElementId id = new ElementId(p.AsElementId().IntegerValue);
						Element e = ParameterEdit.Doc.GetElement(id);

						result = e?.Name ?? "Null Element";
						break;
					}
				case StorageType.Integer:
					{
						result = p.AsInteger().ToString();
						break;
					}
				case StorageType.None:
					{
						result = p.AsValueString();
						break;
					}
				case StorageType.String:
					{
						result = p.AsString();
						break;
					}
				}
			}

			return result;
		}

	}
}