using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ItemsControlArticle
{
public sealed class PlaceDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate CountryDataTemplate { get; set; }

    public DataTemplate CityDataTemplate { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        if (item is CountryViewModel)
        {
            return CountryDataTemplate;
        }
        else if (item is CityViewModel)
        {
            return CityDataTemplate;
        }

        return null;
    }
}
}
