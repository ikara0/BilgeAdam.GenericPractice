using BilgeAdam.GenericPractice;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Test
{
    [TestFixture]
    internal class SwapTestFixture
    {
        [Test]
        public void Can_Swap_Two_Variable()
        {

            int a = 5;
            int b = 10;

            Assert.AreEqual(5, a);
            Assert.AreEqual(10, b);

            Program.Swap<int>(ref a, ref b);

            Assert.AreEqual(10, a);
            Assert.AreEqual(5, b);

        }
        [TestCase(5,10)]
        public void Can_Swap_Two_Variable(int a, int b)
        {
            Program.Swap<int>(ref a,ref b);

            Assert.AreEqual(10, a);
            Assert.AreEqual(5, b);

        }

        [TestCase('a','b')]
        public void Can_Swap_Two_Chars(char a,char b)
        {
            Program.Swap<char>(ref a,ref b);
            Assert.AreEqual('b', b);

        }


    }
}
