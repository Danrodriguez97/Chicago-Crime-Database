#pragma checksum "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7f64e74fe391d651f2122eb0a98ab225d4d67c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(crimes.Pages.Views_CrimesTop10), @"mvc.1.0.razor-page", @"/Views/CrimesTop10.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Views/CrimesTop10.cshtml", typeof(crimes.Pages.Views_CrimesTop10), null)]
namespace crimes.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/codio/workspace/crimes/Views/_ViewImports.cshtml"
using crimes;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7f64e74fe391d651f2122eb0a98ab225d4d67c6", @"/Views/CrimesTop10.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f842f8255da31aa43ed40deaf7f18adbc89934f4", @"/Views/_ViewImports.cshtml")]
    public class Views_CrimesTop10 : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
  
  ViewData["Title"] = "Top-10 Crimes";

#line default
#line hidden
            BeginContext(74, 27, true);
            WriteLiteral("\n<h2>Top-10 Crimes</h2>  \n\n");
            EndContext();
#line 9 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
  
   if (@Model.EX != null)
	 {

#line default
#line hidden
            BeginContext(134, 37, true);
            WriteLiteral("\t   <br />\n\t\t <br />\n\t\t <h3>**ERROR: ");
            EndContext();
            BeginContext(172, 16, false);
#line 14 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
                 Write(Model.EX.Message);

#line default
#line hidden
            EndContext();
            BeginContext(188, 46, true);
            WriteLiteral("</h3>\n\t\t <br />\n\t\t <hr />\n\t\t <br />\n\t\t <br />\n");
            EndContext();
#line 19 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
	 }

#line default
#line hidden
            BeginContext(240, 559, true);
            WriteLiteral(@"
<table class=""table"">  
    <thead>  
        <tr>  
            <th>  
                Rank
            </th>  
            <th>  
                IUCR
            </th>  
            <th>  
                PrimaryDesc 
            </th>  
            <th>  
                SecondaryDesc 
            </th>  
            <th>  
                NumCrimes
            </th> 
            <th>  
                PercentCrime 
            </th>  
            <th>  
                ArrestPercent
            </th>  
        </tr>  
    </thead>  
    <tbody>  
");
            EndContext();
#line 49 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
                  
				   int rank = 1;
				 

#line default
#line hidden
            BeginContext(834, 5, true);
            WriteLiteral("\t\t\t\t\n");
            EndContext();
#line 53 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
         foreach (var item in Model.CrimesList)  
        {  

#line default
#line hidden
            BeginContext(901, 52, true);
            WriteLiteral("            <tr>  \n                <td>  \n\t\t\t\t\t\t\t\t\t\t");
            EndContext();
            BeginContext(954, 4, false);
#line 57 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
                                   Write(rank);

#line default
#line hidden
            EndContext();
            BeginContext(958, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1027, 9, false);
#line 60 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
               Write(item.IUCR);

#line default
#line hidden
            EndContext();
            BeginContext(1036, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1105, 16, false);
#line 63 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
               Write(item.PrimaryDesc);

#line default
#line hidden
            EndContext();
            BeginContext(1121, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1190, 18, false);
#line 66 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
               Write(item.SecondaryDesc);

#line default
#line hidden
            EndContext();
            BeginContext(1208, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1277, 14, false);
#line 69 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
               Write(item.NumCrimes);

#line default
#line hidden
            EndContext();
            BeginContext(1291, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1360, 17, false);
#line 72 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
               Write(item.PercentCrime);

#line default
#line hidden
            EndContext();
            BeginContext(1377, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1446, 18, false);
#line 75 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
               Write(item.ArrestPercent);

#line default
#line hidden
            EndContext();
            BeginContext(1464, 45, true);
            WriteLiteral("\n                </td>  \n            </tr>  \n");
            EndContext();
#line 78 "/home/codio/workspace/crimes/Views/CrimesTop10.cshtml"
						
						rank++;
        }  

#line default
#line hidden
            BeginContext(1542, 24, true);
            WriteLiteral("    </tbody>  \n</table> ");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CrimesTop10Model> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CrimesTop10Model> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CrimesTop10Model>)PageContext?.ViewData;
        public CrimesTop10Model Model => ViewData.Model;
    }
}
#pragma warning restore 1591
