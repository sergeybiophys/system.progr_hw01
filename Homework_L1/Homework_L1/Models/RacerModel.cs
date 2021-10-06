using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Homework_L1.Models
{
    public class RacerModel
    {
        Thread thread;

        public event Action<Button, int> MoveByX;

        TranslateTransform transform;

        Button button;
   
        public int DeltaX;

        const int STOP_LINE = 300;
        public RacerModel(Button btn)
        {
            this.button = btn;
            this.transform = new TranslateTransform();
            thread = new Thread(GameIsOn);
            thread.Start();
       
        }

        public void GameIsOn()
        {
            UpdateX(button, DeltaX);
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



    }
}
