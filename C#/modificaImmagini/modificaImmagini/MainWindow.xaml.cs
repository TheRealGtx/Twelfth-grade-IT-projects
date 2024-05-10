//Manzi Giuliano 4i, this programs modifies an image position and dimension.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace modificaImmagini
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            caricaImmagine();
            setUpTimer();
        }
        Image sponge;
        TransformGroup transformGroup;
        int x = 200, y = 50;
        double scalaX = 0.5, scalaY = 0.5;
        int gradi = 0;

        public void caricaImmagine()
        {
            Uri source;
            source = new Uri(@"/immagini/sponge.png", UriKind.RelativeOrAbsolute);
            BitmapImage bitmap = new BitmapImage(source);
           
            sponge = new Image();
            sponge.VerticalAlignment = VerticalAlignment.Top;
            sponge.HorizontalAlignment = HorizontalAlignment.Left;
            sponge.Source = bitmap;
            sponge.Margin = new Thickness(50, 50, 0, 0);
            renderChanges();
            sfondo.Children.Add(sponge);
        }

        private void btnSinistra_Click(object sender, RoutedEventArgs e)
        {
            x--;
            renderChanges();
        }

        private void btnGiu_Click(object sender, RoutedEventArgs e)
        {
            y++;
            renderChanges();
        }

        private void btnRuota_Click(object sender, RoutedEventArgs e)
        {
            gradi++;
            renderChanges();
        }

        private void btnRuotaAntiorario_Click(object sender, RoutedEventArgs e)
        {
            gradi--;
            renderChanges();
        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            scalaX += 0.1;
            scalaY += 0.1;
            renderChanges();
        }

        private void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {
            scalaX -= 0.1;
            scalaY -= 0.1;
            renderChanges();
        }

        private void btnDestra_Click(object sender, RoutedEventArgs e)
        {
            x++;
            renderChanges();
        }

        private void btnSu_Click(object sender, RoutedEventArgs e)
        {
            y--;
            renderChanges();
        }

        private void renderChanges()
        {
            transformGroup = new TransformGroup();
            TranslateTransform translateTransform;
            RotateTransform rotateTransform;
            ScaleTransform scaleTransform;

            scaleTransform = new ScaleTransform(scalaX, scalaY);
            rotateTransform = new RotateTransform(gradi);
            translateTransform = new TranslateTransform(x, y);
            
            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(translateTransform);

            sponge.RenderTransform = transformGroup;
        }

        DispatcherTimer dispatcherTimer;

        private void setUpTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
        }

        private void btnAltoDestra_Click(object sender, RoutedEventArgs e)
        {
            x++;
            y--;
            renderChanges();
        }

        private void btnBassoDestra_Click(object sender, RoutedEventArgs e)
        {
            x++;
            y++;
            renderChanges();
        }

        private void btnAltoSinistra_Click(object sender, RoutedEventArgs e)
        {
            x--;
            y--;
            renderChanges();
        }

        private void btnBassoSinistra_Click(object sender, RoutedEventArgs e)
        {
            x--;
            y++;
            renderChanges();
        }

        int i = 0;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (btnDestra.IsPressed)
            {
                x++;
                renderChanges();
            }
            else if (btnSu.IsPressed)
            {
                y--;
                renderChanges();
            }
            else if (btnSinistra.IsPressed)
            {
                x--;
                renderChanges();
            }
            else if (btnGiu.IsPressed)
            {
                y++;
                renderChanges();
            }
            else if (btnRuotaOrario.IsPressed)
            {
                gradi++;
                renderChanges();
            }
            else if (btnRuotaAntiorario.IsPressed) 
            {
                gradi--;
                renderChanges();
            }
            else if (btnZoomIn.IsPressed)
            {
                scalaX += 0.1;
                scalaY += 0.1;
                renderChanges();
            }
            else if (btnZoomOut.IsPressed)
            {
                scalaX -= 0.1;
                scalaY -= 0.1;
                renderChanges();
            }
            else if (btnAltoDestra.IsPressed)
            {
                x++;
                y--;
                renderChanges();
            }
            else if (btnBassoDestra.IsPressed)
            {
                x++;
                y++;
                renderChanges();
            }
            if (btnAltoSinistra.IsPressed)
            {
                x--;
                y--;
                renderChanges();
            }
            if (btnBassoSinistra.IsPressed)
            {
                x--;
                y++;
                renderChanges();
            }
        }


    }
}
