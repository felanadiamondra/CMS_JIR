#pragma checksum "D:\stagiaire2020\StageL2\StageL2\Views\Frequentation\AfficherAgent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33277107c03bcc7d0b0a96e68d6fdd1abbad1562"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Frequentation_AfficherAgent), @"mvc.1.0.view", @"/Views/Frequentation/AfficherAgent.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\stagiaire2020\StageL2\StageL2\Views\_ViewImports.cshtml"
using StageL2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\stagiaire2020\StageL2\StageL2\Views\_ViewImports.cshtml"
using StageL2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\stagiaire2020\StageL2\StageL2\Views\Frequentation\AfficherAgent.cshtml"
using StageL2.Views.Frequentation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\stagiaire2020\StageL2\StageL2\Views\Frequentation\AfficherAgent.cshtml"
using Oracle.ManagedDataAccess.Client;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33277107c03bcc7d0b0a96e68d6fdd1abbad1562", @"/Views/Frequentation/AfficherAgent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fae29495dd02049f7d9426ea7b04bf919d0dc7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Frequentation_AfficherAgent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\stagiaire2020\StageL2\StageL2\Views\Frequentation\AfficherAgent.cshtml"
  
    ViewData["Title"] = "Afficher Agent";
    var agent = ViewBag.Message;
    FonctionFreq ag = new FonctionFreq();
    OracleDataReader sql = ag.GetAgent(agent);


#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\stagiaire2020\StageL2\StageL2\Views\Frequentation\AfficherAgent.cshtml"
 while (sql.Read())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p><b>Matricule :</b> ");
#nullable restore
#line 12 "D:\stagiaire2020\StageL2\StageL2\Views\Frequentation\AfficherAgent.cshtml"
                     Write(sql.GetOracleValue(0));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p><b>Nouveau matricule :</b> ");
#nullable restore
#line 13 "D:\stagiaire2020\StageL2\StageL2\Views\Frequentation\AfficherAgent.cshtml"
                             Write(sql.GetOracleValue(1));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n    <p><b>Nom :</b> ");
#nullable restore
#line 14 "D:\stagiaire2020\StageL2\StageL2\Views\Frequentation\AfficherAgent.cshtml"
               Write(sql.GetOracleValue(2));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n    <p><b>Statut :</b> ");
#nullable restore
#line 15 "D:\stagiaire2020\StageL2\StageL2\Views\Frequentation\AfficherAgent.cshtml"
                  Write(sql.GetOracleValue(3));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p><b>SA :</b> ");
#nullable restore
#line 16 "D:\stagiaire2020\StageL2\StageL2\Views\Frequentation\AfficherAgent.cshtml"
              Write(sql.GetOracleValue(4));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p class=\"text-center\"><i class=\"fa fa-circle\"></i> </p>\r\n");
#nullable restore
#line 18 "D:\stagiaire2020\StageL2\StageL2\Views\Frequentation\AfficherAgent.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591