﻿using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace StringCalculator {
    [TestFixture]
    public class ParameterAttributeStringCalculatorTests {

        [Test]
        public void Add_NullOrBlankFromValues_ReturnsZero(
            [Values( null, "", " ", "\t", "\n" )] string input
        ) {
            StringCalculator calculator = new StringCalculator();

            int total = calculator.Add( input );

            Assert.AreEqual( 0, total );
        }

        private static string[] NullOrBlankCases = new string[] { null, "", " ", "\t", "\n" };

        [Test]
        public void Add_NullOrBlankFromSource_ReturnsZero(
            [ValueSource( "NullOrBlankCases" )] string input
        ) {
            StringCalculator calculator = new StringCalculator();

            int total = calculator.Add( input );

            Assert.AreEqual( 0, total );
        }

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
            // Limit the maximum random value to avoid overflows
            const int maxValue = (int.MaxValue - 1) / 2;

            Random r = new Random();
            yield return r.Next( maxValue );
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
        public void Add_RandomNumberBetweenZeroAndTen_ReturnsTheNumber(
            [Random( 0, 10, 1 )] int number
        ) {
            StringCalculator calculator = new StringCalculator();

            string numbers = number.ToString();
            int total = calculator.Add( numbers );

            Assert.AreEqual( number, total );
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
        public void Add_EvenNumbersBetweenTwoAndTen_ReturnsTheNumber(
            [Range( 2, 10, 2 )] int number
        ) {
            StringCalculator calculator = new StringCalculator();

            string numbers = number.ToString();
            int total = calculator.Add( numbers );

            Assert.AreEqual( number, total );
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
