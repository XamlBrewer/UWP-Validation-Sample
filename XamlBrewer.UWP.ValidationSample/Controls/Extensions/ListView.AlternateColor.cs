using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace XamlBrewer.Uwp.ValidationSample.Views
{
    /// <summary>
    /// AlternateColor extension extends your <see cref="ListViewBase"/> control with 
    /// an attached <see cref="DependencyProperty"/> property to provide alternate row color functionality
    /// </summary>
    public static class AlternateRowColor
    {
        /// <summary>
        /// Attached <see cref="DependencyProperty"/> for binding a <see cref="Brush"/> as an alternate row background color to a <see cref="ListViewBase"/>
        /// </summary>
        public static readonly DependencyProperty ColorProperty = DependencyProperty.RegisterAttached(
            "Color",
            typeof(Brush),
            typeof(AlternateRowColor),
            new PropertyMetadata(null, OnColorPropertyChanged));

        /// <summary>
        /// Gets the <see cref="Brush"/> associated with the specified <see cref="DependencyObject"/>
        /// </summary>
        /// <param name="obj">The <see cref="DependencyObject"/> to get the associated <see cref="Brush"/> from</param>
        /// <returns>The <see cref="Brush"/> associated with the <see cref="DependencyObject"/></returns>
        public static Brush GetColor(ListViewBase obj)
        {
            return (Brush)obj.GetValue(ColorProperty);
        }

        /// <summary>
        /// Sets the <see cref="Brush"/> associated with the specified <see cref="DependencyObject"/>
        /// </summary>
        /// <param name="obj">The <see cref="DependencyObject"/> to associate the <see cref="Brush"/> with</param>
        /// <param name="value">The <see cref="Brush"/> for binding to the <see cref="DependencyObject"/></param>
        public static void SetColor(ListViewBase obj, Brush value)
        {
            obj.SetValue(ColorProperty, value);
        }

        private static void OnColorPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            ListViewBase listViewBase = sender as ListViewBase;

            if (listViewBase == null)
            {
                return;
            }

            listViewBase.ContainerContentChanging -= ColorContainerContentChanging;

            if (ColorProperty != null)
            {
                listViewBase.ContainerContentChanging += ColorContainerContentChanging;
            }
        }

        private static void ColorContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            var itemContainer = args.ItemContainer as ListViewItem;
            var itemIndex = sender.IndexFromContainer(itemContainer);

            if (itemIndex % 2 == 0)
            {
                itemContainer.Background = GetColor(sender);
            }
            else
            {
                itemContainer.Background = null;
            }
        }
    }
}
