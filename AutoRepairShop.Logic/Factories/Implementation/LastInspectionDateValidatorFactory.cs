using AutoRepairShop.Logic.Factories.Interfaces;
using AutoRepairShop.Logic.Models.Implementation;
using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Factories.Implementation
{
    public class LastInspectionDateValidatorFactory : ILastInspectionDateValidatorFactory
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public LastInspectionDateValidatorFactory(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public ILastInspectionDateValidator Create()
        {
            return new LastInspectionDateValidator(_dateTimeProvider);
        }
    }
}