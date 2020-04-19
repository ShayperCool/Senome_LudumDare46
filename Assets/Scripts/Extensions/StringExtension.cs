using System.Linq;

namespace Extensions {
	public static class StringExtension {
		//!!!DONT USE IT WITH BIG COLLECTIONS OF CARDS!!!
		public static int SumOfChars(this string value) {
			return value.Aggregate(0, (current, letter) => current + letter);
		}
		
	}
}