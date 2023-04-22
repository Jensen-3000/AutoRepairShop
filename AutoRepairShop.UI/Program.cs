using AutoRepairShop.Logic.Models;
using AutoRepairShop.UI.Prompts;

while (true)
{
    int dateMinValue = 1900;
    int dateMaxValue = DateTime.Now.Year + 1;

    DateValidator dateValidator = new DateValidator();
    try
    {
        string brandInput = GetInputFromUser(UserPrompts.CarBrand);

        string modelInput = GetInputFromUser(UserPrompts.CarModel);

        string yearInput = GetInputFromUser(UserPrompts.CarYear);
        DateTime modelYear = dateValidator.GetCarModelYear(yearInput, dateMinValue, dateMaxValue);

        string inspectionDateInput = GetInputFromUser(UserPrompts.CarLastInspectionDate);
        DateTime lastInspectionDate = dateValidator.GetLastInspectionDate(inspectionDateInput, dateMinValue, dateMaxValue);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fejl: {ex.Message}");
    }
    Console.WriteLine(UserPrompts.PressToQuitProgram);
    if (Console.ReadKey().Key == ConsoleKey.Q) break;
    Console.Clear();
}

string GetInputFromUser(string prompt)
{
    Console.Write(prompt);
    return Console.ReadLine().ToLower().Trim();
}