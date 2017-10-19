using System;
using System.Linq;
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

        public string FormatDate(DateTime date)
        {
            return "hello";
        }

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
            var companyCarViewModel = new CompanyCar(ViewModel.SelectedCompanyCar);
            companyCarViewModel.PropertyChanged += (obj, ev) => EditDialog.IsPrimaryButtonEnabled = companyCarViewModel.IsValid;
            companyCarViewModel.Validate();
            EditDialog.DataContext = companyCarViewModel;
            //EditDialog.MinWidth = 700;
            //EditDialog.MaxWidth = 700;
            //EditDialog.Width = 700;

            var result = await EditDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                // Update model
                companyCarViewModel.Update(ViewModel.SelectedCompanyCar);
            }
        }
    }
}
