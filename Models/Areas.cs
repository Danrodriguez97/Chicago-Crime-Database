//
// One crime
//

namespace crimes.Models
{

  public class Areas
	{
	
		// data members with auto-generated getters and setters:
        public int Area {get; set; }
		public string AreaName { get; set; }
		public int NumCrimes { get; set; }
        public float PercentCrime { get; set; }


		// default constructor:
		public Areas()
		{ }
		
		// constructor:
		public Areas(int area, string areaname, int numcrimes, float percentcrime)
		{
			Area = area;
            AreaName = areaname;
            NumCrimes = numcrimes;
            PercentCrime = percentcrime;
		}
		
	}//class

}//namespace