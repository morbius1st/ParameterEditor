// Solution:     WpfApp1-ListControlTest
// Project:       ParameterVue
// File:             CustomProperties.cs
// Created:      -- ()

using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using ParameterEditor.Managers.Support;

namespace ParameterEditor.WpfSupport 
{

	public class CustomProperties
	{
		public static readonly DependencyProperty GenericBoolOneProperty = DependencyProperty.RegisterAttached(
			"GenericBoolOne", typeof(bool), typeof(CustomProperties),
			new PropertyMetadata(false));
		
		public static readonly DependencyProperty GenericBoolTwoProperty = DependencyProperty.RegisterAttached(
			"GenericBoolTwo", typeof(bool), typeof(CustomProperties),
			new PropertyMetadata(false));
		
		public static readonly DependencyProperty GenericIntOneProperty = DependencyProperty.RegisterAttached(
			"GenericIntOne", typeof(int), typeof(CustomProperties),
			new PropertyMetadata(0));
		
		public static readonly DependencyProperty GenericObjectOneProperty = DependencyProperty.RegisterAttached(
			"GenericObjectOne", typeof(object), typeof(CustomProperties),
			new PropertyMetadata(0));
		
		public static readonly DependencyProperty GenericObjectTwoProperty = DependencyProperty.RegisterAttached(
			"GenericObjectTwo", typeof(object), typeof(CustomProperties),
			new PropertyMetadata(0));

		public static readonly DependencyProperty GenericFontProperty = DependencyProperty.RegisterAttached(
			"GenericFont", typeof(FontInfo), typeof(CustomProperties),
			new PropertyMetadata(new FontInfo("Arial")));

		public static readonly DependencyProperty GenericFontFamilyProperty = DependencyProperty.RegisterAttached(
			"GenericFontFamily", typeof(FontFamily), typeof(CustomProperties),
			new PropertyMetadata(new FontFamily("Arial")));

		public static readonly DependencyProperty ErrorFlagProperty = DependencyProperty.RegisterAttached(
			"ErrorFlag", typeof(bool), typeof(CustomProperties),
			new PropertyMetadata(false));


	#region GenericBoolOne

		public static void SetGenericBoolOne(UIElement e, bool value)
		{
			e.SetValue(GenericBoolOneProperty, value);
		}

		public static bool GetGenericBoolOne(UIElement e)
		{
			return (bool) e.GetValue(GenericBoolOneProperty);
		}

	#endregion
		
	#region GenericBoolTwo

		public static void SetGenericBoolTwo(UIElement e, bool value)
		{
			e.SetValue(GenericBoolTwoProperty, value);
		}

		public static bool GetGenericBoolTwo(UIElement e)
		{
			return (bool) e.GetValue(GenericBoolTwoProperty);
		}

	#endregion
				
	#region GenericIntOne

		public static void SetGenericIntOne(UIElement e, int value)
		{
			e.SetValue(GenericIntOneProperty, value);
		}

		public static int GetGenericIntOne(UIElement e)
		{
			return (int) e.GetValue(GenericIntOneProperty);
		}

	#endregion
				
	#region GenericObjectOne

		public static void SetGenericObjectOne(UIElement e, object value)
		{
			Debug.WriteLine("SetGenericObjectOne| " + value);
			e.SetValue(GenericObjectOneProperty, value);
		}

		public static object GetGenericObjectOne(UIElement e)
		{
			Debug.WriteLine("GetGenericObjectOne| ");
			return (object) e.GetValue(GenericObjectOneProperty);
		}

	#endregion
						
	#region GenericObjectTwo

		public static void SetGenericObjectTwo(UIElement e, object value)
		{
			e.SetValue(GenericObjectTwoProperty, value);
		}

		public static object GetGenericObjectTwo(UIElement e)
		{ 
			return (object) e.GetValue(GenericObjectTwoProperty);
		}

	#endregion

	#region GenericFont

		public static void SetGenericFont(UIElement e, FontInfo value)
		{
			e.SetValue(GenericFontProperty, value);
		}

		public static FontInfo GetGenericFont(UIElement e)
		{
			return (FontInfo) e.GetValue(GenericFontProperty);
		}

	#endregion

	#region GenericFont

		public static void SetGenericFontFamily(UIElement e, FontFamily value)
		{
			e.SetValue(GenericFontFamilyProperty, value);
		}

		public static FontFamily GetGenericFontFamily(UIElement e)
		{
			return (FontFamily) e.GetValue(GenericFontFamilyProperty);
		}

	#endregion

	#region ErrorFlag

		public static void SetErrorFlag(UIElement e, bool value)
		{
			e.SetValue(ErrorFlagProperty, value);
		}

		public static bool GetErrorFlag(UIElement e)
		{
			return (bool) e.GetValue(ErrorFlagProperty);
		}

	#endregion

	#region GenericStringOne

		public static readonly DependencyProperty GenericStringOneProperty = DependencyProperty.RegisterAttached(
			"GenericStringOne", typeof(string), typeof(CustomProperties), new PropertyMetadata(""));

		public static void SetGenericStringOne(UIElement e, string value)
		{
			e.SetValue(GenericStringOneProperty, value);
		}

		public static string GetGenericStringOne(UIElement e)
		{
			return (string) e.GetValue(GenericStringOneProperty);
		}

	#endregion

	}
}