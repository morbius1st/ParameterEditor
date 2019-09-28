#region + Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using Autodesk.Revit.DB;
using ParameterEditor.Managers.Support;

#endregion


// projname: ParameterVue.FamilyManager.FamilyInfo
// itemname: ColumnSpec
// username: jeffs
// created:  8/24/2019 11:41:10 AM


namespace ParameterEditor.Managers.ParameterInfo
{
	public enum ColumnType
	{
		CHECKBOX,
		TEXTBOX,
		DROPDOWN,
		URI
	}

	// holds the definition information about a column
	public class ColumnSpec : INotifyPropertyChanged
	{
	#region Fields

		private  const int CharToPixelWidthFactor = 8;

		public static readonly int MaxAllowedValueWidth = 20;
		public static readonly int MinAllowedValueWidth = 8;

		private bool selected = false;
		private double columnWidth = -1;
		private int widestCell = MinAllowedValueWidth;

		private static int currentColumn = -1;

	#endregion


	#region ctor

		public ColumnSpec(Parameter p)
		{
			VerifyInit();

			ConfigurePerParameter(p);
		}

		public ColumnSpec(string title = null)
		{
			if (title != null)
			{
				ColumnTitle = title;
				ColumnAlignment = HorizontalAlignment.Center;
				ColumnType = ColumnType.TEXTBOX;
			}

			VerifyInit();
		}

		private void VerifyInit()
		{

			if (currentColumn == -1)
				throw new InvalidOperationException();

			ColumnPosition = currentColumn;
			ColumnIndex = currentColumn++;
		}

	#endregion

	#region parameters

		// the whole column has been selected
		public bool Selected
		{
			get => selected;
			set
			{
				if (selected != value) return;
				selected = value;

				OnPropertyChange();
			}
		}


		// get the column position index for this column
		public int ColumnPosition { get; set; } = 0;

		// get the column position index for this column
		public int ColumnIndex { get; private set; } = 0;

		public ColumnType ColumnType { get; private set; } = ColumnType.TEXTBOX;

		// the title of this column = parameter name
		public string ColumnTitle { get; private set; } = null;

		// the defined width for this column
		public Double ColumnWidth
		{
			get => columnWidth * CharToPixelWidthFactor;
			set
			{
				if (value < MinAllowedValueWidth)
				{
					columnWidth = MinAllowedValueWidth;
				}
				else if (value > MaxAllowedValueWidth)
				{
					columnWidth = MaxAllowedValueWidth;
				}
				else
				{
					columnWidth = value;
				}
			}
		}

		public HorizontalAlignment ColumnAlignment { get; private set; } = HorizontalAlignment.Stretch;

		public FontInfo HeaderFont { get; set; } = ConfigurationMgr.GetDefaultHeaderFont();

		public FontInfo FieldFont { get; set; } = ConfigurationMgr.GetDefaultFieldFont();

		public TextAlignment TextAlignment { get; private set; } = TextAlignment.Left;


		// for columns that have a choices, this is the list of choices
		public bool IsChecked { get; set; } = false;
		public bool IsReadOnly { get; set; } = false;

		// the widest cell for this column

		public int WidestCell
		{
			get => widestCell;
			set
			{
				if (value > widestCell)
				{
					widestCell = value;
				}
			}
		}

		// the list of combobox choices
		public Choices Choices { get; set; } = null;

	#endregion

	#region methods

		public static void Initalize()
		{
			currentColumn = 0;
		}

		public void ConfigurePerParameter(Parameter p)
		{
			ColumnTitle = p.Definition.Name;

			ConfigureColumn(p);
		}

