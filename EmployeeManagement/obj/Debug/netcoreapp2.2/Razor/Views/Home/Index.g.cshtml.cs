#pragma checksum "Z:\Aman's\Interview_Prep\DotNetCore\EmployeeManagement\EmployeeManagement\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2680ea4f6635bf58598906aeec97f53db28750a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "Z:\Aman's\Interview_Prep\DotNetCore\EmployeeManagement\EmployeeManagement\Views\_ViewImports.cshtml"
using EmployeeManagement.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2680ea4f6635bf58598906aeec97f53db28750a3", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8dd88fc02820e3aa59ee9312963289a3769092b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Employee>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "Z:\Aman's\Interview_Prep\DotNetCore\EmployeeManagement\EmployeeManagement\Views\Home\Index.cshtml"
  
    //Layout = "~/Views/Shared/_Layout.cshtml";//not required here as already defined in the _viewstart
    ViewBag.Title= "Employee List";

#line default
#line hidden
            BeginContext(181, 215, true);
            WriteLiteral("\r\n<table>\r\n    <thead>\r\n        <tr>\r\n            <td>Id</td>\r\n            <td>Name</td>\r\n            <td>Department</td>\r\n            <td>Email</td>\r\n        </tr>\r\n    </thead>\r\n    <tbody style=\"border:dotted\">\r\n");
            EndContext();
#line 18 "Z:\Aman's\Interview_Prep\DotNetCore\EmployeeManagement\EmployeeManagement\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(445, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(484, 7, false);
#line 21 "Z:\Aman's\Interview_Prep\DotNetCore\EmployeeManagement\EmployeeManagement\Views\Home\Index.cshtml"
               Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(491, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(519, 9, false);
#line 22 "Z:\Aman's\Interview_Prep\DotNetCore\EmployeeManagement\EmployeeManagement\Views\Home\Index.cshtml"
               Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(528, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(556, 15, false);
#line 23 "Z:\Aman's\Interview_Prep\DotNetCore\EmployeeManagement\EmployeeManagement\Views\Home\Index.cshtml"
               Write(item.Department);

#line default
#line hidden
            EndContext();
            BeginContext(571, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(599, 10, false);
#line 24 "Z:\Aman's\Interview_Prep\DotNetCore\EmployeeManagement\EmployeeManagement\Views\Home\Index.cshtml"
               Write(item.Email);

#line default
#line hidden
            EndContext();
            BeginContext(609, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 26 "Z:\Aman's\Interview_Prep\DotNetCore\EmployeeManagement\EmployeeManagement\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(646, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591