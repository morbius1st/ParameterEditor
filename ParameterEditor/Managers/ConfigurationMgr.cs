#region + Using Directives

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using ParameterEditor.Managers.Support;

#endregion


// projname: ParameterVue.WpfSupport
// itemname: ListBoxConfiguration
// username: jeffs
// created:  8/24/2019 12:57:41 PM


namespace ParameterEditor.Managers
{
	// information about the design / settings
	// for a listbox
	public class ConfigurationMgr : INotifyPropertyChanged
	{
		public static readonly FontInfo DefaultFont = new FontInfo("Arial");

		public static FontInfo HeaderFont { get; set; } = new FontInfo("Arial");
		public static FontInfo SymbolFont { get; set; } = new FontInfo("ArialUni");
		public static FontInfo RowHeaderFont { get; set; } = new FontInfo("Arial");
		public static FontInfo FieldFont { get; set; } = new FontInfo("Arial");

		public static FontInfo Header2Font { get; set; } = new FontInfo("Bauhaus 93", 16.0);
		public static FontInfo Header3Font { get; set; } = new FontInfo("Cooper Black", 20.0, new SolidColorBrush(Colors.Blue));


		static ConfigurationMgr()
		{
			HeaderFont.Foreground = new SolidColorBrush(Colors.BlueViolet);
			SymbolFont.Foreground = new SolidColorBrush(Colors.Red);
			RowHeaderFont.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
			FieldFont.Foreground = new SolidColorBrush(Colors.MediumBlue);
		}

		public static FontInfo GetDefaultHeaderFont() { return HeaderFont; }
		public static FontInfo GetDefaultFieldFont() { return FieldFont; }

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}
	}
}