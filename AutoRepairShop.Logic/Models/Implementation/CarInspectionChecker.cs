namespace AutoRepairShop.Logic.Models.Implementation
{
    public struct CarInspectionChecker
    {
        private readonly int _inspectionFrequencyYears;
        private readonly int _minCarAgeBeforeInspectionIsRequired;

        // Hvor mange år der skal være mellem syn
        public const int DefaultInspectionFrequencyYears = 2;
        // Minimums alder før den skal til syn
        public const int DefaultMinCarAgeBeforeInspectionIsRequired = 4;

        public CarInspectionChecker()
        {
            _inspectionFrequencyYears = DefaultInspectionFrequencyYears;
            _minCarAgeBeforeInspectionIsRequired = DefaultMinCarAgeBeforeInspectionIsRequired;
        }
        /// <summary>
        /// Kontrollere om bilen skal til syn eller ej,
        /// baseret på Årgang, Sidste syns dato og nuværende dato
        /// </summary>
        /// <returns>True hvis bilen skal til syn ellers False</returns>
        public bool IsInspectionRequired(DateTime modelYear, DateTime lastInspectionDate, DateTime currentDate)
        {
            // Beregner bilens alder i år
            int carAgeInYears = currentDate.Year - modelYear.Year;

            // Beregner dage siden sidste syn
            int daysSinceLastInspection = (int)(currentDate - lastInspectionDate).TotalDays;

            // Beregner intervalet i dage.
            int inspectionIntervalInDays = _inspectionFrequencyYears * DaysPerYear(currentDate.Year);

            // True hvis bilen er gammel nok
            bool isCarOldEnough = carAgeInYears > _minCarAgeBeforeInspectionIsRequired;

            // True hvis det tid til syn
            bool isTimeForInspection = daysSinceLastInspection >= inspectionIntervalInDays;

            // Returns True hvis begge er true
            return isCarOldEnough && isTimeForInspection;
        }

        private int DaysPerYear(int year)
        {
            return DateTime.IsLeapYear(year) ? 366 : 365;
        }
    }
}