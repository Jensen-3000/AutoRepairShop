using AutoRepairShop.Logic.Models.Implementation;

namespace AutoRepairShop.Logic.Factories.Interfaces
{
    public interface ICarFactory
    {
        Car Create(string brand, string model, DateTime year, DateTime lastInspectionDate);
    }
}