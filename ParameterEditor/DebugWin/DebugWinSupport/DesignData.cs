using System.Collections.ObjectModel;
using Autodesk.Revit.DB;
using ParameterEditor.Managers.ParameterInfo;
using ParameterValue = ParameterEditor.Managers.ParameterInfo.ParameterValue;

namespace ParameterEditor.DebugWin.DebugWinSupport
{

	class DesignData
	{
		public static void LoadDesignData(ObservableCollection<ParameterData> Pd, ColumnData Cd)
		{
			// I need to create date for the above, already initialized data structures

			Pd = new ObservableCollection<ParameterData>();
			Cd = new ColumnData();

			ObservableCollection<AParameterValue> p;
			ParameterData pd;

			pd = new ParameterData("Family 1");
			pd.Selected = false;
			Pd.Add(pd);

			p = Pd[Pd.Count - 1].ParameterValues;

			Cd.ColumnSpecs.Add(new ColumnSpec("Text Size"));
			p.Add(new ParameterValueDbg("1/32\""));
			
			Cd.ColumnSpecs.Add(new ColumnSpec("Text Font"));
			p.Add(new ParameterValueDbg("Arial1"));
			
			Cd.ColumnSpecs.Add(new ColumnSpec("Tab Size"));
			p.Add(new ParameterValueDbg("1/8\" "));


			pd = new ParameterData("Family 2");
			pd.Selected = false;
			Pd.Add(pd);

			p = Pd[Pd.Count - 1].ParameterValues;

			p.Add(new ParameterValueDbg("2/32\""));

			p.Add(new ParameterValueDbg("Arial2"));

			p.Add(new ParameterValueDbg("2/8\" "));
			

			pd = new ParameterData("Family 3");
			pd.Selected = false;
			Pd.Add(pd);

			p = Pd[Pd.Count - 1].ParameterValues;

			p.Add(new ParameterValueDbg("3/32\""));

			p.Add(new ParameterValueDbg("Arial3"));

			p.Add(new ParameterValueDbg("3/8\" "));
			



//			ObservableCollection<ParameterValue> p;
//
//			Parameter pa;
//
//			ParameterData pd;
//
//			pd = new ParameterData("Family 1");
//			pd.Selected = false;
//			Pd.Add(pd);
//			
//			p = Pd[Pd.Count - 1].ParameterValues;
//
//			pa = TestData.DefineParameter(new [] {"3/32\"" , "Text Size" , "Double "  , "105"    , "UT_SheetLength" , "DUT_FRACTIONAL_INCHES"});
//			Cd.ColumnSpecs.Add(new ColumnSpec( pa, 0));
//			p.Add(new ParameterValue(pa));
//			
//			pa = TestData.DefineParameter(new [] {"Arial1" , "Text Font" , "string "  , "Text "  , "UT_Number"      , "(no unit type)"});
//			Cd.ColumnSpecs.Add(new ColumnSpec( pa, 1));
//			p.Add(new ParameterValue(pa));
//
//			
//			pa = TestData.DefineParameter(new [] {"1/2\" " , "Tab Size"  , "Double "  , "105"    , "UT_SheetLength ", "DUT_FRACTIONAL_INCHES"});
//			Cd.ColumnSpecs.Add(new ColumnSpec( pa, 2));
//			p.Add(new ParameterValue(pa));
//
//
//			pd = new ParameterData("Family 2");
//			pd.Selected = true;
//			Pd.Add(pd);
//
//			p = Pd[Pd.Count - 1].ParameterValues;
//			p.Add(new ParameterValue(
//				TestData.DefineParameter(new [] {"4/32\"" , "Text Size" , "Double "  , "105"    , "UT_SheetLength" , "DUT_FRACTIONAL_INCHES"})));
//			p.Add(new ParameterValue(
//				TestData.DefineParameter(new [] {"Arial2" , "Text Font" , "string "  , "Text "  , "UT_Number"      , "(no unit type)" })));
//			p.Add(new ParameterValue(
//				TestData.DefineParameter(new [] {"1/2\" " , "Tab Size"  , "Double "  , "105"    , "UT_SheetLength ", "DUT_FRACTIONAL_INCHES"})));
//
//			pd = new ParameterData("Family 3");
//			pd.Selected = false;
//			Pd.Add(pd);
//
//			p = Pd[Pd.Count - 1].ParameterValues;
//			p.Add(new ParameterValue(
//				TestData.DefineParameter(new [] {"5/32\"" , "Text Size" , "Double "  , "105"    , "UT_SheetLength" , "DUT_FRACTIONAL_INCHES"})));
//			p.Add(new ParameterValue(
//				TestData.DefineParameter(new [] {"Arial3" , "Text Font" , "string "  , "Text "  , "UT_Number"      , "(no unit type)" })));
//			p.Add(new ParameterValue(
//				TestData.DefineParameter(new [] {"1/2\" " , "Tab Size"  , "Double "  , "105"    , "UT_SheetLength ", "DUT_FRACTIONAL_INCHES"})));

		}
	}
}