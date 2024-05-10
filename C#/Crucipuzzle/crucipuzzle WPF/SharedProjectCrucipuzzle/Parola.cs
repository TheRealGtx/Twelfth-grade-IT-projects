using System;
using System.Collections.Generic;
using System.Text;

namespace crucipuzzleConTutore
{
    public class Parola
    {
        private string _contenuto;
        private int _x;
        private int _y;
        private Direzione _direzione;

        public Parola()
        {
            this._contenuto = "";
            this._direzione = Direzione.NULL;
        }

        public Parola(string par)
        {
            this._contenuto = par.ToUpper();
            this._direzione = Direzione.NULL;
        }

        //Verifica se una casella appartiene alla parola
        //"true" quando il carattere di coordinata (riga,colonna) appartiene alla parola
        //"false" quando il carattere di coordinata (riga,colonna) non appartiene alla parola oppure la parola non
        //è stata ancora trovata nel tabellone
        public bool CoordinataAppartiene(int riga, int colonna)
        {
            int stepR = 0;
            int stepC = 0;
            switch (this._direzione)
            {
                case (Direzione.Sinistra_Destra):
                    stepR = 0;
                    stepC = 1;
                    break;
                case (Direzione.Destra_Sinistra):
                    stepR = 0;
                    stepC = -1;
                    break;
                case (Direzione.Alto_Basso):
                    stepR = 1;
                    stepC = 0;
                    break;
                case (Direzione.Basso_Alto):
                    stepR = -1;
                    stepC = 0;
                    break;
                case (Direzione.AltoSinistra_BassoDestra):
                    stepR = 1;
                    stepC = 1;
                    break;
                case (Direzione.BassoDestra_AltoSinistra):
                    stepR = -1;
                    stepC = -1;
                    break;
                case (Direzione.BassoSinistra_AltoDestra):
                    stepR = -1;
                    stepC = 1;
                    break;
                case (Direzione.AltoDestra_BassoSinistra):
                    stepR = 1;
                    stepC = -1;
                    break;
                case (Direzione.NULL):
                    return false;
                    break;
            }

            int r = this._x;
            int c = this._y;
            for (int n = 0; (n < NumCar); n++)
            {
                if (r == riga && c == colonna) return true;
                r = r + stepR;
                c = c + stepC;
            }
            return false;
        }

        public string Contenuto
        {
            get => _contenuto;
            set => _contenuto = value;
        }

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public Direzione Direzione
        {
            get => _direzione;
            set => _direzione = value;
        }
        public int NumCar
        {
            get
            {
                return _contenuto.Length;
            }
        }

        public char Carattere(int indice)
        {
            return (_contenuto[indice]);
        }

        //Serve altro, implementarlo
    }
}