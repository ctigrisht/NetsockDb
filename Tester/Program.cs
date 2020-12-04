using Spectre.Console;
using System;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.MarkupLine("HEYYYYY");

            AnsiConsole.Render(new Markup("WELCOME!", new Style(Color.DarkCyan, null, Decoration.Bold)));

            var str = AnsiConsole.Ask<string>("Give string");

            var parsed = SharedLib.Models.Serialization.DeserializationUtils.ParseSTR(str);
            AnsiConsole.MarkupLine(parsed.Value);

            Task.Delay(-1).Wait();
            Console.ReadKey();
        }
    }
}
