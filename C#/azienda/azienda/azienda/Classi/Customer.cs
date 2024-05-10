using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Azienda
{
    public class Customer<T> : Person<T> where T : struct
    {
        [JsonProperty("nomecustomer")]
        private string _nome;
        [JsonProperty("cognomecustomer")]
        private string _cognome;
        [JsonProperty("acquistiEffettuati")]
        private List<Acquisto<T>> _acquistiEffettuati = new List<Acquisto<T>>();
        [JsonProperty("sommaSpesecustomer")]
        private T _sommaSpese = (dynamic)0;

        public Customer(string nome, string cognome)
        {
            _nome = nome;
            _cognome = cognome;
            controllaGuid();
        }

        public List<Acquisto<T>> AcquistiEffettuati
        {
            get
            {
                return _acquistiEffettuati;
            }
        }

        public Customer() : this("Mario", "Rossi") { }

        public string Nome
        {
            get { return _nome; }
        }

        public string Cognome
        {
            get { return _cognome; }
        }

        public T SommaSpese
        {
            get { return _sommaSpese; }
        }

        //Controllo id
        public override void controllaGuid()
        {
            ID = Guid.NewGuid();
            foreach(Guid g in ListaId)
            {
                if (g != ID)
                    ListaId.Add(ID);
                else
                    controllaGuid();
            }
        }

        //Nuovo acquisto da parte del cliente
        public void nuovoAcquisto(string nomeArticolo, T prezzo)
        {
            Acquisto<T> acquisto = new Acquisto<T>(nomeArticolo, prezzo);
            _acquistiEffettuati.Add(acquisto);
        }

        //compara gli acquisti dei clienti
        public int CompareTo(Customer<T> other)
        {
            if ((dynamic)this._sommaSpese > (dynamic)other._sommaSpese)
                return 1;
            else if ((dynamic)this._sommaSpese < (dynamic)other._sommaSpese)
                return -1;
            return 0;
        }

        public override T GetEconomicValue()
        {
            _sommaSpese = (dynamic)0;
            foreach (Acquisto<T> acq in _acquistiEffettuati)
            {
                _sommaSpese += (acq.PrezzoArticolo) as dynamic;
            }

            return _sommaSpese;
        }

        public override string ToString()
        {
            return "Nome: " + _nome + ", Cognome: " + _cognome + ", Id: " + ID + ", Valore economico: " + _sommaSpese + "€.";
        }
    }
}
