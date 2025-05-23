#pragma checksum "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Datatables\Scroller.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8fefe9bbb8e90c92e62c0bd67a1438a45af6f12b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Datatables_Scroller), @"mvc.1.0.view", @"/Views/Datatables/Scroller.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8fefe9bbb8e90c92e62c0bd67a1438a45af6f12b", @"/Views/Datatables/Scroller.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22b84b265c964a2253c53b091ac6b68388243f81", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Datatables_Scroller : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("media", new global::Microsoft.AspNetCore.Html.HtmlString("screen, print"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/datagrid/datatables/datatables.bundle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datagrid/datatables/datatables.bundle.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Datatables\Scroller.cshtml"
   
	ViewData["Title"] = "Scroller";
	ViewData["PageName"] = "datatables_scroller";
	ViewData["Category1"] = "Datatables";
	ViewData["Heading"] = "<i class='subheader-icon fal fa-table'></i> DataTables: <span class='fw-300'>Scroller</span> <sup class='badge badge-primary fw-500'>ADDON</sup>";
	ViewData["PageDescription"] = "Example of Scroller extention with server side processing ";

#line default
#line hidden
#nullable disable
            DefineSection("HeadBlock", async() => {
                WriteLiteral("\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8fefe9bbb8e90c92e62c0bd67a1438a45af6f12b5479", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
            WriteLiteral(@"<div class=""row"">
	<div class=""col-xl-12"">
		<div id=""panel-1"" class=""panel"">
			<div class=""panel-hdr"">	
				<h2>
					Example <span class=""fw-300""><i>Table</i></span> 
				</h2>
				<div class=""panel-toolbar"">
					<button class=""btn btn-panel"" data-action=""panel-collapse"" data-toggle=""tooltip"" data-offset=""0,10"" data-original-title=""Collapse""></button>
					<button class=""btn btn-panel"" data-action=""panel-fullscreen"" data-toggle=""tooltip"" data-offset=""0,10"" data-original-title=""Fullscreen""></button>
					<button class=""btn btn-panel"" data-action=""panel-close"" data-toggle=""tooltip"" data-offset=""0,10"" data-original-title=""Close""></button>
				</div>
			</div>
			<div class=""panel-container show"">
				<div class=""panel-content"">									
					<div class=""panel-tag"">
						<p>
							Scroller is a plug-in for DataTables which enhances DataTables' built-in scrolling features to allow large amounts of data to be rendered on page very quickly. This is done by Scroller through the use of a virtual rendering techni");
            WriteLiteral(@"que that will render only the part of the table that is actually required for the current view.
						</p>
						<p>
							This example shows how Scroller for DataTables can be initialised, when the Scroller Javascript file is included, by simply setting the <code>scroller</code> option to true. This option can also be given as an object to specify initialisation options for Scroller.
						</p>
					</div>
					<table id=""dt-basic-example"" class=""table table-bordered table-hover table-striped w-100"">
						<thead>
							<tr>
								<th>ID</th>
								<th>Client</th>
								<th>Account#</th>
								<th>Office</th>
								<th>Age.</th>
								<th>Payment date</th>
								<th>Transfer Amount</th>
								<th>Status</th>
								<th></th>
							</tr>
						</thead>
						<tfoot>
							<tr>
								<th>ID</th>
								<th>Client</th>
								<th>Account#</th>
								<th>Office</th>
								<th>Age.</th>
								<th>Payment date</th>
								<th>Transfer Amount</th>
								<th>Status</th>
								<th>");
            WriteLiteral("</th>\n\t\t\t\t\t\t\t</tr>\n\t\t\t\t\t\t</tfoot>\n\t\t\t\t\t</table>\n\t\t\t\t</div>\n\t\t\t</div>\n\t\t</div>\n\t</div>\n</div>\n");
            DefineSection("ScriptsBlock", async() => {
                WriteLiteral("\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fefe9bbb8e90c92e62c0bd67a1438a45af6f12b9190", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
<script>
	$(document).ready( function () {
		$('#dt-basic-example').dataTable({
			responsive:     true,
			stateSave:      true, //remembers your table settings (filter, scroll point, sort, etc)
			processing:     true,
			pageLength:     false,	
			sAjaxSource:    'media/data/2500.json',
			deferRender:    true,
			scrollY:        300,
			scrollCollapse: true,
			scroller:       true,
			/* render dynamic buttons */
			columnDefs: [
				{
					targets: -1,
					title: '',
					orderable: false,
					render: function(data, type, full, meta) {
						/*
						-- ES6
						-- convert using https://babeljs.io online transpiler
						return `
						<a href='javascript:void(0);' class='btn btn-sm btn-icon btn-outline-danger rounded-circle mr-1' title='Delete Record'>
							<i class=""");
#nullable restore
#line 93 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Datatables\Scroller.cshtml"
                                  Write(Settings.Theme.IconPrefix);

#line default
#line hidden
#nullable disable
                WriteLiteral(" fa-times\"></i>\n\t\t\t\t\t\t</a>\n\t\t\t\t\t\t<div class=\'dropdown d-inline-block\'>\n\t\t\t\t\t\t\t<a href=\'#\'\' class=\'btn btn-sm btn-icon btn-outline-primary rounded-circle shadow-0\' data-toggle=\'dropdown\' aria-expanded=\'true\' title=\'More options\'>\n\t\t\t\t\t\t\t\t<i class=\"");
#nullable restore
#line 97 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Datatables\Scroller.cshtml"
                                      Write(Settings.Theme.IconPrefix);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" fa-ellipsis-v""></i>
							</a>
							<div class='dropdown-menu'>
								<a class='dropdown-item' href='javascript:void(0);'>Change Status</a>
								<a class='dropdown-item' href='javascript:void(0);'>Generate Report</a>
							</div>
						</div>`;
						ES5 example below:	
						*/
						return ""\n\t\t\t\t\t\t<a href='javascript:void(0);' class='btn btn-sm btn-icon btn-outline-danger rounded-circle mr-1' title='Delete Record'>\n\t\t\t\t\t\t\t<i class=\""");
#nullable restore
#line 106 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Datatables\Scroller.cshtml"
                                                                                                                                                                                            Write(Settings.Theme.IconPrefix);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" fa-times\""></i>\n\t\t\t\t\t\t</a>\n\t\t\t\t\t\t<div class='dropdown d-inline-block'>\n\t\t\t\t\t\t\t<a href='#'' class='btn btn-sm btn-icon btn-outline-primary rounded-circle shadow-0' data-toggle='dropdown' aria-expanded='true' title='More options'>\n\t\t\t\t\t\t\t\t<i class=\""");
#nullable restore
#line 106 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Datatables\Scroller.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                Write(Settings.Theme.IconPrefix);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" fa-ellipsis-v\""></i>\n\t\t\t\t\t\t\t</a>\n\t\t\t\t\t\t\t<div class='dropdown-menu'>\n\t\t\t\t\t\t\t\t<a class='dropdown-item' href='javascript:void(0);'>Change Status</a>\n\t\t\t\t\t\t\t\t<a class='dropdown-item' href='javascript:void(0);'>Generate Report</a>\n\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t</div>"";
					},
				},
				{
					targets: 7,
					/*	The `data` parameter refers to the data for the cell (defined by the
						`data` option, which defaults to the column being worked with, in this case `data: 16`.*/
					render: function(data, type, full, meta) {
						var badge = {
							1: {'title': 'Pending', 'class': 'badge-warning'},
							2: {'title': 'Pending', 'class': 'badge-warning'},
							3: {'title': 'Canceled', 'class': 'badge-secondary'},
							4: {'title': 'Attempt', 'class': 'bg-danger-100 text-white'},
							5: {'title': 'Failed', 'class': 'badge-danger text-white'},
							6: {'title': 'Delivered', 'class': 'badge-success'},
							7: {'title': 'Attention!', 'class': 'badge-primary'},
						");
                WriteLiteral(@"	8: {'title': 'In Progress', 'class': 'bg-success-300'},
						};
						if (typeof badge[data] === 'undefined') {
							return data;
						}
						return '<span class=""badge ' + badge[data].class + ' badge-pill"">' + badge[data].title + '</span>';
					},
				}
			],				
		});
	});
</script>
");
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
