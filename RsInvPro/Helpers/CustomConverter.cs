using System;
using System.Globalization;
using Xamarin.Forms;

namespace RsInvPro.Helpers
{

    public class CustomConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return value as Syncfusion.SfDataGrid.XForms.GridSelectionChangedEventArgs;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
