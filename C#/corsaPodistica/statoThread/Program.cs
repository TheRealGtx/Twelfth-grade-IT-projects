//Other threads exercises
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;

namespace statoThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread th = Thread.CurrentThread;

            WriteLine("\nThread IsAlive: {0}", th.IsAlive);
            WriteLine("Thread id: {0}", th.ManagedThreadId);
            WriteLine("Thread ThreadState: {0}", th.ThreadState);
            WriteLine("Thread Priority: {0}", th.Priority);
            WriteLine("Is Background Thread: {0}", th.IsBackground);
            WriteLine("Thread Culture: {0}", th.CurrentCulture);

            WriteLine("\nPremi un tasto per terminare il programma");
            ReadKey();
        }
    }
}