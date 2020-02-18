using System.Reflection;
using System;

namespace AssemblyType
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var path = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.ServiceProcess.dll";

            var flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;

            var assembly = Assembly.LoadFrom(path);
            
            Console.WriteLine($"Assembly name: {assembly.FullName}");

            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine($"Name of type: {type}");

                foreach (var member in type.GetMembers(flags))
                {
                    Console.WriteLine($"{member.MemberType} : {member.Name}");
                }
            }

            Console.ReadKey();

        }
    }
}