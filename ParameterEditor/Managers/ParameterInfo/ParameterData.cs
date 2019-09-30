#region + Using Directives

using System.Collections.ObjectModel;

#endregion


// projname: ParameterVue
// itemname: FamilyData
// username: jeffs
// created:  8/18/2019 9:56:59 PM


namespace ParameterEditor.Managers.ParameterInfo
{

	// holds all of the information for a single
	// family item (style)
	public class ParameterData
	{
		public bool Selected { get; set; } = false;
		public string TypeName { get; set; }

		public ObservableCollection<AParameterValue> ParameterValues { get; set; } =
			new ObservableCollection<AParameterValue>();

		public ParameterData(string typeName)
		{
			TypeName = typeName;

			ParameterValues.Clear();
		}

		public ParameterData() { }

	}
}
