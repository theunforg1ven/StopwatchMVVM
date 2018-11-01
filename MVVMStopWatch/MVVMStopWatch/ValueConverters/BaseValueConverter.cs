using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MVVMStopWatch
{
	public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter where T : class, new()
	{
		private static T _converter = null;

		/// <summary>
		/// Provide a static instance of the value converter
		/// </summary>
		/// <param name="serviceProvider"> The service provider </param>
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			// if _converter == 0 -> return new T()
			return _converter ?? (_converter = new T());
		}

		/// <summary>
		/// The method to convert one type to another
		/// </summary>
		public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

		/// <summary>
		/// The method to convert value back to its sourse type
		/// </summary>
		public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
	}
}
