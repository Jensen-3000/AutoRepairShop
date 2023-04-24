using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Models.Implementation
{
    public struct Car : ICar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ModelYear { get; set; }
        public DateTime LastInspectionDate { get; set; }

        public Car(string brand, string model, DateTime year, DateTime lastInspectionDate)
        {
            Brand = brand;
            Model = model;
            ModelYear = year;
            LastInspectionDate = lastInspectionDate;
        }
    }
}