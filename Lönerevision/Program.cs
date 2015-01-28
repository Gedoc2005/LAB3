using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lönrivision2
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfSalaries;

            do
            {
                numberOfSalaries = ReadInt("Ange antal löner att mata in: ");

                if (numberOfSalaries < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDu måste mata in minst två löner för att kunna göra en beräkning!");
                    Console.ResetColor();
                }
                else
                {
                    ProcessSalaries(numberOfSalaries);

                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nTryck ner valfri tangent för ny beräkning - ESC avslutar");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static void ProcessSalaries(int count)
        {

            int[] salaries = new int[count];
            //This for loop, take in the value of each salary.

            for (int i = 0; i < salaries.Length; i++)
            {
                    string prompt = string.Format("Ange lön nummer {0}: ", i + 1);
                    salaries[i] = ReadInt(prompt);
            }
          
            int[] sortSalaries = new int[count];

            // Kopierar nuvarande array till ny array och sorterar den
            Array.Copy(salaries, sortSalaries, count);
            Array.Sort(sortSalaries);

            double medianSalary = 0;
            double medelSalary = sortSalaries.Average();
            int loneSpridning = sortSalaries.Max() - sortSalaries.Min();

            // Räknar ut medianlön vid udda
            if (sortSalaries.Length % 2 == 1)
            {
                medianSalary = sortSalaries[sortSalaries.Length / 2];
            }

                // Räknar ut medianlön vid jämna
            else
            {
                int median1 = sortSalaries[sortSalaries.Length / 2];
                int median2 = sortSalaries[sortSalaries.Length / 2 - 1];
                medianSalary = (median1 + median2) / 2.0;
            }


            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("{0, -11} : {1,9:C0}", "Median Salary", medianSalary);
            Console.WriteLine("{0, -11} : {1,9:C0}", " Medel Salary", medelSalary);
            Console.WriteLine("{0, -11} : {1,9:C0}\n", "Lönespridning", loneSpridning);
            Console.WriteLine("------------------------------------------");


            //lönerna presenteras i den ordning de matats in om tre löner på varje rad
            for (int lonNummer = 0; lonNummer < salaries.Length; lonNummer++)
            {
                if (lonNummer % 3 == 0)
                {
                    Console.Write("\n");
                }

                Console.Write("{0,8}", salaries[lonNummer]);
            }


            Console.WriteLine();
        }

        static int ReadInt(string prompt)
        {

            int number;

            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    number = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    return number;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Antal löner måste vara ett heltal!");
                    Console.ResetColor();
                }
            }
        }
    }
}
