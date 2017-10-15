using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlBrewer.UWP.ValidationSample.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        public List<Models.CompanyCar> Cars => new List<Models.CompanyCar>
        {
            new Models.CompanyCar { Brand = "BMW"},
            new Models.CompanyCar {Brand = "Ford"},
            new Models.CompanyCar {Brand = "Jaguar"},
            new Models.CompanyCar {Brand = "Maserati"},
            new Models.CompanyCar {Brand = "Tesla"}
        };

        private Models.CompanyCar selectedCompanyCar;

        public Models.CompanyCar SelectedCompanyCar
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
