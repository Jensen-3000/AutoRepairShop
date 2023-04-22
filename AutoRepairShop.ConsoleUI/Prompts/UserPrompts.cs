namespace AutoRepairShop.UI.Prompts
{
    public class UserPrompts
    {
        #region Prompts for user input for car brand, model etc.
        public const string CarBrand = "Indtast bilmærke: ";
        public const string CarModel = "Indtast bilmodel: ";
        public const string CarYear = "Indtast bilens årgang: ";
        public const string CarLastInspectionDate = "Indtast bilens sidste syns dato (dd-MM-yyyy)" +
                                                    "\nHvis bilen ikke har været synet før tast 0000: ";
        #endregion

        #region Prompts for if the Car needs Inspection or not
        public const string NeedsInspection = "Bilen skal til syn.";
        public const string DoesntNeedsInspection = "Bilen skal IKKE til syn.";
        #endregion

        public const string Defect = "Bilen har følgende fabriksfejl";

        public const string PressToQuitProgram = "Tryk 'q' for at afslutte eller en anden vilkårlig tast for at genstarte programmet.";
    }
}