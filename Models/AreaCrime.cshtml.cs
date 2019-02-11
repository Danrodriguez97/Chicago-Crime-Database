using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class AreaCrimeModel : PageModel  
    {  
				public List<Models.Crimes> CrimesList { get; set; }
				public string Input { get; set; }
          //      public int NumCrimes { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  List<Models.Crimes> crimes = new List<Models.Crimes>();
					
					// make input available to web page:
					Input = input;
					
					// clear exception:
					EX = null;
					
					try
					{
						//
						// Do we have an input argument?  If so, we do a lookup:
						//
						if (input == null)
						{
							//
							// there's no page argument, perhaps user surfed to the page directly?  
							// In this case, nothing to do.
							//

                        }
						else  
						{
							// 
							// Lookup movie(s) based on input, which could be id or a partial name:
							// 
							int id;
							string sql;

							if (System.Int32.TryParse(input, out id))
							{
                            
                            
								// lookup movie by movie id:
								sql = string.Format(@"
	DECLARE @total AS FLOAT;

    SET @total = (SELECT COUNT(Crimes.IUCR) FROM Crimes WHERE Area = {0});

    SELECT TOP 10  Codes.IUCR,  PrimaryDesc, SecondaryDesc,   Count(Crimes.IUCR) AS NumCrimes, ROUND( ( (Count(Crimes.IUCR) ) / @total ) * 100 , 2) AS PercentCrime,  ROUND((SUM(CONVERT(float, Arrested)) / Count(Crimes.IUCR) * 100.0), 2) AS ArrestPercent
	FROM Crimes
	INNER JOIN Codes ON Crimes.IUCR = Codes.IUCR
	INNER JOIN Areas ON Crimes.Area = Areas.Area
    WHERE  Areas.Area = {0}
	GROUP BY Codes.IUCR, PrimaryDesc, SecondaryDesc
	ORDER BY NumCrimes DESC;
	", id);
							}
							else
							{
								// lookup movie(s) by partial name match:
								input = input.Replace("'", "''");

								sql = string.Format(@"
	DECLARE @total AS FLOAT;

    SET @total = (SELECT COUNT(Crimes.IUCR) FROM Crimes INNER JOIN Areas ON Crimes.Area = Areas.Area WHERE AreaName = '{0}');

    SELECT TOP 10  Codes.IUCR,  PrimaryDesc, SecondaryDesc,   Count(Crimes.IUCR) AS NumCrimes, ROUND( ( (Count(Crimes.IUCR) ) / @total ) * 100 , 2) AS PercentCrime,  ROUND((SUM(CONVERT(float, Arrested)) / Count(Crimes.IUCR) * 100.0), 2) AS ArrestPercent
	FROM Crimes
	INNER JOIN Codes ON Crimes.IUCR = Codes.IUCR
	INNER JOIN Areas ON Crimes.Area = Areas.Area
    WHERE  AreaName = '{0}'
	GROUP BY Codes.IUCR, PrimaryDesc, SecondaryDesc
	ORDER BY NumCrimes DESC;
	", input);
							}
                            
                            
                               
                            

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
						}//else
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
					  CrimesList = crimes;
                    //  NumCrimes = crimes.Count;
				  }
				}
			
    }//class  
}//namespace


