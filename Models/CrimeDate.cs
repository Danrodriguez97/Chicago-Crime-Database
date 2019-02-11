//
// One crime
//

namespace crimes.Models
{

  public class CrimeDate
	{
	
		// data members with auto-generated getters and setters:
        public string Area {get; set; }
		public string AreaName { get; set; }
		public string IUCR { get; set; }
      	public string PrimaryDesc { get; set; }
		public string SecondaryDesc { get; set; }



		// default constructor:
		public CrimeDate()
		{ }
		
		// constructor:
		public CrimeDate(string area, string areaname, string iucr, string primary, string secondary)
		{
			Area = area;
            AreaName = areaname;
            IUCR = iucr;
            PrimaryDesc = primary;
            SecondaryDesc = secondary;
		}
		
	}//class

}//namespace