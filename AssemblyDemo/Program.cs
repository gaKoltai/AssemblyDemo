using System;
using System.Reflection;

namespace AssemblyDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var path = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll";

            Assembly assembly = Assembly.LoadFile(path);
            ShowAssemblyInfo(assembly);

            Console.ReadKey();

            Assembly ourAssembly = Assembly.GetExecutingAssembly();
            ShowAssemblyInfo(ourAssembly);

            Console.ReadKey();
        }

        private static void ShowAssemblyInfo(Assembly assembly)
        {
            Console.WriteLine($"The name of the assembly is: {assembly.FullName}");
            Console.WriteLine($"Is assembly from the global cache? : {assembly.GlobalAssemblyCache}");
            Console.WriteLine($"The location of the assembly is: {assembly.Location}");
            Console.WriteLine($"Version: {assembly.ImageRuntimeVersion}");

            foreach (var module in assembly.Modules)
            {
                Console.WriteLine($"The name of the the module is: {module.Name}");
            }
        }
    }
}