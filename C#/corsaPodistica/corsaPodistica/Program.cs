//A simulation of a run using different threads
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;
using System.Net.Http.Headers;

namespace corsaPodistica
{
    internal class Program
    {
        //CDC
        static int posAldo = 0;
        static int posGiovanni = 0;
        static int posGiacomo = 0;
        static int classifica = 0;

        static Object _lock = new Object();

        static Thread thAldo;
        static Thread thGiovanni;
        static Thread thGiacomo;

        enum Persona { nessuno, aldo, giovanni, giacomo }
        static Persona personaCheAspetta = Persona.nessuno;
        static Persona personaAspettata = Persona.nessuno;
        static void Main(string[] args)
        {
            CursorVisible = false;

            Pronti();

            thAldo = new Thread(Aldo);
            thAldo.Start();

            thGiovanni = new Thread(Giovanni);
            thGiovanni.Start();

            thGiacomo = new Thread(Giacomo);
            thGiacomo.Start();

            Thread scritte = new Thread(scrivi);
            scritte.Start();

            Thread opzione = new Thread(opzioni);
            opzione.Start();

            if (!opzione.IsAlive) 
            {
                ReadLine();
            }
        }
        static void scrivi()
        {
            //Scrive lo stato dei thread
            while (true)
            {
                lock (_lock)
                {
                    ForegroundColor = ConsoleColor.White;
                    SetCursorPosition(4, 2);
                    Write(" --> " + thAldo.ThreadState + "                             ");
                    SetCursorPosition(8, 6);
                    Write(" --> " + thGiovanni.ThreadState + "                             ");
                    SetCursorPosition(7, 10);
                    Write(" --> " + thGiacomo.ThreadState + "                            ");
                }
            }
        }
        #region menu
        static void opzioni()
        {
            //menu opzioni
            bool aldoAbort = false;
            bool giovanniAbort = false;
            bool giacomoAbort = false;
            
            while (true)
            {
                lock (_lock)
                {
                    ForegroundColor = ConsoleColor.White;
                    SetCursorPosition(0, 16);
                    WriteLine("Menù opzioni                                                                                     ");
                    WriteLine("------------        ");
                    WriteLine("1) Aldo       ");
                    WriteLine("2) Giovanni      ");
                    WriteLine("3) Giacomo         ");
                }
                char sceltaPersonaggio = ReadKey(true).KeyChar;
                string scelta = sceltaPersonaggio.ToString();
                switch (sceltaPersonaggio)
                {
                    case '1':
                        lock (_lock)
                        {
                            SetCursorPosition(0, 16);
                            WriteLine("Menù Aldo           ");
                            SetCursorPosition(0, 17);
                            WriteLine("------------");
                            SetCursorPosition(0, 18);
                            WriteLine("1) Abort");
                            SetCursorPosition(0, 19);
                            WriteLine("2) Suspend   ");
                            SetCursorPosition(0, 20);
                            WriteLine("3) Resume     ");
                            SetCursorPosition(0, 21);
                            WriteLine("4) Join");
                        }
                        break;
                    case '2':
                        lock (_lock)
                        {
                            SetCursorPosition(0, 16);
                            WriteLine("Menù Giovanni           ");
                            SetCursorPosition(0, 17);
                            WriteLine("------------         ");
                            SetCursorPosition(0, 18);
                            WriteLine("1) Abort       ");
                            SetCursorPosition(0, 19);
                            WriteLine("2) Suspend           ");
                            SetCursorPosition(0, 20);
                            WriteLine("3) Resume          ");
                            SetCursorPosition(0, 21);
                            WriteLine("4) Join           ");
                        }
                        break;
                    case '3':
                        lock (_lock)
                        {
                            SetCursorPosition(0, 16);
                            WriteLine("Menù Giacomo           ");
                            SetCursorPosition(0, 17);
                            WriteLine("------------        ");
                            SetCursorPosition(0, 18);
                            WriteLine("1) Abort         ");
                            SetCursorPosition(0, 19);
                            WriteLine("2) Suspend           ");
                            SetCursorPosition(0, 20);
                            WriteLine("3) Resume          ");
                            SetCursorPosition(0, 21);
                            WriteLine("4) Join       ");
                        }
                        break;
                }
                char sceltaAzione = ReadKey(true).KeyChar;
                scelta += sceltaAzione;
                switch (scelta)
                {
                    case "11":
                        lock (_lock)
                        {
                            thAldo.Abort();
                            aldoAbort = true;
                            SetCursorPosition(0, 16);
                            WriteLine("Aldo abbatutto           ");
                            SetCursorPosition(0, 17);
                            WriteLine("                   ");
                            SetCursorPosition(0, 18);
                            WriteLine("                   ");
                            SetCursorPosition(0, 19);
                            WriteLine("                   ");
                            SetCursorPosition(0, 20);
                            WriteLine("                   ");
                            SetCursorPosition(0, 21);
                            WriteLine("                   ");
                        }
                        break;
                    case "12":
                        lock (_lock)
                        {
                            if (aldoAbort)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Aldo è morto, non serve sospenderlo. Premi invio per tornare al menù");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                                ReadLine();
                            }
                            else
                            {
                                thAldo.Suspend();
                                SetCursorPosition(0, 16);
                                WriteLine("Aldo in pausa           ");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                            }
                        }
                        break;
                    case "13":
                        lock (_lock)
                        {
                            if (aldoAbort)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Aldo è morto e non può essere resuscitato. Premi invio per tornare al menù");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                                ReadLine();
                            }
                            else
                            {
                                thAldo.Resume();
                                SetCursorPosition(0, 16);
                                WriteLine("Aldo è ripartito           ");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                            }
                        }
                        break;
                    case "14":
                        if (aldoAbort)
                        {
                            lock (_lock)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Aldo è morto, non può aspettare nessuno. Premi invio per tornare al menù");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                                ReadLine();
                            }
                        }
                        else
                        {
                            personaCheAspetta = Persona.aldo;
                            lock (_lock)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Chi vuoi aspettare?");
                                SetCursorPosition(0, 17);
                                WriteLine("1) Giovanni  ");
                                SetCursorPosition(0, 18);
                                WriteLine("2) Giacomo");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                            }
                            char sceltaChiAspettare = ReadKey(true).KeyChar;
                            switch (sceltaChiAspettare)
                            {
                                case '1':
                                    personaAspettata = Persona.giovanni;
                                    break;
                                case '2':
                                    personaAspettata = Persona.giacomo;
                                    break;
                            }
                        }
                        break;
                    case "21":
                        lock (_lock)
                        {
                            thGiovanni.Abort();
                            giovanniAbort = true;
                            SetCursorPosition(0, 16);
                            WriteLine("Giovanni abbatutto           ");
                            SetCursorPosition(0, 17);
                            WriteLine("                   ");
                            SetCursorPosition(0, 18);
                            WriteLine("                   ");
                            SetCursorPosition(0, 19);
                            WriteLine("                   ");
                            SetCursorPosition(0, 20);
                            WriteLine("                   ");
                            SetCursorPosition(0, 21);
                            WriteLine("                   ");
                        }
                        break;
                    case "22":
                        lock (_lock)
                        {
                            if (giovanniAbort)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Giovanni è morto, non serve sospenderlo. Premi invio per tornare al menù");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                                ReadLine();
                            }
                            else
                            {
                                thGiovanni.Suspend();
                                SetCursorPosition(0, 16);
                                WriteLine("Aldo in pausa           ");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                            }
                        }
                        break;
                    case "23":
                        lock (_lock)
                        {
                            if (giovanniAbort)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Giovanni è morto e non può essere resuscitato. Premi invio per tornare al menù");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                                ReadLine();
                            }
                            else
                            {
                                thGiovanni.Resume();
                                SetCursorPosition(0, 16);
                                WriteLine("Giovanni è ripartito           ");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                            }
                        }
                        break;
                    case "24":
                        if (giovanniAbort)
                        {
                            lock (_lock)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Giovanni è morto, non può aspettare nessuno. Premi invio per tornare al menù");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                                ReadLine();
                            }
                        }
                        else
                        {
                            personaCheAspetta = Persona.giovanni;
                            lock (_lock)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Chi vuoi aspettare?");
                                SetCursorPosition(0, 17);
                                WriteLine("1) Aldo          ");
                                SetCursorPosition(0, 18);
                                WriteLine("2) Giacomo        ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                            }
                            char sceltaChiAspettare = ReadKey(true).KeyChar;
                            switch (sceltaChiAspettare)
                            {
                                case '1':
                                    personaAspettata = Persona.aldo;
                                    break;
                                case '2':
                                    personaAspettata = Persona.giacomo;
                                    break;
                            }
                        }
                        break;
                    case "31":
                        lock (_lock)
                        {
                            thGiacomo.Abort();
                            giacomoAbort = true;
                            SetCursorPosition(0, 16);
                            WriteLine("Giacomo abbatutto           ");
                            SetCursorPosition(0, 17);
                            WriteLine("                   ");
                            SetCursorPosition(0, 18);
                            WriteLine("                   ");
                            SetCursorPosition(0, 19);
                            WriteLine("                   ");
                            SetCursorPosition(0, 20);
                            WriteLine("                   ");
                            SetCursorPosition(0, 21);
                            WriteLine("                   ");
                        }
                        break;
                    case "32":
                        lock (_lock)
                        {
                            if (giacomoAbort)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Giacomo è morto, non serve sospenderlo. Premi invio per tornare al menù");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                                ReadLine();
                            }
                            else
                            {
                                thGiacomo.Suspend();
                                SetCursorPosition(0, 16);
                                WriteLine("Aldo in pausa           ");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                            }
                        }
                        break;
                    case "33":
                        lock (_lock)
                        {
                            if (giacomoAbort)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Giacomo è morto e non può essere resuscitato. Premi invio per tornare al menù");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                                ReadLine();
                            }
                            else
                            {
                                thGiacomo.Resume();
                                SetCursorPosition(0, 16);
                                WriteLine("Giacomo è ripartito           ");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                            }
                        }
                        break;
                    case "34":
                        if (giacomoAbort)
                        {
                            lock (_lock)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Giacomo è morto, non può aspettare nessuno. Premi invio per tornare al menù");
                                SetCursorPosition(0, 17);
                                WriteLine("                   ");
                                SetCursorPosition(0, 18);
                                WriteLine("                   ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                                ReadLine();
                            }
                        }
                        else
                        {
                            personaCheAspetta = Persona.giacomo;
                            lock (_lock)
                            {
                                SetCursorPosition(0, 16);
                                WriteLine("Chi vuoi aspettare?");
                                SetCursorPosition(0, 17);
                                WriteLine("1) Aldo          ");
                                SetCursorPosition(0, 18);
                                WriteLine("2) Giovanni        ");
                                SetCursorPosition(0, 19);
                                WriteLine("                   ");
                                SetCursorPosition(0, 20);
                                WriteLine("                   ");
                                SetCursorPosition(0, 21);
                                WriteLine("                   ");
                            }
                            char sceltaChiAspettare = ReadKey(true).KeyChar;
                            switch (sceltaChiAspettare)
                            {
                                case '1':
                                    personaAspettata = Persona.aldo;
                                    break;
                                case '2':
                                    personaAspettata = Persona.giovanni;
                                    break;
                            }
                        }
                        break;
                }
                if (!thAldo.IsAlive && !thGiovanni.IsAlive && !thGiacomo.IsAlive) 
                {
                    lock (_lock)
                    {
                        SetCursorPosition(0, 16);
                        WriteLine("Corsa finita! Riavvia il programma per giocare ancora");
                        SetCursorPosition(0, 17);
                        WriteLine("                ");
                        SetCursorPosition(0, 18);
                        WriteLine("               ");
                        SetCursorPosition(0, 19);
                        WriteLine("                   ");
                        SetCursorPosition(0, 20);
                        WriteLine("                   ");
                        SetCursorPosition(0, 21);
                        WriteLine("                   ");
                    }
                }
            }
        }
        #endregion
        static void Pronti()
        {
            //Prepara il personaggio per la partenza
            SetCursorPosition(posAldo, 2);
            Write("Aldo");
            SetCursorPosition(posAldo, 3);
            Write("  []");
            SetCursorPosition(posAldo, 4);
            Write(@"  /░\");
            SetCursorPosition(posAldo, 5);
            Write(@"  / \");
            SetCursorPosition(posGiovanni, 6);
            Write("Giovanni");
            SetCursorPosition(posGiovanni, 7);
            Write("  ()");
            SetCursorPosition(posGiovanni, 8);
            Write(@"  \▓/");
            SetCursorPosition(posGiovanni, 9);
            Write("  ┘ └");
            SetCursorPosition(posGiacomo, 10);
            Write("Giacomo");
            SetCursorPosition(posGiacomo, 11);
            Write("  <>");
            SetCursorPosition(posGiacomo, 12);
            Write(@" /▒\");
            SetCursorPosition(posGiacomo, 13);
            Write(" ╝ ╚");
            Console.ForegroundColor = ConsoleColor.White;
        }

        #region aldo
        static void Aldo()
        {
            //controlla se aldo deve aspettare qualcuno e lo sposta
            do
            {
                if (personaCheAspetta == Persona.aldo)
                {
                    if (personaAspettata == Persona.giovanni)
                    {
                        thGiovanni.Join();
                        personaCheAspetta = Persona.nessuno;
                    }
                    else if (personaAspettata == Persona.giacomo)
                    {
                        thGiacomo.Join();
                        personaCheAspetta = Persona.nessuno;
                    }
                }
                else
                {
                    posAldo++;
                    Thread.Sleep(50);
                    lock (_lock)
                    {
                        SetCursorPosition(posAldo, 5);
                        Write(@" /\");
                    }
                    Thread.Sleep(50);
                    lock (_lock)
                    {
                        SetCursorPosition(posAldo, 4);
                        Write(@" /░\");
                    }
                    Thread.Sleep(50);
                    lock (_lock)
                    {
                        SetCursorPosition(posAldo, 3);
                        Write("  []");
                    }
                }
            } while (posAldo < 115);
            classifica++;
            SetCursorPosition(115, 2);
            Write(classifica);
        }
        #endregion

        #region giovanni
        static void Giovanni()
        {
            //controlla se giovanni deve aspettare qualcuno e lo sposta
            do
            {
                if (personaCheAspetta == Persona.giovanni)
                {
                    if (personaAspettata == Persona.aldo)
                    {
                        thAldo.Join();
                        personaCheAspetta = Persona.nessuno;
                    }
                    else if (personaAspettata == Persona.giacomo)
                    {
                        thGiacomo.Join();
                        personaCheAspetta = Persona.nessuno;
                    }
                }
                else
                {
                    posGiovanni++;
                    Thread.Sleep(50);
                    lock (_lock)
                    {
                        SetCursorPosition(posGiovanni, 9);
                        Write(@" ┘ └");
                    }
                    Thread.Sleep(50);
                    lock (_lock)
                    {
                        SetCursorPosition(posGiovanni, 8);
                        Write(@" \▓/");
                    }
                    Thread.Sleep(50);
                    lock (_lock)
                    {
                        SetCursorPosition(posGiovanni, 7);
                        Write("  ()");
                    }
                }
            } while (posGiovanni < 115);
            classifica++;
            SetCursorPosition(115, 6);
            Write(classifica);
        }
        #endregion

        #region giacomo
        static void Giacomo()
        {
            //controlla se giacomo deve aspettare qualcuno e lo sposta
            do
            {
                if (personaCheAspetta == Persona.giacomo)
                {
                    if (personaAspettata == Persona.aldo)
                    {
                        thAldo.Join();
                        personaCheAspetta = Persona.nessuno;
                    }
                    else if (personaAspettata == Persona.giovanni)
                    {
                        thGiovanni.Join();
                        personaCheAspetta = Persona.nessuno;
                    }
                }
                else
                {
                    posGiacomo++;
                    Thread.Sleep(50);
                    lock (_lock)
                    {
                        SetCursorPosition(posGiacomo, 13);
                        Write(@" ╝ ╚");
                    }
                    Thread.Sleep(50);
                    lock (_lock)
                    {
                        SetCursorPosition(posGiacomo, 12);
                        Write(@" /▒\");
                    }
                    Thread.Sleep(50);
                    lock (_lock)
                    {
                        SetCursorPosition(posGiacomo, 11);
                        Write("  <>");
                    }
                }
            } while (posGiacomo < 115);
            classifica++;
            SetCursorPosition(115, 10);
            Write(classifica);
        }
        #endregion
    }
}
