using AutoRepairShop.Logic.ErrorMessages;
using System.Globalization;

namespace AutoRepairShop.Logic.Models
{
    public struct DateValidator
    {
        public DateTime GetCarModelYear(string input, int minYear, int maxYear)
        {
            DateTime modelYear;

            if (!DateTime.TryParseExact(input, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out modelYear))
            {
                throw new FormatException(ErrorMessagesLogic.CarModelYearFormat);
            }

            if (modelYear.Year < minYear || modelYear.Year > maxYear)
            {
                throw new ArgumentOutOfRangeException(string.Format(ErrorMessagesLogic.CarModelYearRange, minYear, maxYear));
            }
            return modelYear;
        }

        public DateTime GetLastInspectionDate(string input, int minYear, int maxYear)
        {
            DateTime lastInspectionDate;

            if (input == "0000")
            {
                lastInspectionDate = DateTime.MinValue;
            }

            if (!DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastInspectionDate))
            {
                throw new FormatException(ErrorMessagesLogic.LastInspectionDateFormat);
            }

            if (lastInspectionDate.Year < minYear || lastInspectionDate.Year > maxYear)
            {
                throw new ArgumentOutOfRangeException(string.Format(ErrorMessagesLogic.LastInspectionDateRange, minYear, maxYear));
            }
            return lastInspectionDate;
        }
    }
}