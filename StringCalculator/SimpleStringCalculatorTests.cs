using NUnit.Framework;

namespace StringCalculator {

    public class SimpleStringCalculatorTests {

        [Test]
        public void Add_EmptyString_ReturnsZero() {
            StringCalculator calculator = new StringCalculator();

            int total = calculator.Add("");

            Assert.AreEqual(0, total);
        }

        [Test]
        public void Add_SingleNumber_ReturnsTheNumber() {
            StringCalculator calculator = new StringCalculator();

            int total = calculator.Add("1");

            Assert.AreEqual(1, total);
        }
    }
}
