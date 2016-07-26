using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace schulzem.XamlConverters
{
[ValueConversion( typeof( object ), typeof( Visibility ) )]
public class NullToVisibilityConverter : IValueConverter
{
    public object
    Convert
        (
        object aValue,
        Type aTargetType,
        object aParameter,
        CultureInfo aCulture
        )
    {
        return aValue == null ? Null : NotNull;
    }

    public object
    ConvertBack
        (
        object aValue,
        Type aTargetType,
        object aParameter,
        CultureInfo aCulture
        )
    {
        throw new NotSupportedException();
    }

    public Visibility Null{ get; set; }
    public Visibility NotNull{ get; set; }
}

}