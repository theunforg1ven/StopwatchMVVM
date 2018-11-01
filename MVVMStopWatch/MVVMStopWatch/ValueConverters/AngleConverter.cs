using System;
using System.Globalization;

namespace MVVMStopWatch
{
	class AngleConverter : BaseValueConverter<AngleConverter>
	{
		/// <summary>
		/// The method to convert double values for adding them into clock
		/// </summary>
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double parsedValue;
			if ((value != null) && double.TryParse(value.ToString(), out parsedValue) && (parameter != null))
				switch (parameter.ToString())
				{
					case "Hours":
						return parsedValue * 30;
					case "Minutes":
					case "Seconds":
						return parsedValue * 6;
				}
			return 0;
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
