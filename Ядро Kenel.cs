using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class Kernel
{
    private readonly List<IModule> _modules = new();

    public void LoadModules(string path)
    {
        foreach (var file in Directory.GetFiles(path, "*.dll"))
        {
            var assembly = Assembly.LoadFrom(file);
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(IModule).IsAssignableFrom(type) && !type.IsInterface)
                {
                    var module = (IModule)Activator.CreateInstance(type)!;
                    _modules.Add(module);
                    Console.WriteLine($"Завантажено модуль: {module.Name}");
                }
            }
        }
    }

    public void RunModules()
    {
        foreach (var module in _modules)
        {
            module.Execute();
        }
    }

    public void UnloadModules()
    {
        _modules.Clear();
        Console.WriteLine("Модулі вивантажено.");
    }
}
