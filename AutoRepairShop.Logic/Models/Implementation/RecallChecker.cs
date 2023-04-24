using AutoRepairShop.Logic.Models.Interfaces;
using AutoRepairShop.Logic.Utilities;

namespace AutoRepairShop.Logic.Models.Implementation
{
    public class RecallChecker : IRecallChecker
    {
        private IRecalledCarsData _recalledCars;

        public RecallChecker(IRecalledCarsData recalledCars)
        {
            _recalledCars = recalledCars;
        }

        public RecalledCar FindRecalledCar(Car car)
        {
            return _recalledCars.Cars.FirstOrDefault(recalledCarItem => IsCarRecalled(car, recalledCarItem));
        }

        private bool IsCarRecalled(Car car, RecalledCar recalledCarItem)
        {
            return car.Brand.Equals(StringUtil.CleanString(recalledCarItem.Brand), StringComparison.OrdinalIgnoreCase) &&
                   car.Model.Equals(StringUtil.CleanString(recalledCarItem.Model), StringComparison.OrdinalIgnoreCase) &&
                   car.ModelYear < recalledCarItem.RecallThresholdDate;
        }
    }
}