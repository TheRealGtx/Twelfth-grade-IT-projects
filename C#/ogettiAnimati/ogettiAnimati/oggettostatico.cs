using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace ogettiAnimati
{
    class oggettoStatico
    {
        Image _img = new Image();
        double _x, _y, _scalaX = 1.5, _scalaY = 1.5, _gradi;
        TransformGroup transformGroup;
        public oggettoStatico() 
        { 
        }

        public oggettoStatico(Uri source, Canvas acquario, double x, double y)
        {
            _x = x;
            _y = y;
            BitmapImage bitmap = new BitmapImage(source);
            _img.Source = bitmap;
            _img.Margin = new Thickness(x, y, 0, 0);
            acquario.Children.Add(_img);
        }

        public virtual void Step()
        {
            applicaModifiche(_scalaX, _scalaY, _gradi, _x, _y, _img);
        }

        public void applicaModifiche(double scalaX, double scalaY, double gradi, double x, double y, Image img)
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

            img.RenderTransform = transformGroup;
        }
    }
}
