using AutoRepairShop.Logic.Factories.Interfaces;
using AutoRepairShop.Logic.Models.Implementation;
using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Factories.Implementation
{
    public class RecalledCarsDataFactory : IRecalledCarsDataFactory
    {
        public IRecalledCarsData Create()
        {
            return new RecalledCarsData();
        }
    }
}