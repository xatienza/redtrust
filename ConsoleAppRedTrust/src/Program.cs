using System;
using System.Drawing;
using System.Reflection;
using ConsoleAppRedTrust.Service;
using Console = Colorful.Console;

namespace ConsoleAppRedTrust
{
    
    class Program
    {
        [MTAThread]
        static void Main(string[] args)
        {
            WelcomeMessage();
            
            new ConsumerService().Start();
            
            Console.WriteLine("\r\n[INF] See you later!");
            Environment.Exit(0);
        }

        private static void WelcomeMessage()
        {
            Console.WriteAscii("Redtrust - Challenge", Color.FromArgb(155, 0, 0));
            Console.WriteLine("Author: Xavier Sánchez Atienza", Color.FromArgb(155, 0, 0));
            Console.WriteLine($"Version: {GetAssemblyVersion()}", Color.FromArgb(155, 0, 0));
            Console.WriteLine("Press ESC to stop\r\n");
        }

        private static string GetAssemblyVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return (version == null) ? "0.0.0" : version.ToString();
        }
    }
}