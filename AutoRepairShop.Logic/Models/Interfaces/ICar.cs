namespace AutoRepairShop.Logic.Models.Interfaces
{
    public interface ICar
    {
        string Brand { get; set; }
        DateTime LastInspectionDate { get; set; }
        string Model { get; set; }
        DateTime ModelYear { get; set; }
    }
}