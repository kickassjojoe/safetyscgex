#pragma checksum "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6556ad57593a761cd02ff39030ce5e96810fc635"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CAR_ViewAsPdf), @"mvc.1.0.view", @"/Views/CAR/ViewAsPdf.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6556ad57593a761cd02ff39030ce5e96810fc635", @"/Views/CAR/ViewAsPdf.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad089ff6942dee7852c6438a678bc9b30921c910", @"/Views/_ViewImports.cshtml")]
    public class Views_CAR_ViewAsPdf : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dictionary<CorrectiveActionRequest, List<CorrectiveActionRequestItem>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
   Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6556ad57593a761cd02ff39030ce5e96810fc6355968", async() => {
                WriteLiteral("\r\n    <!-- Bootstrap core CSS -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6556ad57593a761cd02ff39030ce5e96810fc6356265", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <style>
        table {
            border-collapse: collapse;
            border-spacing: 0;
            /* width: 100%;*/
        }

        table, th, td {
            border: 1px solid black;
        }
        /*  .td-w100{
            width:100px !important;
        }*/
        /*body {*/
        /* A5 dimensions
            height: 215mm;
            width: 140mm;
            margin: 0;*/
        /*font-size: 14px;
        }*/

        .page-breaker {
            display: block;
            clear: both;
            page-break-after: always;
        }

        .breakhere {
            page-break-after: always;
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6556ad57593a761cd02ff39030ce5e96810fc6358829", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 41 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
      
        var itemPerPage = 10;
        var dict = Model.Values.Sum(x => x.Count);
        var totalPage = Convert.ToInt32(Math.Ceiling(dict / Convert.ToDouble(itemPerPage)));
        ViewBag.TotalPage = totalPage;
        var CARCode = Model.FirstOrDefault().Key.CARCode;
        var created = $"{Model.FirstOrDefault().Key.Created: dd/MM/yyyy}";
        var branchName = Model.FirstOrDefault().Key.BranchName;
        var vehicleType = Model.FirstOrDefault().Key.VehicleType;
        var plateNumber = Model.FirstOrDefault().Key.PlateNumber;
        var branchManager = Model.FirstOrDefault().Key.Branch.BranchManager;
        var email = Model.FirstOrDefault().Key.Branch.Email;

        //
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
      int itemNo = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
     for (int i = 0; i < totalPage; i++) {
        var page = i + 1;

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        <div style=""height:600px;flex-flow:wrap"">
            <div>
                <div>
                    <h5 style=""text-align:center;font-weight:400""><u>แบบฟอร์มรายงานให้แก้ไขความผิดปกติของรถ</u></h5>
                </div>
            </div>
            <div>
                <div style=""text-align:right;height:25px;""><span>เลขที่เอกสาร :");
#nullable restore
#line 66 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                                                          Write(CARCode);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </span></div>\r\n                <div style=\"text-align:right;height:25px\"><span>วันที่สร้างเอกสาร : ");
#nullable restore
#line 67 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                                                               Write(created);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></div>\r\n            </div>\r\n            <div>\r\n                <div><span style=\"font-size:14px\">ผู้ออกเอกสาร : ");
#nullable restore
#line 70 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                                            Write(branchManager);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></div>\r\n                <div><span style=\"font-size:14px\">Email : ");
#nullable restore
#line 71 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                                     Write(email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></div>\r\n                <div><span style=\"font-size:14px\">ฝ่าย :</span></div>\r\n                <div><span style=\"font-size:14px\">แผนก :</span></div>\r\n                <div><span style=\"font-size:14px\">สาขา : ");
#nullable restore
#line 74 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                                    Write(branchName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></div>\r\n                <div><span style=\"font-size:14px\">ประเภทรถ : ");
#nullable restore
#line 75 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                                        Write(vehicleType);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></div>\r\n                <div><span style=\"font-size:14px\">ทะเบียนรถ : ");
#nullable restore
#line 76 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                                         Write(plateNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span></div>
            </div>
            <div style=""height:15px""></div>
            <div><b><u>รายการผิดปกติของรถที่ต้องแก้ไข</u></b></div>
            <table>
                <thead>
                    <tr style=""font-size:12px;text-align:center"">
                        <td>ลำดับ </td>
                        <td>ความผิดปกติ</td>
                        <td>สาเหตุ</td>
                        <td>วันที่ตรวจพบ</td>
                        <td>แก้ไขแล้ว</td>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 91 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                     foreach (var key in Model) {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                         foreach (var value in key.Value.Skip((i + 1 - 1) * itemPerPage).Take(itemPerPage)) {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <div>\r\n                                        <span style=\"font-size:12px\">");
#nullable restore
#line 96 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                                                Write(itemNo);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                    </div>
                                </td>
                                <td>
                                    <div style=""width:230px"" class=""text-wrap"">
                                        <span style=""font-size:12px"">
                                            ");
#nullable restore
#line 102 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                       Write(value.TruckInspectionItemName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                        </span>
                                    </div>
                                </td>
                                <td>
                                    <div style=""width:250px"" class=""text-wrap"">
                                        <span style=""font-size:12px"">
                                            ");
#nullable restore
#line 109 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                       Write(value.TruckInspectionCardDetail.Remark);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </span>\r\n                                    </div>\r\n                                </td>\r\n                                <td><span style=\"font-size:12px\">");
#nullable restore
#line 113 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                                             Write($"{value.IssuedDate: dd/MM/yyyy}");

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></td>\r\n                                <td style=\"text-align:center\">\r\n");
#nullable restore
#line 115 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                     if (value.IsFixed) {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <span style=\"font-size:12px\">\r\n                                            &#10003;\r\n                                        </span>\r\n");
#nullable restore
#line 119 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 122 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                            itemNo++;
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </tbody>
            </table>
        </div>
        <div>
            <div style=""height:15px""></div>
            <div><b><u>ดำเนินการ</u></b></div>
            <div>
                <div style=""width:50%;height:20px;font-size:14px;
                        border-top:solid 1px;
                        border-left:solid 1px;
                        float:left""
                     class=""text-wrap"">นำรถเข้าแก้ไข ที่ศูนย์บริการชื่อ </div>
                <div style=""width:49%;height:20px;
                        border-top:solid 1px;
                        border-left:solid 1px;
                        border-right:solid 1px; float:left""></div>
            </div>
            <div>
                <div style=""width:50%;height:20px;font-size:14px;
                        border-top:solid 1px;
                        border-left:solid 1px;
                        float:left"">วันที่นัดเข้าแก้ไข </div>
                <div style=""width:49%;height:20px;
                       ");
                WriteLiteral(@" border-top:solid 1px;
                        border-left:solid 1px;
                        border-right:solid 1px; float:left""></div>
            </div>
            <div>
                <div style=""width:50%;height:20px;font-size:14px;
                        border-top:solid 1px;
                        border-left:solid 1px;border-bottom:solid 1px;
                        float:left"">ผู้รับเรื่อง/เบอร์ติดต่อ </div>
                <div style=""width:49%;height:20px;
                        border-top:solid 1px;
                        border-left:solid 1px;border-bottom:solid 1px;
                        border-right:solid 1px; float:left""></div>
            </div>
        </div>
");
                WriteLiteral(@"        <div>
            <div style=""float:left;width:100%;height:20px;""></div>
        </div>
        <div><b><u>หมายเหตุ</u></b></div>
        <div>
            <div style=""width:100%;height:30px; border-bottom:dotted 1px""></div>
            <div style=""width:100%;height:30px; border-bottom:dotted 1px""></div>
        </div>
        <div style=""height:50px""></div>
        <div class=""float-left w-50"">
            <div><span style=""font-size:14px"">ผู้รับผิดชอบแก้ไข : ");
#nullable restore
#line 174 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
                                                             Write(branchName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span></div>
            <div><span style=""font-size:14px"">กำหนดการแล้วเสร็จ :</span></div>
            <div><span style=""font-size:14px"">ผู้อนุมัติ : Safety</span></div>
        </div>
        <div class=""float-right w-50"">
            <div style=""float:right""><span style=""font-size:14px"">ตรวจสอบแล้วโดย (เจ้าหน้าที่ศูนย์บริการ)</span></div>
        </div>
");
#nullable restore
#line 182 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
         if (totalPage != page) {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"page-breaker\"></div>\r\n");
#nullable restore
#line 184 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 184 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\CAR\ViewAsPdf.cshtml"
         
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\r\n");
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
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dictionary<CorrectiveActionRequest, List<CorrectiveActionRequestItem>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
