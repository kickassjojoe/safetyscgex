#pragma checksum "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "896282b4c5ad7e6f36a879a1df7bbf9a1000b8d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CARApproves__AllCAR), @"mvc.1.0.view", @"/Views/CARApproves/_AllCAR.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"896282b4c5ad7e6f36a879a1df7bbf9a1000b8d0", @"/Views/CARApproves/_AllCAR.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad089ff6942dee7852c6438a678bc9b30921c910", @"/Views/_ViewImports.cshtml")]
    public class Views_CARApproves__AllCAR : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
 if (ViewBag.Model != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table id=""datatable"" class=""table table-sm table-hover"">
        <thead>
            <tr>
                <th>ลำดับ</th>
                <th>วันที่สร้างเอกสาร</th>
                <th>เลขที่ใบCAR</th>
                <th>สาขา</th>
                <th>ทะเบียนรถ</th>
                <th>Status</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 15 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
               int itemNo = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
             foreach (var item in ViewBag.Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 18 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
                    Write(itemNo++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 19 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
                    Write($"{item.Created:dd/MM/yyyy}");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 20 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
                   Write(item.CARCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
                   Write(item.BranchName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
                   Write(item.PlateNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
                   Write(item.CARStatusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 876, "\"", 919, 4);
            WriteAttributeValue("", 886, "return", 886, 6, true);
            WriteAttributeValue(" ", 892, "fnApprove(\'", 893, 12, true);
#nullable restore
#line 25 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
WriteAttributeValue("", 904, item.CARCode, 904, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 917, "\')", 917, 2, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                           class=\"btn btn-mdb-color btn-sm\">\r\n                            Approve\r\n                        </a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 31 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 34 "C:\Users\Admin\Git\Safety\VK1.SCGE.Safety.Mvc\Views\CARApproves\_AllCAR.cshtml"
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