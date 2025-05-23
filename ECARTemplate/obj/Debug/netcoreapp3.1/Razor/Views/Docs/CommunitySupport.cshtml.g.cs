#pragma checksum "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Docs\CommunitySupport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21e3529448035952f4c6e8977866f78cfbbab98b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Docs_CommunitySupport), @"mvc.1.0.view", @"/Views/Docs/CommunitySupport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21e3529448035952f4c6e8977866f78cfbbab98b", @"/Views/Docs/CommunitySupport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22b84b265c964a2253c53b091ac6b68388243f81", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Docs_CommunitySupport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Docs\CommunitySupport.cshtml"
   
	ViewData["Title"] = "Flavors & Editions";
	ViewData["PageName"] = "docs_community_support";
	ViewData["Category1"] = "Documentation";
	ViewData["PreemptiveClass"] = "layout-composed nav-function-fixed";

#line default
#line hidden
#nullable disable
            DefineSection("HeadBlock", async() => {
            }
            );
            WriteLiteral(@"<div class=""alert alert-info m-0 p-0 border-left-0 border-right-0 rounded-0 px-5 py-2"">
	<div class=""container"">
		<div class=""px-3 d-flex pr-5"">
			<strong>SmartAdmin Support Forum is a public support forum hosted on <a href=""https://support.gotbootstrap.com/t/asp-net-core"" target=""_blank"">https://support.gotbootstrap.com/t/asp-net-core</a></strong>
			<div class=""ml-auto"">
				<a href=""javascript:void(0);"" class=""btn btn-danger btn-xs btn-icon rounded-circle"" data-dismiss=""alert"" aria-label=""Close"">
					<span aria-hidden=""true""><i class=""fal fa-times""></i></span>
				</a>
			</div>
		</div>
	</div>
</div>
<div class=""d-flex flex-grow-1 p-0 iframe-wrapper"">
	<iframe src=""https://support.gotbootstrap.com/t/asp-net-core"" id=""iframe"" class=""w-100 border-0"" allowtransparency=""true""></iframe>
</div>
");
            DefineSection("ScriptsBlock", async() => {
                WriteLiteral(@"
<script type=""text/javascript"">
	// push settings with ""false"" save to local
	initApp.pushSettings(""layout-composed nav-function-fixed"", false);
	//
	/*$('#iframe').load( function() {
    $('#iframe').contents().find(""head"")
      .append($(""<style type='text/css'>  .Header-title{display:none;}  </style>""));
	});*/
	/*$('#iframe').on(""load"", function() {
    var iframe = $(window.top.document).find(""#iframe"");
    iframe.height(iframe[0].ownerDocument.body.scrollHeight+'px' );
});*/
/*var framefenster = document.getElementsByTagName(""iframe"");
 var auto_resize_timer = window.setInterval(""autoresize_frames()"", 1000);
 function autoresize_frames() {
   for (var i = 0; i < framefenster.length; ++i) {
       if(framefenster[i].contentWindow.document.body){
         var framefenster_size = framefenster[i].contentWindow.document.body.offsetHeight;
         if(document.all && !window.opera) {
           framefenster_size = framefenster[i].contentWindow.document.body.scrollHeight;
         }
         framefenster[i]");
                WriteLiteral(".style.height = framefenster_size + \'px\';\n       }\n   }\n }*/\n</script>\n");
            }
            );
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
