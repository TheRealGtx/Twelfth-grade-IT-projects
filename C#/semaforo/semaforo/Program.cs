//Some tests with Semaphores
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace semaforo
{
    internal class Program
    {
        static SemaphoreSlim _sem = new SemaphoreSlim(3);
        static void Main(string[] args)
        {
            int nSemafori;

            Write("Numero di semafori da creare: ");
            nSemafori = int.Parse(ReadLine());

           for (int i = 1; i <= nSemafori; i++)
           {
                Thread td;
                td = new Thread(Enter);
                td.Start(i);
           }
            
            ReadLine();
        }

        static void Enter (object id)
        {
            WriteLine(id + " wants to enter");
            _sem.Wait();
            WriteLine(id + " is in");
            Thread.Sleep(1000 * (int)id);
            WriteLine(id + " is leaving");
            _sem.Release();
        }
    }
}
