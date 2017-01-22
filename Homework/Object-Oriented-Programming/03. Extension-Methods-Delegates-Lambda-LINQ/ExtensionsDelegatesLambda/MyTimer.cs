using System.Collections.Generic;
using System.Timers;
using Extensions;
using System;
using System.Threading;
using DefiningClasses;
using Timer = System.Timers.Timer;

namespace ExtensionsDelegatesLambda
{
    public delegate void PrintDelegate(IEnumerable<int> list);

    public delegate void ElapsedEventHadler(object sender, EventArgs e);

    class MyTimer
    {
        public PrintDelegate TimerCallback { get; set; }
        public IEnumerable<int> ListOfInts { get; set; }
        public event ElapsedEventHadler OnElapsed;

        public void Start(int t, IEnumerable<int> list, PrintDelegate printDel = null)
        {
            if (printDel == null)
            {
                throw new InvalidOperationException("No callback set for the Timer");
            }

            SimpleValidator.CheckNull(list, "Timer list Argument");

            TimerCallback = printDel;
            ListOfInts = list;

            Timer aTimer = new Timer();
            aTimer.Interval = t;
            aTimer.Elapsed += OnTimedDelegate;
            aTimer.AutoReset = true;
            aTimer.Start();
            Console.ReadLine();
        }

        public void StartWithEvent(int t, IEnumerable<int> list)
        {
            if (OnElapsed == null)
            {
                throw new InvalidOperationException("No callback set for the Timer");
            }

            SimpleValidator.CheckNull(list, "Timer list Argument");

            ListOfInts = list;

            while (true)
            {
                Thread.Sleep(t);
                this.OnTimedEvent();
            }
            
        }

        private void OnTimedDelegate(object source, ElapsedEventArgs e)
        {
            TimerCallback(ListOfInts);
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