#pragma checksum "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35177d791fa25da9d743f52ba44b9dee273e5bd2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TruckInspectionItems_pv_Table), @"mvc.1.0.view", @"/Views/TruckInspectionItems/pv_Table.cshtml")]
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
#line 1 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc.Models.ReportViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Mvc.Models.ManageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\_ViewImports.cshtml"
using VK1.SCGE.Safety.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35177d791fa25da9d743f52ba44b9dee273e5bd2", @"/Views/TruckInspectionItems/pv_Table.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad089ff6942dee7852c6438a678bc9b30921c910", @"/Views/_ViewImports.cshtml")]
    public class Views_TruckInspectionItems_pv_Table : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("แก้ไข"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success px-2 py-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<p class=""card-title lead text-center"">
    รายการตรวจย่อย
</p>
<table id=""datatable"" class=""table table-striped table-bordered table-sm table-hover"">
    <thead>
        <tr>
            <th>ลำดับ</th>
            <th>รายการตรวจย่อย</th>
            <th>ต้องตรวจ</th>
            <th>ตรวจวันที่1และ15</th>
            <th>รายการตรวจหลัก</th>
            <th></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 17 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
           int itemNo = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
         foreach (var item in ViewBag.CategoryItems) {
            var bold = item.IsMust ? "font-weight-bold" : "";

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
                Write(itemNo++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td");
            BeginWriteAttribute("class", " class=\"", 665, "\"", 690, 2);
            WriteAttributeValue("", 673, "text-nowrap", 673, 11, true);
#nullable restore
#line 22 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
WriteAttributeValue(" ", 684, bold, 685, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 22 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
                                         Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
                     if (item.IsMust) {

#line default
#line hidden
#nullable disable
            WriteLiteral("<i class=\"fas fa-check\"></i>");
#nullable restore
#line 23 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
                                                                   }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
                     if (item.IsFirstAndFifteenth) {

#line default
#line hidden
#nullable disable
            WriteLiteral("<i class=\"fas fa-check\"></i>");
#nullable restore
#line 24 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
                                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
               Write(item.TruckInspectionCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35177d791fa25da9d743f52ba44b9dee273e5bd28982", async() => {
                WriteLiteral("\r\n                        <i class=\"far fa-edit\" aria-hidden=\"true\"></i>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
                         WriteLiteral(item.TruckInspectionItemId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a title=\"ลบข้อมูล\" class=\"btn btn-outline-danger px-2 py-1\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1392, "\"", 1448, 4);
            WriteAttributeValue("", 1402, "return", 1402, 6, true);
            WriteAttributeValue(" ", 1408, "deleteItem(", 1409, 12, true);
#nullable restore
#line 35 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
WriteAttributeValue("", 1420, item.TruckInspectionItemId, 1420, 27, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1447, ")", 1447, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"far fa-trash-alt\" aria-hidden=\"true\"></i>\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 40 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionItems\pv_Table.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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