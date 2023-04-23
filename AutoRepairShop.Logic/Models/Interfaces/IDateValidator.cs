namespace AutoRepairShop.Logic.Models.Interfaces
{
    public interface IDateValidator
    {
        DateTime GetCarModelYear(string input);
        DateTime GetLastInspectionDate(string input);
    }
}