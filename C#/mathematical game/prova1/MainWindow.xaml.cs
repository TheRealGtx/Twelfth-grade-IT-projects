//Manzi Giuliano 4i 17/09/2022, little mathematical game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prova1
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Cdc
        int i = 0;
        int numeroPensato = 4;
        int numeroEstratto;
 
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            var numeroCasuale = new Random();
            if (i < 2)
            {
                numeroEstratto = numeroCasuale.Next(-11, 11);
                if (numeroEstratto >= 0)
                    lblTesto.Content = ("Ora calcola il tuo numero + " + numeroEstratto);
                else
                    lblTesto.Content = ("Ora calcola il tuo numero - " + (numeroEstratto * -1));
                numeroPensato += numeroEstratto;
                i++;
            }
            else if (i == 2)
            {
                lblTesto.Content = "Ora sottrai il numero che hai pensato all'inizio";
                numeroPensato -= 4;
                i++;
            }
            else if (i < 5)
            {
                numeroEstratto = numeroCasuale.Next(-11, 11);
                if (numeroEstratto >= 0)
                    lblTesto.Content = ("Ora calcola il tuo numero + " + numeroEstratto);
                else
                    lblTesto.Content = ("Ora calcola il tuo numero - " + (numeroEstratto * -1));
                numeroPensato += numeroEstratto;
                i++;
            }
            else if (i == 5)
            {
                lblTesto.Content = "il numero che stai pensando è " + numeroPensato;
            }
            
        }
    }
}
