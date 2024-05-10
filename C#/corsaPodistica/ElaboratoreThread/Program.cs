//Other threads exercises
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;


namespace ElaboratoreThread
{
    internal class Program
    {
        static int var;
        static Object lock0 = new Object();

        static void Elabora01()
        {
            WriteLine("\nStarting " + Thread.CurrentThread.Name);
            int v;
            for (int i = 1; i <= 100; i++)
            {
                lock (lock0)
                {
                    v = var;
                    Thread.Sleep(10);
                    var = v + 1;
                }
                Thread.Sleep(1);
            }
        }

        static void Elabora02()
        {
            WriteLine("\nStarting " + Thread.CurrentThread.Name);
            int v;
            for (int i = 1; i <= 100; i++)
            {
                lock (lock0)
                {
                    v = var;
                    Thread.Sleep(10);
                    var = v + 1;
                }
                Thread.Sleep(1);
            }
        }

        static void Main(string[] args)
        {
            var = 0;

            Thread t1 = new Thread(Elabora01);
            t1.Name = "T1";
            Thread t2 = new Thread(Elabora02);
            t2.Name = "T2";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            WriteLine("\n var = " + var);
            WriteLine("\n\nPremi un tasto per terminare il programma");
            ReadLine();
        }
    }
}
