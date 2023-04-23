using AutoRepairShop.Logic.Models.Implementation;

namespace AutoRepairShop.Logic.Models.Interfaces
{
    public interface IRecalledCars
    {
        RecalledCar[] Cars { get; }
    }
}
