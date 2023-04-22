using AutoRepairShop.Logic.Factories.Implementation;
using AutoRepairShop.Logic.Factories.Interfaces;
using AutoRepairShop.Logic.Models.Implementation;
using AutoRepairShop.Logic.Utilities;
using AutoRepairShop.UI.Prompts;

while (true)
{
    int dateMinValue = 1900;
    int dateMaxValue = DateTime.Now.Year + 1;

    #region Init Factories
    IDateValidatorFactory dateValidatorFactory = new DateValidatorFactory();
    ICarInspectionCheckerFactory carInspectionCheckerFactory = new CarInspectionCheckerFactory();
    ICarFactory carFactory = new CarFactory();
    IRecallCheckerFactory recallCheckerFactory = new RecallCheckerFactory();
    #endregion

    try
    {
        #region User inputs for Brand, Model, Year and last inspection date
        // Asks Car brand
        Console.Write(UserPrompts.CarBrand);
        string brandInput = Console.ReadLine();
        brandInput = StringUtil.CleanString(brandInput);

        // Asks for Car Model
        Console.Write(UserPrompts.CarModel);
        string modelInput = Console.ReadLine();
        modelInput = StringUtil.CleanString(modelInput);

        // Asks for Car Year
        Console.Write(UserPrompts.CarYear);
        string yearInput = Console.ReadLine();
        DateTime modelYear = dateValidatorFactory.Create().GetCarModelYear(yearInput, dateMinValue, dateMaxValue);

        // Asks for last inspection date
        Console.Write(UserPrompts.CarLastInspectionDate);
        string inspectionDateInput = Console.ReadLine();
        DateTime lastInspectionDate = dateValidatorFactory.Create().GetLastInspectionDate(inspectionDateInput, dateMinValue, dateMaxValue);
        #endregion


        // Create car object and puts data into it
        Car car = carFactory.Create(brandInput, modelInput, modelYear, lastInspectionDate);

        #region Checks if car needs an inspection
        CarInspectionChecker carInspectionChecker = carInspectionCheckerFactory.Create();
        bool needsInspection = carInspectionChecker.IsInspectionRequired(car);
        if (needsInspection)
        {
            Console.WriteLine($"{UserPrompts.NeedsInspection}");
        }
        else
        {
            Console.WriteLine($"{UserPrompts.DoesntNeedsInspection}");
        }
        #endregion


        #region Checks if the car is being recalled because of defects
        RecalledCars recalledCarsDatabase = new RecalledCars();
        RecallChecker carRecallChecker = recallCheckerFactory.Create(recalledCarsDatabase);
        RecalledCar matchingRecalledCar = carRecallChecker.FindRecalledCar(car);
        if (matchingRecalledCar != null)
        {
            Console.WriteLine($"{UserPrompts.Defect}: {matchingRecalledCar.FactoryDefect}");
        }
        #endregion

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fejl: {ex.Message}");
    }

    #region Prompts user if they want to quit the program
    Console.WriteLine(UserPrompts.PressToQuitProgram);
    if (Console.ReadKey().Key == ConsoleKey.Q) break;
    Console.Clear();
    #endregion
}