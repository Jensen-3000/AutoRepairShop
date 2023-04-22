namespace AutoRepairShop.UI.Prompts
{
    public class UserPrompts
    {
        #region Prompt for Indtastning for bil mærke, model etc.
        public const string CarBrand = "Indtast bilmærke: ";
        public const string CarModel = "Indtast bilmodel: ";
        public const string CarYear = "Indtast bilens årgang: ";
        public const string CarLastInspectionDate = "Indtast bilens sidste syns dato (dd-MM-yyyy)" +
                                                    "\nHvis bilen ikke har været synet før tast 0000: ";
        #endregion
        public const string PressToQuitProgram = "Tryk 'q' for at afslutte eller en anden vilkårlig tast for at genstarte programmet.";
    }
}
