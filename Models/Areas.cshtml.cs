using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class AreasModel : PageModel  
    {  
        public List<Models.Areas> AreasList { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet()  
        {  
				  List<Models.Areas> areas = new List<Models.Areas>();
					
					// clear exception:
					EX = null;
					
					try
					{
						string sql = string.Format(@"
    SELECT Areas.Area, AreaName, Count(CID) as NumCrimes, ROUND(( CONVERT(float,(Count(CID))) / MAX(CID) * 100), 2) AS PercentCrime
	FROM Areas
	INNER JOIN Crimes ON Crimes.Area = Areas.Area
    WHERE Areas.Area <> 0
	GROUP BY Areas.Area, AreaName
	ORDER BY AreaName ASC;
	");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Areas m = new Models.Areas();
                         	m.Area = Convert.ToInt32(row["Area"]);   
                            m.AreaName = Convert.ToString(row["AreaName"]);                    
                         	m.NumCrimes = Convert.ToInt32(row["NumCrimes"]);                    
							m.PercentCrime = Convert.ToSingle(row["PercentCrime"]);

							areas.Add(m);
						}
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
            AreasList = areas;  
				  }
        }  
				
    }//class
}//namespace