//Manzi Giuliano 4i, i was asked to do do some images animations using classes for different types of movement.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Collections.Generic;
using ogettiAnimati;

namespace ogettiAnimati
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

        DispatcherTimer dispatcherTimer;
        List<oggettoStatico> _ogm;
        double h, w;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AggiungiOggetti();
            SetupTimer();
            this.SizeChanged += MainWindow_SizeChanged;
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            h = e.NewSize.Height;
            w = e.NewSize.Width;
        }

        private void AggiungiOggetti()
        {
            _ogm = new List<oggettoStatico>();
            _ogm.Add(new oggettoStatico(new Uri(@"/immagini/relitto.png", UriKind.RelativeOrAbsolute), canvasAcquario, 200, 220));
            _ogm.Add(new oggettomovimentobase(new Uri(@"/immagini/pesce.png", UriKind.RelativeOrAbsolute), canvasAcquario, 10, 100));
            _ogm.Add(new oggettomovimentobase(new Uri(@"/immagini/pesci.png", UriKind.RelativeOrAbsolute), canvasAcquario, 500, 200));
            _ogm.Add(new oggettomovimentominimo(new Uri(@"/immagini/pescepalla.png", UriKind.RelativeOrAbsolute), canvasAcquario, 700, 400));
        }

        private void SetupTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            foreach (oggettoStatico og in _ogm)
            {
                og.Step();
            }
        }

        
    }
}
