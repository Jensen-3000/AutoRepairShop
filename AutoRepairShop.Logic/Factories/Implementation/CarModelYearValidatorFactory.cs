using AutoRepairShop.Logic.Factories.Interfaces;
using AutoRepairShop.Logic.Models.Implementation;
using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Factories.Implementation
{
    public class CarModelYearValidatorFactory : ICarModelYearValidatorFactory
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public CarModelYearValidatorFactory(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public ICarModelYearValidator Create()
        {
            return new CarModelYearValidator(_dateTimeProvider);
        }
    }
}