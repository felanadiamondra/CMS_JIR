#pragma checksum "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48fa78409c5a18d7616614ab428c47124e933f93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ConsultMedecin_Index), @"mvc.1.0.view", @"/Views/ConsultMedecin/Index.cshtml")]
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
#line 1 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
using Oracle.ManagedDataAccess.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
using StageL2.Views.ConsultMedecin;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48fa78409c5a18d7616614ab428c47124e933f93", @"/Views/ConsultMedecin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fae29495dd02049f7d9426ea7b04bf919d0dc7b", @"/Views/_ViewImports.cshtml")]
    public class Views_ConsultMedecin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Home/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/ConsultMedecin/updateFreq"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
  
    ViewData["Title"] = "Index";
    var login = ViewBag.message;
    int i = 0;
    FonctionA a = new FonctionA();
    OracleDataReader listepat = a.GetFreqMed(login);

    FonctionA liste = new FonctionA();
    OracleDataReader drL = liste.ListeFreqT(login);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48fa78409c5a18d7616614ab428c47124e933f935650", async() => {
                WriteLiteral(@"
        <!-- Begin page -->
        <div id=""wrapper"">

            <!---------------------------------------------------------------------------------- TOP MENU ----------------------------------------------------------------------------------->
            <div class=""topbar"">
                <!-- LOGO -->
                <div class=""topbar-left"">
                    <div class=""text-center"">
                        <a href=""#"" class=""logo""><i class=""md md-terrain""></i> <span>CMS JIRAMA </span></a>
                    </div>
                </div>
                <!-- Button mobile view to collapse sidebar menu -->
                <div class=""navbar navbar-default"" role=""navigation"">
                    <div class=""container"">
                        <div");
                BeginWriteAttribute("class", " class=\"", 1154, "\"", 1162, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                            <div class=""pull-left"">
                                <button class=""button-menu-mobile open-left"">
                                    <i class=""fa fa-bars""></i>
                                </button>
                                <span class=""clearfix""></span>
                            </div>

                            <ul class=""nav navbar-nav navbar-right pull-right"">
                                <!--Full screen or not-->
                                <li class=""hidden-xs"">
                                    <a href=""#"" id=""btn-fullscreen"" class=""waves-effect waves-light""><i class=""md md-crop-free""></i></a>
                                </li>
                                <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48fa78409c5a18d7616614ab428c47124e933f937636", async() => {
                    WriteLiteral("<i class=\"md md-settings-power\"></i>");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"</li>
                                <!--User-->
                            </ul>
                        </div>
                        <!--/.nav-collapse -->
                    </div>
                </div>
            </div>
            <!----------------------------------------------------- MENU GAUCHE -------------------------------------------------->
            <!------------------------------------------------------- CONTENU ------------------------------------------------------->
            <br><br><br><br>

            <div class=""content"">
                <div class=""container"">
                    <!-- Page-Title -->
                    <div class=""text-xl-center"">
                        <div class=""col-sm-12"">
                            <h4 class=""pull-left page-title"">Liste des patients</h4>
                            <ol class=""breadcrumb pull-right"">
                                <li>");
#nullable restore
#line 63 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                               Write(System.DateTime.Today.ToLongDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                                <li>");
#nullable restore
#line 64 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                               Write(System.DateTime.Now.ToShortTimeString());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</li>
                            </ol>
                        </div>
                    </div>

                    <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""panel panel-default"">
                                <div class=""panel-body"">
                                    <div class=""row"">
                                        <div class=""row"">
                                            <div class=""col-md-12 col-sm-12 col-xs-12"">
                                                <table id=""datatable"" class=""table table-striped table-bordered"">
                                                    <thead>
                                                        <tr>
                                                            <th>Numero</th>
                                                            <th>Nom</th>
                                                            <th>Age</th>
                                             ");
                WriteLiteral(@"               <th>Prestation</th>
                                                            <th>Nat_Consult</th>
                                                            <th>Temp</th>
                                                            <th>Tamax</th>
                                                            <th>Tamin</th>
                                                            <th>Pullsation</th>
                                                            <th>Poids</th>
                                                            <th>Pc</th>
                                                            <th>Albumine</th>
                                                            <th>Glycemie</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
");
#nullable restore
#line 95 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                         while (listepat.Read())
                                                        {
                                                            i = i + 1;

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <tr class=\"gradeU\"");
                BeginWriteAttribute("onclick", " onclick=\"", 5279, "\"", 5303, 3);
                WriteAttributeValue("", 5289, "PatientMed(", 5289, 11, true);
#nullable restore
#line 98 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
WriteAttributeValue("", 5300, i, 5300, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 5302, ")", 5302, 1, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                                >\r\n                                                                <td>");
#nullable restore
#line 100 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(0));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 101 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(1));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 102 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(2));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 103 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(3));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 104 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(4));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 105 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(5));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 106 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(6));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 107 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(7));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 108 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(8));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 109 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(9));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 110 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(10));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 111 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(11));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td>");
#nullable restore
#line 112 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                               Write(listepat.GetOracleValue(12));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                            </tr>\r\n");
#nullable restore
#line 114 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div> <!-- end row table-->

                                    </div> <!-- end row-->
                                </div> <!-- end panel body-->
                            </div> <!-- end panel panel-default-->
                        </div> <!-- end col-->
                    </div> <!-- End Row -->
                </div> <!-- end container -->

                <div class=""container"">
                    <div class=""row"">
                        <div class=""col-md-3"">
                            <div class=""panel-body p-0"">
                                <div class=""list-group mail-list"">
                                    <a class=""list-group-item no-border active"">
                                        <div class=""row"">
                                            <div c");
                WriteLiteral(@"lass=""col-md-8"">
                                                <i class=""fa fa-stethoscope m-r-5""></i><b>Prestation :</b>
                                            </div>
                                            <div class=""col-md-4"">
                                                <input type=""text"" class=""form-control text-center"" id=""prest"" readonly/>
                                            </div>
                                        </div><div id=""prest""></div>
                                    </a>
                                    <a class=""list-group-item no-border"">
                                        <div class=""row"">
                                            <div class=""col-md-8"">
                                                <i class=""ion-arrow-right-b m-r-5""></i>Température :
                                            </div>
                                            <div class=""col-md-4""><input type=""text"" class=""form-control text-center"" id=""temp"" readonl");
                WriteLiteral(@"y/></div>
                                        </div>
                                    </a>
                                    <a class=""list-group-item no-border"">
                                        <div class=""row"">
                                            <div class=""col-md-6"">
                                                <i class=""ion-arrow-right-b m-r-5""></i>Tension min/max :
                                            </div>
                                            <div class=""col-md-3""><input type=""text"" class=""form-control text-center"" id=""tamin"" readonly/></div>
                                            <div class=""col-md-3""><input type=""text"" class=""form-control text-center"" id=""tamax"" readonly/></div>
                                        </div>
                                    </a>
                                    <a class=""list-group-item no-border"">
                                        <div class=""row"">
                                            <");
                WriteLiteral(@"div class=""col-md-8"">
                                                <i class=""ion-arrow-right-b m-r-5""></i>Pulsation :
                                            </div>
                                            <div class=""col-md-4""><input type=""text"" class=""form-control text-center"" id=""puls"" readonly/></div>
                                        </div>
                                    </a>
                                    <a class=""list-group-item no-border"">
                                        <div class=""row"">
                                            <div class=""col-md-6"">
                                                <i class=""ion-arrow-right-b m-r-5""></i>Poids / P.C(enfant) :
                                            </div>
                                            <div class=""col-md-3""><input type=""text"" class=""form-control text-center"" id=""poids"" readonly/></div>
                                            <div class=""col-md-3""><input type=""text"" class=""form-contr");
                WriteLiteral(@"ol text-center"" id=""pc"" readonly/></div>
                                        </div>
                                    </a>
                                    <a class=""list-group-item no-border"">
                                        <div class=""row"">
                                            <div class=""col-md-6"">
                                                <i class=""ion-arrow-right-b m-r-5""></i>Albumine / Glycémie :
                                            </div>
                                            <div class=""col-md-3""><input type=""text"" class=""form-control text-center"" id=""alb"" readonly/></div>
                                            <div class=""col-md-3""><input type=""text"" class=""form-control text-center"" id=""gly"" readonly/></div>
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-");
                WriteLiteral("md-9\">\r\n                            <div class=\"panel panel-default\">\r\n                                <div class=\"panel-body\">\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48fa78409c5a18d7616614ab428c47124e933f9323982", async() => {
                    WriteLiteral(@"
                                        <div class=""form-group "">
                                            <div class=""row"">
                                                <div class=""col-md-1"">
                                                    <label class=""control-label col-lg-2"">Numero :</label>
                                                </div>
                                                <div class=""col-md-1"">
                                                    <input type=""number"" class=""form-control"" name=""num"" id=""num"" readonly>
                                                </div>
                                                <div class=""col-md-2"">
                                                    <label class=""control-label col-lg-12"">Nature consultation :</label>
                                                </div>
                                                <div class=""col-md-2"">
                                                    <input type=""text"" class=""for");
                    WriteLiteral(@"m-control"" id=""nat"" readonly>
                                                </div>
                                                <div class=""col-md-1"">
                                                    <label class=""control-label col-lg-12"">Nom :</label>
                                                </div>
                                                <div class=""col-md-3"">
                                                    <input type=""text"" class=""form-control"" id=""nom"" placeholder=""Nom"" readonly>
                                                </div>
                                                <div class=""col-md-1"">
                                                    <label class=""control-label col-lg-12"">Age :</label>
                                                </div>
                                                <div class=""col-md-1"">
                                                    <input type=""text"" class=""form-control"" id=""age"" placeholder=""Age"" readonly>
         ");
                    WriteLiteral(@"                                       </div>
                                            </div>
                                        </div>

                                        <div class=""form-group"">
                                            <div class=""row"">
                                                <div class=""col-md-2"">
                                                    <label class=""control-label col-lg-12"">Jours de repos :</label>
                                                </div>
                                                <div class=""col-md-2"">
                                                    <input type=""number"" class=""form-control"" name=""Jrepos"">
                                                </div>
                                                <div class=""col-md-2"">
                                                    <label class=""control-label col-lg-12"">Rendez-vous :</label>
                                                </div>
                     ");
                    WriteLiteral(@"                           <div class=""col-md-3"">
                                                    <input type=""text"" class=""form-control"" name=""daterdz"" placeholder=""jj/mm/aaaa hh:mn"">
                                                </div>
                                            </div>
                                        </div>

                                        <div class=""form-group"">
                                            <label class=""control-label col-lg-2"">Observation :</label>
                                            <textarea class=""wysihtml5 form-control"" placeholder=""Observation"" name=""obs"" style=""height: 150px""></textarea>
                                        </div>

                                        <div class=""row"">
                                            <!--boutons-->
                                            <div class=""col-lg-12"">
                                                <div class=""btn-toolbar"" role=""toolbar"">
                   ");
                    WriteLiteral(@"                                 <div class=""pull-right"">
                                                        <button type=""button"" class=""btn btn-success waves-effect waves-light m-r-5"" data-toggle=""modal"" data-target=""#myModal"" title=""Voir la liste des patients traités""><i class=""fa fa-eye""></i></button>
                                                        <button type=""reset"" class=""btn btn-danger waves-effect waves-light m-r-5"" title=""Annuler""><i class=""fa fa-times""></i></button>
                                                        <button type=""submit"" class=""btn btn-purple waves-effect waves-light""> <span>Valider</span> <i class=""fa fa-send m-l-10""></i> </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>  <!-- fin boutons-->
                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </div> <!-- panel -body -->
                            </div> <!-- panel -->
                        </div> <!-- End Rightsidebar -->
                    </div>
                </div>
            </div>
        <br /><br /><br />
        <footer class=""footer text-right"">
            2019 © CMS Jirama.
        </footer>
        </div>

        <!-- Affiche liste des fréquentations traitées -->
        <div id=""myModal"" class=""modal fade"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true"">
            <div class=""modal-dialog"" style=""width:65%;"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
                        <h4 class=""modal-title"" id=""myModalLabel"">Liste des patients traités</h4>
                    </div>
                    <div class=""modal-body"">
                     ");
                WriteLiteral(@"   <table id=""datatable"" class=""table table-striped table-bordered"">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Numero</th>
                                    <th>Nom</th>
                                    <th>Age</th>
                                    <th>Prestation</th>
                                    <th>Rendez-vous</th>
                                    <th>Avis</th>
                                    <th>Jour Repos</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 292 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                 while (drL.Read())
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr class=\"gradeU\">\r\n                                        <td>");
#nullable restore
#line 295 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                       Write(drL.GetOracleValue(0));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 296 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                       Write(drL.GetOracleValue(1));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 297 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                       Write(drL.GetOracleValue(2));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 298 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                       Write(drL.GetOracleValue(3));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 299 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                       Write(drL.GetOracleValue(4));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 300 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                       Write(drL.GetOracleValue(5));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 301 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                       Write(drL.GetOracleValue(6));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 302 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                       Write(drL.GetOracleValue(7));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 304 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            </tbody>
                        </table>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-success waves-effect"" data-dismiss=""modal"">Fermer</button>
                    </div>
                </div><!-- /.modal-content -->
            </div><!-- /.modal-dialog -->
        </div><!-- /.modal -->
        <!--------------------------------------------------------------------------------------- FIN CONTENU ---------------------------------------------------------------------------------->
        <!--------------------------------------------------------------------------------------- SCRIPT JS ----------------------------------------------------------------------------------->
        <script>
            var resizefunc = [];
        </script>

    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n<!--Notification ajout-->\r\n");
#nullable restore
#line 324 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
 if (TempData["text"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n        alert(\'");
#nullable restore
#line 327 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
          Write(TempData["text"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    </script>\r\n");
#nullable restore
#line 329 "D:\stagiaire2020\StageL2\StageL2\Views\ConsultMedecin\Index.cshtml"
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