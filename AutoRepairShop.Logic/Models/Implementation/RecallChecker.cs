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
        // Finder og returnerer den tilbagekaldte bil baseret på bilens mærke, model og modelår.
        // Returnerer null, hvis bilen ikke er i listen over biler i RecalledCarsData
        public RecalledCar FindRecalledCar(Car car)
        {
            return _recalledCars.Cars.FirstOrDefault(recalledCarItem => IsCarRecalled(car, recalledCarItem));
        }
        // Retunere True hvis bilen har defekts, ellers false
        private bool IsCarRecalled(Car car, RecalledCar recalledCarItem)
        {
            return car.Brand.Equals(StringUtil.CleanString(recalledCarItem.Brand), StringComparison.OrdinalIgnoreCase) &&
                   car.Model.Equals(StringUtil.CleanString(recalledCarItem.Model), StringComparison.OrdinalIgnoreCase) &&
                   car.ModelYear < recalledCarItem.RecallThresholdDate;
        }
    }
}