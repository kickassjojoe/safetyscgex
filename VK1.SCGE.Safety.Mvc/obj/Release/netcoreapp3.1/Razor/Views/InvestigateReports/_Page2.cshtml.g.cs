#pragma checksum "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\InvestigateReports\_Page2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d12e4fcfe0fa2badb976d2106f3ffa6f217bcedb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_InvestigateReports__Page2), @"mvc.1.0.view", @"/Views/InvestigateReports/_Page2.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d12e4fcfe0fa2badb976d2106f3ffa6f217bcedb", @"/Views/InvestigateReports/_Page2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad089ff6942dee7852c6438a678bc9b30921c910", @"/Views/_ViewImports.cshtml")]
    public class Views_InvestigateReports__Page2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InvestigateCard>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div style=""height:25px"">
    <div style=""width:45%;text-align:left;float:left"">
        <span style=""font-size:14px"">รายงานการสอบสวนอุบัติเหตุ</span>
    </div>
    <div style=""width:55%;text-align:left;float:right"">
        <span style=""font-size:15px;font-family:Tahoma"">Accident Report </span>
    </div>
</div>
<div style=""width:100%;text-align:left"">
    <span style=""font-size:14px"">บริษัท เอสซีจี ยามาโต๊ะ เอ็กซ์เพรส จำกัด</span>
</div>
<div style=""height:15px;border:solid #000 1px;text-align:center"">
    <span style=""font-size:14px"">ส่วนที่ 3 ข้อมูลการเกิดอุบัติเหตุ</span>
</div>
<table cellpadding=""0"" cellspacing=""0"" style=""width:100%"">
    <tr>
        <td style=""border-left:solid #000 1px;
                   border-right:solid #000 1px;
                   border-bottom:solid #000 1px;
                   width:50%;height:180px;"">

            <div style=""word-break:break-all; overflow: hidden;font-size:13px;font-family:Tahoma;text-align:left;"">
                ");
#nullable restore
#line 24 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\InvestigateReports\_Page2.cshtml"
           Write(Model.PartThree.BeforeIncidentDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>

        </td>
        <td style=""border-right:solid #000 1px;
                   border-bottom:solid #000 1px;
                   width:50%;height:180px"">
            <div style=""word-break:break-all; overflow: hidden;font-size:13px;font-family:Tahoma;text-align:left;padding:2px"">
                <img");
            BeginWriteAttribute("src", " src=\"", 1401, "\"", 1426, 1);
#nullable restore
#line 32 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\InvestigateReports\_Page2.cshtml"
WriteAttributeValue("", 1407, ViewData["Image1"], 1407, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" width=""340"" height=""180"" />
            </div>
        </td>
    </tr>
    <tr>
        <td style=""border-left:solid #000 1px;
                   border-right:solid #000 1px;
                   border-bottom:solid #000 1px;
                   width:50%;height:180px;"">

            <div style=""word-break:break-all; overflow: hidden;font-size:13px;font-family:Tahoma;text-align:left"">
                ");
#nullable restore
#line 43 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\InvestigateReports\_Page2.cshtml"
           Write(Model.PartThree.IncidentDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </td>
        <td style=""border-right:solid #000 1px;
                   border-bottom:solid #000 1px;
                   width:50%;height:180px"">
            <div style=""word-break:break-all; overflow: hidden;font-size:13px;font-family:Tahoma;text-align:left;padding:2px"">
                <img");
            BeginWriteAttribute("src", " src=\"", 2205, "\"", 2230, 1);
#nullable restore
#line 50 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\InvestigateReports\_Page2.cshtml"
WriteAttributeValue("", 2211, ViewData["Image2"], 2211, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" width=""340"" height=""180"" />
            </div>
        </td>
    </tr>
    <tr>
        <td style=""border-left:solid #000 1px;
                   border-right:solid #000 1px;
                   border-bottom:solid #000 1px;
                   width:50%;height:180px;"">
            <div style=""word-break:break-all; overflow: hidden;font-size:13px;font-family:Tahoma;text-align:left"">
                ");
#nullable restore
#line 60 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\InvestigateReports\_Page2.cshtml"
           Write(Model.PartThree.AfterIncidentDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </td>
        <td style=""border-right:solid #000 1px;
                   border-bottom:solid #000 1px;
                   width:50%;height:180px"">
            <div style=""word-break:break-all; overflow: hidden;font-size:13px;font-family:Tahoma;text-align:left;padding:2px"">
                <img");
            BeginWriteAttribute("src", " src=\"", 3012, "\"", 3037, 1);
#nullable restore
#line 67 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\InvestigateReports\_Page2.cshtml"
WriteAttributeValue("", 3018, ViewData["Image3"], 3018, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" width=""340"" height=""180"" />
            </div>
        </td>
    </tr>
    <tr>
        <td colspan=""2"" style=""border-left:solid #000 1px;
                   border-right:solid #000 1px;
                   border-bottom:solid #000 1px;
                   width:100%;height:240px;text-align:center"">
            
                <img");
            BeginWriteAttribute("src", " src=\"", 3381, "\"", 3406, 1);
#nullable restore
#line 77 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\InvestigateReports\_Page2.cshtml"
WriteAttributeValue("", 3387, ViewData["Image4"], 3387, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"340\" height=\"220\" />\r\n        </td>\r\n    </tr>\r\n\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InvestigateCard> Html { get; private set; }
    }
}
#pragma warning restore 1591
