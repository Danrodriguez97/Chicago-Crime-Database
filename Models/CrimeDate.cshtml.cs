using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimeDateModel : PageModel  
    {  
				public List<Models.CrimeDate> CrimeDateList { get; set; }
				public string Input { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  List<Models.CrimeDate> crimeDate = new List<Models.CrimeDate>();
					
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
							string sql;

							
                            
                            
								// lookup movie by movie id:
								sql = string.Format(@"
	SELECT Areas.Area, AreaName, Crimes.IUCR, PrimaryDesc, SecondaryDesc
	FROM Codes
	INNER JOIN Crimes ON Crimes.IUCR = Codes.IUCR
	INNER JOIN Areas ON Areas.Area = Crimes.Area
	WHERE cast(CrimeDate as date) = '{0}'
    GROUP BY Areas.Area, AreaName,Crimes.IUCR, PrimaryDesc, SecondaryDesc
	ORDER BY AreaName, PrimaryDesc, SecondaryDesc DESC

    ", input);     

							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

							foreach (DataRow row in ds.Tables["TABLE"].Rows)
							{
								Models.CrimeDate m = new Models.CrimeDate();
                                m.Area = Convert.ToString(row["Area"]);   
                                m.AreaName = Convert.ToString(row["AreaName"]);                    
                                m.IUCR = Convert.ToString(row["IUCR"]); 
                                m.PrimaryDesc = Convert.ToString(row["PrimaryDesc"]); 
                                m.SecondaryDesc = Convert.ToString(row["SecondaryDesc"]); 


							crimeDate.Add(m);
							}
						}//else
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
					  CrimeDateList = crimeDate;
				  }
				}
			
    }//class  
}//namespace

