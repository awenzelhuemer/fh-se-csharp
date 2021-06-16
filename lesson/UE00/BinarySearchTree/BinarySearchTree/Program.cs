using System;
using System.Collections.Generic;

namespace Swe4.Collections.Test
{
    internal class Program
    {
        #region Private Methods

        private static void ComparerTest()
        {
            Console.WriteLine("== Comparator test ==");

            ICollection<int> numbers = new BinarySearchTree<int>(Greater) {
                5, 3, 7
            };

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }

        private static void EnumeratorTest()
        {
            Console.WriteLine("== Enumerator test ==");

            ICollection<int> numbers = new BinarySearchTree<int>() {
                5,
                3,
                7
            };

            var e = numbers.GetEnumerator();
            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }

            Console.WriteLine("---");

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }

        private static int Greater(int i1, int i2)
        {
            if (i1 < i2)
            {
                return 1;
            }
            else if (i1 > i2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private static void Main(string[] args)
        {
            SimpleTest();
            EnumeratorTest();
            ComparerTest();
        }

        private static void SimpleTest()
        {
            Console.WriteLine("== Simple test ==");

            ICollection<int> numbers = new BinarySearchTree<int>()
            {
                5,
                3,
                7
            };

            Console.WriteLine($"numbers.Contains(5)={numbers.Contains(5)}");
            Console.WriteLine($"numbers.Contains(3)={numbers.Contains(3)}");
            Console.WriteLine($"numbers.Contains(7)={numbers.Contains(7)}");
            Console.WriteLine($"numbers.Contains(9)={numbers.Contains(9)}");
        }

        #endregion
    }
}