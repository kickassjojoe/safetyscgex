#pragma checksum "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "443c5536ce88f59d36b90fe09bedf439bdf3568d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SubContacts__Table), @"mvc.1.0.view", @"/Views/SubContacts/_Table.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"443c5536ce88f59d36b90fe09bedf439bdf3568d", @"/Views/SubContacts/_Table.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad089ff6942dee7852c6438a678bc9b30921c910", @"/Views/_ViewImports.cshtml")]
    public class Views_SubContacts__Table : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SubContact>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
 if (ViewBag.Model != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table id=""datatable"" class=""table table-sm table-hover"">
        <thead>
            <tr>
                <th>ลำดับ</th>
                <th>ชื่อบริษัทขนส่ง</th>
                <th>ชื่อผู้ใช้งานระบบ</th>
                <th>ทะเบียน</th>
                <th>ภาค</th>
                <th>สาขา</th>
                <th>ยี่ห้อรถ</th>
                <th>ประเภทรถ</th>
                <th></th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 19 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
               int itemNo = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
             foreach (var item in ViewBag.Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
                Write(itemNo++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
               Write(item.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
               Write(item.PlateNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
               Write(item.Region.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
               Write(item.Branch.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
               Write(item.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
               Write(item.VehicleType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n");
#nullable restore
#line 31 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
                     if (item.IsApproved) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p class=\"text-info font-weight-bold p-0\">Approved</p>\r\n");
#nullable restore
#line 33 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
                    } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1188, "\"", 1236, 4);
            WriteAttributeValue("", 1198, "return", 1198, 6, true);
            WriteAttributeValue(" ", 1204, "fnApprove(\'", 1205, 12, true);
#nullable restore
#line 34 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
WriteAttributeValue("", 1216, item.SubContactId, 1216, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1234, "\')", 1234, 2, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                           class=\"btn btn-mdb-color btn-sm\">\r\n                            Approve\r\n                        </a>\r\n");
#nullable restore
#line 38 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1458, "\"", 1505, 4);
            WriteAttributeValue("", 1468, "return", 1468, 6, true);
            WriteAttributeValue(" ", 1474, "fnDelete(\'", 1475, 11, true);
#nullable restore
#line 41 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
WriteAttributeValue("", 1485, item.SubContactId, 1485, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1503, "\')", 1503, 2, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                       class=\"btn btn-danger btn-sm\">\r\n                        <i class=\"fas fa-trash\"></i>\r\n                        Delete\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 48 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 51 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\SubContacts\_Table.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SubContact>> Html { get; private set; }
    }
}
#pragma warning restore 1591
