using System;
using System.Linq;

namespace StringCalculator {

    // From http://osherove.com/tdd-kata-1/
    public class StringCalculator {

		public int Add( string numbers ) {
			if ( string.IsNullOrWhiteSpace( numbers ) ) {
				return 0;
			}

            string[] delimiters = { ",", "\n" };

            if ( numbers.StartsWith( "//" ) ) {
                int endOfDeliminter = numbers.IndexOf( "\n" );
                delimiters = new string[] { numbers.Substring( 2, endOfDeliminter - 2 ) };
                numbers = numbers.Substring( endOfDeliminter + 1 );
            }

			int total = numbers
                            .Split( delimiters, StringSplitOptions.None )
                            .Select(x => int.Parse(x) )
                            .Sum();

			return total;
		}

    }
}
