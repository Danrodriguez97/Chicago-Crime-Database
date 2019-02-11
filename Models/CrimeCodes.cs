//
// One crime
//

namespace crimes.Models
{

  public class CrimeCodes
	{
	
		// data members with auto-generated getters and setters:
        public string IUCR {get; set; }
		public string PrimaryDesc { get; set; }
		public string SecondaryDesc { get; set; }
		public int NumCrimes { get; set; }


		// default constructor:
		public CrimeCodes()
		{ }
		
		// constructor:
		public CrimeCodes(string iucr, string primary, string secondary, int numcrimes)
		{
			IUCR = iucr;
            PrimaryDesc = primary;
            SecondaryDesc = secondary;
            NumCrimes = numcrimes;
		}
		
	}//class

}//namespace