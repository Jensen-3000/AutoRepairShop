using AutoRepairShop.Logic.Models.Implementation;

namespace AutoRepairShop.Logic.Models.Interfaces
{
    public interface IRecallChecker
    {
        RecalledCar FindRecalledCar(Car car);
    }
}