		private void ConfigureColumn(Parameter p)
		{
			switch (p.Definition.ParameterType)
			{
			case ParameterType.YesNo:
				{
					ColumnAlignment = HorizontalAlignment.Center;
					ColumnType = ColumnType.CHECKBOX;
					break;
				}
			case ParameterType.Length:
				{
					TextAlignment = TextAlignment.Center;
					ColumnType = ColumnType.TEXTBOX;
					break;
				}
			case ParameterType.Number:
				{
					TextAlignment = TextAlignment.Center;
					ColumnType = ColumnType.TEXTBOX;
					break;
				}
			case ParameterType.Text:
				{
					TextAlignment = TextAlignment.Left;
					ColumnType = ColumnType.TEXTBOX;
					break;
				}
			case ParameterType.Invalid:
			default:
				{
					TextAlignment = TextAlignment.Left;
					ColumnType = ColumnType.TEXTBOX;
					break;
				}
			}
		}

	#endregion

	#region property handling

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}

	#endregion

		public string DivideStringByMaxLength(string s, int maxLength)
		{
//			string divided = Regex.Replace(s, @"(.{1," + maxLength + @"})(?:\s|$)", "$1\n");
			string divided = Regex.Replace(s, @"(.{1," + maxLength + @"})(?:\s)", "$1\n");

			if (divided.IndexOf("/") > -1)
			{
				divided = Regex.Replace(divided, @"(.(?:\/))", "$1/\n");
			}

			return divided;
		}

		public void DivideTitle()
		{
			if (string.IsNullOrWhiteSpace(ColumnTitle) ||
				ColumnTitle.IndexOf(' ') == -1 ) return;

			ColumnTitle = DivideStringByMaxLength(ColumnTitle, widestCell);
//
//			test = test.TrimEnd('\n');
//
//			string pattern = @"(\b.{1," + $"{MinAllowedValueWidth:D}" + @"})(?:\s+|\W|$)";
//
//			MatchCollection matches =
//				Regex.Matches(ColumnTitle, pattern);
//
//			if (matches.Count == 0 || matches.Count == 1) return;
//
//			Match[] titles = new Match[matches.Count];
//
//			matches.CopyTo(titles,0);
//
//			foreach (string t in titles)
//			{
//				if (t.Length > widestCell)
//				{
//					ColumnTitle = AdjustTitle(titles, widestCell);
//					break;
//				}
//			}
		}

//		private string AdjustTitle(string[] titles, int length)
//		{
//			if (titles.Length < 2) return titles[0];
//
//			string finalTitle = "";
//			string titleLine = titles[0];
//
//			string N = System.Environment.NewLine;
//
//			int pos = 1;
//
//			foreach (string t in titles)
//			{
//				if (titleLine.Length + titles[pos].Length < length)
//				{
//					titleLine += titles[pos];
//				}
//				else
//				{
//					finalTitle += titleLine;
//
//					if (pos + 1 != titles.Length)
//					{
//						finalTitle += N;
//
//						pos++; 
//
//						titleLine = titles[pos];
//					}
//				}
//				pos++;
//			}
//
//			return finalTitle;
//		}


//		private int LongestWord(string phrase)
//		{
//			if (string.IsNullOrWhiteSpace(phrase)) return 0;
//
//			string pattern = @"(\b.{1," + $"{MinAllowedValueWidth:D}" + @"})(?:\s+|\W|$)";
//
//			MatchCollection matches =
//				Regex.Matches(phrase, pattern);
//
//			if (matches.Count == 0) return phrase.Length;
//
//			int longest = 0;
//
//			foreach (Match match in matches)
//			{
//				if (match.Length > longest) longest = match.Length;
//			}
//
//			return longest;
//		}
	}

	// holds the list of possible choices for the column
	public class Choices
	{
		public bool StringCaseMatters { get; set; }
		public bool CanUseCustomValue { get; set; }
		public bool AddCustomChoicetoList { get; set; }
		public bool HasChoices { get; set; }

		private List<string> choices = new List<string>();

		public List<string> ChoiceList => choices;

		public string this[int index]
		{
			get => choices[index];
			set => choices[index] = value;
		}

		public bool Add(string item)
		{
			if (FindItemIndex(item) == -1) return false;

			choices.Add(item);

			return true;
		}

		public int FindItemIndex(string item)
		{
			if (!StringCaseMatters)
				return choices.FindIndex(x => x.ToUpper().Equals(item.ToUpper()));

			return choices.FindIndex(x => x.Equals(item));
		}
	}
}