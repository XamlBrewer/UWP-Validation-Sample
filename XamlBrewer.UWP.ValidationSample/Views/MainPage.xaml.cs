using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using XamlBrewer.UWP.ValidationSample.ViewModels;

namespace XamlBrewer.Uwp.ValidationSample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            DataContext = new MainPageViewModel();
        }

        MainPageViewModel ViewModel => (MainPageViewModel)DataContext;

        private void Catalog_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0)
            {
                return;
            }

            ViewModel.SelectedCompanyCar = e.AddedItems.First() as UWP.ValidationSample.Models.CompanyCar;

            Details.DataContext = ViewModel.SelectedCompanyCar;
        }

        private async void EditButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var cc = new CompanyCar(ViewModel.SelectedCompanyCar);
            cc.Validate();
            EditDialog.DataContext = cc;
            var result = await EditDialog.ShowAsync();
        }
    }
}
