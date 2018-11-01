using System;
using System.Globalization;

namespace MVVMStopWatch
{
	class TimeNumberFormatConverter : BaseValueConverter<TimeNumberFormatConverter>
	{
		/// <summary>
		/// Converts stopwatch timer values into correct format
		/// </summary>
		/// <returns> Formatted value </returns>
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is decimal)
				return ((decimal)value).ToString("00.00");
			else if (value is int)
			{
				if (parameter == null)
					return ((int)value).ToString("d1");
				else
					return ((int)value).ToString(parameter.ToString());
			}

			return value;		
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
