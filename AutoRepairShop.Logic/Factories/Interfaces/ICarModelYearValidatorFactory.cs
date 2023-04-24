using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Factories.Interfaces
{
    public interface ICarModelYearValidatorFactory
    {
        ICarModelYearValidator Create();
    }
}