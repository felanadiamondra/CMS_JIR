#pragma checksum "D:\stagiaire2020\StageL2\StageL2\Views\Prestation\AjouterPrest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ed4bbdc52a553a17690d06c4172a22fd58b9b25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Prestation_AjouterPrest), @"mvc.1.0.view", @"/Views/Prestation/AjouterPrest.cshtml")]
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
#line 1 "D:\stagiaire2020\StageL2\StageL2\Views\Prestation\AjouterPrest.cshtml"
using StageL2.Views.Prestation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\stagiaire2020\StageL2\StageL2\Views\Prestation\AjouterPrest.cshtml"
using Oracle.ManagedDataAccess.Client;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ed4bbdc52a553a17690d06c4172a22fd58b9b25", @"/Views/Prestation/AjouterPrest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fae29495dd02049f7d9426ea7b04bf919d0dc7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Prestation_AjouterPrest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "#", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Prestation/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cmxform form-horizontal tasi-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Prestation/AjoutPrest"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\stagiaire2020\StageL2\StageL2\Views\Prestation\AjouterPrest.cshtml"
  
    ViewData["Title"] = "Ajout Prestation";
    FonctionPrest Act = new FonctionPrest();
    OracleDataReader drAct = Act.ListeAct();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <div class=""container"">
            <div class=""col-sm-12"">
                <div class=""panel panel-default"">
                    <div class=""panel-heading"" id=""ajout""><h3 class=""panel-title"">Ajouter une nouvelle prestation</h3></div>
                    <div class=""panel-body"">
                        <div class="" form"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ed4bbdc52a553a17690d06c4172a22fd58b9b256222", async() => {
                WriteLiteral(@"
                                <div class=""form-group "">
                                    <label for=""code"" class=""control-label col-lg-2"" id=""prest"">Code</label>
                                    <div class=""col-lg-9"">
                                        <input class="" form-control"" id=""code"" name=""code"" type=""text""");
                BeginWriteAttribute("required", " required=\"", 1013, "\"", 1024, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                    </div>
                                </div>
                                <div class=""form-group "">
                                    <label for=""libelle"" class=""control-label col-lg-2"">Désignation</label>
                                    <div class=""col-lg-9"">
                                        <input class="" form-control"" id=""libelle"" name=""libelle"" type=""text""");
                BeginWriteAttribute("required", " required=\"", 1448, "\"", 1459, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                    </div>
                                </div>
                                <div class=""form-group "">
                                    <label class=""control-label col-lg-2"">Activité</label>
                                    <div class=""col-lg-9"">
                                        <select class=""form-control"" name=""act""");
                BeginWriteAttribute("required", " required=\"", 1837, "\"", 1848, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ed4bbdc52a553a17690d06c4172a22fd58b9b258185", async() => {
                    WriteLiteral("Code activité - Libellé");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 33 "D:\stagiaire2020\StageL2\StageL2\Views\Prestation\AjouterPrest.cshtml"
                                             while (drAct.Read())
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ed4bbdc52a553a17690d06c4172a22fd58b9b259773", async() => {
#nullable restore
#line 35 "D:\stagiaire2020\StageL2\StageL2\Views\Prestation\AjouterPrest.cshtml"
                                                                                    Write(drAct.GetOracleValue(0));

#line default
#line hidden
#nullable disable
                    WriteLiteral(" - ");
#nullable restore
#line 35 "D:\stagiaire2020\StageL2\StageL2\Views\Prestation\AjouterPrest.cshtml"
                                                                                                               Write(drAct.GetOracleValue(1));

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "D:\stagiaire2020\StageL2\StageL2\Views\Prestation\AjouterPrest.cshtml"
                                                   WriteLiteral(drAct.GetOracleValue(0));

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 36 "D:\stagiaire2020\StageL2\StageL2\Views\Prestation\AjouterPrest.cshtml"
                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                        </select>
                                    </div>
                                </div>
                                <div class=""form-group "">
                                    <label class=""control-label col-lg-2"">Prix interne</label>
                                    <div class=""col-lg-9"">
                                        <input class=""form-control "" name=""puInt"" type=""text"">
                                    </div>
                                </div>
                                <div class=""form-group "">
                                    <label class=""control-label col-lg-2"">Prix externe</label>
                                    <div class=""col-lg-9"">
                                        <input class=""form-control "" name=""puExt"" type=""text"">
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div ");
                WriteLiteral("class=\"col-lg-offset-2 col-lg-10\">\r\n                                        <input type=\"submit\" value=\"Enregistrer\" class=\"btn btn-success \">\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ed4bbdc52a553a17690d06c4172a22fd58b9b2513562", async() => {
                    WriteLiteral("<input type=\"button\" value=\"Annuler\" class=\"btn btn-default waves-effect waves-lignt\">");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div> <!-- form -->\r\n                    </div> <!-- panel-body -->\r\n                </div> <!-- panel -->\r\n            </div> <!-- col -->\r\n        </div><!-- container AJOUT -->\r\n");
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
