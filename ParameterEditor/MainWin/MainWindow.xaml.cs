using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using ParameterEditor.Managers;

using Autodesk.Revit.DB;
using ParameterEditor.DebugWin;

namespace ParameterEditor.MainWin
{
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
	#region private fields

		private string windowMessage;
		private string typeName = "Text";

	#endregion

		public MainWindow()
		{
			InitializeComponent();

//			Pm = new ParameterMgr();
//
//			lbc = new ConfigurationMgr();
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

	#endregion

	#region property handler

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}

		#endregion

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
//			Pm.Initalize(ElementTypeGroup.TextNoteType);
		}

		private void ButtonVueData_Click(object sender, RoutedEventArgs e)
		{
			(new DataVue()).ShowDialog();
		}
		
		private void ButtonVueDebug_Click(object sender, RoutedEventArgs e)
		{
			(new DebugWindow()).ShowDialog();
		}

		private void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}