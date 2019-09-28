using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Autodesk.Revit.DB;
using ParameterEditor.Managers;

namespace ParameterEditor.WpfSupport.EmptyWin
{
	public partial class MT : Window, INotifyPropertyChanged
	{
	#region private fields

	#endregion

		public MT()
		{
			InitializeComponent();
		}

	#region properties

	#endregion

	#region property handler

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}

	#endregion
	}
}