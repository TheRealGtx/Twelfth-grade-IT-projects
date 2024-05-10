//Manzi Giuliano 4i, console stopwatch
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classeCronometro;

namespace interfacciaConsole
{
    internal class Program
    {
        static Cronometro crono = new Cronometro();
        static bool inEsecuzione = false;
        static void Main(string[] args)
        {
            Console.Title = "Cronometro";

            
            int tempoPartenza;
            string tempoTrascorso;
            bool esegui = true;

            do
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Scegli un'opzione:");
                Console.WriteLine("1- Start");
                Console.WriteLine("2- Stop");
                Console.WriteLine("3- Reset");
                Console.WriteLine("4- Imposta tempo di inizio");
                Console.WriteLine("5- Mostra quanto tempo è passato");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        crono.Start();
                        Console.WriteLine("Cronometro partito");
                        break;

                    case "2":
                        crono.Stop();
                        Console.WriteLine("Cronometro fermato");
                        break;

                    case "3":
                        crono.Reset();
                        Console.WriteLine("Cronometro Resettato");
                        break;

                    case "4":
                        Console.Write("Inserisci il tempo (in secondi): ");
                        tempoPartenza = int.Parse(Console.ReadLine());
                        crono.Reset(tempoPartenza);
                        Console.WriteLine("Tempo di inizio impostato");
                        break;

                    case "5":
                        tempoTrascorso = conversione();
                        Console.WriteLine(tempoTrascorso);
                        break;

                    case "6":
                        esegui = false;
                        break;

                    default:
                        Console.WriteLine("Inserisci un numero valido");
                        break;
                }
            } while (esegui);
            
        }

        static string conversione()
        {
            int tempoTrascorso = crono.Read();
            int minuti, secondi, ore, giorni;
            string daStampare;

            if (tempoTrascorso < 60)
            {
                daStampare = "Tempo trascorso: " + tempoTrascorso + " secondi";
                return daStampare;
            }
            else if (tempoTrascorso >= 60 && tempoTrascorso < 3600)
            {
                minuti = tempoTrascorso / 60;
                secondi = tempoTrascorso % 60;
                daStampare = "Tempo trascorso: " + minuti + " minuti e " + secondi + " secondi";
                return daStampare;
            }
            else if (tempoTrascorso >= 3600 && tempoTrascorso < 86400)
            {
                minuti = tempoTrascorso / 60;
                ore = minuti / 60;
                secondi = tempoTrascorso % 60;
                minuti %= 60;
                daStampare = "Tempo trascorso: " + ore + " ore,  " + minuti + " minuti e " + secondi + " secondi";
                return daStampare;
            }
            else if (tempoTrascorso >= 86400)
            {
                giorni = tempoTrascorso / 86400;
                minuti = tempoTrascorso / 60;
                ore = minuti / 60;
                secondi = tempoTrascorso % 60;
                minuti %= 60;
                daStampare = "Tempo trascorso: " + giorni + " giorni, " + ore + " ore,  " + minuti +
                " minuti e " + secondi + " secondi";
                return daStampare;
            }
            else
            {
                daStampare = "Errore";
                return daStampare;
            }
        }
    }
}
