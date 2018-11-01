using System;
using System.Globalization;
using System.Windows;

namespace MVVMStopWatch
{
	class BoolenVisibilityConverter : BaseValueConverter<BoolenVisibilityConverter>
	{
		/// <summary>
		/// Converts boolen object params into 'Visibility'
		/// </summary>
		/// <returns> Visibility value </returns>
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((value is bool) && ((bool)value) == false)
				return Visibility.Visible;
			else
				return Visibility.Collapsed;
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
