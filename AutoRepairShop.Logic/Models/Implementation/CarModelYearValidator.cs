using AutoRepairShop.Logic.ErrorMessages;
using AutoRepairShop.Logic.Models.Interfaces;
using System.Globalization;

namespace AutoRepairShop.Logic.Models.Implementation
{
    public class CarModelYearValidator : DateValidatorBase, ICarModelYearValidator
    {
        public CarModelYearValidator(IDateTimeProvider dateTimeProvider) : base(dateTimeProvider) { }
        /// <summary>
        /// Validere årgangen for bilen ved at følge det korrekte input format. ie: yyyy
        /// </summary>
        public DateTime ValidateCarModelYear(string input)
        {
            if (!DateTime.TryParseExact(input, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime modelYear))
            {
                throw new FormatException(InputErrorMessages.CarModelYearFormat);
            }

            if (modelYear.Year < MinYear || modelYear.Year > MaxYear)
            {
                throw new ArgumentOutOfRangeException("", string.Format(InputErrorMessages.CarModelYearRange, MinYear, MaxYear));
            }
            return modelYear;
        }
    }
}