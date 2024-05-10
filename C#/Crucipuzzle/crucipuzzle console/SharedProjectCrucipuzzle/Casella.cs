using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProjectCrucipuzzle
{
    public class Casella
    {
        public char _carattere;
        private bool _impegnata;
        private bool _nuova;
        //private ConsoleColor background;
        //private ConsoleColor foreground;

        public Casella()
        {
            _carattere = ' ';
            _impegnata = false;
            //background = ConsoleColor = black;
            //foreground = ConsoleColor = white;
        }

        public Casella(char carattere)
        {
            ToUpper(carattere);
            this._carattere = carattere;
            this._impegnata = false;
            //background = ConsoleColor = black;
            //foreground = ConsoleColor = white;
            //aggiungere quello che può servire
        }

        public static char ToUpper(char c)
        {
            return c;
        }


        public Casella(char carattere, ConsoleColor background, ConsoleColor foreground)
        {
            this._carattere = carattere;
            this._impegnata = false;
            this._nuova = false;
            //background = ConsoleColor = black;
            //foreground = ConsoleColor = white;
            //aggiungere quello che può servire
        }

        public override string ToString()
        {
            return _carattere.ToString();
        }

        public char Carattere
        {
            get => _carattere;
            set => _carattere = value;
        }

        public bool Impegnata
        {
            get => _impegnata;
            set => _impegnata = value;
        }

        public bool Nuova
        {
            get => _nuova;
            set => _nuova = value;
        }

        //Serve altro, implementarlo

    }


}
