# XAML Converters
A small collection of simple XAML converters for re-use.

# Steps to include the converters in your project
Install the nuget package (https://www.nuget.org/packages/schulzem.XamlConverters/)
Add this to your App.xaml file:

```csharp
<ResourceDictionary>
  <!--Bool to Visibility-->
  <cnv:BooleanToVisibilityConverter x:Key="BoolToVisibility" True="Visible" False="Collapsed" />
  <cnv:BooleanToVisibilityConverter x:Key="InverseBoolToVisibility" True="Collapsed" False="Visible" />
  <cnv:BooleanToVisibilityConverter x:Key="BoolToHidden" True="Visible" False="Hidden" />
  <cnv:BooleanToVisibilityConverter x:Key="InverseBoolToHidden" True="Hidden" False="Visible" />

  <!--Inverse Bool-->
  <cnv:InverseBooleanConverter x:Key="InverseBool" True="false" False="true" />
    
  <!--Null to Visibility-->
  <cnv:NullToVisibilityConverter x:Key="NullToVisibility" Null="Visible" NotNull="Collapsed" />
  <cnv:NullToVisibilityConverter x:Key="InverseNullToVisibility" Null="Collapsed" NotNull="Visible" />
  <cnv:NullToVisibilityConverter x:Key="NullToHidden" Null="Visible" NotNull="Hidden" />
  <cnv:NullToVisibilityConverter x:Key="InverseNullToHidden" Null="Hidden" NotNull="Visible" />
</ResourceDictionary>
```

You will also have to define the cnv namespace, so add this attribute to App.xaml's 'Application' tag:
```csharp
xmlns:cnv="clr-namespace:schulzem.XamlConverters;assembly=schulzem.XamlConverters"
```

Note: feel free to leave out converters you are not interested in using. You can also change the key names to your liking, of course.

# Usage sample

```csharp
<Button Content="Delete"
        Visibility="{Binding CanBeDeleted, Converter={StaticResource InverseNullToVisibility} }"
        Command="{Binding DeleteCommand}" />
```
