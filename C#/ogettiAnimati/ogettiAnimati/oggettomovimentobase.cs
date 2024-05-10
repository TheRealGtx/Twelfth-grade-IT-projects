using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace ogettiAnimati
{
    internal class oggettomovimentobase : oggettoStatico
    {
        double _x = 10, _y, _scalaX, _scalaY, _gradi;
        double fineCanvas;
        bool sinistraDestra = true;
        Image _img = new Image();
        public oggettomovimentobase(Uri source, Canvas acquario, double x, double y)
        {
            _x = x;
            _y = y;
            BitmapImage bitmap = new BitmapImage(source);
            _img.Source = bitmap;
            _img.Margin = new Thickness(x, y, 0, 0);
            acquario.Children.Add(_img);
            //fineCanvas = acquario.
        }

        public override void Step()
        {
            if (_x < 1950 && sinistraDestra == true)
            {
                _x += 10;
                _scalaX = 0.35;
                _scalaY = 0.35;
                _gradi = 0;
            }
            else
            {
                sinistraDestra = false;
                _x -= 10;
                _scalaX = -0.35;
                _scalaY = 0.35;
                _gradi = 10;
                if (_x < 0)
                {
                    sinistraDestra = true;
                }
            }
            base.applicaModifiche(_scalaX, _scalaY, _gradi, _x, _y, _img);
        }
    }
}
