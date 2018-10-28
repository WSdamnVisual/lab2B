using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2BWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();
        Random rnd = new Random();
        Point[] locations = new Point[52];
        Image[] images = new Image[52];
        int[] rands = new int[52];
        TranslateTransform trans;

        public MainWindow()
        {
            InitializeComponent();
            for (int j = 0; j < rands.Length; j++)
            {
                rands[j] = rnd.Next(17, 25);
            }
            String[] tempName;
            String imgSource;
            int i = 0;
            int x = 5, y = 5;
            foreach (Card card in deck)
            {
                images[i] = new Image();
                trans = new TranslateTransform(x, y);
                tempName = deck[i].ToString().ToLower().Replace(":", "").Split(' ');
                imgSource = String.Format(@"/img/{0}.jpg", String.Concat(tempName[1], tempName[3]));
                /* ---FOR STORYBOARD---
                images[i].Name = String.Concat(tempName[1], tempName[3]);
                this.RegisterName(images[i].Name, images[i]);*/
                images[i].Source = new BitmapImage(new Uri(imgSource, UriKind.Relative));
                images[i].RenderTransform = trans;
                locations[i] = new Point(x, y);
                mCanv.Children.Add(images[i]);
                i++;
                x += 110;
                if (i % 13 == 0)
                {
                    y += 140;
                    x = 5;
                }
            }
        }

        public void Collect2()
        {
            int i = 0;
            int del = 50;
            foreach (Image image in images)
            {
                int dec = rands[i] / 10, unit = rands[i] % 10 * 100;
                int toX = 623 + dec + unit / del, toY = 197 + dec + unit / del;

                Point location = new Point((double)image.RenderTransform.GetValue(TranslateTransform.XProperty),
                (double)image.RenderTransform.GetValue(TranslateTransform.YProperty));
                Duration duration = new Duration(new TimeSpan(0, 0, 0, dec, unit));

                DoubleAnimation daX = new DoubleAnimation(location.X, toX, duration);
                daX.AccelerationRatio = 0.6;
                DoubleAnimation daY = new DoubleAnimation(location.Y, toY, duration);
                daY.AccelerationRatio = 0.6;
                Transform tr = image.RenderTransform;
                tr.BeginAnimation(TranslateTransform.XProperty, daX);
                tr.BeginAnimation(TranslateTransform.YProperty, daY);
                i++;
            }

            ShuffleCol();
            Spread();
        }
        public void Spread()
        {
            int i = 0;
            foreach (Image image in images)
            {
                int dec = rands[i] / 10, unit = rands[i] % 10 * 100;

                Point location = new Point((double)image.RenderTransform.GetValue(TranslateTransform.XProperty),
                (double)image.RenderTransform.GetValue(TranslateTransform.YProperty));
                Duration duration = new Duration(new TimeSpan(0, 0, 0, dec, unit));

                DoubleAnimation daX = new DoubleAnimation(location.X, locations[i].X, duration);
                daX.AccelerationRatio = 0.6;
                DoubleAnimation daY = new DoubleAnimation(location.Y, locations[i].Y, duration);
                daY.AccelerationRatio = 0.6;

                Transform tr = image.RenderTransform;
                tr.BeginAnimation(TranslateTransform.XProperty, daX);
                tr.BeginAnimation(TranslateTransform.YProperty, daY);
                i++;
            }
        }
        public void ShuffleCol()
        {
            Random random = new Random();
            locations = locations.OrderBy(x => random.Next()).ToArray();
        }

        private void mCanv_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Collect2();
        }
        /*THERE IS SOME STUFF W/ STORYBOARD
        public void ToOne(Image image)
        {
            Point location = new Point((double)image.RenderTransform.GetValue(TranslateTransform.XProperty),
                (double)image.RenderTransform.GetValue(TranslateTransform.YProperty));
            Duration duration = new Duration(new TimeSpan(0, 0, 2));


            DoubleAnimation daX = new DoubleAnimation(location.X, 5, duration);
            daX.AccelerationRatio = 0.6;
            DoubleAnimation daY = new DoubleAnimation(location.Y, 5, duration);
            daY.AccelerationRatio = 0.6;

            Transform tr = image.RenderTransform;
            tr.BeginAnimation(TranslateTransform.XProperty, daX);
            tr.BeginAnimation(TranslateTransform.YProperty, daY);

            /* ---USING STORYBOARD---

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(daX);
            storyboard.Children.Add(daY);
            Storyboard.SetTarget(daX, image);
            Storyboard.SetTarget(daY, image);
            Storyboard.SetTargetProperty(daX, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
            Storyboard.SetTargetProperty(daY, new PropertyPath("RenderTransform.(TranslateTransform.Y)"));
            //Storyboard.SetTargetProperty(daX, new PropertyPath(TranslateTransform.XProperty));
            storyboard.Begin();
            
        }*/

    }
}
        //---------------BORDER OF NOT USELESS CODE-------------------

        /*public bool CollectBool()
        {
            int i = 0;
            int del = 50;
            foreach (Image image in images)
            {
                int dec = rands[i] / 10, unit = rands[i] % 10 * 100;
                int toX = 623 + dec + unit / del, toY = 197 + dec + unit / del;

                Point location = new Point((double)image.RenderTransform.GetValue(TranslateTransform.XProperty),
                (double)image.RenderTransform.GetValue(TranslateTransform.YProperty));
                Duration duration = new Duration(new TimeSpan(0, 0, 0, dec, unit));

                DoubleAnimation daX = new DoubleAnimation(location.X, toX, duration);
                daX.AccelerationRatio = 0.6;
                DoubleAnimation daY = new DoubleAnimation(location.Y, toY, duration);
                daY.AccelerationRatio = 0.6;
                Transform tr = image.RenderTransform;
                tr.BeginAnimation(TranslateTransform.XProperty, daX);
                tr.BeginAnimation(TranslateTransform.YProperty, daY);
                i++;
            }
            return true;
        }
        */
        /*  private void DaX_Completed(object sender, EventArgs e)
          {
              ShuffleCol();
              Spread();
          }
          */
        /*public void Collect()
                {
                    foreach (Image image in images)
                    {
                        Point location = new Point((double)image.RenderTransform.GetValue(TranslateTransform.XProperty),
                        (double)image.RenderTransform.GetValue(TranslateTransform.YProperty));
                        Duration duration = new Duration(new TimeSpan(0, 0, 2));

                        int x = 623, y = 200;
                        DoubleAnimation daX = new DoubleAnimation(location.X, y, duration);
                        daX.AccelerationRatio = 0.6;
                        DoubleAnimation daY = new DoubleAnimation(location.Y, y, duration);
                        daY.AccelerationRatio = 0.6;

                        Transform tr = image.RenderTransform;
                        tr.BeginAnimation(TranslateTransform.XProperty, daX);
                        tr.BeginAnimation(TranslateTransform.YProperty, daY);
                    }

                }
                */

