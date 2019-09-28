// Solution:     ParameterVue
// Project:       ParameterVue
// File:             FontInfo.cs
// Created:      -- ()

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace ParameterEditor.Managers.Support 
{
	public class FontInfo : INotifyPropertyChanged
	{
		private const double DEFAULT_FONT_SIZE = 11.0f;

		private FontFamily fontFamily;		
		private double fontSize;		
		private FontStyle fontStyle;
		private FontWeight fontWeight;
		private FontStretch fontStretch;
		private Brush foreground;

		public FontInfo() { }

		public FontInfo(string fontFamily, double fontSize,
			Brush foreground) : this(fontFamily, fontSize, FontStyles.Normal,
			FontWeights.Normal, FontStretches.Normal, foreground) { }

		public FontInfo(string fontFamily = null, double fontSize = DEFAULT_FONT_SIZE,
			FontStyle fontStyle = default(FontStyle),
			FontWeight fontWeight = default(FontWeight),
			FontStretch fontStretch = default(FontStretch),
			Brush foreground = null )
		{
			FontFamily = new FontFamily(fontFamily ?? "Arial");
			FontSize = fontSize;
			FontStyle = fontStyle;     //?? default(FontStyle);
			FontWeight = fontWeight;   //?? default(FontWeight);
			FontStretch = fontStretch; //?? default(FontStretch);
			Foreground = foreground ?? new SolidColorBrush(Colors.Black);
		}

		public FontFamily FontFamily
		{
			get => fontFamily;
			set
			{
				fontFamily = value;
				OnPropertyChange();
			}
		}

		public double FontSize
		{
			get => fontSize;
			set
			{
				fontSize = value;
				OnPropertyChange();
			}
		}

		public FontStyle FontStyle
		{
			get => fontStyle;
			set
			{
				fontStyle = value;
				OnPropertyChange();
			}
		}

		public FontWeight FontWeight
		{
			get => fontWeight;
			set
			{
				fontWeight = value;
				OnPropertyChange();
			}
		}

		public FontStretch FontStretch
		{
			get => fontStretch;
			set
			{
				fontStretch = value;
				OnPropertyChange();
			}
		}

		public Brush Foreground
		{
			get => foreground;
			set
			{
				foreground = value; 
				OnPropertyChange();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this,   new PropertyChangedEventArgs(memberName));
		}
	}
}