using Mvvm;
using System;

namespace XamlBrewer.UWP.ValidationSample.Models
{
    public class CompanyCar : BindableBase
    {
        private string _brand;
        private string _type;
        private string _body;
        private string _powerUnit;
        private DateTime _productionDate;
        private DateTime _firstUseDate;
        private double _mileage;
        private double _emission;
        private string _driver;

        public string Brand
        {
            get { return _brand; }
            set { SetProperty(ref _brand, value); }
        }

        public string Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                SetProperty(ref _body, value);
                OnPropertyChanged(nameof(BodyIcon));
            }
        }

        public string PowerUnit
        {
            get { return _powerUnit; }
            set { SetProperty(ref _powerUnit, value); }
        }

        public DateTime ProductionDate
        {
            get { return _productionDate; }
            set { SetProperty(ref _productionDate, value); }
        }

        public DateTime FirstUseDate
        {
            get { return _firstUseDate; }
            set { SetProperty(ref _firstUseDate, value); }
        }

        public double Mileage
        {
            get { return _mileage; }
            set { SetProperty(ref _mileage, value); }
        }

        public double Emission
        {
            get { return _emission; }
            set { SetProperty(ref _emission, value); }
        }

        public string Driver
        {
            get { return _driver; }
            set { SetProperty(ref _driver, value); }
        }

        // This is soooo not MVVM ;-)
        public string BodyIcon => Mvvm.Services.Icon.GetIcon(Body + "Icon");
    }
}
