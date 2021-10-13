using System;
using System.Collections.Generic;
using HashDictionary.Impl;
using Xunit;
using static Xunit.Assert;

namespace HashDictionary.Test
{
    public class HashDictionaryTests
    {
        #region Public Methods

        [Fact]
        public void AddAndIndexerGetterAreConsistent()
        {
            IDictionary<int, int> dict = new HashDictionary<int, int>();
            dict.Add(1, 10);
            Equal(10, dict[1]);

            dict.Add(2, 20);
            Equal(10, dict[1]);
            Equal(20, dict[2]);

            dict.Add(3, 30);
            Equal(10, dict[1]);
            Equal(20, dict[2]);
            Equal(30, dict[3]);
        }

        [Fact]
        public void ArgumentException_WhenItemAddedTwice()
        {
            IDictionary<int, int> dict = new HashDictionary<int, int>
            {
                { 1, 10 },
                { 2, 20 }
            };

            Throws<ArgumentException>(() => dict.Add(2, 40));
        }

        [Theory]
        [InlineData(new [] { 10 }, 1)]
        [InlineData(new[] { 10, 30, 40 }, 3)]
        [InlineData(new[] { 10, -5 }, 2)]
        public void CountPropertyIsOk_WhenAddingItems(IEnumerable<int> list, int expected)
        {
            IDictionary<int, int> dict = new HashDictionary<int, int>();
            int i = 0;
            foreach (var item in list)
            {
                dict.Add(i++, item);
            }

            Equal(expected, dict.Count);
        }

        #endregion
    }
}