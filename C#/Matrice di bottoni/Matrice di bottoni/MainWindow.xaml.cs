/*Manzi Giuliano 4i 19/09/2022. Givena number the program creates a matrix that big and then inserts random numbers
in random positions*/
using System;
using System.Windows;
using System.Windows.Controls;

namespace Matrice_di_bottoni
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
        int numeroBottoni;
        Button[,] matriceBottoni;
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            
            int inputUtente;
            
            inputUtente = int.Parse(txtInput.Text);

            try
            {
                numeroBottoni = int.Parse(Math.Sqrt(inputUtente) + "");
                matriceBottoni = new Button[numeroBottoni, numeroBottoni];
            }
            catch
            {
                MessageBox.Show(
                    "Errore",
                    "Inserire un numero valido",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Error);
            }
        }
        private void btnCrea_Click(object sender, RoutedEventArgs e)
        {
            int maxRows = numeroBottoni, maxCols = numeroBottoni;

            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxCols; j++)
                {
                    Button b = new Button();
                    b.Width = 20;
                    b.Height = 20;
                    b.HorizontalAlignment = HorizontalAlignment.Center;
                    b.VerticalAlignment = VerticalAlignment.Center;
                    b.Margin = new Thickness(j * 30, i * 30, 0, 0);
                    gridWin.Children.Add(b);
                    matriceBottoni[i,j] = b;
                }
            }
        }

        private void btnContent_Click(object sender, RoutedEventArgs e)
        {
            Random z = new Random();
            int righe = z.Next(0, numeroBottoni);
            int colonne = z.Next(0, numeroBottoni);
            int contenuto = z.Next(0, 99);
            matriceBottoni[righe, colonne].Content = contenuto;
        }
    }
}
