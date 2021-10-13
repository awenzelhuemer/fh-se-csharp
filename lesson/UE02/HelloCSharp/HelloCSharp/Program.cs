using System;

namespace HelloCSharp
{
    internal class Program
    {
        #region Public Constructors

        public Program()
        {
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This is my first function
        /// </summary>
        /// <returns></returns>
        private static int Func()
        {
            return 17;
        }

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Command line args</param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Func();
        }

        #endregion
    }
}