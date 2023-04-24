using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Factories.Interfaces
{
    public interface ILastInspectionDateValidatorFactory
    {
        ILastInspectionDateValidator Create();
    }
}