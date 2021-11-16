using System;

namespace Delegates
{
    class Program
    {
        delegate int MathOperationDelegate(int a, int b);


        private static event MathOperationDelegate Test;

        static int Add(int a, int b) => a + b;

        static int Multiply(int a, int b) => a * b;

        static void Main(string[] args)
        {
            TestEvent xx = new TestEvent();
            xx.Test += (x,y) => (x + y);

            Console.WriteLine(Test?.Invoke(5, 3));

            Func<int, int, int> dd = Add;
            MathOperationDelegate d = Add;
            d += Multiply;
            Console.WriteLine(d?.Invoke(3, 5));

        }
    }
}
