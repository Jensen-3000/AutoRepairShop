using AutoRepairShop.Logic.ErrorMessages;
using AutoRepairShop.Logic.Models.Interfaces;
using System.Globalization;

namespace AutoRepairShop.Logic.Models.Implementation
{
    public struct DateValidator : IDateValidator
    {
        private const int MinYear = 1900;
        private readonly int _maxYear;

        public DateValidator(DateTime currentDateTime)
        {
            _maxYear = currentDateTime.Year + 1;
        }

        public DateTime GetCarModelYear(string input)
        {
            if (!DateTime.TryParseExact(input, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime modelYear))
            {
                throw new FormatException(InputErrorMessages.CarModelYearFormat);
            }

            else if (modelYear.Year < MinYear || modelYear.Year > _maxYear)
            {
                throw new ArgumentOutOfRangeException("", string.Format(InputErrorMessages.CarModelYearRange, MinYear, _maxYear));
            }
            return modelYear;
        }

        public DateTime GetLastInspectionDate(string input)
        {
            if (input == "0000")
            {
                return DateTime.MinValue;
            }

            if (!DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime lastInspectionDate))
            {
                throw new FormatException(InputErrorMessages.LastInspectionDateFormat);
            }

            else if (lastInspectionDate.Year < MinYear || lastInspectionDate.Year > _maxYear)
            {
                throw new ArgumentOutOfRangeException("", string.Format(InputErrorMessages.LastInspectionDateRange, MinYear, _maxYear));
            }
            return lastInspectionDate;
        }
    }
}