public class TaskModule : IModule
{
    public string Name => "Task Module";

    public void Execute()
    {
        Console.WriteLine("Керування завданнями запущено.");
        // логіка роботи з завданнями...
    }
}
