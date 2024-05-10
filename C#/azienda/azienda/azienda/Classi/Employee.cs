using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace Azienda
{
    public class Employee<T> : Person<T>, IComparable<Employee<T>> where T : struct
    {
        private string _nome;
        private string _cognome;
        private T _stipendioAnnuale = (dynamic)0;

        public Employee(string nome, string cognome, T stipendioAnnuale)
        {
            _nome = nome;
            _cognome = cognome;
            _stipendioAnnuale = stipendioAnnuale;
            controllaGuid();
        }

        public T stipendioAnnuale
        {
            get { return _stipendioAnnuale; }
        }
        public string Nome
        {
            get { return _nome; }
        }
        public string Cognome
        {
            get { return _cognome; }
        }

        //Controllo id
        public override void controllaGuid()
        {
            ID = Guid.NewGuid();
            foreach (Guid g in ListaId)
            {
                if (g != ID)
                    ListaId.Add(ID);
                else
                    controllaGuid();
            }
        }

        //Compara gli stipendi dei dipendenti
        public int CompareTo(Employee<T> other)
        {
            return Convert.ToInt32((dynamic)this.stipendioAnnuale - other.stipendioAnnuale);
        }

        public override T GetEconomicValue()
        {
            return _stipendioAnnuale;
        }

        public override string ToString()
        {
            return "Nome: " + _nome + ", Cognome: " + _cognome + ", Id: " + ID + ", Valore economico: " + _stipendioAnnuale + "€.";
        }
    }
}
