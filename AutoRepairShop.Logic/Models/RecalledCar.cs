namespace AutoRepairShop.Logic.Models
{
    public class RecalledCar : Car
    {
        public DateTime RecallThresholdDate { get; set; }
        public string FactoryDefect { get; set; }
    }

    public class RecalledCars
    {
        public RecalledCar[] recalledCars = new RecalledCar[]
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