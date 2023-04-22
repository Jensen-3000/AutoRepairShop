using AutoRepairShop.Logic.Factories.Interfaces;
using AutoRepairShop.Logic.Models.Implementation;

namespace AutoRepairShop.Logic.Factories.Implementation
{
    public class RecallCheckerFactory : IRecallCheckerFactory
    {
        public RecallChecker Create(RecalledCars database)
        {
            return new RecallChecker(database);
        }
    }
}
