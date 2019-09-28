#region + Using Directives

using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ParameterEditor.Managers.ParameterSupport;
using static UtilityLibrary.MessageUtilities;

#endregion


// projname: ParameterEditor.Support.DebugSupport
// itemname: ParameterDebugSupport
// username: jeffs
// created:  9/22/2019 6:14:00 AM


namespace ParameterEditor.DebugWin.DebugWinSupport
{
	public class ParameterDebugSupport
	{
		public const int PAD_RIGHT = 18;

		private const int FIRSTPASS_MAX = 19;
		private static int firstPassItem = 0;
		private static bool[] firstPass = new bool[FIRSTPASS_MAX + 1];


		public static StringBuilder GetAllElements(ElementTypeGroup type = ElementTypeGroup.TextNoteType)
		{
			StringBuilder sb = new StringBuilder();

			ICollection<Element> elements = ParametersSupport.GetElementsOfType(type);

			foreach (Element el in elements)
			{
				firstPassItem = 0;

				sb.AppendLine(ListParameters(el).ToString());
			}

			return sb;
		}

		private static StringBuilder ListParameters(Element el)
		{
			StringBuilder sb = new StringBuilder();

			// this provides some extra and un-needed parameters dd
			ParameterSet ps = el.Parameters;

			// both are basically the same
			ParameterMap pm = el.ParametersMap;
			IList<Parameter> ipm = el.GetOrderedParameters();


			sb.AppendLine(logMsgDbS("name", el.Name));

			// no good - this is null
			//			sb.AppendLine(logMsgDbS("category", el.Category.Name));

			string header = "value".PadRight(PAD_RIGHT);
			header += " :: " + "storage type".PadRight(PAD_RIGHT);
			header += " :: " + "read-only".PadRight(PAD_RIGHT);
			//			header += " :: " + "user-modifiable".PadRight(PAD_RIGHT);
			//			header += " :: " + "has value".PadRight(PAD_RIGHT);
			header += " :: " + "param type".PadRight(PAD_RIGHT);
			header += " :: " + "unit type".PadRight(PAD_RIGHT);
			header += " :: " + "disp unit type".PadRight(PAD_RIGHT + 6);
			header += " :: " + "param group".PadRight(PAD_RIGHT);


			sb.AppendLine(logMsgDbS("definition name", header));

			foreach (Parameter p in ipm)
			{
				sb.AppendLine(logMsgDbS(p.Definition.Name, ParameterValue(p)));
			}

			return sb;
		}

		public static StringBuilder ListTypes(Dictionary<string, IList<Parameter>> types)
		{
			StringBuilder sb = new StringBuilder();

			foreach (KeyValuePair<string, IList<Parameter>> kvp in types)
			{
				sb.Append(listParameters(kvp.Key, kvp.Value));
			}

			return sb;
		}

		private static StringBuilder listParameters(string name, IList<Parameter> ipm)
		{
			StringBuilder sb = new StringBuilder("\n");

			sb.AppendLine(logMsgDbS("name", name));

			// no good - this is null
			//			sb.AppendLine(logMsgDbS("category", el.Category.Name));

//			sb.Append(logMsgDbS("definition name", ""));
//			sb.Append("value".PadRight(PAD_RIGHT));
//			sb.Append(" :: ");
//			sb.Append("storage type".PadRight(PAD_RIGHT));
//			sb.Append(" :: ");
//			sb.Append("read-only".PadRight(PAD_RIGHT));
//			sb.Append(" :: ");
//			sb.Append("param type".PadRight(PAD_RIGHT));
//			sb.Append(" :: ");
//			sb.Append("unit type".PadRight(PAD_RIGHT));
//			sb.Append(" :: ");
//			sb.Append("disp unit type".PadRight(PAD_RIGHT + 6));
//			sb.Append(" :: ");
//			sb.Append("param group".PadRight(PAD_RIGHT));
//			sb.Append("\n");

			sb.Append(Header());


			foreach (Parameter p in ipm)
			{
				sb.AppendLine(logMsgDbS(p.Definition.Name, ParameterValue(p)));
			}
			return sb;
		}

