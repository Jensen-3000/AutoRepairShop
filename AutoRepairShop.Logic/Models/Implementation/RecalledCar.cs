using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Models.Implementation
{
    public class RecalledCar : ICar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ModelYear { get; set; }
        public DateTime LastInspectionDate { get; set; }
        public DateTime RecallThresholdDate { get; set; }
        public string FactoryDefect { get; set; }
    }
}