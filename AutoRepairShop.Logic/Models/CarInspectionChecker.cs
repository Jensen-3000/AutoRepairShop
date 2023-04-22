namespace AutoRepairShop.Logic.Models
{
    public struct CarInspectionChecker
    {
        public bool IsInspectionRequired(Car car)
        {
            const int inspectionFrequencyYears = 2;
            const int minCarAgeBeforeInspectionIsRequired = 4;
            const int daysPerYear = 365;

            int carAge = DateTime.Now.Year - car.ModelYear.Year;

            int daysSinceLastInspection = (int)(DateTime.Now - car.LastInspectionDate).TotalDays;
            int daysBetweenInspections = inspectionFrequencyYears * daysPerYear;

            return carAge > minCarAgeBeforeInspectionIsRequired && daysSinceLastInspection >= daysBetweenInspections;
        }
    }
}
