#pragma checksum "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Form\CheckboxRadio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b885d125b4c5b2e7e883671c95f4abd36f09888"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Form_CheckboxRadio), @"mvc.1.0.view", @"/Views/Form/CheckboxRadio.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b885d125b4c5b2e7e883671c95f4abd36f09888", @"/Views/Form/CheckboxRadio.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22b84b265c964a2253c53b091ac6b68388243f81", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Form_CheckboxRadio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\jagiraldo\source\repos\ECARTemplate\ECARTemplate\Views\Form\CheckboxRadio.cshtml"
   
	ViewData["Title"] = "Checkbox & Radio";
	ViewData["PageName"] = "form_checkbox_radio";
	ViewData["Heading"] = "<i class='subheader-icon fal fa-edit'></i> Checkbox & Radio";
	ViewData["Category1"] = "Form Stuff";
	ViewData["PageDescription"] = "Default input elements for forms";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
	<div class=""col-xl-6"">
		<div id=""panel-1"" class=""panel"">
			<div class=""panel-hdr"">	
				<h2>
					Checkbox <span class=""fw-300""><i>inputs</i></span> 
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
						Add <code>.custom-control</code> and <code>.custom-checkbox</code> wrapper to your <code>input</code> and <code>label</code> to create a custom checkbox component. You can add <code>.custom-checkbox-circle</code> to change it to a circular ");
            WriteLiteral(@"checkbox
					</div>
					<button id=""js-checkbox-toggle"" data-toggle=""button"" class=""btn btn-outline-danger mb-g"" onclick=""toggleCheckbox();"">Change to CIRCLE</button>
					<h5 class=""frame-heading"">Block alignment</h5>
					<div class=""frame-wrap"">
						<div class=""demo"">
							<div class=""custom-control custom-checkbox"">
								<input type=""checkbox"" class=""custom-control-input"" id=""defaultUnchecked"">
								<label class=""custom-control-label"" for=""defaultUnchecked"">Unchecked</label>
							</div>
							<div class=""custom-control custom-checkbox"">
								<input type=""checkbox"" class=""custom-control-input"" id=""defaultChecked""");
            BeginWriteAttribute("checked", " checked=\"", 1951, "\"", 1961, 0);
            EndWriteAttribute();
            WriteLiteral(">\n\t\t\t\t\t\t\t\t<label class=\"custom-control-label\" for=\"defaultChecked\">Checked</label>\n\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t\t<div class=\"custom-control custom-checkbox\">\n\t\t\t\t\t\t\t\t<input type=\"checkbox\" class=\"custom-control-input\" id=\"defaultIndeterminate\"");
            BeginWriteAttribute("checked", " checked=\"", 2196, "\"", 2206, 0);
            EndWriteAttribute();
            WriteLiteral(">\n\t\t\t\t\t\t\t\t<label class=\"custom-control-label\" for=\"defaultIndeterminate\">Indeterminate</label>\n\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t\t<div class=\"custom-control custom-checkbox\">\n\t\t\t\t\t\t\t\t<input type=\"checkbox\" class=\"custom-control-input\" id=\"defaultUncheckedDisabled\"");
            BeginWriteAttribute("disabled", " disabled=\"", 2457, "\"", 2468, 0);
            EndWriteAttribute();
            WriteLiteral(@">
								<label class=""custom-control-label"" for=""defaultUncheckedDisabled"">Unchecked & disabled</label>
							</div>
							<div class=""custom-control custom-checkbox"">
								<input type=""checkbox"" class=""custom-control-input"" id=""defaultCheckedDisabled""");
            BeginWriteAttribute("checked", " checked=\"", 2728, "\"", 2738, 0);
            EndWriteAttribute();
            BeginWriteAttribute("disabled", " disabled=\"", 2739, "\"", 2750, 0);
            EndWriteAttribute();
            WriteLiteral(@">
								<label class=""custom-control-label"" for=""defaultCheckedDisabled"">Checked & disabled</label>
							</div>
						</div>
					</div>
					<h5 class=""frame-heading"">Inline alignment</h5>
					<div class=""frame-wrap"">
						<div class=""custom-control custom-checkbox custom-control-inline"">
							<input type=""checkbox"" class=""custom-control-input"" id=""defaultInline1"">
							<label class=""custom-control-label"" for=""defaultInline1"">Unchecked</label>
						</div>
						<div class=""custom-control custom-checkbox custom-control-inline"">
							<input type=""checkbox"" class=""custom-control-input"" id=""defaultInline2""");
            BeginWriteAttribute("checked", " checked=\"", 3374, "\"", 3384, 0);
            EndWriteAttribute();
            WriteLiteral(">\n\t\t\t\t\t\t\t<label class=\"custom-control-label\" for=\"defaultInline2\">Checked</label>\n\t\t\t\t\t\t</div>\n\t\t\t\t\t\t<div class=\"custom-control custom-checkbox custom-control-inline\">\n\t\t\t\t\t\t\t<input type=\"checkbox\" class=\"custom-control-input\" id=\"defaultInlined\"");
            BeginWriteAttribute("disabled", " disabled=\"", 3631, "\"", 3642, 0);
            EndWriteAttribute();
            WriteLiteral(">\n\t\t\t\t\t\t\t<label class=\"custom-control-label\" for=\"defaultInlined\">Disabled</label>\n\t\t\t\t\t\t</div>\n\t\t\t\t\t\t<div class=\"custom-control custom-checkbox custom-control-inline\">\n\t\t\t\t\t\t\t<input type=\"checkbox\" class=\"custom-control-input\" id=\"defaultInline3\"");
            BeginWriteAttribute("checked", " checked=\"", 3890, "\"", 3900, 0);
            EndWriteAttribute();
            BeginWriteAttribute("disabled", " disabled=\"", 3901, "\"", 3912, 0);
            EndWriteAttribute();
            WriteLiteral(@">
							<label class=""custom-control-label"" for=""defaultInline3"">Checked & disabled</label>
						</div>
					</div>
				</div>
			</div>
		</div>		
	</div>
	<div class=""col-xl-6"">
		<div id=""panel-2"" class=""panel"">
			<div class=""panel-hdr"">	
				<h2>
					Radio <span class=""fw-300""><i>inputs</i></span> 
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
						Add <code>.custom-control</code> and <code>.custom-radio</code> wrapper to your <code>input</code> and ");
            WriteLiteral(@"<code>label</code> to create a custom radio component. You can add <code>.custom-radio-rounded</code> to change it to a rounded radio
					</div>
					<button id=""js-radio-toggle"" data-toggle=""button"" class=""btn btn-outline-danger mb-g"" onclick=""toggleRadio();"">Change to ROUNDED</button>
					<h5 class=""frame-heading"">Block alignment</h5>
					<div class=""frame-wrap"">
						<div class=""demo"">
							<div class=""custom-control custom-radio"">
								<input type=""radio"" class=""custom-control-input"" id=""defaultUncheckedRadio"" name=""defaultExampleRadios"">
								<label class=""custom-control-label"" for=""defaultUncheckedRadio"">Unchecked</label>
							</div>
							<div class=""custom-control custom-radio"">
								<input type=""radio"" class=""custom-control-input"" id=""defaultCheckedRadio"" name=""defaultExampleRadios""");
            BeginWriteAttribute("checked", " checked=\"", 5757, "\"", 5767, 0);
            EndWriteAttribute();
            WriteLiteral(@">
								<label class=""custom-control-label"" for=""defaultCheckedRadio"">Checked</label>
							</div>
							<div class=""custom-control custom-radio"">
								<input type=""radio"" class=""custom-control-input active"" id=""defaultUncheckedRadio2"" name=""defaultExampleRadios"">
								<label class=""custom-control-label"" for=""defaultUncheckedRadio2"">Unchecked</label>
							</div>
							<div class=""custom-control custom-radio"">
								<input type=""radio"" class=""custom-control-input"" id=""defaultUncheckedDisabledRadio2"" name=""defaultExampleRadios1""");
            BeginWriteAttribute("disabled", " disabled=\"", 6315, "\"", 6326, 0);
            EndWriteAttribute();
            WriteLiteral(@">
								<label class=""custom-control-label"" for=""defaultUncheckedDisabledRadio2"">Disabled</label>
							</div>
							<div class=""custom-control custom-radio"">
								<input type=""radio"" class=""custom-control-input"" id=""defaultCheckedDisabledRadio2"" name=""defaultCheckedDisabledRadio2""");
            BeginWriteAttribute("checked", " checked=\"", 6616, "\"", 6626, 0);
            EndWriteAttribute();
            BeginWriteAttribute("disabled", " disabled=\"", 6627, "\"", 6638, 0);
            EndWriteAttribute();
            WriteLiteral(@">
								<label class=""custom-control-label"" for=""defaultCheckedDisabledRadio2"">Checked & disabled</label>
							</div>
						</div>
					</div>	
					<h5 class=""frame-heading"">Inline alignment</h5>
					<div class=""frame-wrap"">
						<div class=""custom-control custom-radio custom-control-inline"">
							<input type=""radio"" class=""custom-control-input"" id=""defaultInline1Radio"" name=""inlineDefaultRadiosExample"">
							<label class=""custom-control-label"" for=""defaultInline1Radio"">Unchecked</label>
						</div>
						<div class=""custom-control custom-radio custom-control-inline"">
							<input type=""radio"" class=""custom-control-input"" id=""defaultInline2Radio"" name=""inlineDefaultRadiosExample""");
            BeginWriteAttribute("checked", " checked=\"", 7340, "\"", 7350, 0);
            EndWriteAttribute();
            WriteLiteral(@">
							<label class=""custom-control-label"" for=""defaultInline2Radio"">Checked</label>
						</div>
						<div class=""custom-control custom-radio custom-control-inline"">
							<input type=""radio"" class=""custom-control-input"" id=""defaultInline4Radio"" name=""inlineDefaultRadiosExample2""");
            BeginWriteAttribute("disabled", " disabled=\"", 7636, "\"", 7647, 0);
            EndWriteAttribute();
            WriteLiteral(@">
							<label class=""custom-control-label"" for=""defaultInline4Radio"">Disabled</label>
						</div>
						<div class=""custom-control custom-radio custom-control-inline"">
							<input type=""radio"" class=""custom-control-input"" id=""defaultInline3Radio"" name=""inlineDefaultRadiosExample2""");
            BeginWriteAttribute("checked", " checked=\"", 7934, "\"", 7944, 0);
            EndWriteAttribute();
            BeginWriteAttribute("disabled", " disabled=\"", 7945, "\"", 7956, 0);
            EndWriteAttribute();
            WriteLiteral(@">
							<label class=""custom-control-label"" for=""defaultInline3Radio"">Checked & disabled</label>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class=""col-xl-12"">
		<div id=""panel-3"" class=""panel"">
			<div class=""panel-hdr"">
				<h2>
					Switch <span class=""fw-300""><i>radio and checkbox</i></span> 
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
						A switch has the markup of a custom checkbox but uses the <code>.custom-switch</code> class to r");
            WriteLiteral(@"ender a toggle switch. Switches also support the <code>disabled</code> attribute
					</div>
					<div class=""row"">
						<div class=""col-xl-6"">
							<h5 class=""frame-heading"">
								Switch checkbox
							</h5>
							<div class=""frame-wrap demo"">
								<div class=""demo"">
									<div class=""custom-control custom-switch"">
										<input type=""checkbox"" class=""custom-control-input"" id=""customSwitch1"">
										<label class=""custom-control-label"" for=""customSwitch1"">Unchecked</label>
									</div>
									<div class=""custom-control custom-switch"">
										<input type=""checkbox"" class=""custom-control-input"" id=""customSwitch2""");
            BeginWriteAttribute("checked", " checked=\"", 9627, "\"", 9637, 0);
            EndWriteAttribute();
            WriteLiteral(@">
										<label class=""custom-control-label"" for=""customSwitch2"">Checked</label>
									</div>
									<div class=""custom-control custom-switch"">
										<input type=""checkbox"" class=""custom-control-input"" disabled id=""customSwitchd"">
										<label class=""custom-control-label"" for=""customSwitchd"">Disabled</label>
									</div>
									<div class=""custom-control custom-switch"">
										<input type=""checkbox"" class=""custom-control-input"" id=""customSwitch3""");
            BeginWriteAttribute("checked", " checked=\"", 10112, "\"", 10122, 0);
            EndWriteAttribute();
            BeginWriteAttribute("disabled", " disabled=\"", 10123, "\"", 10134, 0);
            EndWriteAttribute();
            WriteLiteral(@">
										<label class=""custom-control-label"" for=""customSwitch3"">Checked & disabled</label>
									</div>
								</div>
							</div>
						</div>
						<div class=""col-xl-6"">
							<h5 class=""frame-heading"">Switch Radio</h5>
								<div class=""frame-wrap demo"">
								<div class=""demo"">
									<div class=""custom-control custom-switch"">
										<input type=""radio"" class=""custom-control-input"" id=""customSwitch1radio"" name=""defaultSwitchRadioExample"">
										<label class=""custom-control-label"" for=""customSwitch1radio"">Unchecked</label>
									</div>
									<div class=""custom-control custom-switch"">
										<input type=""radio"" class=""custom-control-input"" id=""customSwitch2radio""");
            BeginWriteAttribute("checked", " checked=\"", 10841, "\"", 10851, 0);
            EndWriteAttribute();
            WriteLiteral(@" name=""defaultSwitchRadioExample"">
										<label class=""custom-control-label"" for=""customSwitch2radio"">Checked</label>
									</div>
									<div class=""custom-control custom-switch"">
										<input type=""radio"" class=""custom-control-input"" disabled id=""customSwitchdradio"" name=""defaultSwitchRadioExample2"">
										<label class=""custom-control-label"" for=""customSwitchdradio"">Disabled</label>
									</div>
									<div class=""custom-control custom-switch"">
										<input type=""radio"" class=""custom-control-input"" id=""customSwitch3radio""");
            BeginWriteAttribute("checked", " checked=\"", 11407, "\"", 11417, 0);
            EndWriteAttribute();
            BeginWriteAttribute("disabled", " disabled=\"", 11418, "\"", 11429, 0);
            EndWriteAttribute();
            WriteLiteral(" name=\"defaultSwitchRadioExample2\">\n\t\t\t\t\t\t\t\t\t\t<label class=\"custom-control-label\" for=\"customSwitch3radio\">Checked & disabled</label>\n\t\t\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t</div>\n\t\t\t\t\t</div>\n\t\t\t\t</div>\n\t\t\t</div>\n\t\t</div>\n\t</div>\n</div>\n");
            DefineSection("ScriptsBlock", async() => {
                WriteLiteral(@"
<script type=""text/javascript"">
	$('#defaultIndeterminate').prop('indeterminate', true)
	var toggleCheckbox = function(){
		$('#js-checkbox-toggle').toggleText('Change to CIRCLE', 'Change back to default');
		$('.frame-wrap .custom-checkbox').toggleClass('custom-checkbox-circle');
	}
	var toggleRadio = function (){
		$('#js-radio-toggle').toggleText('Change to ROUNDED', 'Change back to default');
		$('.frame-wrap .custom-radio').toggleClass('custom-radio-rounded');
	}
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
