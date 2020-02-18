using System.Reflection;
using System;

namespace AssemblyAttrDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var assemblyAttrType = typeof(AssemblyDescriptionAttribute);
            var attributes = currentAssembly.GetCustomAttributes(assemblyAttrType, false);

            if (attributes.Length <= 0) return;
            
            var descriptionAttr = (AssemblyDescriptionAttribute)attributes[0];
            Console.WriteLine($"The description of the currently running assembly is: {descriptionAttr.Description}");

        }
    }
}