using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    public class Company<T> : IEnumerable<Employee<T>>, IEnumerable<Customer<T>> where T : struct
    {
        [JsonProperty("impiegati")]
        private List<Employee<T>> _impiegati;
        [JsonProperty("clienti")]
        private List<Customer<T>> _clienti;
        [JsonProperty("sommaSpese")]
        private T _sommaSpese = (dynamic)0;
        [JsonProperty("sommaEntrate")]
        private T _sommaEntrate = (dynamic)0;
        [JsonProperty("totaleProfitto")]
        private T _totaleProfitto = (dynamic)0;
        [JsonProperty("indiceClienti")]
        private int _indiceClienti = 0;
        [JsonProperty("indiceDipendenti")]
        private int _indiceDipendenti = 0;


        public Company()
        {
            _impiegati = new List<Employee<T>>();
            _clienti = new List<Customer<T>>();
        }

        public int IndiceClienti
        {
            get
            {
                return _indiceClienti;
            }
            set
            {
                _indiceClienti = value;
            }
        }

        public int IndiceDipendenti
        {
            get
            {
                return _indiceDipendenti;
            }
            set
            {
                _indiceDipendenti = value;
            }
        }

        public void aggiungiImpiegato(Employee<T> impiegato)
        {
            _impiegati.Add(impiegato);
        }
        public void aggiungiCliente(Customer<T> cliente)
        {
            _clienti.Add(cliente);
        }

        public Employee<T> getImpiegato(int i)
        {
            controllaIndiceDipendenti(i);
            return _impiegati.ElementAt(i);
        }

        public Customer<T> getCliente(int i)
        {
            controllaIndiceClienti(i);
            return _clienti.ElementAt(i);
        }

        public List<Employee<T>> getListaImpiegati()
        {
            return _impiegati;
        }
        public List<Customer<T>> getListaClienti()
        {
            return _clienti;
        }

        private void controllaIndiceDipendenti(int i)
        {
            if (i == null && i < 0 && i >= _impiegati.Count)
                throw new Exception("Errore nella richiesta di dati all'azienda");
        }
        private void controllaIndiceClienti(int i)
        {
            if (i == null && i < 0 && i >= _clienti.Count)
                throw new Exception("Errore nella richiesta di dati all'azienda");
        }

        public T totaleSpese()
        {
            _sommaSpese = default;
            foreach (Employee<T> impiegato in _impiegati)
            {
                _sommaSpese += (dynamic)impiegato.GetEconomicValue();
            }
            return _sommaSpese;
        }

        public T totaleEntrate()
        {
            _sommaEntrate = default;
            foreach (Customer<T> cliente in _clienti)
            {
                _sommaEntrate += (dynamic)cliente.GetEconomicValue();
            }
            return _sommaEntrate;
        }

        public T totaleProfitto()
        {
            _totaleProfitto = (dynamic)_sommaEntrate - _sommaSpese;
            return _totaleProfitto;
        }

        public override string ToString()
        {
            return "Numero di impiegati: " + _impiegati.Count + ", Numero di clienti: " + _clienti.Count
                + "Totale delle spese: " + _sommaSpese + "€. Totale delle entrate: " + _sommaEntrate +
                "€. Profitto totale: " + _totaleProfitto + "€.";
        }

        public IEnumerator<Employee<T>> GetEnumerator()
        {
            for (int i = 0; i < _impiegati.Count() - 1; i++)
            {
                yield return _impiegati[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        } 

        IEnumerator<Customer<T>> IEnumerable<Customer<T>>.GetEnumerator()
        {
            for (int i = 0; i < _clienti.Count() - 1; i++)
            {
                yield return _clienti[i];
            };
        }
         
        public IEnumerable ReverseClienti
        {
            get
            {
                for (int i = _clienti.Count() - 1; i >= 0; i--)
                {
                    yield return _clienti[i];
                }
            }
        }
        public IEnumerable stipendioSopraDuemila
        {
            get
            {
                for (int i = 0; i < _impiegati.Count() - 1; i++)
                {
                    if ((dynamic)_impiegati[i].stipendioAnnuale >= 2000)
                    {
                        yield return _impiegati[i];
                    }
                }
            }
        }
    }
}
