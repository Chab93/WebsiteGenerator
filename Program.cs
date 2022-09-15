using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfClass = "ITHS .NET 2022";
            string[] messages = { "Nu ska vi lära oss att programmera", "Testmeddelande", "Meddelande 3" };
            string[] classes = { "   C#", "daTAbaser", "WebbuTVeCkling  ", "clean Code      " };
            string styleColor = "blue";

            GenerateWebsite website1 = new GenerateWebsite(nameOfClass, messages, classes, styleColor);

            Console.ReadLine();
        }

        abstract class Website
        {
            string className;
            string[] messages;
            string[] classes;
            string style;

            protected Website(string className, string[] messages, string[] classes, string style = "")
            {
                this.className = className;
                this.messages = messages;
                this.classes = classes;
                this.style = style;

                PrintWebpage(className, messages, classes, style);
            }
            void PrintWebpage(string className, string[] messages, string[] classes, string style)
            {
                Start();

                ClassAndMessage(className, messages, classes, style);

                End();
            }

            void Start()
            {
                Console.WriteLine("<!DOCTYPE html>\n<html>");
            }

            void ClassAndMessage(string className, string[] messages, string[] classes, string style)
            {
                if (style != "")
                {
                    style = $"p {{ color: {style}; }}";

                    Console.WriteLine($"<head>\n<style>\n{style}\n</style>\n</head>");
                }

                Console.WriteLine($"<body>\n<h1>Välkomna {className}!</h1>");

                for (int i = 0; i < messages.Length; i++)
                {
                    Console.WriteLine($"<p><b>Meddelande {i + 1}:</b> {messages[i]}</p>");
                }

                Console.WriteLine("<main>");

                foreach (string c in classes)
                {
                    Console.WriteLine($"<p>Kurs om {c.Trim().Substring(0, 1).ToUpper()}{c.Trim().Substring(1).ToLower()}</p>");
                }
            }

            void End()
            {
                Console.WriteLine("</main>\n</body>\n</html>");
            }
        }

        class GenerateWebsite : Website
        {
            public GenerateWebsite(string className, string[] messages, string[] classes, string style = "") : base(className, messages, classes, style)
            {
            }
        } 
    }
}
