using System.Globalization;

while (true)
{
    int dateMinValue = 1900;
    int dateMaxValue = DateTime.Now.Year + 1;

    try
    {
        string brandInput = GetInputFromUser("Indtast bilmærke: ");

        string modelInput = GetInputFromUser("Indtast bilmodel: ");

        string yearInput = GetInputFromUser("Indtast bilens årgang: ");
        DateTime modelYear = GetCarModelYear(yearInput, dateMinValue, dateMaxValue);

        string inspectionDateInput = GetInputFromUser("Indtast bilens sidste syns dato (dd-MM-yyyy) \nHvis bilen ikke har været synet før tast 0000: ");
        DateTime lastInspectionDate = GetLastInspectionDate(inspectionDateInput, dateMinValue, dateMaxValue);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fejl: {ex.Message}");
    }
    Console.WriteLine("Tryk 'q' for at afslutte eller en anden vilkårlig tast for at genstarte programmet.");
    if (Console.ReadKey().Key == ConsoleKey.Q) break;
    Console.Clear();
}

// ToDo: Move methods into classes and refactor and DRY DateTime methods
string GetInputFromUser(string prompt)
{
    Console.Write(prompt);
    return Console.ReadLine().ToLower().Trim();
}

DateTime GetCarModelYear(string input, int minYear, int maxYear)
{
    DateTime modelYear;

    if (!DateTime.TryParseExact(input, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out modelYear))
    {
        throw new FormatException("Forkert format. Skal være yyyy. fx. 1999");
    }

    if (modelYear.Year < minYear || modelYear.Year > maxYear)
    {
        throw new ArgumentOutOfRangeException("modelYear", $"Årgang skal være mellem {minYear} og {maxYear}.");
    }
    return modelYear;
}

DateTime GetLastInspectionDate(string input, int minYear, int maxYear)
{
    DateTime lastInspectionDate;

    if (input == "0000")
    {
        lastInspectionDate = DateTime.MinValue;
    }

    if (!DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastInspectionDate))
    {
        throw new FormatException("Forkert format. Skal være dd-MM-yyyy. fx. 01-12-1999");
    }

    if (lastInspectionDate.Year < minYear || lastInspectionDate.Year > maxYear)
    {
        throw new ArgumentOutOfRangeException("lastInspectionDate", $"Sidste syns dato skal være mellem {minYear} og {maxYear}.");
    }
    return lastInspectionDate;
}