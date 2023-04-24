using AutoRepairShop.Logic.Models.Interfaces;

namespace AutoRepairShop.Logic.Models.Implementation
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}