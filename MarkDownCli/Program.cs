namespace MarkDownCli
{
    using System;
    using System.IO;
    using MarkdownSharp;

    internal static class Program
    {
        private const string HtmlHeader = "<html>\n<head />\n<body>";
        private const string HtmlFooter = "</body>\n</html>\n";

        internal static void Main(string[] args)
        {
            try
            {
                TextReader reader;
                TextWriter writer;
                if (!ParseArgs(args, out reader, out writer))
                {
                    return;
                }

                var markdown = new Markdown();
                string input = reader.ReadToEnd();
                string body = markdown.Transform(input);
                string output = HtmlHeader + body + HtmlFooter;
                writer.Write(output);
            }
            catch (Exception x)
            {
                Console.Write("Error: {0} - {1}", x.GetType().Name, x.Message);
                if (x.InnerException != null)
                {
                    Console.Write(" -> {0} - {1}", x.InnerException.GetType().Name, x.InnerException.Message);
                }

                Console.WriteLine();
            }
        }

        private static bool ParseArgs(string[] args, out TextReader reader, out TextWriter writer)
        {
            reader = null;
            writer = null;

            if (args.Length == 0)
            {
                reader = Console.In;
                writer = Console.Out;
                return true;
            }
            else if (args.Length == 1)
            {
                if (args[0] == "-?" || args[0] == "/?")
                {
                    PrintUsage();
                    return false;
                }

                if (!File.Exists(args[0]))
                {
                    Console.WriteLine("Error: File {0} does not exist.", args[0]);
                    return false;
                }

                reader = new StreamReader(args[0]);
                writer = Console.Out;
                return true;
            }
            else if (args.Length == 2)
            {
                if (!File.Exists(args[0]))
                {
                    Console.WriteLine("Error: File {0} does not exist.", args[0]);
                    return false;
                }

                reader = new StreamReader(args[0]);
                writer = new StreamWriter(args[1]);
                return true;
            }
            else
            {
                PrintUsage();
                return false;
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("# Markdown.exe - A .Net Markdown processor");
            Console.WriteLine();

            Console.WriteLine("## Usage");
            Console.WriteLine();

            Console.WriteLine("* With no arguments, reads from standard input and writes to standard output.");
            Console.WriteLine("* Markdown -? - Prints this message and exits.");
            Console.WriteLine("* Markdown <input.txt> - Converts input.txt to HTML, and writes the result to standard output.");
            Console.WriteLine("* Markdown <input.txt> <output.html> - Converts input.txt to HTML, and writes the result to output.html.");
            Console.WriteLine();

            Console.WriteLine("Credits: This program is a very thin wrapper over the handy [MarkdownSharp](http://code.google.com/p/markdownsharp) library.");
            Console.WriteLine();
        }
    }
}
