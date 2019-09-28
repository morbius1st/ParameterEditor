#region + Using Directives

using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Autodesk.Revit.DB;
using ParameterEditor.Managers.ParameterSupport;

#endregion


// projname: ParameterVue
// itemname: ParameterValue
// username: jeffs
// created:  8/18/2019 9:08:35 PM


namespace ParameterEditor.Managers.ParameterInfo
{
	#if DEBUG

	public class ParameterValueDbg : AParameterValue
	{
		public ParameterValueDbg(string value)
		{
			ParamValue = value;
		}

		public new string ParamValue { get; set; }
	}

	#endif


	// holds a single parameter item - data & header info
	public class ParameterValue : AParameterValue
	{
//		private string paramValue;
//		private string paramOrigValue;
//		private bool revised;
//		private bool invalid;
//		private int row = 100;
//		private int col = 200;
//		private DataGridCell cell;

		private readonly Parameter parameter;

		public ParameterValue (Parameter parameter)
		{
			this.parameter = parameter;

			string test = ParametersSupport.GetParameterValue(parameter);

			base.paramOrigValue = ParamValue;

			revised = false;
			invalid = false;
		}

		public new string ParamValue
		{
			get => ParametersSupport.GetParameterValue(parameter);
			set
			{
				if (string.IsNullOrWhiteSpace(value)) return;

				base.OnPropertyChange();

//				string priorValue = ParamValue;
//
//				bool result = parameter.SetValueString(value);
//
//				if (!result) // invalid value entered
//				{
//					invalid = true;
//					return;
//				}
//
//				string newValue = parameter.AsValueString();
//
//				if (!newValue.Equals(priorValue))
//				{
//					Revised = true;
//					base.OnPropertyChange();
//				}
//				else
//				{
//					Revised = false;
//				}
			}
		}
//
//		public string ParamOrigValue
//		{
//			get => paramOrigValue;
//			private set
//			{
//				if (!value.Equals(paramOrigValue))
//				{
//					OnPropertyChange();
//				}
//			}
//		}
//
//		public bool Revised
//		{
//			get => revised;
//			set
//			{
//				if (value != revised)
//				{
//					revised = value;
//					OnPropertyChange();
//				}
//			}
//		}
//
//		public bool Invalid
//		{
//			get => invalid;
//			set
//			{
//				invalid = value;
//				OnPropertyChange();
//			}
//		}
//
////		public DataGridCell Cell
////		{
////			private get => cell;
////			set
////			{
////				Debug.WriteLine("at cell| ");
////				cell = value;
////			}
////		}
//
//		public int Row
//		{
//			get => row;
//			set
//			{
//				row = value;
//				OnPropertyChange();
//			}
//		}
//
//		public int Col
//		{
//			get => col;
//			set
//			{
//				col = value;
//				OnPropertyChange();
//			}
//		}
//
//		public void Commit()
//		{
//			if (revised)
//			{
//				paramOrigValue = parameter.AsValueString();
//
//				Revised = false;
//				Invalid = false;
//			}
//		}
//
//		public event PropertyChangedEventHandler PropertyChanged;
//
//		private void OnPropertyChange([CallerMemberName] string memberName = "")
//		{
//			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
//		}
	}
}
