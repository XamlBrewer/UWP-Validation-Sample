using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlBrewer.UWP.ValidationSample.Models
{
    public class CompanyCar
    {
        public string Brand { get; set; }

        public string Type { get; set; }

        public string Body { get; set; }

        public string PowerUnit { get; set; }

        public DateTime ProductionDate { get; set; }

        public DateTime FirstUseDate { get; set; }

        public double Mileage { get; set; }

        public double Emission { get; set; }

        public string Driver { get; set; }

        // This is soooo not MVVM.
        public string BodyIcon => Mvvm.Services.Icon.GetIcon(Body + "Icon");
    }
}
