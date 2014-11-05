public class MatchObject
{
		private static MatchObject _matchSingleton {
				get;
				set;
		}

		public static MatchObject MatchSingleton {
				get {
						return _matchSingleton ?? (_matchSingleton = new MatchObject ());
				}
		}

		private const int STARTING_NUMBER_MATCHES = 10;
		private const int MAXIMUM_BRIGHTNESS = 1000;
		// Rate of match brightness decrease per frame
		private const int MATCH_BRIGHTNESS_DECREASE_RATE = 5;

		private MatchObject(){
			NumberOfMatches = STARTING_NUMBER_MATCHES;
		}

		public bool IsLit {
				get {
						if (MatchBrightness > 0)
								return true;
						else
								return false;
				}
		}
	
		public int MatchBrightness {
				get;
				set;
		}

		public int NumberOfMatches {
				get;
				set;
		}

		public int IncreaseMatches (int increase)
		{
				NumberOfMatches += increase;
				if (NumberOfMatches < 0)
						NumberOfMatches = 0;
				return NumberOfMatches;
		}

		public void DecreaseMatchBrightness ()
		{
				MatchBrightness -= MATCH_BRIGHTNESS_DECREASE_RATE;
				if (MatchBrightness <= 0)
						NumberOfMatches--;
		}

		public bool LightNewMatch ()
		{
				if (NumberOfMatches == 0 || MatchBrightness >= MAXIMUM_BRIGHTNESS/2)
						return false;
				NumberOfMatches--;
				MatchBrightness = MAXIMUM_BRIGHTNESS;
				return true;
		}

}
