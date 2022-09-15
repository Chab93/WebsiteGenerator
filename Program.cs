using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            string color = "red";

            GenerateWebsite website1 = new GenerateWebsite();
            website1.PrintWebpage(nameOfClass, messages, classes);

            Console.WriteLine("\n\n");

            StyledWebsite website2 = new StyledWebsite();
            website2.PrintWebpage(nameOfClass, messages, classes, color);

            Console.ReadLine();
        }

        class StyledWebsite : GenerateWebsite
        {
            override protected void ClassAndMessage(string className, string[] messages, string[] classes, string color)
            {
                string style = $"p {{ color: {color}; }}";

                Console.WriteLine($"<head>\n<style>\n{style}\n</style>\n</head>");

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
        }
        class GenerateWebsite
        {
            public void PrintWebpage(string className, string[] messages, string[] classes)
            {
                Start();

                ClassAndMessage(className, messages, classes);

                End();
            }

            public void PrintWebpage(string className, string[] messages, string[] classes, string color)
            {
                Start();

                ClassAndMessage(className, messages, classes, color);

                End();
            }

            void Start()
            {
                Console.WriteLine("<!DOCTYPE html>\n<html>");
            }

            void ClassAndMessage(string className, string[] messages, string[] classes)
            {

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

            virtual protected void ClassAndMessage(string className, string[] messages, string[] classes, string color)
            {
            }

            void End()
            {
                Console.WriteLine("</main>\n</body>\n</html>");
            }
        }

    }
}
