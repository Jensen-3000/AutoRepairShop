namespace AutoRepairShop.Logic.ErrorMessages
{
    /// <summary>
    /// Fejl beskeder til bruger at de har indtastet noget forkert
    /// </summary>
    public static class InputErrorMessages
    {
        #region Fejl, forkert Format
        public const string CarModelYearFormat = "Forkert format. Skal være yyyy. fx. 1999";
        public const string LastInspectionDateFormat = "Forkert format. Skal være dd-MM-yyyy. fx. 01-12-1999";
        #endregion

        #region Fejl, forkert range
        public const string CarModelYearRange = "Årgang skal være mellem {0} og {1}.";
        public const string LastInspectionDateRange = "Sidste syns dato skal være mellem {0} og {1}.";
        #endregion
    }
}