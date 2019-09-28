using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Autodesk.Revit.DB;
using ParameterEditor.MainWin;
using ParameterEditor.Managers;

namespace ParameterEditor.DebugWin
{
	public partial class DataVue : Window, INotifyPropertyChanged
	{
	#region private fields

		private string windowMessage;

	#endregion

		public DataVue()
		{
			InitializeComponent();
		}

	#region properties

		public string WindowMessage
		{
			get => windowMessage;
			set
			{
				windowMessage = value;
				OnPropertyChange();
			}
		}
	#endregion

	#region property handler

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}

		#endregion

		private void ButtonDebug_Click(object sender, RoutedEventArgs e)
		{
			int a = ParameterMgr.Cd.ColumnSpecs.Count;
			int b = ParameterMgr.Pd.Count;


			Debug.WriteLine("At Debug| ");
		}

		private void ButtonView_Click(object sender, RoutedEventArgs e)
		{
			ParameterMgr.ParamMgr.Initalize(ElementTypeGroup.TextNoteType);

			DgColumnData.ItemsSource = ParameterMgr.Cd.ColumnSpecs;
			DgParameterData.ItemsSource = ParameterMgr.Pd;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

			this.Close();
		}

		private void DgColumnData_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (((string) e.Column.Header).Contains("Font"))
			{
				e.Cancel = true;
			}
		}

		private void DgParameterData_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (((string) e.Column.Header).Equals("ParameterValues"))
			{
				e.Cancel = true;
			}
		}
	}
}