#pragma checksum "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55d1d5d7a0e06a20184258604ae57d4d166fcce2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CARApproves__Table), @"mvc.1.0.view", @"/Views/CARApproves/_Table.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55d1d5d7a0e06a20184258604ae57d4d166fcce2", @"/Views/CARApproves/_Table.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad089ff6942dee7852c6438a678bc9b30921c910", @"/Views/_ViewImports.cshtml")]
    public class Views_CARApproves__Table : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CorrectiveActionRequestItem>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ApproveCAR", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CARApproves", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
 if (Model != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 123, "\"", 145, 1);
#nullable restore
#line 6 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
WriteAttributeValue("", 131, ViewBag.Count, 131, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"count\" />\r\n");
#nullable restore
#line 7 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
     if (Model.Count() > 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55d1d5d7a0e06a20184258604ae57d4d166fcce27725", async() => {
                WriteLiteral("\r\n            <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 255, "\"", 279, 1);
#nullable restore
#line 9 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
WriteAttributeValue("", 263, ViewBag.CARCode, 263, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" name=""carcode"" />
            <table class=""table table-sm"">
                <thead>
                    <tr>
                        <th>ลำดับ</th>
                        <th>สาขา</th>
                        <th>ประเภทรถ</th>
                        <th>ทะเบียน</th>
                        <th>ความผิดปกติ</th>
                        <th>หัวข้อหลัก</th>
                        <th>วันที่ตรวจพบ</th>
                        <th>แก้ไข</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 24 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
                       int itemNo = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
                     foreach (var item in Model) {
                        var isDisable = item.IsFixed ? "disabled" : "";

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 28 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
                            Write(itemNo++);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 29 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
                           Write(item.CorrectiveActionRequest.BranchName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 30 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
                           Write(item.CorrectiveActionRequest.VehicleType);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 31 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
                           Write(item.CorrectiveActionRequest.PlateNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 32 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
                           Write(item.TruckInspectionItemName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 33 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
                           Write(item.TruckInspectionCategory.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 34 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
                            Write($"{item.IssuedDate:dd/MM/yyyy}");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>
                            <td scope=""row"" class=""p-1"">
                                <!-- Material unchecked -->
                                <div class=""form-check p-0"">
                                    <input type=""checkbox"" class=""form-check-input p-0""");
                BeginWriteAttribute("id", " id=\"", 1782, "\"", 1802, 1);
#nullable restore
#line 38 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
WriteAttributeValue("", 1787, item.CARItemId, 1787, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1803, "\"", 1826, 1);
#nullable restore
#line 38 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
WriteAttributeValue("", 1811, item.CARItemId, 1811, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"chk\" ");
#nullable restore
#line 38 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
                                                                                                                                           Write(isDisable);

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                                    <label class=\"form-check-label\"");
                BeginWriteAttribute("for", " for=\"", 1919, "\"", 1940, 1);
#nullable restore
#line 39 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
WriteAttributeValue("", 1925, item.CARItemId, 1925, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></label>\r\n                                </div>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 43 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </tbody>
                <tfoot>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td class=""text-right"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55d1d5d7a0e06a20184258604ae57d4d166fcce214476", async() => {
                    WriteLiteral("\r\n                                Approve\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
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
                        </td>
                        <td class=""text-left"">
                            <button type=""button"" class=""btn btn-outline-danger waves-effect"" data-dismiss=""modal"">Close</button>
                        </td>
                        <td></td>
                    </tr>
                </tfoot>

            </table>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 69 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_Table.cshtml"
     
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CorrectiveActionRequestItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591