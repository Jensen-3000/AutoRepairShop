namespace AutoRepairShop.Logic.ErrorMessages
{
    /// <summary>
    /// Error messages for DateValidator struct / wrong user inputs.
    /// </summary>
    public static class InputErrorMessages
    {
        #region Errors for wrong input Format
        public const string CarModelYearFormat = "Forkert format. Skal være yyyy. fx. 1999";
        public const string LastInspectionDateFormat = "Forkert format. Skal være dd-MM-yyyy. fx. 01-12-1999";
        #endregion

        #region Errors for wrong input Range
        public const string CarModelYearRange = "Årgang skal være mellem {0} og {1}.";
        public const string LastInspectionDateRange = "Sidste syns dato skal være mellem {0} og {1}.";
        #endregion
    }
}