using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Autodesk.Revit.DB;
using ParameterEditor.DebugWin.DebugWinSupport;
using ParameterEditor.Managers.ParameterSupport;

namespace ParameterEditor.DebugWin
{
	public partial class DebugWindow : Window, INotifyPropertyChanged
	{
		private string windowMessage;

		public string WindowMessage
		{
			get => windowMessage;
			set
			{
				windowMessage = value;
				OnPropertyChange();
			}
		}

		public DebugWindow()
		{
			InitializeComponent();
		}

		//			DebugWindow dw = new DebugWindow();
//			dw.WindowMessage = ParameterDebugSupport.GetAllElements().ToString();
//			dw.WindowMessage =
//				ParameterDebugSupport.ListTypes(ParametersSupport.GetAllTypes(ElementTypeGroup.TextNoteType)).ToString();
//
//			dw.ShowDialog();


		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}

		private void Exit_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void DebugWindow_OnLoaded(object sender, RoutedEventArgs e)
		{
			ShowData();
		}

		private void ShowData(ElementTypeGroup type = ElementTypeGroup.TextNoteType)
		{
			WindowMessage = 
				ParameterDebugSupport.ListTypes(ParametersSupport.GetAllTypes(ElementTypeGroup.TextNoteType)).ToString();
		}
	}
}
