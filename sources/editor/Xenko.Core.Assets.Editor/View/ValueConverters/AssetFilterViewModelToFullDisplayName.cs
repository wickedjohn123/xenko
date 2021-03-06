// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Globalization;
using System.Windows.Data;
using Xenko.Core.Assets.Editor.ViewModel;
using Xenko.Core.Presentation.ValueConverters;

namespace Xenko.Core.Assets.Editor.View.ValueConverters
{
    [ValueConversion(typeof(AssetCollectionViewModel.AssetFilterViewModel), typeof(string))]
    public class AssetFilterViewModelToFullDisplayName : OneWayValueConverter<AssetFilterViewModelToFullDisplayName>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filter = value as AssetCollectionViewModel.AssetFilterViewModel;
            if (filter == null)
                return null;

            string category;
            switch (filter.Category)
            {
                case FilterCategory.AssetName:
                    category = "name";
                    break;
                case FilterCategory.AssetTag:
                    category = "tag";
                    break;
                case FilterCategory.AssetType:
                    category = "type";
                    break;
                default:
                    throw new NotSupportedException();
            }
            return $"{category}: {filter.DisplayName}";
        }
    }
}
