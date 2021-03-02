using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace DA.Commons.Hodgepodge.NetCore.Wpf
{
	/// <ChangeLog>
	/// <Create Datum="01.03.2021" Entwickler="DA" />
	/// </ChangeLog>
	public sealed class DecimalConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToDecimal(value, culture);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToDecimal(value);
		}
	}
	public sealed class Bool2VisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is Boolean)
			{
				return ((bool)value) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
			}
			throw new ArgumentException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}