using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Models.Implementation
{
    public class RecalledCarsData : IRecalledCarsData
    {
        public RecalledCar[] Cars { get; } = new RecalledCar[]
        {
            new RecalledCar
            {
                Brand = "Fiat",
                Model = "Punto",
                RecallThresholdDate = new DateTime(2010,01,01),
                FactoryDefect = "Udstødning"
            },
            new RecalledCar
            {
                Brand = "Alfa Romeo",
                Model = "Giulia",
                RecallThresholdDate = new DateTime(2019,07,01),
                FactoryDefect = "Styretøjet"
            }
        };
    }
}