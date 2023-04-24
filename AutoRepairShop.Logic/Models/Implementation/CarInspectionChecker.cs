namespace AutoRepairShop.Logic.Models.Implementation
{
    public struct CarInspectionChecker
    {
        private readonly int _inspectionFrequencyYears;
        private readonly int _minCarAgeBeforeInspectionIsRequired;

        public const int DefaultInspectionFrequencyYears = 2;
        public const int DefaultMinCarAgeBeforeInspectionIsRequired = 4;

        public CarInspectionChecker()
        {
            _inspectionFrequencyYears = DefaultInspectionFrequencyYears;
            _minCarAgeBeforeInspectionIsRequired = DefaultMinCarAgeBeforeInspectionIsRequired;
        }

        public bool IsInspectionRequired(DateTime modelYear, DateTime lastInspectionDate, DateTime currentDate)
        {
            int carAgeInYears = currentDate.Year - modelYear.Year;

            int daysSinceLastInspection = (int)(currentDate - lastInspectionDate).TotalDays;

            int inspectionIntervalInDays = _inspectionFrequencyYears * DaysPerYear(currentDate.Year);

            // True if car is old enough
            bool isCarOldEnough = carAgeInYears > _minCarAgeBeforeInspectionIsRequired;

            // True if time for inspection
            bool isTimeForInspection = daysSinceLastInspection >= inspectionIntervalInDays;

            // Returns true if both conditions are met
            return isCarOldEnough && isTimeForInspection;
        }

        private int DaysPerYear(int year)
        {
            return DateTime.IsLeapYear(year) ? 366 : 365;
        }
    }
}