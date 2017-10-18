using Mvvm;
using System;
using System.Collections.Generic;

namespace XamlBrewer.UWP.ValidationSample.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        public List<Models.CompanyCar> Cars => new List<Models.CompanyCar>
        {
            new Models.CompanyCar { Brand = "Aston Martin", Type = "DB5", Body="Car", PowerUnit="Petrol", ProductionDate = new DateTime(2000, 10, 1), FirstUseDate = new DateTime(2000, 10, 1), Driver="James" },
            new Models.CompanyCar { Brand = "DeLorean", Type = "DMC-12", Body="Car", PowerUnit="Petrol", ProductionDate = new DateTime(2000, 10, 1), FirstUseDate = new DateTime(2000, 10, 1), Driver="Marty" },
            new Models.CompanyCar { Brand = "Jaguar", Type = "XKR Convertible", Body="Convertible", PowerUnit="Petrol", ProductionDate = new DateTime(2000, 10, 1), FirstUseDate = new DateTime(2000, 10, 1), Driver = "Diederik" },
            new Models.CompanyCar { Brand = "Little", Type="Tank", Body = "Tank", PowerUnit="Gasoline", ProductionDate = new DateTime(2000, 10, 1), FirstUseDate = new DateTime(2000, 10, 1), Driver = "Lt. Grüber" },
            new Models.CompanyCar { Brand = "McLaren Honda", Type = "MCL32", Body="Convertible", PowerUnit="Hybrid", ProductionDate = new DateTime(2000, 10, 1), FirstUseDate = new DateTime(2000, 10, 1), Driver = "Stoffel" },
            new Models.CompanyCar { Brand = "Mercedes", Type = "G Wagon", Body="Suv", PowerUnit="Petrol", ProductionDate = new DateTime(2000, 10, 1), FirstUseDate = new DateTime(2000, 10, 1), Driver = "Kanye" },
            new Models.CompanyCar { Brand = "Tesla", Type = "Model X P100D", Body="Suv", PowerUnit="Electricity", ProductionDate = new DateTime(2000, 10, 1), FirstUseDate = new DateTime(2000, 10, 1), Driver = "Elon" },
            new Models.CompanyCar { Brand = "Volkswagen", Type = "Bus", Body = "Van", PowerUnit="Petrol", ProductionDate = new DateTime(2000, 10, 1), FirstUseDate = new DateTime(2000, 10, 1),  Driver = "Jimi" }
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
