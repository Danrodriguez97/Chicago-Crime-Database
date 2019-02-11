using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class HomicidesModel : PageModel  
    {  
        public List<Models.Homicides> HomicidesList { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet()  
        {  
				  List<Models.Homicides> homicides = new List<Models.Homicides>();
					
					// clear exception:
					EX = null;
					
					try
					{
						string sql = string.Format(@"
    DECLARE @total AS FLOAT;

    SET @total = (SELECT COUNT(PrimaryDesc) FROM Codes INNER JOIN Crimes ON Crimes.IUCR = Codes.IUCR INNER JOIN Areas ON Areas.Area = Crimes.Area 
 WHERE (PrimaryDesc = 'Homicide' AND Areas.Area <> 0) AND ((Month(CrimeDate) = 6 OR Month(CrimeDate) = 7 OR Month(CrimeDate) = 8)));
    
    SELECT Areas.Area, AreaName, PrimaryDesc, Count(PrimaryDesc) AS NumHomicide, ROUND( ( (Count(PrimaryDesc) ) / @total ) * 100 , 2) AS PercentCrime
	FROM Codes
	INNER JOIN Crimes ON Crimes.IUCR = Codes.IUCR
	INNER JOIN Areas ON Areas.Area = Crimes.Area
	WHERE (PrimaryDesc = 'Homicide' AND Areas.Area <> 0)
	AND (Month(CrimeDate) = 6 OR Month(CrimeDate) = 7 OR Month(CrimeDate) = 8)
    GROUP BY Areas.Area, AreaName, PrimaryDesc
	ORDER BY NumHomicide DESC
	");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Homicides m = new Models.Homicides();
                         	m.Area = Convert.ToInt32(row["Area"]);   
                            m.AreaName = Convert.ToString(row["AreaName"]);
                            m.PrimaryDesc = Convert.ToString(row["PrimaryDesc"]);                    
							m.NumHomicide = Convert.ToInt32(row["NumHomicide"]);
							m.PercentCrime = Convert.ToSingle(row["PercentCrime"]);

							homicides.Add(m);
						}
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
            HomicidesList = homicides;  
				  }
        }  
				
    }//class
}//namespace