using System;
using System.IO;
using NUnitLite.Runner;

namespace SimpleWinceGuiAutomation.Tests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var writer = new StringWriter();
            new TextUI(writer).Execute(new string[0]);
            if (writer.ToString().Contains("Errors and Failures"))
            {
                throw new Exception(writer.ToString());
            }
        }
    }
}