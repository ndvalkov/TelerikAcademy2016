using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using DefiningClasses;

namespace StockApp.Utils
{
    public delegate void ElapsedEventHadler(object sender, EventArgs e);

    class RequestTimer
    {
        private event ElapsedEventHadler OnElapsed;

        // TODO: Not handled Exceptions
        public void StartWithCallback(int t, ElapsedEventHadler callback)
        {
            SimpleValidator.CheckNull(callback, "Handler Argument");
            OnElapsed = callback;

            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += (s, e) =>
            {
                while (true)
                {
                    Thread.Sleep(t);
                    this.OnTimedEvent();
                }
            };

            // bw.RunWorkerCompleted += (s, e) => { this.OnTimedEvent(); };

            bw.RunWorkerAsync();
        }

        private void OnTimedEvent()
        {
            if (this.OnElapsed != null)
            {
                this.OnElapsed(this, EventArgs.Empty);
            }
        }
    }
}
