#pragma checksum "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11190c6e9ca74b2d264d788a91cc6b65e46da9ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AccidentReports_pv_Table), @"mvc.1.0.view", @"/Views/AccidentReports/pv_Table.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11190c6e9ca74b2d264d788a91cc6b65e46da9ee", @"/Views/AccidentReports/pv_Table.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad089ff6942dee7852c6438a678bc9b30921c910", @"/Views/_ViewImports.cshtml")]
    public class Views_AccidentReports_pv_Table : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AccidentReportViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExportToExcel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AccidentReports", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
 if (Model != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11190c6e9ca74b2d264d788a91cc6b65e46da9ee5634", async() => {
                WriteLiteral("<i class=\"far fa-file-excel fa-2x indigo-text\"></i>");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-from", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 7 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
               WriteLiteral(ViewBag.From);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-from", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["from"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 8 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
             WriteLiteral(ViewBag.To);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["to"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-to", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["to"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 9 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                   WriteLiteral(ViewBag.Region);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["regionId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-regionId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["regionId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 10 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                     WriteLiteral(ViewBag.Branch);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["branchCode"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-branchCode", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["branchCode"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        <span class=""text-muted text-lg-center font-weight-bold"">รายงานอุบัติเหตุ</span>
    </div>
    <div>
        <table id=""basicTable"" class=""table table-striped table-bordered table-sm table-hover"">
            <thead class=""mdb-color text-white"">
                <tr>
                    <th class=""text-center"">#</th>
                    <th class=""text-center"">วันที่เกิดเหตุ</th>
                    <th class=""text-center"">หน่วยงาน</th>
                    <th class=""text-center"">สาขา</th>
                    <th class=""text-center"">ชื่อเคส</th>
                    <th class=""text-center"">ชื่อพนักงาน</th>
                    <th class=""text-center"">ตำแหน่ง</th>
                    <th class=""text-center"">อายุพนักงาน</th>
                    <th class=""text-center"">อายุงาน</th>
                    <th class=""text-center"">สังกัดบริษัทฯ</th>
                    <th class=""text-center"">กะการทำงาน</th>
                    <th class=""text-center"">ประเมินความผิด</th>
                    <");
            WriteLiteral(@"th class=""text-center"">ประเภทของอุบัติเหตุ</th>
                    <th class=""text-center"">ระดับความรุนแรง</th>
                    <th class=""text-center"">ระยะเวลาตั้งแต่เกิดจนแล้วเสร็จ</th>
                    <th class=""text-center"">เวลาพักผ่อน</th>
                    <th class=""text-center"">เส้นทางที่วิ่ง</th>
                    <th class=""text-center"">สินค้าหลังตู้รถขณะเกิดเหตุ</th>
                    <th class=""text-center"">การดำเนินการ</th>
                    <th class=""text-center"">การบาดเจ็บของพนักงาน</th>
                    <th class=""text-center"">การบาดเจ็บของคู่กรณี</th>
                    <th class=""text-center"">การบาดเจ็บของบุคคลที่ 3</th>
                    <th class=""text-center"">ความเสียหายของรถ</th>
                    <th class=""text-center"">ความเสียหายของรถคู่กรณี</th>
                    <th class=""text-center"">ความเสียหายของอุปกรณ์</th>
                    <th class=""text-center"">กล้องหน้ารถ</th>
                    <th class=""text-center"">การตรวจสภาพรถ</th>
      ");
            WriteLiteral(@"              <th class=""text-center"">GPS</th>
                    <th class=""text-center"">ความเร็วขณะเกิดเหตุ</th>
                    <th class=""text-center"">กล้องวงจรปิด</th>
                    <th class=""text-center"">อบรมความปลอดภัย</th>
                    <th class=""text-center"">อบรม SDC</th>
                    <th class=""text-center"">ผลการตรวจแอลกอฮอล์</th>
                    <th class=""text-center"">รายละเอียด</th>
                    <th class=""text-center"">สภาพพื้นที่</th>
                    <th class=""text-center"">สภาพอากาศ</th>
                    <th class=""text-center"">การจราจร</th>
                    <th class=""text-center"">ลักษณะบริเวณเกิดเหตุ</th>
                    <th class=""text-center"">ลักษณะอุบัติเหตุ</th>
                    <th class=""text-center"">สาเหตุของอุบัติเหต Unsafe Act.</th>
                    <th class=""text-center"">สาเหตุของอุบัติเหตุ Unsafe Con.</th>
                    <th class=""text-center"">มาตรการป้องกันที่ดำเนินการ</th>

                </tr>
    ");
            WriteLiteral("        </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 63 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                   int itemNo = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                 foreach (var item in Model) {

                    string[] _description = GlobalData.SeparateWord(item.IncidentDescription, 40);
                    string[] _casename = GlobalData.SeparateWord(item.CaseName, 30);


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"font-smaller\">\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 70 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                 Write(itemNo++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 71 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.CaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 72 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.RegionName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 73 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.BranchCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial;white-space:nowrap\">\r\n");
#nullable restore
#line 75 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                             if (_casename != null) {
                                for (int i = 0; i < _casename.Length; i++) {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                               Write(_casename[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 78 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 81 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.EmployeeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 82 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 83 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 84 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.YearExperience);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 85 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 86 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.Shift);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 87 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.CaseType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 88 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.AccidentMode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 89 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.Rank);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 90 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.SolutionHour);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 91 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.LeisureHour);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 92 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.IncidentRoute);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 93 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.ProductDamage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 94 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.CaseEffect);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 95 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.EmpInjure);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 96 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.PartiesInjure);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 97 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.ThirdPartiesInjure);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 98 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.TruckDamage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 99 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.PartiesDamage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 100 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.EquipmentDamage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 101 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.Camera);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 102 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.TruckInspectionNormal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 103 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.Gps);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 104 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.GpsSpeed);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 105 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.Cctv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 106 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.SafetyCourse);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 107 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.SdcCourse);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 108 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.AlcoholCheck);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial;white-space:nowrap\">\r\n");
