//Some exercises with threads
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;

namespace ConsoleAppPrintNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(PrintNumbers);
            t1.Name = "T1";
            t1.Start();
            Thread t2 = new Thread(PrintNumbers);
            t2.Name = "T2";
            t2.Start();

            WriteLine("\nStarting...\n");
            for (int i = 0; i <= 6; i++)
            {
                Thread.Sleep(700); //In millisecondi
                WriteLine(" Main" + i);
            }

            t1.Suspend();
            WriteLine(" T1 sospeso");

            for (int i = 6; i <= 10; i++)
            {
                Thread.Sleep(500); //In millisecondi
                WriteLine(" Main" + i);
            }

            t1.Resume();
            WriteLine(" T1 ripartito");

            for (int i = 11; i <= 15; i++)
            {
                Thread.Sleep(700); //In millisecondi
                WriteLine(" Main" + i);
            }

            WriteLine("\n\nMain terminato");
            ReadKey();
        }
        
        static void PrintNumbers()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(700); //In millisecondi
                WriteLine(Thread.CurrentThread.Name + "  " + i); 
            }
        }
    }
}
