using System;
using System.Globalization;


namespace MVVMStopWatch
{
	class BoolenNotConverter : BaseValueConverter<BoolenNotConverter>
	{
		/// <summary>
		/// Converts bool value
		/// </summary>
		/// <returns> true or false value </returns>
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((value is bool) && ((bool)value) == false)
				return true;
			else
				return false;
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
