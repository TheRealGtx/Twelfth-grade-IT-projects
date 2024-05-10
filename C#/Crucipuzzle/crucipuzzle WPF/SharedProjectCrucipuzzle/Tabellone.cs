using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;

namespace crucipuzzleConTutore
{
    public class Tabellone
    {
        private Casella[,] _caselle;

        public Casella[,] Caselle
        {
            get
            {
                return _caselle;
            }
            set
            {
                _caselle = value;
            }
        }

        public Tabellone() { }

        public int numeroRighe;

        public int numeroColonne;

        public Tabellone(int Righe, int Colonne)
        {
            numeroRighe = Righe;
            numeroColonne = Colonne;
            _caselle = new Casella[Righe, Colonne];
        }


        public Tabellone(string fileTabellone)
        {

        }

        public bool CercaSinistraDestra(Parola par, bool trovataSoluzione)
        {
            bool trovata;
            for (int i = 0; i < numeroRighe; i++)
            {
                for (int j = 0; j <= (numeroColonne - par.NumCar); j++)
                {
                    trovata = true;
                    for (int x = 0; (x < par.NumCar) && trovata; x++)
                    {
                        if (Caselle[i, x + j].Carattere != par.Carattere(x))
                            trovata = false;
                    }
                    if (trovata)
                    {
                        for (int x = 0; (x < par.NumCar) && trovata; x++)
                        {
                            Caselle[i, x + j].Nuova = true;
                            Caselle[i, x + j].Nuova = true;

                        }
                        par.Direzione = Direzione.Sinistra_Destra;
                        par.X = i;
                        par.Y = j;
                        trovataSoluzione = true;
                        return trovataSoluzione;
                    }
                }
            }
            return trovataSoluzione;
        }
        public bool CercaDestraSinistra(Parola par, bool trovataSoluzione)
        {
            bool trovata;
            for (int i = 0; i < numeroRighe; i++)
            {
                for (int j = numeroColonne - 1; j >= (numeroColonne - par.NumCar); j--)
                {
                    trovata = true;
                    for (int x = 0; (x < par.NumCar) && trovata; x++)
                    {
                        if (Caselle[i, j - x].Carattere != par.Carattere(x))
                            trovata = false;
                    }
                    if (trovata)
                    {
                        for (int x = 0; (x < par.NumCar) && trovata; x++)
                        {
                            Caselle[i, j - x].Nuova = true;
                            Caselle[i, j - x].Nuova = true;

                        }
                        par.Direzione = Direzione.Destra_Sinistra;
                        par.X = i;
                        par.Y = j;
                        trovataSoluzione = true;
                        return trovataSoluzione;
                    }
                }
            }
            return trovataSoluzione;
        }

        public bool CercaAltoBasso(Parola par, bool trovataSoluzione)
        {
            bool trovata;
            for (int j = 0; j < numeroColonne; j++)
            {
                for (int i = 0; i < (numeroRighe - par.NumCar); i++)
                {
                    trovata = true;
                    for (int x = 0; (x < par.NumCar) && trovata; x++)
                    {
                        if (Caselle[x + i, j].Carattere != par.Carattere(x))
                            trovata = false;
                    }
                    if (trovata)
                    {
                        for (int x = 0; (x < par.NumCar) && trovata; x++)
                        {
                            Caselle[x + i, j].Nuova = true;
                            Caselle[x + i, j].Nuova = true;

                        }
                        par.Direzione = Direzione.Alto_Basso;
                        par.X = i;
                        par.Y = j;
                        trovataSoluzione = true;
                        return trovataSoluzione;
                    }
                }
            }
            return trovataSoluzione;
        }
        public bool CercaBassoAlto(Parola par, bool trovataSoluzione)
        {
            bool trovata;
            for (int j = 0; j <= numeroColonne - 1; j++)
            {
                for (int i = numeroRighe - 1; i >= (numeroRighe - par.NumCar); i--)
                {
                    trovata = true;
                    for (int x = 0; (x < par.NumCar) && trovata; x++)
                    {
                        if (Caselle[i - x, j].Carattere != par.Carattere(x))
                            trovata = false;
                    }
                    if (trovata)
                    {
                        for (int x = 0; (x < par.NumCar) && trovata; x++)
                        {
                            Caselle[i - x, j].Nuova = true;
                            Caselle[i - x, j].Nuova = true;

                        }
                        par.Direzione = Direzione.Basso_Alto;
                        par.X = i;
                        par.Y = j;
                        trovataSoluzione = true;
                        return trovataSoluzione;
                    }
                }
            }
            return trovataSoluzione;
        }

        //MODIFICA QUESTO \
        public bool CercaAltoSinistra_BassoDestra(Parola par, bool trovataSoluzione)
        {
            bool trovata;
            for (int i = 0; i < numeroRighe - 1; i++)
            {
                for (int j = 0; j < numeroColonne - 1; j++)
                {
                    trovata = true;
                    for (int x = 0; (x < par.NumCar) && trovata; x++)
                    {
                        if (Caselle[i + x, j + x].Carattere != par.Carattere(x))
                            trovata = false;
                    }
                    if (trovata)
                    {
                        for (int x = 0; (x < par.NumCar) && trovata; x++)
                        {
                            Caselle[i + x, j - x].Nuova = true;
                        }
                        par.Direzione = Direzione.AltoSinistra_BassoDestra;
                        par.X = i;
                        par.Y = j;
                        trovataSoluzione = true;
                        return trovataSoluzione;
                    }
                }
            }
            return trovataSoluzione;
        }

        //NON MODIFICARE /
        public bool CercaAltoDestra_BassoSinistra(Parola par, bool trovataSoluzione){
            bool trovata;
            for (int j = numeroColonne - 1; j >= 0; j--)
            {
                for (int i = 0; i <= numeroRighe - 1; i++)
                {
                    trovata = true;
                    for (int x = 0; (x < par.NumCar) && trovata && j > x; x++)
                    {
                        if (Caselle[i + x, j - x].Carattere != par.Carattere(x))
                            trovata = false;
                    }
                    if (trovata)
                    {
                        for (int x = 0; (x < par.NumCar) && trovata && j > x; x++)
                        {
                            Caselle[i + x, j - x].Nuova = true;
                        }
                        par.Direzione = Direzione.AltoDestra_BassoSinistra;
                        par.X = i;
                        par.Y = j;
                        trovataSoluzione = true;
                        return trovataSoluzione;
                    }
                }
            }
            return trovataSoluzione;
        }

        public bool CercaBassoDestra_AltoSinistra(Parola par, bool trovataSoluzione)
        {
            bool trovata;
            for (int i = par.NumCar - 1; i < numeroRighe; i++)
            {
                for (int j = par.NumCar - 1; j < numeroColonne; j++)
                {
                    trovata = true;
                    for (int x = 0; (x < par.NumCar) && trovata; x++)
                    {
                        if (Caselle[i - x, j - x].Carattere != par.Carattere(x))
                            trovata = false;
                    }
                    if (trovata)
                    {
                        for (int x = 0; (x < par.NumCar) && trovata; x++)
                        {
                            Caselle[i - x, j - x].Nuova = true;
                        }
                        par.Direzione = Direzione.BassoDestra_AltoSinistra;
                        par.X = i;
                        par.Y = j;
                        trovataSoluzione = true;
                        return trovataSoluzione;
                    }
                }
            }
            return trovataSoluzione;
        }

        public string Soluzione()
        {
            return "";
        }

        //serve altro, implementarlo
    }
}