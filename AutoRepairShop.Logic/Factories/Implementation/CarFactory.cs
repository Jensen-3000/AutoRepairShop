using AutoRepairShop.Logic.Factories.Interfaces;
using AutoRepairShop.Logic.Models.Implementation;

namespace AutoRepairShop.Logic.Factories.Implementation
{
    public class CarFactory : ICarFactory
    {
        public Car Create(string brand, string model, DateTime year, DateTime lastInspectionDate)
        {
            return new Car(brand, model, year, lastInspectionDate);
        }
    }
}