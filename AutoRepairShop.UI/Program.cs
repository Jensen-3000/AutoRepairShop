using AutoRepairShop.Logic.Models;
using AutoRepairShop.Logic.Utilities;
using AutoRepairShop.UI.Prompts;

while (true)
{
    int dateMinValue = 1900;
    int dateMaxValue = DateTime.Now.Year + 1;

    DateValidator dateValidator = new DateValidator();
    try
    {
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
        DateTime modelYear = dateValidator.GetCarModelYear(yearInput, dateMinValue, dateMaxValue);

        // Asks for last inspection date
        Console.Write(UserPrompts.CarLastInspectionDate);
        string inspectionDateInput = Console.ReadLine();
        DateTime lastInspectionDate = dateValidator.GetLastInspectionDate(inspectionDateInput, dateMinValue, dateMaxValue);

        // Create car object and puts data into it
        Car car = new Car
        {
            Brand = brandInput,
            Model = modelInput,
            ModelYear = modelYear,
            LastInspectionDate = lastInspectionDate
        };

        // Checks if car needs an inspection
        CarInspectionChecker carInspectionChecker = new CarInspectionChecker();
        bool needsInspection = carInspectionChecker.IsInspectionRequired(car);
        if (needsInspection)
        {
            Console.WriteLine($"{UserPrompts.NeedsInspection}");
        }
        else
        {
            Console.WriteLine($"{UserPrompts.DoesntNeedsInspection}");

        }

        // Checks if the car is being recalled because of defects
        RecalledCars recalledCarsDatabase = new RecalledCars();
        RecallChecker carRecallChecker = new RecallChecker(recalledCarsDatabase);
        RecalledCar matchingRecalledCar = carRecallChecker.FindRecalledCar(car);

        if (matchingRecalledCar != null)
        {
            Console.WriteLine($"{UserPrompts.Defect}: {matchingRecalledCar.FactoryDefect}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fejl: {ex.Message}");
    }
    Console.WriteLine(UserPrompts.PressToQuitProgram);
    if (Console.ReadKey().Key == ConsoleKey.Q) break;
    Console.Clear();
}