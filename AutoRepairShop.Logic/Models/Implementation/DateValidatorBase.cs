using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Models.Implementation
{
    // Her sættes minimum dato for årstal og max årstal som er currentdate +1 år
    // Bliver brugt i CarModelYearValidator og LastInspectionDateValidator
    public abstract class DateValidatorBase
    {
        protected const int MinYear = 1900;
        protected readonly int MaxYear;
        protected readonly IDateTimeProvider DateTimeProvider;

        protected DateValidatorBase(IDateTimeProvider dateTimeProvider)
        {
            DateTimeProvider = dateTimeProvider;
            MaxYear = DateTimeProvider.Now.Year + 1;
        }
    }
}