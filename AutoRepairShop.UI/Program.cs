while (true)
{
    try
    {
        Console.WriteLine("Hello, World!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fejl: {ex.Message}");
    }
    Console.WriteLine("Tryk 'q' for at afslutte eller en anden vilkårlig tast for at genstarte programmet.");
    if (Console.ReadKey().Key == ConsoleKey.Q) break;
    Console.Clear();
}