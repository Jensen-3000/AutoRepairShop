using AutoRepairShop.Logic.Utilities;

namespace AutoRepairShop.Logic.Models
{
    public class RecallChecker
    {
        private RecalledCars _recalledCars;

        public RecallChecker(RecalledCars recalledCars)
        {
            _recalledCars = recalledCars;
        }

        public RecalledCar FindRecalledCar(Car car)
        {
            return _recalledCars.recalledCars.FirstOrDefault(recalledCarItem => IsCarRecalled(car, recalledCarItem));
        }

        private bool IsCarRecalled(Car car, RecalledCar recalledCarItem)
        {
            return car.Brand.Equals(StringUtil.CleanString(recalledCarItem.Brand), StringComparison.OrdinalIgnoreCase) &&
                   car.Model.Equals(StringUtil.CleanString(recalledCarItem.Model), StringComparison.OrdinalIgnoreCase) &&
                   car.ModelYear < recalledCarItem.RecallThresholdDate;
        }
    }

}
