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

            GenerateWebsite website1 = new GenerateWebsite(nameOfClass, messages, classes);

            Console.ReadLine();
        }

        class GenerateWebsite
        {
            string className;
            string[] messages;
            string[] classes;

            public GenerateWebsite(string className, string[] messages, string[] classes)
            {
                this.className = className;
                this.messages = messages;
                this.classes = classes;

                PrintWebpage(className, messages, classes);
            }

            static void PrintWebpage(string className, string[] messages, string[] classes)
            {
                Start();

                ClassAndMessage(className, messages, classes);

                End();
            }

            static void Start()
            {
                Console.WriteLine("<!DOCTYPE html>\n<html>");
            }

            static void ClassAndMessage(string className, string[] messages, string[] classes)
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

            static void End()
            {
                Console.WriteLine("</main>\n</body>\n</html>");
            }
        }
    }
}
