#region + Using Directives

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using ParameterEditor.MainWin;
using ParameterEditor.Managers;
using ParameterEditor.Managers.ParameterInfo;
using ParameterEditor.WpfSupport;

#endregion


// projname: ParameterVue.Wpf_Support
// itemname: WpfSupport
// username: jeffs
// created:  8/19/2019 10:52:29 PM


namespace ParameterEditor.MainWin.MainWindowSupport
{
	// the process for adding a new column to the listbox
	// find the (2) grids and confirm that each is the same length
	// add the header item to the grid previously found
	// add the field data to each row
	// for each listboxitem in the listbox
	//   find the "data" grid
	//   add the control and bind to the data
	public class MainWindowSupport
	{ 
		public static void ConfigureDataGrid(DataGrid dg, ParameterMgr Pm)
		{
			
			dg.Columns.Clear();

			Pm.CanUserDeleteColumns = false;
			Pm.CanUserAddColumns = false;

			dg.ItemsSource = ParameterMgr.ParamMgr.Pd;

		}

		public static void AddColumn(Window w, DataGrid dg, ColumnSpec cs, Binding b)
		{
			DataGridColumn col = null;

			switch (cs.ColumnType)
			{
			case ColumnType.CHECKBOX:
				{
					col = new DataGridCheckBoxColumn();
					((DataGridCheckBoxColumn) col).Binding = b;
					break;
				}
			case ColumnType.TEXTBOX:
				{
					col = new DataGridTextColumn();
					((DataGridTextColumn) col).Binding = b;
					break;
				}
			case ColumnType.DROPDOWN:
				{
					col = new DataGridComboBoxColumn();
					((DataGridComboBoxColumn) col).ItemsSource = cs.Choices.ChoiceList;
					((DataGridComboBoxColumn) col).SelectedItemBinding = b;
					break;
				}
			}

//			DataTemplate dt = (DataTemplate) w.FindResource("HeaderTemplate1");
			Style dt = (Style) w.FindResource("DataGridColumnHeaderStyle3");

			if (cs.ColumnWidth > 0) col.Width = cs.ColumnWidth;

			col.Header = cs;
//			col.HeaderTemplate = dt;
			col.HeaderStyle = dt;


			dg.Columns.Add(col);

		}

		public static Binding CreateBinding2(string path, dynamic fallback, BindingMode m)
		{
			Binding b = new Binding(path);
			b.Mode = m;
			b.FallbackValue = fallback;

			if (fallback is bool)
			{
				b.Converter = new YesNoToBoolConverter();
			}

			return  b;

		}

	#region ListBoxSupport

		// adds a field to the end of the grid
		public static void AddField(Window w, Grid g, string basePath, object source, int priorColWidth)
		{
			TextBox tbx = new TextBox();
			tbx.Name = (string) source;

			tbx.SetBinding(TextBox.TextProperty, 
				CreateBinding(basePath + ".ParamValue", source, BindingMode.TwoWay));

			tbx.HorizontalAlignment = HorizontalAlignment.Stretch;

			Style s = (Style) w.FindResource(MainWindow.FieldTbxStyleName);

			tbx.Style = s;

			Binding b = new Binding(basePath + ".Revised");
			b.FallbackValue = "false";
			b.Mode = BindingMode.OneWay;

			tbx.SetBinding(CustomProperties.GenericBoolOneProperty, b);
			

			AddControlToEndOfGrid(g, tbx,  priorColWidth);
		}

		public static Binding CreateBinding(string path, object source, BindingMode m)
		{
			Binding b = new Binding(path);
			b.Mode = m;
			b.FallbackValue = "none";

			return b;
		}

		public static void AddHeader(Window w, Grid g, ColumnSpec h, int priorColWidth)
		{
			TextBlock tbk = new TextBlock();

			//			System.Drawing.Graphics x = System.Drawing.Graphics.FromImage(new Bitmap(1, 1));
			//
			////			SizeF sz = x.MeasureString(h.ParamSpec.Name, ListBoxConfiguration.HeaderFont);
			////			Debug.WriteLine("header length via graphics| " + h.ParamSpec.Name 
			////				+ " = " + sz);
			//
			//			Window w = new Window();
			//
			//
			//			TextBlock t = MainWindow.tx;
			//
			//
			//			t.Text = h.ParamSpec.Name;
			//			
			//			t.TextWrapping = TextWrapping.NoWrap;
			//
			//			w.Content = t;
			//
			//			Debug.WriteLine("header length via textblock| " + h.ParamSpec.Name
			//				+ "= W| " + t.ActualWidth + " x H| " + t.ActualHeight );
			//
			//

			Style s = (Style) w.FindResource(MainWindow.ColHeaderTbkStyleName);

			tbk.Style = s;
			tbk.Text = h.ColumnTitle;
			tbk.HorizontalAlignment = h.ColumnAlignment;

			AddControlToEndOfGrid(g, tbk, priorColWidth);
		}

		// control must be pre-configured
		// add a control to the end of a grid
		private static void AddControlToEndOfGrid(Grid g, FrameworkElement fe, 
			int priorColumnWidth)
		{
			int c = g.ColumnDefinitions.Count;

			g.ColumnDefinitions[c-1].Width = new GridLength(priorColumnWidth);

			ColumnDefinition cd = new ColumnDefinition();
			cd.Width = new GridLength(1, GridUnitType.Star);

			g.ColumnDefinitions.Add(cd);

			Grid.SetColumn(fe, c);

			g.Children.Add(fe);
		}

		public static VirtualizingStackPanel GetVirtualizingStackPanel(DependencyObject dObj)
		{
			return FindVisualChild<VirtualizingStackPanel>(dObj);
		}

	#endregion

		public static childItem FindNamedVisualChild<childItem>(DependencyObject obj, string name)
			where childItem : FrameworkElement
		{
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
			{
				DependencyObject child = VisualTreeHelper.GetChild(obj, i);
				if (child != null && child is childItem && ((FrameworkElement) child).Name.Equals(name))
				{
					return (childItem) child;
				}
				else
				{
					childItem childOfChild = FindNamedVisualChild<childItem>(child, name);
					if (childOfChild != null)
						return childOfChild;
				}
			}

			return null;
		}

		public static childItem FindVisualChild<childItem>(DependencyObject obj)
			where childItem : DependencyObject
		{
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
			{
				DependencyObject child = VisualTreeHelper.GetChild(obj, i);
				if (child != null && child is childItem)
				{
					return (childItem) child;
				}
				else
				{
					childItem childOfChild = FindVisualChild<childItem>(child);
					if (childOfChild != null)
						return childOfChild;
				}
			}

			return null;
		}


	}
}
