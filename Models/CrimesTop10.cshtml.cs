using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimesTop10Model : PageModel  
    {  
        public List<Models.Crimes> CrimesList { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet()  
        {  
				  List<Models.Crimes> crimes = new List<Models.Crimes>();
					
					// clear exception:
					EX = null;
					
					try
					{
						string sql = string.Format(@"
    SELECT TOP 10 Codes.IUCR,  PrimaryDesc, SecondaryDesc,  Count(Crimes.IUCR) AS NumCrimes, ROUND(( CONVERT(float,(Count(Crimes.IUCR))) / MAX(CID) * 100), 2) AS PercentCrime,  ROUND((SUM(CONVERT(float, Arrested)) / Count(Crimes.IUCR) * 100.0), 2) AS ArrestPercent
	FROM Crimes
	INNER JOIN Codes ON Crimes.IUCR = Codes.IUCR
	GROUP BY Codes.IUCR, PrimaryDesc, SecondaryDesc
	ORDER BY NumCrimes DESC, IUCR ASC;
	");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Crimes m = new Models.Crimes();
                         	m.IUCR = Convert.ToString(row["IUCR"]);   
                            m.PrimaryDesc = Convert.ToString(row["PrimaryDesc"]);                    
                         	m.SecondaryDesc = Convert.ToString(row["SecondaryDesc"]);                    
							m.NumCrimes = Convert.ToInt32(row["NumCrimes"]);
							m.PercentCrime = Convert.ToSingle(row["PercentCrime"]);
							m.ArrestPercent = Convert.ToSingle(row["ArrestPercent"]);

							crimes.Add(m);
						}
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
            CrimesList = crimes;  
				  }
        }  
				
    }//class
}//namespace