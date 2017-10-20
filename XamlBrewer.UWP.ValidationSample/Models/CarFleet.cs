using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlBrewer.UWP.ValidationSample.Models
{
    /// <summary>
    /// Not StarFleet.
    /// </summary>
    public class CarFleet : BindableBase
    {
        public static List<CompanyCar> Cars => new List<CompanyCar>
        {
            new CompanyCar { Brand = "Aston Martin", Type = "DB5", Body="Car", PowerUnit="Petrol", ProductionDate = new DateTime(1964, 5, 1), FirstUseDate = new DateTime(1964, 5, 1), Driver="James", Mileage=12000, Emission=600 },
            new CompanyCar { Brand = "DeLorean", Type = "DMC-12", Body="Car", PowerUnit="Petrol", ProductionDate = new DateTime(1982, 4, 1), FirstUseDate = new DateTime(1982, 5, 1), Driver="Marty", Mileage=10000000, Emission=400 },
            new CompanyCar { Brand = "Jaguar", Type = "XKR Convertible", Body="Convertible", PowerUnit="Petrol", ProductionDate = new DateTime(1999, 3, 20), FirstUseDate = new DateTime(1999, 4, 17), Driver = "Diederik",Mileage=115000, Emission=400 },
            new CompanyCar { Brand = "Little", Type="Tank", Body = "Tank", PowerUnit="Gasoline", ProductionDate = new DateTime(2000, 10, 1), FirstUseDate = new DateTime(2000, 10, 1), Driver = "Lt. Grüber",Mileage=4000, Emission=12000 },
            new CompanyCar { Brand = "McLaren Honda", Type = "MCL32", Body="Convertible", PowerUnit="Hybrid", ProductionDate = new DateTime(2017, 10, 1), FirstUseDate = new DateTime(2017, 10, 1), Driver = "Stoffel", Mileage=300, Emission=800 },
            new CompanyCar { Brand = "Mercedes", Type = "G Wagon", Body="Suv", PowerUnit="Petrol", ProductionDate = new DateTime(2015, 8, 1), FirstUseDate = new DateTime(2015, 10, 1), Driver = "Kanye", Mileage=4000, Emission=400 },
            new CompanyCar { Brand = "Tesla", Type = "Model X P100D", Body="Suv", PowerUnit="Electricity", ProductionDate = new DateTime(2017, 2, 1), FirstUseDate = new DateTime(2017, 2, 2), Driver = "Elon", Mileage=100000, Emission=0 },
            new CompanyCar { Brand = "Volkswagen", Type = "Bus", Body = "Van", PowerUnit="Petrol", ProductionDate = new DateTime(1966, 10, 1), FirstUseDate = new DateTime(1967, 2, 1),  Driver = "Jimi", Mileage=230000, Emission=200 }
        };
    }
}
