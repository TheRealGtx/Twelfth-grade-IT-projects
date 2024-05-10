//Manzi Giuliano 4i, WPF stopwatch
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

namespace classeCronometro
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
        Cronometro crono = new Cronometro();
        bool inEsecuzione = false;
        int tempoTrascorso;

        public async void AsyncMostraValori()
        {
            await Task.Run(() =>
            {
                tempoTrascorso = crono.Read();
                int minuti, secondi, ore, giorni;

            for (int i = tempoTrascorso; inEsecuzione == true; i++)
                {
                    Dispatcher.Invoke(() =>
                    {
                        if (i < 60)
                        {
                            this.lblOutput.Content = "Tempo trascorso = " + i + " secondi";
                        }
                        else if (i >= 60 && i < 3600)
                        {
                            minuti = i / 60;
                            secondi = i % 60;
                            this.lblOutput.Content = "Tempo trascorso = " + minuti + " minuti e " + secondi + " secondi" ;
                        }
                        else if (i >= 3600 && i < 86400)
                        {
                            minuti = i / 60;
                            ore = minuti / 60;
                            secondi = i % 60;
                            minuti %= 60;
                            this.lblOutput.Content = "Tempo trascorso = " + ore + " ore,  " + minuti + " minuti e " +
                            secondi + " secondi";
                        }
                        else if (i >= 86400)
                        {
                            minuti = i / 60;
                            ore = minuti / 60;
                            giorni = ore / 24;
                            secondi = i % 60;
                            minuti %= 60;
                            ore %= 24;
                            giorni %= 24;
                            this.lblOutput.Content = "Tempo trascorso = " + giorni + " giorni, " + ore + " ore,  "
                            + minuti + " minuti e " + secondi + " secondi";
                        }
                    });
                    Task.Delay(750).Wait();
                }
            });
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            crono.Start();
            inEsecuzione = true;
            AsyncMostraValori();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            crono.Stop();
            inEsecuzione = false;
            btnMostra.IsEnabled = true;
            AsyncMostraValori();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            crono.Reset();
        }

        private void check_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtTempoInizioSecondi_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnMostra_Click(object sender, RoutedEventArgs e)
        {
            int tempoTrascorso = crono.Read();
            int minuti, secondi, ore, giorni;

            if (tempoTrascorso < 60)
            {
                lblOutput.Content = "Tempo trascorso: " + tempoTrascorso + " secondi";
            }
            else if (tempoTrascorso >= 60 && tempoTrascorso < 3600)
            {
                minuti = tempoTrascorso / 60;
                secondi = tempoTrascorso % 60;
                lblOutput.Content = "Tempo trascorso: " + minuti + " minuti e " + secondi + " secondi";
            }
            else if (tempoTrascorso >= 3600 && tempoTrascorso < 86400)
            {
                minuti = tempoTrascorso / 60;
                ore = minuti / 60;
                secondi = tempoTrascorso % 60;
                minuti %= 60;
                lblOutput.Content = "Tempo trascorso: " + ore + " ore,  " + minuti + " minuti e " + secondi + " secondi";
            }
            else if (tempoTrascorso >= 86400)
            {
                giorni = tempoTrascorso / 86400;
                minuti = tempoTrascorso / 60;
                ore = minuti / 60;
                secondi = tempoTrascorso % 60;
                minuti %= 60;
                lblOutput.Content = "Tempo trascorso: " + giorni + " giorni, " + ore + " ore,  " + minuti +
                " minuti e " + secondi + " secondi";
            }
        }

        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {
            int tempoInizio = int.Parse(txtInizio.Text);

            crono.Reset(tempoInizio);
        }
    }
}
