//Manzi Giuliano 4i, classe cronometro
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classeCronometro
{
    public class Cronometro
    {
        public DateTime _tempoInizio;
        int _tempoTrascorso = 0;
        public Cronometro()
        {
        }

        public void Start()
        {
            _tempoInizio = DateTime.Now;
        }

        public void Stop()
        {
            _tempoTrascorso += (DateTime.Now - _tempoInizio).Seconds;
        }

        public void Reset()
        {
            _tempoInizio = DateTime.Now;
            _tempoTrascorso = 0;
        }

        public void Reset(int tempoInizio)
        {
            _tempoTrascorso = tempoInizio;
        }

        public int Read()
        {
            return _tempoTrascorso;
        }
    }  
}
