//
// One crime
//

namespace crimes.Models
{

  public class Homicides
	{
	
		// data members with auto-generated getters and setters:
        public int Area {get; set; }
		public string AreaName { get; set; }
        public string PrimaryDesc {get; set; }
		public int NumHomicide { get; set; }
        public float PercentCrime { get; set; }


		// default constructor:
		public Homicides()
		{ }
		
		// constructor:
		public Homicides(int area, string areaname, string primary, int num, float percentcrime)
		{
			Area = area;
            AreaName = areaname;
            PrimaryDesc = primary;
            NumHomicide = num;
            PercentCrime = percentcrime;
		}
		
	}//class

}//namespace