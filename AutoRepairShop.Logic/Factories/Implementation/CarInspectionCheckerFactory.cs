using AutoRepairShop.Logic.Factories.Interfaces;
using AutoRepairShop.Logic.Models.Implementation;

namespace AutoRepairShop.Logic.Factories.Implementation
{
    public class CarInspectionCheckerFactory : ICarInspectionCheckerFactory
    {
        public CarInspectionChecker Create()
        {
            return new CarInspectionChecker();
        }
    }
}