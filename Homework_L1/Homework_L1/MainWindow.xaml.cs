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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Homework_L1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Thread t1;
        Thread t2;
        Thread t3;
        Thread t4;
        Thread t5;


        TranslateTransform transform1 = new TranslateTransform();
        TranslateTransform transform2;
        TranslateTransform transform3;
        TranslateTransform transform4;
        TranslateTransform transform5;
        Random rnd = new Random();


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        void StartClick(object sender, RoutedEventArgs e)
        {
            //t1 = new Thread(()=> {

            //    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            //    {


            //        while (transform1.X <= 300)
            //        {
            //            transform1.X += rnd.Next(5, 45);
            //            Thread.Sleep(500);
            //            btnRacer1.RenderTransform = transform1;

            //        }
            //    });


            //});
            //t1.Start();

            t1 = new Thread(new ThreadStart(() =>
            {
                //btnRacer1.Content = transform1.X.ToString();
    

                    while (btnRacer1 <= 200)
                    {
                    //while (transform1.X <= 300)
                    // {
                    this.Dispatcher.Invoke(() =>
                    {
                        transform1.X += rnd.Next(5, 45);

                        //btnRacer1.RenderTransform = transform1;
                        btnRacer1.Content = transform1.X.ToString();

                        Thread.Sleep(500);
                    });
                }
                    //}
        

            }));
            t1.Start();


            //transform1.X += rnd.Next(5, 45);
            //btnRacer1.RenderTransform = transform1;
        }
        void StopClick(object sender, RoutedEventArgs e)
        {
            t1.Abort();
        }

        void Move(TranslateTransform transform)
        {

            transform.X += rnd.Next(5, 45);
            //btnRacer1.RenderTransform = transform;
            btnRacer1.Content = transform.X.ToString();




        }

        void UpdateCoordX()
        {
            //TranslateTransform transform = new TranslateTransform();
            this.Dispatcher.BeginInvoke(DispatcherPriority.Render, (ThreadStart)delegate ()
            {

                Move(transform1);

            });
        }
    }
}
