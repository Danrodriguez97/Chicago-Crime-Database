using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimesCodesModel : PageModel  
    {  
        public List<Models.CrimeCodes> CrimeCodesList { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet()  
        {  
				  List<Models.CrimeCodes> crimecodes = new List<Models.CrimeCodes>();
					
					// clear exception:
					EX = null;
					
					try
					{
						string sql = string.Format(@"
    SELECT Codes.IUCR, PrimaryDesc, SecondaryDesc, COUNT(Crimes.IUCR) as NumCrimes
	FROM Codes
	FULL OUTER JOIN Crimes ON Crimes.IUCR = Codes.IUCR
    GROUP BY Codes.IUCR, PrimaryDesc, SecondaryDesc
	ORDER BY PrimaryDesc ASC, SecondaryDesc ASC;
	");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.CrimeCodes m = new Models.CrimeCodes();
                         	m.IUCR = Convert.ToString(row["IUCR"]);   
                            m.PrimaryDesc = Convert.ToString(row["PrimaryDesc"]);                    
                         	m.SecondaryDesc = Convert.ToString(row["SecondaryDesc"]);                    
							m.NumCrimes = Convert.ToInt32(row["NumCrimes"]);

							crimecodes.Add(m);
						}
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
            CrimeCodesList = crimecodes;  
				  }
        }  
				
    }//class
}//namespace