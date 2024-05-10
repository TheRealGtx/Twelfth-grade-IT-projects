using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    public abstract class Person<T> where T : struct
    {
        private string _nome;
        private string _cognome;
        private Guid _id;
        private List<Guid> _listaId = new List<Guid>();

        public Guid ID 
        {
            get
            {
                return _id;
            } 
            set
            {
                _id = value;
            }
        }

        public List<Guid> ListaId
        {
            get
            {
                return _listaId;
            }
        }

        public abstract T GetEconomicValue(); //salario dipendente, somma importo acquisti cliente

        public abstract void controllaGuid();
    }
}
