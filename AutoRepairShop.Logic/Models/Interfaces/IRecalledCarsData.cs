using AutoRepairShop.Logic.Models.Implementation;

namespace AutoRepairShop.Logic.Models.Interfaces
{
    public interface IRecalledCarsData
    {
        RecalledCar[] Cars { get; }
    }
}
