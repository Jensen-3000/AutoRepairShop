using AutoRepairShop.Logic.Factories.Interfaces;
using AutoRepairShop.Logic.Models.Implementation;
using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Factories.Implementation
{
    public class RecallCheckerFactory : IRecallCheckerFactory
    {
        public RecallChecker Create(IRecalledCarsData database)
        {
            return new RecallChecker(database);
        }
    }
}