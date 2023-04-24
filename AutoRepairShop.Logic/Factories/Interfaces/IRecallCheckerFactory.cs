using AutoRepairShop.Logic.Models.Implementation;

namespace AutoRepairShop.Logic.Factories.Interfaces
{
    public interface IRecallCheckerFactory
    {
        RecallChecker Create(RecalledCarsData database);
    }
}