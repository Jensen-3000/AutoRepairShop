using AutoRepairShop.Logic.ErrorMessages;
using AutoRepairShop.Logic.Models.Interfaces;
using System.Globalization;

namespace AutoRepairShop.Logic.Models.Implementation
{
    public class LastInspectionDateValidator : DateValidatorBase, ILastInspectionDateValidator
    {
        public LastInspectionDateValidator(IDateTimeProvider dateTimeProvider) : base(dateTimeProvider) { }
        /// <summary>
        /// Validere at årstal er i korrekt format ie: dd-mm-yyyy for bilens sidste syns dato
        /// Hvis input er 0000 er bilen ikke synet før.
        /// </summary>
        public DateTime ValidateLastInspectionDate(string input)
        {
            if (input == "0000")
            {
                return DateTime.MinValue;
            }

            if (!DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime lastInspectionDate))
            {
                throw new FormatException(InputErrorMessages.LastInspectionDateFormat);
            }

            else if (lastInspectionDate.Year < MinYear || lastInspectionDate.Year > MaxYear)
            {
                throw new ArgumentOutOfRangeException("", string.Format(InputErrorMessages.LastInspectionDateRange, MinYear, MaxYear));
            }
            return lastInspectionDate;
        }
    }
}