#nullable restore
#line 110 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                             if (_description != null) {
                                for (int i = 0; i < _description.Length; i++) {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 112 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                               Write(_description[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n");
#nullable restore
#line 113 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 116 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.AreaConditon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 117 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.Weather);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 118 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.Traffic);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 119 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.IncidentArea);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial\">");
#nullable restore
#line 120 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                                                Write(item.Incident);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"font-size:12px;font-family:Arial;white-space:nowrap\">\r\n");
#nullable restore
#line 122 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                             foreach (var unsafeact in item.UnsafeActs) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>- ");
#nullable restore
#line 123 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                   Write(unsafeact.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n");
#nullable restore
#line 124 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td style=\"font-size:12px;font-family:Arial;white-space:nowrap\">\r\n");
#nullable restore
#line 127 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                             foreach (var unsafecon in item.UnsafeCons) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>- ");
#nullable restore
#line 128 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                   Write(unsafecon.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n");
#nullable restore
#line 129 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td style=\"font-size:12px;font-family:Arial;white-space:nowrap\">\r\n");
#nullable restore
#line 132 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                             foreach (var solution in item.Solutions) {
                                var solutionCollect = GlobalData.SeparateWord(solution, 40);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>-</span>\r\n");
#nullable restore
#line 135 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                for (int i = 0; i < solutionCollect.Length; i++) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>");
#nullable restore
#line 136 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                     Write(solutionCollect[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n");
#nullable restore
#line 137 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 141 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
#nullable restore
#line 145 "C:\Users\SCG EXPRESS\Git\MvcAndAngularForSCGESafety\VK1.SCGE.Safety.Mvc\Views\AccidentReports\pv_Table.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AccidentReportViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
