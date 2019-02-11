//
// One crime
//

namespace crimes.Models
{

  public class Crimes
	{
	
		// data members with auto-generated getters and setters:
        public string IUCR {get; set; }
		public string PrimaryDesc { get; set; }
		public string SecondaryDesc { get; set; }
		public int NumCrimes { get; set; }
        public float PercentCrime { get; set; }
      	public float ArrestPercent { get; set; }


		// default constructor:
		public Crimes()
		{ }
		
		// constructor:
		public Crimes(string iucr, string primary, string secondary, int numcrimes, float percentcrime, float arrestpercent)
		{
			IUCR = iucr;
            PrimaryDesc = primary;
            SecondaryDesc = secondary;
            NumCrimes = numcrimes;
            PercentCrime = percentcrime;
            ArrestPercent = arrestpercent;
		}
		
	}//class

}//namespace