#pragma checksum "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6926f84a0060156076d8fb7116edc36328674a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DistanceReports__TableMonthlyBranch), @"mvc.1.0.view", @"/Views/DistanceReports/_TableMonthlyBranch.cshtml")]
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
#line 1 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc.Models.ReportViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc.Models.ManageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6926f84a0060156076d8fb7116edc36328674a5", @"/Views/DistanceReports/_TableMonthlyBranch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad089ff6942dee7852c6438a678bc9b30921c910", @"/Views/_ViewImports.cshtml")]
    public class Views_DistanceReports__TableMonthlyBranch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExcecGetDistanceByBranchMonth", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "DistanceReports", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
 if (ViewBag.Count > 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"d-flex justify-content-between\">\r\n        <div class=\"d-flex flex-row\"><h5 class=\"mt-3\">รายงานเลขระยะทางรวม ปี ");
#nullable restore
#line 3 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
                                                                        Write(ViewBag.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - เดือน ");
#nullable restore
#line 3 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
                                                                                              Write(ViewBag.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5></div>\r\n        <div class=\"d-flex flex-row\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6926f84a0060156076d8fb7116edc36328674a56893", async() => {
                WriteLiteral("<i class=\"fas fa-file-excel\"></i> Excel");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-year", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 7 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
                   WriteLiteral(ViewBag.Year);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["year"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-year", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["year"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 8 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
                    WriteLiteral(ViewBag.M);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["month"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-month", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["month"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 9 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
                     WriteLiteral(ViewBag.Branch);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["branch"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-branch", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["branch"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 636, "\"", 654, 1);
#nullable restore
#line 13 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
WriteAttributeValue("", 644, ViewBag.C, 644, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""C""/>
    <table class=""table table-sm"">
        <thead class=""default-color white-text"">
            <tr class=""text-center"">
                <th class=""font-weight-bold"">ภาค</th>
                <th class=""font-weight-bold"">สาขา</th>
                <th class=""font-weight-bold"">ทะเบียน</th>
                <th class=""font-weight-bold"">ประเภทรถ</th>
                <th class=""font-weight-bold"">รวมระยะทางที่รถวิ่ง</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 25 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
             foreach (var item in ViewBag.MonthlyBranch) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"text-center\">\r\n                    <td>");
#nullable restore
#line 27 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
                   Write(item.RegionName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
                   Write(item.BranchCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 29 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
                   Write(item.PlateNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
                   Write(item.VehicleType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
                   Write(item.TotalOdometer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 33 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n        <tfoot>\r\n            <tr class=\"text-center\">\r\n                <td colspan=\"4\">รวม</td>\r\n                <td>");
#nullable restore
#line 38 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
               Write(ViewBag.GrandTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </tfoot>\r\n    </table>\r\n");
#nullable restore
#line 42 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\DistanceReports\_TableMonthlyBranch.cshtml"
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
