//Manzi Giuliano 4i, 05/11/2022
//Crossword puzzle in console
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedProjectCrucipuzzle;
using static System.Console;

namespace crucipuzzleConsole
{
    internal class Program
    {
        static string percorso;
        static int righe = 0;
        static int colonne;
        static int paroleCercate;
        

        static void Main(string[] args)
        {
            string file;

            Write("Inserisci il percorso del file, invio per il file di default: ");
            file = ReadLine().Trim();

            WriteLine("");
            Write("    ");

            
            if (file == "")
            {
                percorso = "../../../cruciverba.txt";
            }
            else
            {
                percorso = file;
            }

            caricaPuzzle();

        }

        static void caricaPuzzle()
        {
            
            StreamReader file = new StreamReader(percorso);
            

            string riga;
            char[] colonna;

            do
            {
                riga = file.ReadLine();
                righe++;
            } while (!file.EndOfStream);
            colonna = riga.ToCharArray();
            colonne = colonna.Length;
            Tabellone tab = new Tabellone(righe, colonne);
            file.Close();
            StreamReader file2 = new StreamReader(percorso);

            char[] carattere;
            int k = 0;
            //i = colonna, k = riga
            do
            {
                riga = file2.ReadLine();
                carattere = riga.ToCharArray();

                for (int i = 0; i < carattere.Length; i++)
                {
                    Casella casella = new Casella(carattere[i], ConsoleColor.Black, ConsoleColor.White);
                    tab.Caselle[k, i] = casella;
                    Write(casella.ToString());
                }
                k++;
                WriteLine("");
                Write("    ");
            } while (!file2.EndOfStream);

            WriteLine("");

            colonne = carattere.Length;
            file2.Close();

            cercaParola(tab);
            
        }

        static void cercaParola(Tabellone tab)
        {
            

            string parola;
            
            Direzione direzione;

            bool esci = false;
            do
            {
                Write("        ");
                Write("Parola da cercare (scrivi 'fine' per terminare il programma): ");
                parola = ReadLine();

                if (parola == "fine")
                {
                    //metodo parole rosse
                    WriteLine("Premi invio per terminare il programma");
                    esci = true;
                }
                else
                {
                    paroleCercate += 1;
                    Parola par = new Parola(parola);

                    tab.CercaSinistraDestra(par);
                    tab.CercaBassoDestra_AltoSinistra(par);
                    tab.CercaAltoBasso(par);
                    tab.CercaDestraSinistra(par);
                    tab.CercaBassoAlto(par);
                    tab.CercaAltoSinistra_BassoDestra(par);
                   // tab.CercaAltoDestra_BassoSinistra(par);

                    direzione = par.Direzione;

                    coloraParola(par, tab);

                    esci = false;
                }
            } while (esci == false);
            ReadLine();

        }

        static void coloraParola (Parola par, Tabellone tab)
        {
            Casella cas;
            Write("    ");

            for (int i = 0; i < tab.numeroRighe; i++)
            {
                for (int j = 0; j < tab.numeroColonne; j++)
                {
                    cas = tab.Caselle[i, j];
                    if (cas.Nuova == true)
                    {
                        BackgroundColor = ConsoleColor.Magenta;
                        Write(cas.ToString());
                        cas.Nuova = false;
                        cas.Impegnata = true;
                        BackgroundColor = ConsoleColor.Black;
                    }
                    else if (cas.Impegnata == true)
                    {
                        BackgroundColor = ConsoleColor.Green;
                        Write(cas.ToString());
                        BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        BackgroundColor = ConsoleColor.Black;
                        Write(cas.ToString());
                        BackgroundColor = ConsoleColor.Black;
                    }
                }
                WriteLine("");
                Write("    ");
            }
        }
    }
}
