namespace AutoRepairShop.Logic.Models.Interfaces
{
    public interface ILastInspectionDateValidator
    {
        DateTime ValidateLastInspectionDate(string input);
    }
}