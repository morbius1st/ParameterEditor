using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using ParameterEditor.Managers.ParameterInfo;

namespace ParameterEditor.MainWin.MainWindowSupport
{

	[ValueConversion(typeof(string), typeof(string))]
	public class  YesNoToBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value.ToString().ToLower().Equals("yes")) return true;

			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool)
			{
				if ((bool) value == true)
				{
					return "Yes";
				}
			}
			return "No";
		}
	}

	public class RowToIndexConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			DataGridRow row = value as DataGridRow;
			if (row != null)
				return row.GetIndex();
			else
				return -1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

//	public class CellColToIndexConverter : IMultiValueConverter
//	{
//		private const int PARAMETER_LIST = 0;
//		private const int COLUMN_INDEX = 1;
//		private const int GRID_COLUMN = 2;
//
//
//
//		// parameter 0 = flag to reconvert
//		// parameter 1 = the List of the parameters
//		// parameter 2 = the column index (index to the correct "parameter 1"
//		// the new column id
//		public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
//		{
//			if (!(value[PARAMETER_LIST] is ObservableCollection<ParameterValue>) ||
//				!(value[COLUMN_INDEX] is int) || (int) value[COLUMN_INDEX] < 0 )
//			{
//				return (value[GRID_COLUMN] is int) ? value[GRID_COLUMN].ToString() : "n/a";
//			}
//
//			((ObservableCollection<ParameterValue>) 
//				value[PARAMETER_LIST])[((int) value[COLUMN_INDEX])].Col = (int) value[GRID_COLUMN];
//
//			return value[GRID_COLUMN].ToString();
//		}
//
//		public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
//		{
//			throw new NotImplementedException();
//		}
//
//	}
	
//	public class CellRowToIndexConverter : IValueConverter
//	{
//		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
//		{
//			if (!(value is DataGridCell))
//			{
//				return "-1";
//			}
//
//			DataGridCell cell = (DataGridCell) value;
//
//			DataGridRow r = DataGridRow.GetRowContainingElement(cell);
//
//			if (r == null)
//				return -1;
//
//			int row = r.GetIndex();
//
//			if (cell.DataContext is ParameterData)
//			{
//				ParameterData pd = (ParameterData) cell.DataContext;
//
//				pd.ParameterValues[cell.Column.DisplayIndex].Row = row;
//			}
//
//
//			return row;
//		}
//
//		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
//		{
//			throw new NotImplementedException();
//		}
//
//	}

//	public class TestConverter : IValueConverter
//	{
//		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
//		{
//			Debug.WriteLine("at test convert");
//
//			return value;
//		}
//
//		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
//		{
//			throw new NotImplementedException();
//		}
//
//	}

}
