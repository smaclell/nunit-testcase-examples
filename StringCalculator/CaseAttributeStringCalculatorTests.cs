using NUnit.Framework;

namespace StringCalculator {
	[TestFixture]
	public class CaseAttributeStringCalculatorTests {

		[TestCase( "", 0 )]
		[TestCase( "1", 1 )]
		[TestCase( "1,2", 3 )]
		[TestCase( "1,2,3,4", 10 )]
		[TestCase( "1\n2,3", 6 )]
		[TestCase( "//;\n1;2", 3 )]
		public void Add_SimpleInputs_AddsNumbers( string numbers, int expectedTotal ) {
			StringCalculator calculator = new StringCalculator();

			int total = calculator.Add( numbers );

			Assert.AreEqual( expectedTotal, total );
		}

	}
}
