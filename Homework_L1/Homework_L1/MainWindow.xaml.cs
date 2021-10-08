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
        TranslateTransform transform2 = new TranslateTransform();
        TranslateTransform transform3 = new TranslateTransform();
        TranslateTransform transform4 = new TranslateTransform();
        TranslateTransform transform5 = new TranslateTransform();
        Random rnd = new Random();


        RacerModel racer1;

        Thread t1 = null;
        Thread t2;
        Thread t3;
        Thread t4;
        Thread t5;
        Thread t6;

        public delegate void TestThis();
        public TestThis delegateTestTest;
        public static int Places = 1;
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

        private void MoveByX(Button btn, TextBlock tb, TranslateTransform transl)
        {
            int distance = 0;
            while(distance <= 610)
            {
                //distance += rnd.Next(10, 30);
                distance += 10;
                try
                {
                    Thread.Sleep(rnd.Next(100, 450));

                }
                catch
                {
                    Thread.Sleep(2000);
                }
                UpdatePositionButton(btn, tb, transl, distance);
            }
        }

        private void UpdateProgressBaar(int i)
        {
            Action action = () => { SetProgress(i); };
            progress.Dispatcher.BeginInvoke(action);
        }

        private void UpdatePositionButton(Button btn, TextBlock tb, TranslateTransform transl, int distance)
        {
            Action action = () => { SetDistance(btn, tb, transl, distance); };
            btn.Dispatcher.BeginInvoke(action);
        }

        private void SetProgress(int i)
        {
            progress.Value = i;
        }

        private void SetDistance(Button btn, TextBlock tb, TranslateTransform transl, int dist)
        {
            //transform1.X += rnd.Next(5, 10);

            transl.X = dist;
            btn.RenderTransform = transl;
            if (dist == 610)
            {
                //t2.Abort();
                tb.Text = Places.ToString() + " Place";
                Places++;

                //Thread.CurrentThread.Abort();
      
                //Thread.CurrentThread.Join();
            }
            //btn.Content = transl.X.ToString();
            //this.Title = transform1.X.ToString();
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

            Places = 1;
            btn1Pos.Text = "";
            btn2Pos.Text = "";
            btn3Pos.Text = "";
            btn4Pos.Text = "";
            btn5Pos.Text = "";

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
            t2 = new Thread(() => MoveByX(btnRacer1, btn1Pos,transform1));
            t2.IsBackground = true;
            t3 = new Thread(() => MoveByX(btnRacer3, btn3Pos, transform3));
            t3.IsBackground = true;

            t4 = new Thread(() => MoveByX(btnRacer2, btn2Pos, transform2));
            t4.IsBackground = true;

            t5 = new Thread(() => MoveByX(btnRacer4, btn4Pos, transform4));
            t5.IsBackground = true;

            t6 = new Thread(() => MoveByX(btnRacer5, btn5Pos, transform5));
            t6.IsBackground = true;

            //if (t2.IsAlive)
            //{
            //    //t2.Sl();
            //    //t3.Resume();
            //    //t4.Resume();
            //    //t5.Resume();
            //    //t6.Resume();
            //}
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
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
            //try 
            //{ 
            //}
            //finally
            //{
            t2.Interrupt();
            t3.Interrupt();
            t4.Interrupt();
            t5.Interrupt();
            t6.Interrupt();
            //}



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