		private static StringBuilder Header()
		{
			StringBuilder sb1 = new StringBuilder();
			StringBuilder sb2 = new StringBuilder();

			sb1.Append(logMsgDbS("definition name", ""));
			sb2.Append(logMsgDbS("---------------", ""));
			sb1.Append("value".PadRight(PAD_RIGHT));
			sb2.Append("".PadRight(PAD_RIGHT, '-'));
			sb1.Append(" :: ");
			sb2.Append(" :: ");
			sb1.Append("storage type".PadRight(PAD_RIGHT));
			sb2.Append("".PadRight(PAD_RIGHT, '-'));
			sb1.Append(" :: ");
			sb2.Append(" :: ");
			sb1.Append("read-only".PadRight(PAD_RIGHT));
			sb2.Append("".PadRight(PAD_RIGHT, '-'));
			sb1.Append(" :: ");
			sb2.Append(" :: ");
			sb1.Append("param type".PadRight(PAD_RIGHT));
			sb2.Append("".PadRight(PAD_RIGHT, '-'));
			sb1.Append(" :: ");
			sb2.Append(" :: ");
			sb1.Append("unit type".PadRight(PAD_RIGHT));
			sb2.Append("".PadRight(PAD_RIGHT, '-'));
			sb1.Append(" :: ");
			sb2.Append(" :: ");
			sb1.Append("disp unit type".PadRight(PAD_RIGHT + 6));
			sb2.Append("".PadRight(PAD_RIGHT + 6, '-'));
			sb1.Append(" :: ");
			sb2.Append(" :: ");
			sb1.Append("param group".PadRight(PAD_RIGHT));
			sb2.Append("".PadRight(PAD_RIGHT, '-'));
			sb1.Append("\n");
			sb2.Append("\n");


			return sb1.Append(sb2);
		}


		private static string ParameterValue(Parameter p)
		{
			string storageType = p.StorageType.ToString();
			string result = (p.AsValueString() ?? "").Trim();

			if (String.IsNullOrWhiteSpace(result))
			{
				switch (p.StorageType)
				{
				case StorageType.Double:
					{
						storageType = "double";
						result = p.AsValueString();
						break;
					}
				case StorageType.ElementId:
					{
						storageType = "element id";
						ElementId id = new ElementId(p.AsElementId().IntegerValue);
						Element e = ParameterEdit.Doc.GetElement(id);

						result = e?.Name ?? "Null Element";
						break;
					}
				case StorageType.Integer:
					{
						storageType = "integer";
						result = p.AsInteger().ToString();
						break;
					}
				case StorageType.None:
					{
						storageType = "none";
						result = p.AsValueString();
						break;
					}
				case StorageType.String:
					{
						storageType = "string";
						result = p.AsString();
						break;
					}
				}
			}


			if (p.StorageType == StorageType.ElementId && !ParameterDebugSupport.firstPass[ParameterDebugSupport.firstPassItem])
			{
				ElementArray ea = GetSimilarForElement(p.AsElementId());

				ElementType et = ParameterEdit.Doc.GetElement(p.AsElementId()) as ElementType;

				if (ea != null)
				{
					ParameterDebugSupport.firstPass[ParameterDebugSupport.firstPassItem++] = true;

					logMsgDbLn2("getting similar", et.Name + " :: " + et.FamilyName);

					foreach (Element e in ea)
					{
						logMsgDbLn2("type", e.Name);
					}
				}
			}
//
//			UnitType u = UnitType.UT_Undefined;
//			ParameterType pt = ParameterType.Acceleration;


			result = result.PadRight(18);
			result += " :: " + storageType.ToString().PadRight(ParameterDebugSupport.PAD_RIGHT);


			//not valid info
			result += " :: " + p.IsReadOnly.ToString().PadRight(ParameterDebugSupport.PAD_RIGHT);

			// not valid info
			//			result += " :: " + p.UserModifiable.ToString().PadRight(PAD_RIGHT);

			// valid info
			//			result += " :: " + p.HasValue.ToString().PadRight(PAD_RIGHT);

			result += " :: " + p.Definition.ParameterType.ToString().PadRight(ParameterDebugSupport.PAD_RIGHT);
			result += " :: " + p.Definition.UnitType.ToString().PadRight(ParameterDebugSupport.PAD_RIGHT);

			try
			{
				result += " :: " + p.DisplayUnitType.ToString().PadRight(ParameterDebugSupport.PAD_RIGHT + 6);
			}
			catch
			{
				result += " :: " + "(no unit type)".PadRight(ParameterDebugSupport.PAD_RIGHT + 6);
			}

			result += " :: " + p.Definition.ParameterGroup.ToString().PadRight(ParameterDebugSupport.PAD_RIGHT);


			return result;
		}


		private static ElementArray GetSimilarForElement(ElementId elementId)
		{
			ElementArray ea = null;

			if (elementId != null)
			{
				ElementType et = ParameterEdit.Doc.GetElement(elementId) as ElementType;

				if (et != null)
				{
					ea = new ElementArray();

					foreach (ElementId eid in et.GetSimilarTypes())
					{
						ea.Append(ParameterEdit.Doc.GetElement(eid));
					}
				}
			}

			return ea;
		}

		private void GetAllFamilies()
		{
			StringBuilder sb = new StringBuilder();

			FilteredElementCollector collector =
				new FilteredElementCollector(ParameterEdit.Doc);

			ICollection<Element> elements =
				collector.OfClass(typeof(Family)).ToElements();

			foreach (Element element in elements)
			{
				sb.AppendLine(element.Name);
			}

			TaskDialog.Show("Parameter Edit", sb.ToString());
		}
	}
}
