using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using ParameterEditor.Managers;
using Autodesk.Revit.DB;
using ParameterEditor.DebugWin;
using ParameterEditor.Managers.ParameterInfo;

namespace ParameterEditor.MainWin
{
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
	#region private fields

		private string windowMessage;
		private string typeName = ElementTypeGroup.TextNoteType.ToString();
		private bool updateColumn;

		#endregion

		public MainWindow()
		{
			InitializeComponent();

		}

	#region properties

		public static string ColHeaderTbkStyleName { get; set; } = "ColHeaderTbk";
		public static string RowHeaderTbxStyleName { get; set; } = "RowHeaderTbx";
		public static string FieldTbxStyleName { get; set; } = "FieldTbx";

		public string WindowMessage
		{
			get => windowMessage;
			set
			{
				windowMessage = value;
				OnPropertyChange();
			}
		}

		public string TypeName
		{
			get => typeName;
			set
			{
				typeName = value;
				OnPropertyChange();
			}
		}

		public bool UpdateColumn
		{
			get => updateColumn;
			set
			{
				updateColumn = value;
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

	#region events

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			//Pm.Initalize(ElementTypeGroup.ModelTextType);

			//DgFamilyType.ItemsSource = ParameterMgr.Pd;
		}

		private void ButtonVueData_Click(object sender, RoutedEventArgs e)
		{
			(new DataVue()).ShowDialog();
		}

		private void ButtonVueDebug_Click(object sender, RoutedEventArgs e)
		{
			(new DebugWindow()).ShowDialog();
		}

		private void ButtonDebug_Click(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("At Debug");

			ParameterMgr.ParamMgr.Initalize(ElementTypeGroup.ModelTextType);
//
//			DgFamilyType.ItemsSource = ParameterMgr.ParamMgr.Pd;
		}

		private void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void DgFamilyType_ColumnReordered(object sender, DataGridColumnEventArgs e)
		{
			UpdateColumn = !updateColumn;
		}

	#endregion

	}
}