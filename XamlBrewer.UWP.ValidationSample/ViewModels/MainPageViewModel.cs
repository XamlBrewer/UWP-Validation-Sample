using Mvvm;
using System.Collections.Generic;
using XamlBrewer.UWP.ValidationSample.Models;

namespace XamlBrewer.UWP.ValidationSample.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        public List<CompanyCar> Cars => CarFleet.Cars;

        private CompanyCar selectedCompanyCar;

        public CompanyCar SelectedCompanyCar
        {
            get { return selectedCompanyCar; }
            set
            {
                SetProperty(ref selectedCompanyCar, value);
                OnPropertyChanged(nameof(HasSelection));
            }
        }

        public bool HasSelection => SelectedCompanyCar != null;
    }
}
