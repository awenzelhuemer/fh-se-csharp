using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class TimerClient
    {
        static void TimerExpired(DateTime expiredTime) {
            Console.WriteLine($"Timer expired: {expiredTime}");
        }

        static void Timer2Expired(DateTime expiredTime)
        {
            Console.WriteLine($"Timer2 expired: {expiredTime}");
        }


        public static void Test()
        {
            var timer = new Timer
            {
                Interval = 500
            };
            timer.Start();
            timer.Expired += TimerExpired;
            timer.Expired += Timer2Expired;
            timer.Expired += GeneratedTimerHandler;

            timer.Expired += delegate (DateTime expired)
            {
                Console.WriteLine("Anonymous method");
            };

            timer.Expired += expired =>
            {
                Console.WriteLine("Lambda expression");
            };

            //timer.Expired?.Invoke(new DateTime(1900, 1, 1));
        }

        private static void GeneratedTimerHandler(DateTime expiredTime)
        {
            Console.WriteLine(nameof(GeneratedTimerHandler));
        }
    }
}
