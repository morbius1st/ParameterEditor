#region + Using Directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using Autodesk.Revit.DB;
using ParameterEditor.DebugWin.DebugWinSupport;
using ParameterEditor.Managers.ParameterInfo;
using ParameterEditor.Managers.ParameterSupport;
using ParameterEditor.Managers.Support;
using ParameterValue = ParameterEditor.Managers.ParameterInfo.ParameterValue;

#endregion


// projname: ParameterVue.ListBoxManager
// itemname: ListBoxMgr
// username: jeffs
// created:  8/19/2019 9:55:52 PM


namespace ParameterEditor.Managers
{
	public class ParameterMgr : INotifyPropertyChanged
	{
		private readonly string N = System.Environment.NewLine;

		public static ObservableCollection<ParameterData> Pd { get; set; } = new ObservableCollection<ParameterData>();
		public static ColumnData Cd { get; set; } = new ColumnData();

		private static readonly ParameterMgr Pm;

		private ParameterMgr() { }

		static ParameterMgr()
		{
			Pm = new ParameterMgr();

			LoadDesignData();
		}

		public static ParameterMgr ParamMgr
		{ 
			get => Pm;
		}

		// overall datagrid properties
		public bool CanUserAddRows { get; set; } = false;
		public bool CanUserDeleteRows { get; set; } = true;
		public bool CanUserAddColumns { get; set; } = false;
		public bool CanUserDeleteColumns { get; set; } = false;

		public static void LoadDesignData()
		{
			DesignData.LoadDesignData(Pd, Cd);
		}

		// load a family's data from the test data
		public void Initalize(ElementTypeGroup type)
		{
			Pd = new ObservableCollection<ParameterData>();
			Cd = new ColumnData();

			Dictionary<string, IList<Parameter>> k = ParametersSupport.GetAllTypes(type);

			// setup the column specifications
			foreach (Parameter p in k.First().Value)
			{
				ColumnSpec cs = CreateColumnSpec(p);

				Cd.ColumnSpecs.Add(cs);
			}

			// set up each row with the neme & set selected to false plus
			// the value for each parameter
			foreach (KeyValuePair<string, IList<Parameter>> kvp in k)
			{
				AddRow( kvp.Key, kvp.Value);
			}

			UpdateTitles();


		}

		private void AddRow( string familyName, IList<Parameter> parameters)
		{
			int col = 0;
			ParameterData pd;

			pd = new ParameterData(familyName) {Selected = false };

			foreach (Parameter p in parameters)
			{
				ParameterValue pv = new ParameterValue(p);

				if (Cd.ColumnSpecs[col].ColumnType == ColumnType.CHECKBOX)
				{
					Cd.ColumnSpecs[col].WidestCell = 1;
				}
				else
				{
					Cd.ColumnSpecs[col].WidestCell = pv.ParamValue.Length;
				}

				pd.ParameterValues.Add(new ParameterValue(p));

				col++;
			}

			Pd.Add(pd);
		}


		private void UpdateTitles()
		{
			foreach (ColumnSpec cs in Cd.ColumnSpecs)
			{
				cs.DivideTitle();
			}
		}

		private ColumnSpec CreateColumnSpec(Parameter p)
		{
			ColumnSpec cs = new ColumnSpec( p) {Choices = null };

			return cs;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}

	}
}
