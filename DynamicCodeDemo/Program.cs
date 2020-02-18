using System.Reflection;
using System;

namespace DynamicCodeDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var path = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Web.dll";
            var webAssembly = Assembly.LoadFrom(path);
            var utilType = webAssembly.GetType("System.Web.HttpUtility");

            var encode = utilType.GetMethod("HtmlEncode", new Type[]
            {
                typeof(string)
            });

            var decode = utilType.GetMethod("HtmlDecode", new Type[]
            {
                typeof(string)
            });

            const string stringWithSpecialChars = "Marks & Spencer is the shit <sic>";
            
             Console.WriteLine(stringWithSpecialChars);

            var encodedString = (string) encode.Invoke(null, new object[]
            {
                stringWithSpecialChars
            });
            
            Console.WriteLine(encodedString);

            var decodedString = (string) decode.Invoke(null, new object[]
            {
                encodedString
            });

            Console.WriteLine(decodedString);
            Console.ReadKey();

        }
    }
}