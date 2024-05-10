using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    public class Acquisto<T> where T : struct
    {
        private string _nomeArticolo;
        private T _prezzoArticolo;

        public string NomeArticolo
        {
            get
            {
                return _nomeArticolo;
            }
            set
            {
                if (value != null)
                {
                    _nomeArticolo = value;
                }
            }
        }

        public T PrezzoArticolo
        {
            get
            {
                return _prezzoArticolo;
            }
            set
            {
                _prezzoArticolo = value;
            }
        }

        public Acquisto(string nomeArticolo, T prezzoArticolo)
        {
            _nomeArticolo = nomeArticolo;
            _prezzoArticolo = prezzoArticolo;
        }

        public override string ToString()
        {
            return "Nome articolo: " + _nomeArticolo + ", Prezzo articolo: " + _prezzoArticolo + "€.";
        }
    }
}
