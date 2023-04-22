using AutoRepairShop.Logic.Models.Implementation;

namespace AutoRepairShop.Logic.Factories.Interfaces
{
    public interface ICarInspectionCheckerFactory
    {
        CarInspectionChecker Create();
    }
}