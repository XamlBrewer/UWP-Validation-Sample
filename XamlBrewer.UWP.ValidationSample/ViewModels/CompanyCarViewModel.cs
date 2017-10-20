using System;
using System.Collections.Generic;
using Template10.Validation;

namespace XamlBrewer.UWP.ValidationSample.ViewModels
{
    public class CompanyCarViewModel : ValidatableModelBase
    {
        public CompanyCarViewModel(Models.CompanyCar model)
        {
            this.Brand = model.Brand;
            this.Type = model.Type;
            this.Body = model.Body;
            this.ProductionDate = model.ProductionDate;
            this.FirstUseDate = model.FirstUseDate;
            this.PowerUnit = model.PowerUnit;
            this.Emission = model.Emission;
            this.Mileage = model.Mileage;
            this.Driver = model.Driver;
            this.Validator = that => { Validation_Executed(that as CompanyCarViewModel); };

            // Not needed: ValidatableModelBase constructor does this.
            // this.PropertyChanged += (o, e) => Val(o as CompanyCar);
        }

        public string Brand { get { return Read<string>(); } set { Write(value); } }

        public string Type { get { return Read<string>(); } set { Write(value); } }

        public string Body { get { return Read<string>(); } set { Write(value); } }

        public string PowerUnit { get { return Read<string>(); } set { Write(value); } }

        public DateTime ProductionDate { get { return Read<DateTime>(); } set { Write(value); } }

        public DateTime FirstUseDate { get { return Read<DateTime>(); } set { Write(value); } }

        public double Mileage { get { return Read<double>(); } set { Write(value); } }

        public double Emission { get { return Read<double>(); } set { Write(value); } }

        public string Driver { get { return Read<string>(); } set { Write(value); } }

        public List<String> BodyTypes => new List<string>
        {
            "Car",
            "Convertible",
            "Suv",
            "Tank",
            "Van"
        };

        public List<string> PowerUnitTypes => new List<string>
        {
            "Dilithium Crystals",
            "Electricity",
            "Gasoline",
            "Hybrid",
            "Hydrogen",
            "Petrol"
        };

        internal void Update(Models.CompanyCar model)
        {
            model.Brand = this.Brand;
            model.Type = this.Type;
            model.Body = this.Body;
            model.ProductionDate = this.ProductionDate;
            model.FirstUseDate = this.FirstUseDate;
            model.PowerUnit = this.PowerUnit;
            model.Emission = this.Emission;
            model.Mileage = this.Mileage;
            model.Driver = this.Driver;
        }

        private void Validation_Executed(CompanyCarViewModel c)
        {
            if (string.IsNullOrEmpty(c.Brand))
            {
                c.Properties[nameof(c.Brand)].Errors.Add("Brand is mandatory.");
            }

            if (string.IsNullOrEmpty(c.Type))
            {
                c.Properties[nameof(c.Type)].Errors.Add("Type is mandatory.");
            }

            // Compare two properties.
            if (c.FirstUseDate < c.ProductionDate)
            {
                // Unfortunately errors have to be assigned to a property.
                c.Properties[nameof(c.FirstUseDate)].Errors.Add("Date of first use should come after date of production.");
            }

            // Compare with original value.
            if (c.Mileage < (c.Properties[nameof(c.Mileage)] as Property<double>).OriginalValue)
            {
                c.Properties[nameof(c.Mileage)].Errors.Add("Turning back the mileage is illegal.");
            }
        }
    }
}
