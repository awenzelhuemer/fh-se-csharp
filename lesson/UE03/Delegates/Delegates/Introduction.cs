using System;

namespace Delegates
{
    class Introduction
    {
        #region Private Delegates

        private delegate void Procedure();

        private delegate int StringToIntFunction(string value);

        #endregion

        #region Private Methods

        private static void SayHello() => Console.WriteLine("Hello World");

        private static void SayHelloAgain() => Console.WriteLine("Hello again");

        #endregion

        #region Public Methods

        public static void Test()
        {
            //Procedure p = new(SayHello);
            Procedure p = SayHello;
            //p();
            p?.Invoke();

            StringToIntFunction f1 = int.Parse;
            Console.WriteLine(f1?.Invoke("1234"));

            Func<string, int> f2 = int.Parse;
            Console.WriteLine(f1?.Invoke("1234"));

            Action a1 = SayHello;
            a1 += SayHelloAgain;
            a1?.Invoke();
        }

        #endregion
    }
}