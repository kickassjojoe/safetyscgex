#pragma checksum "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionCategories\pv_Table.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ce1b22b8ca820adfa1babc28cab1bf63e45b5a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TruckInspectionCategories_pv_Table), @"mvc.1.0.view", @"/Views/TruckInspectionCategories/pv_Table.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ce1b22b8ca820adfa1babc28cab1bf63e45b5a5", @"/Views/TruckInspectionCategories/pv_Table.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad089ff6942dee7852c6438a678bc9b30921c910", @"/Views/_ViewImports.cshtml")]
    public class Views_TruckInspectionCategories_pv_Table : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<p class=""card-title lead text-center"">
    รายการตรวจหลัก
</p>
<div class=""table-responsive"">
    <table id=""datatable"" class=""table table-striped table-bordered table-sm table-hover"">
        <thead>
            <tr>
                <th>ลำดับ</th>
                <th>ชื่อรายการตรวจหลัก</th>
                <th>วันที่สร้างรายการตรวจ</th>
                <th>สร้างโดย</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 16 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionCategories\pv_Table.cshtml"
               int itemNo = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionCategories\pv_Table.cshtml"
             foreach (var item in ViewBag.Categories) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 19 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionCategories\pv_Table.cshtml"
                    Write(itemNo++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 20 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionCategories\pv_Table.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionCategories\pv_Table.cshtml"
                    Write($"{item.CreatedDate:dd/MM/yyyy}");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionCategories\pv_Table.cshtml"
                   Write(item.CreatedBy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a title=\"ลบข้อมูล\" class=\"btn btn-outline-danger px-2 py-1\"");
            BeginWriteAttribute("onclick", " onclick=\"", 884, "\"", 944, 4);
            WriteAttributeValue("", 894, "return", 894, 6, true);
            WriteAttributeValue(" ", 900, "deleteItem(", 901, 12, true);
#nullable restore
#line 24 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionCategories\pv_Table.cshtml"
WriteAttributeValue("", 912, item.TruckInspectionCategoryId, 912, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 943, ")", 943, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"far fa-trash-alt\" aria-hidden=\"true\"></i>\r\n                        </a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 28 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\TruckInspectionCategories\pv_Table.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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