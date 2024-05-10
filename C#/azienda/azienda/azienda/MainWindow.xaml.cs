/*Manzi Giuliano, 4i. Really simple business management program that allows to create employees, clients, business
 * expenses and wages. It's also possible to save and upload the configuration in a json file.*/
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
using System.Xml.Serialization;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Reflection;
using System.Collections.Generic;

namespace Azienda
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
        //cdc e dipendenti d'esempio
        Company<decimal> _compagnia;

        class mySerializableClass
        {
            //da aggiungere
        }

        private void rdCliente_Checked(object sender, RoutedEventArgs e)
        {
            grdCliente.Visibility = Visibility.Visible;
            grdDipendente.Visibility = Visibility.Hidden;
            grdAzienda.Visibility = Visibility.Hidden;

            lblNome.Visibility = Visibility.Visible;
            lblCognome.Visibility = Visibility.Visible;
            txtNome.Visibility = Visibility.Visible;
            txtCognome.Visibility = Visibility.Visible;
            btnAggiungi.IsEnabled = true;
            btnElimina.IsEnabled = true;
            btnPrimo.IsEnabled = true;
            btnUltimo.IsEnabled = true;
            btnIndietro.IsEnabled = true;
            btnAvanti.IsEnabled = true;
            lblIstruzioni.Visibility = Visibility.Hidden;

            _compagnia.IndiceClienti = 0;
            scorriCliente();
        }

        private void rdDipendente_Checked(object sender, RoutedEventArgs e)
        {
            grdDipendente.Visibility = Visibility.Visible;
            grdCliente.Visibility = Visibility.Hidden;
            grdAzienda.Visibility = Visibility.Hidden;

            lblNome.Visibility = Visibility.Visible;
            lblCognome.Visibility = Visibility.Visible;
            txtNome.Visibility = Visibility.Visible;
            txtCognome.Visibility = Visibility.Visible;
            btnAggiungi.IsEnabled = true;
            btnElimina.IsEnabled = true;
            btnPrimo.IsEnabled = true;
            btnUltimo.IsEnabled = true;
            btnIndietro.IsEnabled = true;
            btnAvanti.IsEnabled = true;
            lblIstruzioni.Visibility = Visibility.Hidden;

            _compagnia.IndiceDipendenti = 0;
            scorriDipendente();
        }

        private void rdAzienda_Checked(object sender, RoutedEventArgs e)
        {
            grdAzienda.Visibility = Visibility.Visible;
            grdCliente.Visibility = Visibility.Hidden;
            grdDipendente.Visibility = Visibility.Hidden;

            lblNome.Visibility = Visibility.Hidden;
            lblCognome.Visibility = Visibility.Hidden;
            txtNome.Visibility = Visibility.Hidden;
            txtCognome.Visibility = Visibility.Hidden;
            btnAggiungi.IsEnabled = false;
            btnElimina.IsEnabled = false;
            btnPrimo.IsEnabled = false;
            btnUltimo.IsEnabled = false;
            btnIndietro.IsEnabled = false;
            btnAvanti.IsEnabled = false;
            lblIstruzioni.Visibility = Visibility.Hidden;

            visualizzaAzienda();
        }

        private void txtNome_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNome.Text = "";
        }

        private void txtCognome_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCognome.Text = "";
        }

        private void txtNomeArticolo_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNomeArticolo.Text = "";
        }

        private void txtNomeArticolo_Copy_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNomeArticolo_Copy.Text = "";
        }

        private void txtStipendioAnnuale_GotFocus(object sender, RoutedEventArgs e)
        {
            txtStipendioAnnuale.Text = "";
        }

        private void btnAggiungi_Click(object sender, RoutedEventArgs e)
        {
            if (rdCliente.IsChecked == true)
            {
                Customer<decimal> nuovoCliente = new Customer<decimal>(txtNome.Text, txtCognome.Text);
                _compagnia.aggiungiCliente(nuovoCliente);
                _compagnia.IndiceClienti = _compagnia.getListaClienti().Count - 1;
                lblIndice.Content = "Indice: " + _compagnia.IndiceClienti;
                MessageBox.Show(
                    "Nuovo cliente aggiunto con successo",
                    "Nuovo cliente",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                lstAcquisti.Items.Clear();
                lblId.Content = "ID Cliente: " + nuovoCliente.ID.ToString();
                if (txtNomeArticolo.Text != "" && txtNomeArticolo_Copy.Text != "")
                {
                    nuovoCliente.nuovoAcquisto(txtNomeArticolo.Text, decimal.Parse(txtNomeArticolo_Copy.Text));
                    foreach (Acquisto<decimal> acquisto in nuovoCliente.AcquistiEffettuati)
                    {
                        lstAcquisti.Items.Add(acquisto.ToString());
                    }
                }
            }
            if (rdDipendente.IsChecked == true)
            {
                try
                {
                    Employee<decimal> nuovoImpiegato = new Employee<decimal>(txtNome.Text, txtCognome.Text, decimal.Parse(txtStipendioAnnuale.Text));
                    _compagnia.aggiungiImpiegato(nuovoImpiegato);
                    _compagnia.IndiceDipendenti = _compagnia.getListaImpiegati().Count - 1;
                    lblIndice.Content = "Indice: " + _compagnia.IndiceDipendenti;
                    MessageBox.Show(
                       "Nuovo dipendente aggiunto con successo",
                       "Nuovo dipendente",
                       MessageBoxButton.OK,
                       MessageBoxImage.Information);
                    lblIDDipendente.Content = "ID Dipendente: " + nuovoImpiegato.ID.ToString();
                    txtStipendioAnnuale.Text = nuovoImpiegato.stipendioAnnuale.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                    "Errore nella creazione del dipendente",
                    "Errore",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                }
            }
        }

        private void btnIndietro_Click(object sender, RoutedEventArgs e)
        {
            if(rdCliente.IsChecked == true)
            {
                if(_compagnia.getListaClienti().Count - 1 == 0 || _compagnia.IndiceClienti <= 0)
                {
                    MessageBox.Show(
                        "E' stato raggiunto il primo cliente",
                        "Fine della visualizzazione",
                        MessageBoxButton.OK,
                        MessageBoxImage.Stop);
                }
                else
                {
                    _compagnia.IndiceClienti--;
                    scorriCliente();
                }
            }
            else if (rdDipendente.IsChecked == true)
            {
                if (_compagnia.getListaImpiegati().Count - 1 == 0 || _compagnia.IndiceDipendenti <= 0)
                {
                    MessageBox.Show(
                        "E' stato raggiunto il primo dipendente",
                        "Fine della visualizzazione",
                        MessageBoxButton.OK,
                        MessageBoxImage.Stop);
                }
                else
                {
                    _compagnia.IndiceDipendenti--;
                    scorriDipendente();
                }
            }
        }

        private void btnAvanti_Click(object sender, RoutedEventArgs e)
        {
            if (rdCliente.IsChecked == true)
            {
                if (_compagnia.IndiceClienti + 1 >= _compagnia.getListaClienti().Count())
                {
                    MessageBox.Show(
                        "E' stato raggiunto l'ultimo cliente",
                        "Fine della visualizzazione",
                        MessageBoxButton.OK,
                        MessageBoxImage.Stop);
                }
                else
                {
                    _compagnia.IndiceClienti++;
                    scorriCliente();
                }
            }
            else if (rdDipendente.IsChecked == true)
            {
                if (_compagnia.IndiceDipendenti + 1 >= _compagnia.getListaImpiegati().Count())
                {
                    MessageBox.Show(
                        "E' stato raggiunto l'ultimo dipendente",
                        "Fine della visualizzazione",
                        MessageBoxButton.OK,
                        MessageBoxImage.Stop);
                }
                else
                {
                    _compagnia.IndiceDipendenti++;
                    scorriDipendente();
                }
            }
        }
        private void btnAggiungiArticolo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lstAcquisti.Items.Clear();
                _compagnia.getListaClienti().ElementAt(_compagnia.IndiceClienti).nuovoAcquisto(txtNomeArticolo.Text, decimal.Parse(txtNomeArticolo_Copy.Text));
                foreach (Acquisto<decimal> acquisto in _compagnia.getListaClienti().ElementAt(_compagnia.IndiceClienti).AcquistiEffettuati)
                {
                    lstAcquisti.Items.Add(acquisto.ToString());
                }
                rdCliente_Checked(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Errore nell'aggiunta dell'acquisto",
                    "Gestione articoli",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void scorriCliente()
        {
            decimal spese = 0;
            if (_compagnia.getListaClienti().Count == 0)
            {
                lblIndice.Content = "Indice: ";
                txtNomeArticolo.Text = "";
                txtNomeArticolo_Copy.Text = "";
                txtNome.Text = "";
                txtCognome.Text = "";
                lblId.Content = "ID Cliente: ";
                lstAcquisti.Items.Clear();
            }
            else
            {
                lblIndice.Content = "Indice: " + _compagnia.IndiceClienti;
                txtNomeArticolo.Text = "";
                txtNomeArticolo_Copy.Text = "";
                txtNome.Text = _compagnia.getListaClienti().ElementAt(_compagnia.IndiceClienti).Nome;
                txtCognome.Text = _compagnia.getListaClienti().ElementAt(_compagnia.IndiceClienti).Cognome;
                lblId.Content = "ID Cliente: " + _compagnia.getListaClienti().ElementAt(_compagnia.IndiceClienti).ID.ToString();
                lstAcquisti.Items.Clear();
                if (_compagnia.getListaClienti().ElementAt(_compagnia.IndiceClienti).AcquistiEffettuati.Count >= 1)
                {
                    foreach (Acquisto<decimal> acquisto in _compagnia.getListaClienti().ElementAt(_compagnia.IndiceClienti).AcquistiEffettuati)
                    {
                        lstAcquisti.Items.Add(acquisto.ToString());
                        spese += acquisto.PrezzoArticolo;
                    }
                    lblTotaleSpeseCliente.Content = "Totale delle spese effettuate: " + spese + "€";
                }
            }
        }

        private void btnPrimo_Click(object sender, RoutedEventArgs e)
        {
            if (rdCliente.IsChecked == true)
            {
                _compagnia.IndiceClienti = 0;
                scorriCliente();
            }
            else if (rdDipendente.IsChecked == true)
            {
                _compagnia.IndiceDipendenti = 0;
                scorriDipendente();
            }
        }

        private void btnUltimo_Click(object sender, RoutedEventArgs e)
        {
            if (rdCliente.IsChecked == true)
            {
                _compagnia.IndiceClienti = _compagnia.getListaClienti().Count - 1;
                scorriCliente();
            }
            else if (rdDipendente.IsChecked == true)
            {
                _compagnia.IndiceDipendenti = _compagnia.getListaImpiegati().Count - 1;
                scorriDipendente();
            }
        }
        private void scorriDipendente()
        {
            if (_compagnia.getListaImpiegati().Count == 0)
            {
                lblIndice.Content = "Indice: ";
                txtNome.Text = "";
                txtCognome.Text = "";
                lblIDDipendente.Content = "ID Dipendente: ";
                txtStipendioAnnuale.Text = "";
            }
            else
            {
                lblIndice.Content = "Indice: " + _compagnia.IndiceDipendenti;
                txtNome.Text = _compagnia.getListaImpiegati().ElementAt(_compagnia.IndiceDipendenti).Nome;
                txtCognome.Text = _compagnia.getListaImpiegati().ElementAt(_compagnia.IndiceDipendenti).Cognome;
                lblIDDipendente.Content = "ID Dipendente: " + _compagnia.getListaImpiegati().ElementAt(_compagnia.IndiceDipendenti).ID.ToString();
                txtStipendioAnnuale.Text = _compagnia.getListaImpiegati().ElementAt(_compagnia.IndiceDipendenti).stipendioAnnuale.ToString();
            }
        }

        private void visualizzaAzienda()
        {
            lblTotaleSpese1.Content = "Totale delle spese: " + _compagnia.totaleSpese().ToString() + "€";
            lblTotaleEntrate.Content = "Totale delle entrate: " + _compagnia.totaleEntrate().ToString() + "€";
            lblTotaleProfitto.Content = "Totale del profitto: " + _compagnia.totaleProfitto().ToString() + "€";

            lstClienti.Items.Clear();
            foreach (Customer<decimal> cliente in _compagnia.getListaClienti())
            {
                lstClienti.Items.Add(cliente.ToString());
            }

            lstDipendenti.Items.Clear();
            foreach (Employee<decimal> impiegato in _compagnia.getListaImpiegati())
            {
                lstDipendenti.Items.Add(impiegato.ToString());
            }
        }

        private void btnEsporta_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializer serializer = new JsonSerializer();
            StreamWriter scriviFile;
            SaveFileDialog fileDialog = new SaveFileDialog();
            string nomeFile;

            try
            {
                //scegli percorso
                fileDialog.Filter = "Json|*.json";
                fileDialog.Title = "Esporta file Json";
                fileDialog.DefaultExt = ".json";
                nomeFile = "compagnia.json";
                fileDialog.FileName = nomeFile;
                fileDialog.ShowDialog();

                //serializza compagnia
                using (scriviFile = File.CreateText(fileDialog.FileName))
                {
                    serializer.Serialize(scriviFile, _compagnia);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Errore nel salvataggio dei dati",
                    "Errore",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void btnCarica_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializer serializer = new JsonSerializer();
            StreamReader leggiFile;
            OpenFileDialog fileDialog = new OpenFileDialog();

            try
            {
                //scegli percorso
                fileDialog.Filter = "Json|*.json";
                fileDialog.Title = "Importa file Json";
                fileDialog.DefaultExt = ".json";
                fileDialog.ShowDialog();
                leggiFile = File.OpenText(fileDialog.FileName);

                //leggi compagnia
                _compagnia = (Company<decimal>)serializer.Deserialize(leggiFile, typeof(Company<decimal>));
                leggiFile.Close();

                rdAzienda_Checked(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Errore nel salvataggio dei dati",
                    "Errore",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            _compagnia = new Company<decimal>();
            Customer<decimal> clienteEsempio = new Customer<decimal>("Mario", "Rossi");
            _compagnia.aggiungiCliente(clienteEsempio);
            Employee<decimal> dipendenteEsempio = new Employee<decimal>("Claudio", "Neri", 2000);
            _compagnia.aggiungiImpiegato(dipendenteEsempio);
        }

        private void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            if (rdCliente.IsChecked == true)
            {
                _compagnia.getListaClienti().Remove(_compagnia.getListaClienti().ElementAt(_compagnia.IndiceClienti));
                _compagnia.IndiceClienti = _compagnia.getListaClienti().Count - 2;
                lblIndice.Content = "Indice: " + _compagnia.IndiceClienti;
                MessageBox.Show(
                    "Cliente eliminato con successo",
                    "Eliminazione cliente",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                lstAcquisti.Items.Clear();
                lblId.Content = "ID Cliente: ";
                rdCliente_Checked(sender, e);
            }
            if (rdDipendente.IsChecked == true)
            {
                try
                {
                    _compagnia.getListaImpiegati().Remove(_compagnia.getListaImpiegati().ElementAt(_compagnia.IndiceDipendenti));
                    _compagnia.IndiceDipendenti = _compagnia.getListaImpiegati().Count - 2;
                    lblIndice.Content = "Indice: " + _compagnia.IndiceDipendenti;
                    MessageBox.Show(
                       "Dipendente eliminato con successo",
                       "Elimina dipendente",
                       MessageBoxButton.OK,
                       MessageBoxImage.Information);
                    lblIDDipendente.Content = "ID Dipendente: ";
                    txtStipendioAnnuale.Text = "";
                    rdDipendente_Checked(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                    "Errore nella creazione del dipendente",
                    "Errore",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                }
            }
        }

        private void btnOrdinaPerCognome_Click(object sender, RoutedEventArgs e)
        {
            _compagnia.getListaClienti().Sort(new sortCustomerBySurname());
            rdAzienda_Checked(sender, e);
        }

        private void btnOrdinaPerStipendio_Click(object sender, RoutedEventArgs e)
        {
            _compagnia.getListaImpiegati().Sort();
            rdAzienda_Checked(sender, e);
        }

        private void btnOrdinaClientiReverse_Click(object sender, RoutedEventArgs e)
        {
            lstClienti.Items.Clear();

            foreach (Customer<decimal> customer in _compagnia.ReverseClienti)
            {
                lstClienti.Items.Add(customer.ToString());
            }
        }

        private void btnOrdinaImpiegatiStipendioSopraDuemila_Click(object sender, RoutedEventArgs e)
        {
            lstDipendenti.Items.Clear();

            foreach (Employee<decimal> impiegato in _compagnia.stipendioSopraDuemila)
            {
                lstDipendenti.Items.Add(impiegato.ToString());
            }
        }
    }
}
