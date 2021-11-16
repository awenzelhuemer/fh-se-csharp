namespace Delegates
{
    public class TestEvent
    {
        public delegate int MathOperationDelegate(int a, int b);


        public event MathOperationDelegate Test;
    }
}
