#pragma checksum "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Shared\_PageBreadcrumb.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cad35708438f87a1af982c7fba3591dc999ae89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PageBreadcrumb), @"mvc.1.0.view", @"/Views/Shared/_PageBreadcrumb.cshtml")]
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
#line 1 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\_ViewImports.cshtml"
using ECARTemplate;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\_ViewImports.cshtml"
using ECARTemplate.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\_ViewImports.cshtml"
using ECARTemplate.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cad35708438f87a1af982c7fba3591dc999ae89", @"/Views/Shared/_PageBreadcrumb.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22b84b265c964a2253c53b091ac6b68388243f81", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__PageBreadcrumb : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Shared\_PageBreadcrumb.cshtml"
 if (ViewBag.Category1?.Length > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb page-breadcrumb\">\n\t<li class=\"breadcrumb-item\"><a href=\"javascript:void(0);\">SmartAdmin</a></li>\n");
#nullable restore
#line 5 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Shared\_PageBreadcrumb.cshtml"
     if (ViewBag.Category1?.Length > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<li class=\"breadcrumb-item\">");
#nullable restore
#line 6 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Shared\_PageBreadcrumb.cshtml"
                        Write(ViewBag.Category1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>");
#nullable restore
#line 6 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Shared\_PageBreadcrumb.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Shared\_PageBreadcrumb.cshtml"
     if (ViewBag.Category2?.Length > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<li class=\"breadcrumb-item\">");
#nullable restore
#line 8 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Shared\_PageBreadcrumb.cshtml"
                        Write(ViewBag.Category2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>");
#nullable restore
#line 8 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Shared\_PageBreadcrumb.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<li class=\"breadcrumb-item active\">");
#nullable restore
#line 9 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Shared\_PageBreadcrumb.cshtml"
                                  Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n\t<li class=\"position-absolute pos-top pos-right d-none d-sm-block\"><span class=\"js-get-date\"></span></li>\n</ol>\n");
#nullable restore
#line 12 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Shared\_PageBreadcrumb.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SmartSettings Settings { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
