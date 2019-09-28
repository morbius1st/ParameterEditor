#region + Using Directives

using System.Collections.Generic;
using Autodesk.Revit.DB;

#endregion


// projname: ParameterVue.ListBoxManager.FamilyData
// itemname: TestData
// username: jeffs
// created:  8/19/2019 10:08:12 PM


namespace ParameterEditor.DebugWin.DebugWinSupport
{

// load test data into a dictionary

	public static class TestData
	{
		public static Dictionary<string, List<Parameter>> TestFamilyData = new Dictionary<string, List<Parameter>>();

		static TestData()
		{
			LoadData();
		}

		private static void LoadData()
		{
			TestFamilyData = new Dictionary<string, List<Parameter>>();
//
//			List<Parameter> px = new List<Parameter>();
//
//			//                               0                 1                         2           3          4                  5
//			//                                               parameter                 storage     parameter   unit             display unit  
//			//                             value             name                      type        type        type             type
//			px.Add(DefineParameter(new [] {"Arial"          , "Text Font"            , "string "  , "Text "  , "UT_Number"      , "(no unit type)"       }));
//			px.Add(DefineParameter(new [] {"3/32\""         , "Text Size"			 , "Double "  , "105"    , "UT_SheetLength" , "DUT_FRACTIONAL_INCHES"}));
//			px.Add(DefineParameter(new [] {"1/2\" "         , "Tab Size"			 , "Double "  , "105"    , "UT_SheetLength ", "DUT_FRACTIONAL_INCHES"}));
//			px.Add(DefineParameter(new [] {"0"              , "Color"				 , "integer"  , "Invalid", "UT_Number"      , "(no unit type)"       }));
//			px.Add(DefineParameter(new [] {"1"              , "Line Weight"			 , "Integer"  , "Invalid", "UT_Number"      , "(no unit type)"       }));
//			px.Add(DefineParameter(new [] {"No "            , "Bold"				 , "Integer"  , "YesNo"  , "UT_Number"      , "(no unit type)"       }));
//			px.Add(DefineParameter(new [] {"No "            , "Italic"				 , "Integer"  , "YesNo"  , "UT_Number"      , "(no unit type)"       }));
//			px.Add(DefineParameter(new [] {"No "            , "Underline"			 , "Integer"  , "YesNo"  , "UT_Number"      , "(no unit type)"       }));
//			px.Add(DefineParameter(new [] {"Opaque "        , "Background"			 , "Integer"  , "Invalid", "UT_Number"      , "(no unit type)"       }));
//			px.Add(DefineParameter(new [] {"1"              , "Width Factor"		 , "Double "  , "Number ", "UT_Number"      , "DUT_GENERAL "         }));
//			px.Add(DefineParameter(new [] {"No "            , "Show Border"			 , "Integer"  , "YesNo"  , "UT_Number"      , "(no unit type)"       }));
//			px.Add(DefineParameter(new [] {"1/128\" "       , "Leader/Border Offset" , "Double "  , "105"    , "UT_SheetLength ", "DUT_FRACTIONAL_INCHES"}));
//			px.Add(DefineParameter(new [] {"Arrow 30 Degree", "Leader Arrowhead"     , "ElementId", "Invalid", "UT_Number"      , "(no unit type)"       }));
//
//			TestFamilyData.Add("3/32\" Arial", px);
//
//			px = new List<Parameter>();
//
//
//			px.Add(DefineParameter(new [] {"Arial"          , "Text Font"            , "string "  , "Text "  , "UT_Number"      , "(no unit type)"       }));
//			px.Add(DefineParameter(new [] {"1/8\" "         , "Text Size"            , "Double "  , "105"    , "UT_SheetLength ", "DUT_FRACTIONAL_INCHES" }));
//			px.Add(DefineParameter(new [] {"15/32\" "       , "Tab Size"             , "Double "  , "105"    , "UT_SheetLength ", "DUT_FRACTIONAL_INCHES" }));
//			px.Add(DefineParameter(new [] {"0"              , "Color"                , "integer"  , "Invalid", "UT_Number"      , "(no unit type)"        }));
//			px.Add(DefineParameter(new [] {"1"              , "Line Weight"          , "Integer"  , "Invalid", "UT_Number"      , "(no unit type)"        }));
//			px.Add(DefineParameter(new [] {"No "            , "Bold"                 , "Integer"  , "YesNo"  , "UT_Number"      , "(no unit type)"        }));
//			px.Add(DefineParameter(new [] {"No "            , "Italic"               , "Integer"  , "YesNo"  , "UT_Number"      , "(no unit type)"        }));
//			px.Add(DefineParameter(new [] {"No "            , "Underline"            , "Integer"  , "YesNo"  , "UT_Number"      , "(no unit type)"        }));
//			px.Add(DefineParameter(new [] {"Opaque "        , "Background"           , "Integer"  , "Invalid", "UT_Number"      , "(no unit type)"        }));
//			px.Add(DefineParameter(new [] {"1"              , "Width Factor"         , "Double "  , "Number ", "UT_Number"      , "DUT_GENERAL "          }));
//			px.Add(DefineParameter(new [] {"No "            , "Show Border"          , "Integer"  , "YesNo"  , "UT_Number"      , "(no unit type)"        }));
//			px.Add(DefineParameter(new [] {"5/64\""         , "Leader/Border Offset" , "Double "  , "105"    , "UT_SheetLength ", "DUT_FRACTIONAL_INCHES" }));
//			px.Add(DefineParameter(new [] {"Arrow 30 Degree", "Leader Arrowhead"     , "ElementId", "Invalid", "UT_Number"      , "(no unit type)"        }));
//
//			TestFamilyData.Add("Schedule Default", px);
//
//			px = new List<Parameter>();

		}
//
//		public static  Parameter DefineParameter(string value, string name,
//			string storageType, string paramType, string unitType, string dispUnitType)
//		{
//			Parameter p = new Parameter();
//			p.Definition = new InternalDefinition();
//
//			p.Definition.Name = name;
//
//			StorageType st;
//			if (Enum.TryParse(storageType, true, out st))
//				p.StorageType = st;
//			else
//				p.StorageType = StorageType.None;
//
//			ParameterType pt;
//			if (paramType.Equals("105"))
//			{
//				p.Definition.ParameterType = ParameterType.Length;
//			}
//			else
//			{
//				if (Enum.TryParse(paramType, true, out pt))
//					p.Definition.ParameterType = pt;
//				else
//					p.Definition.ParameterType = ParameterType.Invalid;
//			}
//
//			UnitType ut;
//			if (Enum.TryParse(unitType, true, out ut))
//				p.Definition.UnitType = ut;
//			else
//				p.Definition.UnitType = UnitType.UT_Undefined;
//
//			DisplayUnitType dut;
//			if (Enum.TryParse(dispUnitType, true, out dut))
//				p.DisplayUnitType = dut;
//			else
//				p.DisplayUnitType = DisplayUnitType.DUT_UNDEFINED;
//
//			p.SetValueString(value);
//
//			return p;
//		}
//
//		public static Parameter DefineParameter(string[] pd)
//		{
//			return DefineParameter(pd[0], pd[1], pd[2], pd[3], pd[4], pd[5]);
//		}


	}
}











































