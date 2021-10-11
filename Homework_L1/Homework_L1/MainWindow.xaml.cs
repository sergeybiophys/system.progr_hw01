
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


        TranslateTransform transform1 = new TranslateTransform();
        TranslateTransform transform2 = new TranslateTransform();
        TranslateTransform transform3 = new TranslateTransform();
        TranslateTransform transform4 = new TranslateTransform();
        TranslateTransform transform5 = new TranslateTransform();



        Random rnd = new Random();

    
        Thread t1;
        Thread t2;
        Thread t3;
        Thread t4;
        Thread t5;


        //public delegate void TestThis();
        //public TestThis delegateTestTest;

        public static int Places = 1;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

      
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


        private void UpdatePositionButton(Button btn, TextBlock tb, TranslateTransform transl, int distance)
        {
            Action action = () => { SetNewPosition(btn, tb, transl, distance); };
            btn.Dispatcher.BeginInvoke(action);
        }


        private void SetNewPosition(Button btn, TextBlock tb, TranslateTransform transl, int dist)
        {


            transl.X = dist;
            btn.RenderTransform = transl;
            if (dist == 610)
            {

                tb.Text = Places.ToString() + " Place";
                Places++;

            }

        }


        void Reset()
>>>>>>> 1-2_test
        {


            ClearFields();
            //t1.Start();
            //this.Title = progress.Value.ToString();

            t1 = new Thread(() => MoveByX(btnRacer1, btn1Pos,transform1));
            t1.IsBackground = true;

            t2 = new Thread(() => MoveByX(btnRacer2, btn2Pos, transform2));
            t2.IsBackground = true;

            t3 = new Thread(() => MoveByX(btnRacer3, btn3Pos, transform3));
            t3.IsBackground = true;

            t4 = new Thread(() => MoveByX(btnRacer4, btn4Pos, transform4));
            t4.IsBackground = true;

            t5 = new Thread(() => MoveByX(btnRacer5, btn5Pos, transform5));
            t5.IsBackground = true;


            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

        void ClearFields()
        {
            Places = 1;
            btn1Pos.Text = "";
            btn2Pos.Text = "";
            btn3Pos.Text = "";
            btn4Pos.Text = "";
            btn5Pos.Text = "";
        }

        void StopClick(object sender, RoutedEventArgs e)
        {

            t1.Interrupt();
            t2.Interrupt();
            t3.Interrupt();
            t4.Interrupt();
            t5.Interrupt();

        }
    }
}
