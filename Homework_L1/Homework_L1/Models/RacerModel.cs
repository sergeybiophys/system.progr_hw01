using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Homework_L1.Models
{
    public class RacerModel
    {
        public Thread thread;

        public event Action<Button, int> MoveByX;
        public event Action LoadingProgress;

        TranslateTransform transform;

        Button button;
        ProgressBar progressBar;
   
        public int DeltaX;

        const int STOP_LINE = 300;
        const int LOADING_VAL_PER_SEC = 10;
        const int LOADING_DELAY = 500;

        public RacerModel() { }
        public RacerModel(Button btn, ProgressBar progress )
        {
            this.button = btn;
            this.progressBar = progress;
            this.transform = new TranslateTransform();
            thread = new Thread(GameIsOn);
            //thread.Start();
       
        }

        public void GameIsOn()
        {
            DoLoading2();

            //UpdateX(button, DeltaX);
        }

        public void UpdateX(Button btn, int deltaX)
        {
            while(this.transform.X<=STOP_LINE)
            {
                MoveByX?.Invoke(btn, (int)transform.X);
                transform.X += deltaX;
                Thread.Sleep(200);

            }
        }

        //public void DoLoading()
        //{
        //    int loadingProgress = 0;

        //    while (loadingProgress <= STOP_LINE)
        //    {
        //        LoadingProgress?.Invoke(loadingProgress);
        //        loadingProgress += DeltaX;
        //        Thread.Sleep(LOADING_DELAY);
        //    }
        //}

        public void DoLoading2()
        {
            //int loadingProgress = 0;
 
                while (progressBar.Value <= 300)
                {
                    LoadingProgress?.Invoke();
                    progressBar.Value += DeltaX;

                    Thread.Sleep(LOADING_DELAY);
                }
         

        }



    }
}
