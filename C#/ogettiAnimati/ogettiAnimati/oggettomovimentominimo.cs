using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace ogettiAnimati
{
    internal class oggettomovimentominimo : oggettoStatico
    {
        double _x, _y, _scalaX, _scalaY, _gradi = -30;
        Image _img = new Image();
        public oggettomovimentominimo(Uri source, Canvas acquario, double x, double y)
        {
            _x = x;
            _y = y;
            BitmapImage bitmap = new BitmapImage(source);
            _img.Source = bitmap;
            _img.Margin = new Thickness(x, y, 0, 0);
            acquario.Children.Add(_img);
        }

        public override void Step()
        {
            bool trueSu = true;
            _x = 700;
            _y = 400;
            _scalaX = 0.35;
            _scalaY = 0.35;

            _gradi++;
            base.applicaModifiche(_scalaX, _scalaY, _gradi, _x, _y, _img);
        }
    }
}
