using System;
using Template10.Validation;

namespace XamlBrewer.UWP.ValidationSample.ViewModels
{
    public class CompanyCar : ValidatableModelBase
    {
        public CompanyCar(Models.CompanyCar model)
        {
            this.Brand = model.Brand;
            this.Type = model.Type;
            this.ProductionDate = model.ProductionDate;
            this.FirstUseDate = model.FirstUseDate;
            this.PowerUnit = model.PowerUnit;
            this.Emission = model.Emission;
            this.Mileage = model.Mileage;
            this.Driver = model.Driver;
            this.Validator = that => { Val(that as CompanyCar); };
        }

        public void Val(CompanyCar c)
        {
            if (string.IsNullOrEmpty(c.Type))
            {
                c.Properties[nameof(c.Brand)].Errors.Add("Type is mandatory.");
            }
        }

        public string Brand { get { return Read<string>(); } set { Write(value); } }

        public string Type { get { return Read<string>(); } set { Write(value); } }

        public string PowerUnit { get { return Read<string>(); } set { Write(value); } }

        public DateTime ProductionDate { get { return Read<DateTime>(); } set { Write(value); } }

        public DateTime FirstUseDate { get { return Read<DateTime>(); } set { Write(value); } }

        public double Mileage { get { return Read<double>(); } set { Write(value); } }

        public double Emission { get { return Read<double>(); } set { Write(value); } }

        public string Driver { get { return Read<string>(); } set { Write(value); } }
    }
}
