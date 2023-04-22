using AutoRepairShop.Logic.Factories.Interfaces;
using AutoRepairShop.Logic.Models.Implementation;

namespace AutoRepairShop.Logic.Factories.Implementation
{
    public class DateValidatorFactory : IDateValidatorFactory
    {
        public DateValidator Create()
        {
            return new DateValidator();
        }
    }
}
