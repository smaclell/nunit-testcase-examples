using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace StringCalculator {
    [TestFixture]
    public class ParameterAttributeStringCalculatorTests {

        private static string[] TestNumbers() {
            return new string[] {
                "",
                "1",
                "1,2",
                "1,2,3,4",
                "1\n2,3",
                "//;\n1;2"
            };
        }

        private static int[] TestTotals() {
            return new int[] {
                0,
                1,
                3,
                10,
                6,
                3
            };
        }

        [Test, Sequential]
        public void Add_SimpleInputs_AddsNumbers(
            [ValueSource( "TestNumbers" )] string numbers,
            [ValueSource( "TestTotals" )] int expectedTotal
        ) {
            StringCalculator calculator = new StringCalculator();

            int total = calculator.Add( numbers );

            Assert.AreEqual( expectedTotal, total );
        }

        private static IEnumerable<int> AnyRandomNumber() {
            Random r = new Random();
            yield return r.Next();
        }

        [Test]
        public void Add_AnyRandomNumbers_AddsNumbers(
            [ValueSource( "AnyRandomNumber" )] int a,
            [ValueSource( "AnyRandomNumber" )] int b
        ) {
            StringCalculator calculator = new StringCalculator();

            string numbers = a + "," + b;
            int total = calculator.Add( numbers );

            Assert.AreEqual( a + b, total );
        }

        [Test]
        public void Add_RandomNumbers_AddsNumbers(
            [Random( 0, 10, 1 )] int a,
            [Random( 0, 10, 1 )] int b
        ) {
            StringCalculator calculator = new StringCalculator();

            string numbers = a + "," + b;
            int total = calculator.Add( numbers );

            Assert.AreEqual( a + b, total );
        }

        [Test]
        public void Add_AnyPairBetweenOneAndFive_AddsNumbers(
            [Values( 1, 2, 3, 4, 5 )] int a,
            [Values( 1, 2, 3, 4, 5 )] int b
        ) {
            StringCalculator calculator = new StringCalculator();

            string numbers = a + "," + b;
            int total = calculator.Add( numbers );

            Assert.AreEqual( a + b, total );
        }

        [Test]
        public void Add_RangeBetweenOneAndFive_AddsNumbers(
            [Range( 1, 5 )] int a,
            [Range( 1, 5 )] int b
        ) {
            StringCalculator calculator = new StringCalculator();

            string numbers = a + "," + b;
            int total = calculator.Add( numbers );

            Assert.AreEqual( a + b, total );
        }

    }
}
