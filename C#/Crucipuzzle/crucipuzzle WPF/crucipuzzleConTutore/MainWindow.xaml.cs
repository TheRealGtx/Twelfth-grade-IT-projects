//Tutore: Lorenzo Serra, Tutelato: Manzi Giuliano, 4i. Crossword puzzle game in WPF
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
using System.IO;
using System.Windows.Media.Media3D;
using crucipuzzleConTutore;

namespace crucipuzzleConTutore
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
        string linea;
        Button[,] buttons;
        string parolaDaCercare;
        int righe;
        int colonne;
        Parola par;
        Tabellone tab;

        private void caricaFile()
        {
            //implementare scelta file da parte dell'utente
            string fileDefault = "../../../cruciverba.txt";
            string percorso = txtPercorso.Text;
            if (percorso == null || percorso == "")
            {
                percorso = fileDefault;
            }

            StreamReader file = new StreamReader(percorso);

            //lettura numero righe e colonne
            string riga;
            char[] colonna;

            riga = file.ReadLine();
            righe++;
            colonna = riga.ToCharArray();
            colonne = colonna.Length;
            do
            {
                riga = file.ReadLine();
                righe++;
            } while (riga != "");
            
            file.Close();
            righe -= 1;

            tab = new Tabellone(righe, colonne);
        
            //creazione matrice bottoni
            buttons = new Button[righe, colonne];

            for (int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    Button b = new Button();
                    b.Width = 29;
                    b.Height = 29;
                    b.HorizontalAlignment = HorizontalAlignment.Left;
                    b.VerticalAlignment = VerticalAlignment.Top;
                    b.Margin = new Thickness(j * 30, i * 30, 0, 0);
                    gridBottoni.Children.Add(b);
                    buttons[i, j] = b;
                    buttons[i, j].Click += new RoutedEventHandler(btnEvent_click);
                }
            }

            //assegnazione testo ai bottoni
            StreamReader file2 = new StreamReader(percorso);
            int k = 0;
            char carattere;

            do
            {
                riga = file2.ReadLine();
                righe++;
                colonna = riga.ToCharArray();
                for (int j = 0; j < colonna.Length; j++)
                {
                    carattere = colonna[j];
                    buttons[k, j].Content = carattere;
                    Casella cas = new Casella(carattere);
                    tab.Caselle[k, j] = cas;
                }
                k++;
            } while (riga != "");

            file2.Close();

            //lettura soluzioni
            StreamReader file3 = new StreamReader(percorso);
            do
            {
                riga = file3.ReadLine();
            } while (riga != "");

            lstSoluzioni.Items.Clear();

            do
            {
                riga = file3.ReadLine();
                lstSoluzioni.Items.Add(riga);
            } while (!file3.EndOfStream);

            lstSoluzioni.IsEnabled = true;
        }
        
        
        void btnEvent_click(object sender, EventArgs e)
        {
            
            Button bottone = ((Button)sender);

            if (bottone.Background == Brushes.Red)
            {
                //Bottone già premuto, non deve fare nulla
            }
            else
            {
                bottone.Background = Brushes.Red;
                linea += bottone.Content;
            }

        }

        private void cercaParola()
        {
            bool trovataSoluzione = false;
            parolaDaCercare = par.Contenuto;
            //mancano alcune direzioni e l'ultima di questo switch non funziona
            if (linea == parolaDaCercare)
            {
                trovataSoluzione = tab.CercaSinistraDestra(par, trovataSoluzione);
                if (trovataSoluzione)
                    return;
                trovataSoluzione = tab.CercaDestraSinistra(par, trovataSoluzione);
                if (trovataSoluzione)
                    return;
                trovataSoluzione = tab.CercaAltoBasso(par, trovataSoluzione);
                if (trovataSoluzione)
                    return;
                trovataSoluzione = tab.CercaBassoAlto(par, trovataSoluzione);
                if (trovataSoluzione)
                    return;
                trovataSoluzione = tab.CercaAltoDestra_BassoSinistra(par, trovataSoluzione);
                if (trovataSoluzione)
                    return;
                /*
                trovataSoluzione = tab.CercaAltoSinistra_BassoDestra(par, trovataSoluzione);
                if (trovataSoluzione)
                    return;
                */
            }
            lblNonTrovata.Content = "Parola non trovata, riprova!";
        }

        private void parolaTrovata()
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if (tab.Caselle[i, j].Nuova == true)
                    {
                        buttons[i, j].Background = Brushes.Magenta;
                        tab.Caselle[i, j].Nuova = false;
                        tab.Caselle[i, j].Impegnata = true;
                    }
                    else if (tab.Caselle[i, j].Impegnata == true)
                        buttons[i, j].Background = Brushes.Green;
                    else
                        buttons[i, j].Background = Brushes.LightGray;
                }
            }
        }

        private void btnControlla_Click(object sender, RoutedEventArgs e)
        {
            lblNonTrovata.Content = "";
            cercaParola();
            parolaDaCercare = "";
            linea = "";
            parolaTrovata();
        }

        private void btnCarica_Click(object sender, RoutedEventArgs e)
        {
            caricaFile();
            btnCarica.IsEnabled = false;
        }

        private void btnSoluzione_Click(object sender, RoutedEventArgs e)
        {
            string soluzione = txtSoluzione.Text;
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < (buttons.GetLength(1) - soluzione.Length) - 1; j++)
                {
                    for (int x = 0; x < soluzione.Length; x++)
                    {
                        if (tab.Caselle[i, j + x]._carattere.ToString() == soluzione.Substring(x, 1).ToUpper() && tab.Caselle[i, j + x].Impegnata == false)
                        {
                            buttons[i, j + x].Background = Brushes.Red;
                        }
                    }
                    
                }
            }
            btnControlla.IsEnabled = false;
        }

        private void lstSoluzioni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            par = new Parola(lstSoluzioni.SelectedItem.ToString());
            btnControlla.IsEnabled = true;
        }
    }
}
