using AutoRepairShop.Logic.Models.Implementation;
using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Factories.Interfaces
{
    public interface IRecallCheckerFactory
    {
        RecallChecker Create(IRecalledCarsData database);
    }
}