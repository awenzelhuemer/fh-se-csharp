using System;
using System.Threading;

namespace Delegates
{
    public class Timer
    {
        #region Private Fields

        private const int DEFAULT_INTERVAL = 1000;
        private readonly Thread ticker;

        #endregion

        #region Public Fields

        public event ExpiredEventHandler Expired;

        #endregion

        #region Public Constructors

        public Timer()
        {
            ticker = new Thread(OnTick);
        }

        #endregion

        #region Public Delegates

        public delegate void ExpiredEventHandler(DateTime expiredTime);

        #endregion

        #region Public Properties

        public int Interval { get; set; } = DEFAULT_INTERVAL;

        #endregion

        #region Private Methods

        private void OnTick()
        {
            while (true)
            {
                Thread.Sleep(Interval);
                Expired?.Invoke(DateTime.Now);
                //Console.WriteLine("Timer ellapsed");
            }
        }

        #endregion

        #region Public Methods

        public void Start() => ticker.Start();

        #endregion
    }
}