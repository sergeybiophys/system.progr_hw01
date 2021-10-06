using Homework_L1.Models;
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

        //Thread t1;
        //Thread t2;
        //Thread t3;
        //Thread t4;
        //Thread t5;


        //TranslateTransform transform1 = new TranslateTransform();
        //TranslateTransform transform2;
        //TranslateTransform transform3;
        //TranslateTransform transform4;
        //TranslateTransform transform5;
        Random rnd = new Random();


        RacerModel racer1;


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
           racer1  = new RacerModel(btnRacer1);
            

        }


        void StartClick(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                racer1.UpdateX(btnRacer1, rnd.Next(4, 45));
            });
 
            //t1 = new Thread(UpdateCoordX);
            //t1.Start();
        }
        void StopClick(object sender, RoutedEventArgs e)
        {
            //t1.Abort();
        }

        //void Move(TranslateTransform transform)
        //{

        //    transform.X += rnd.Next(5, 45);
        //    //btnRacer1.RenderTransform = transform;
        //    btnRacer1.Content = transform.X.ToString();

        //    Thread.Sleep(200);


        //}

        //void UpdateCoordX()
        //{
        //    //TranslateTransform transform = new TranslateTransform();
        //    this.Dispatcher.BeginInvoke( new Action(()=>
        //    {
        //        while(transform1.X<=300)
        //        {
        //            Move(transform1);
        //            Console.WriteLine(transform1.X);
        //        }

        //    }));
        //}


    }
}
