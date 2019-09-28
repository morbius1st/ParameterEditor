using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace ParameterEditor.Managers.ParameterInfo
{
	public abstract class AParameterValue : INotifyPropertyChanged
	{
		protected string paramOrigValue;
		protected bool revised;
		protected bool invalid;
		protected int row = 100;
		protected int col = 200;

		public virtual string ParamValue { get; set; }

		public string ParamOrigValue
		{
			get => paramOrigValue;
			private set
			{
				paramOrigValue = value;

				OnPropertyChange();
			}
		}

		public bool Revised
		{
			get => revised;
			set
			{
				if (value != revised)
				{
					revised = value;
					OnPropertyChange();
				}
			}
		}

		public bool Invalid
		{
			get => invalid;
			set
			{
				invalid = value;
				OnPropertyChange();
			}
		}

		public int Row
		{
			get => row;
			set
			{
				row = value;
				OnPropertyChange();
			}
		}

		public int Col
		{
			get => col;
			set
			{
				col = value;
				OnPropertyChange();
			}
		}


		public void Commit()
		{
			if (revised)
			{
				paramOrigValue = ParamValue;

				Revised = false;
				Invalid = false;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}

	}
}
