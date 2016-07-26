using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace schulzem.XamlConverters
{
    /// <summary>
    /// Base Class for anything that converts from Boolean.
    /// T represents class it will be converted to.
    /// Set True to whatever you want to convert to if the source is true.
    /// Set False to whatever you want to convert to if the source is false.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BooleanConverter<T> : IValueConverter
    {
        public
        BooleanConverter
            (
            T aTrueValue,
            T aFalseValue
            )
        {
            True = aTrueValue;
            False = aFalseValue;
        }

        public virtual object
        Convert
            (
            object aValue, 
            Type aTargetType, 
            object aParameter, 
            CultureInfo aCulture
            )
        {
            return aValue is bool && ((bool)aValue) ? True : False;
        }

        public virtual object
        ConvertBack
            (
            object aValue, 
            Type aTargetType, 
            object aParameter, 
            CultureInfo aCulture
            )
        {
            return aValue is T &&
                   EqualityComparer<T>.Default.Equals( (T) aValue, True );
        }

        public T True { get; set; }
        public T False { get; set; }
    }

    /// <summary>
    /// Converts from Bool to Visisbility.
    /// Can be re-used for the inverse. And to convert to Hidden or Collapsed.
    /// </summary>
    [ValueConversion( typeof( object ), typeof( Visibility ) )]
    public sealed class BooleanToVisibilityConverter : BooleanConverter<Visibility>
    {
        public BooleanToVisibilityConverter
            (
            ) 
        :
            base( Visibility.Visible, Visibility.Collapsed )
        { 
        }
    }

    /// <summary>
    /// Check if string is empty. Can be re-used for inverse.
    /// </summary>
    public sealed class StringEmptyToBoolConverter : BooleanConverter<bool>
    {
        public StringEmptyToBoolConverter
            (
            )
        :
            base( true, false )
        {
        }

        public override object
        Convert
            (
            object aValue,
            Type aTargetType,
            object aParameter,
            CultureInfo aCulture
            )
        {
            if( !(aValue is string) )
            {
                // if not a string, return that it IS empty
                return True;
            }

            return String.IsNullOrEmpty( ( string )aValue ) ? True : False;
        }
    }

    /// <summary>
    /// Simply inverts a bool.
    /// </summary>
    public sealed class InverseBooleanConverter : BooleanConverter<bool>
    {
        public InverseBooleanConverter
            (
            )
        :
            base( false, true )
        {
        }
    }
}