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

        RacerModel racer = new RacerModel();

        //Thread t1;
        //Thread t2;
        //Thread t3;
        //Thread t4;
        //Thread t5;


        TranslateTransform transform1 = new TranslateTransform();
        //TranslateTransform transform2;
        //TranslateTransform transform3;
        //TranslateTransform transform4;
        //TranslateTransform transform5;
        Random rnd = new Random();


        RacerModel racer1;

        Thread t1 = null;
        Thread t2;

        public delegate void TestThis();
        public TestThis delegateTestTest;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            racer1  = new RacerModel(btnRacer1, progress);
            //racer.LoadingProgress += Racer_LoadingProgress;
            progress.Maximum = 300;
            //progress.Value = 50;
           // delegateTestTest = new TestThis(TestTest);
      
        }

        private void Work()
        {
            //for(int i = 0; i<=100; i++)
            //{
            //    Thread.Sleep(200);
            //    UpdateProgressBaar(i);
            //}
            int count = 0;

            while(count<=300)
            {
                count += rnd.Next(5, 25);
                Thread.Sleep(200);
                UpdateProgressBaar(count);
            }
        }

        private void MoveByX()
        {
            int distance = 0;
            while(distance <= 460)
            {
                distance += rnd.Next(10, 30);
                Thread.Sleep(200);
                UpdatePositionButton(distance);
            }
        }

        private void UpdateProgressBaar(int i)
        {
            Action action = () => { SetProgress(i); };
            progress.Dispatcher.BeginInvoke(action);
        }

        private void UpdatePositionButton(int distance)
        {
            Action action = () => { SetDistance(distance); };
            btnRacer1.Dispatcher.BeginInvoke(action);
        }

        private void SetProgress(int i)
        {
            progress.Value = i;
        }

        private void SetDistance(int dist)
        {
            transform1.X += rnd.Next(5, 10);
            btnRacer1.RenderTransform = transform1;
            this.Title = transform1.X.ToString();
        }
        //private void Racer_LoadingProgress()
        //{
        //    Dispatcher.Invoke(new Action(() =>
        //    {
        //        racer.DoLoading2();
        //    }));
        //}

        void StartClick(object sender, RoutedEventArgs e)
        {
            //racer.DeltaX = rnd.Next(5, 15);
            //Racer_LoadingProgress();
            //this.Dispatcher.BeginInvoke(() =>
            //{
            //    racer1.UpdateX(btnRacer1, rnd.Next(4, 45));
            //});

            //t1 = new Thread(UpdateCoordX);
            //t1.Start();
            //this.Title = progress.Value.ToString();

            //this.Dispatcher.Invoke(delegateTestTest);
            t2 = new Thread(MoveByX);
            t2.Start();
            //t1 = new Thread(Work);
            //t1.Start();
         
        }

        public void TestTest()
        {
            while(progress.Value<=300)
            {
                progress.Value += rnd.Next(5, 25);
         
                this.Title = progress.Value.ToString();
                Thread.Sleep(500);
            }
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
