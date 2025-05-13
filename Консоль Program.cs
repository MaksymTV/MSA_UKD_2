class Program
{
    static void Main(string[] args)
    {
        var kernel = new Kernel();
        kernel.LoadModules("Plugins");

        Console.WriteLine("Натисніть будь-яку клавішу для запуску модулів...");
        Console.ReadKey();
        kernel.RunModules();

        Console.WriteLine("Натисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
        kernel.UnloadModules();
    }
}
