#pragma checksum "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76972c6b1d18c2beb591c88ac2a7df11ba523a2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Knjige_Details), @"mvc.1.0.view", @"/Views/Knjige/Details.cshtml")]
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
#line 1 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\_ViewImports.cshtml"
using Biblioteka;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\_ViewImports.cshtml"
using Biblioteka.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76972c6b1d18c2beb591c88ac2a7df11ba523a2c", @"/Views/Knjige/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa542a412a840c3692166b9cac5e1ec3cbdb951f", @"/Views/_ViewImports.cshtml")]
    public class Views_Knjige_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Biblioteka.Models.KnjigaPage>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
  
    ViewData["Title"] = "Svi detalji knjige";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detalji knjige</h1>\r\n\r\n<div>\r\n    <h4>Knjiga</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.naslov));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayFor(model => model.naslov));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.autor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayFor(model => model.autor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.broj_stranica));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayFor(model => model.broj_stranica));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.datum_izdavanja));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayFor(model => model.datum_izdavanja));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.kolicina));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayFor(model => model.kolicina));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.opis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayFor(model => model.opis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.jezici));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayFor(model => model.jezici));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.zanrovi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayFor(model => model.zanrovi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 62 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.komentari));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 65 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
       Write(Html.DisplayFor(model => model.komentari));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<p>Ostavi komentar za ovu knjigu!</p>\r\n");
#nullable restore
#line 70 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
 using (Html.BeginForm("Update", "Knjige", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
Write(Html.TextArea("komentar"));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"submit\" value=\"Potvrdi Komentar\" />\r\n");
#nullable restore
#line 74 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 76 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
 using (Html.BeginForm("DodajIznajmljenu", "Knjige", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type =\"submit\" value=\"Pozajmi\" />\r\n");
#nullable restore
#line 79 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "76972c6b1d18c2beb591c88ac2a7df11ba523a2c11529", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "C:\Users\Kerim\Desktop\lol\Grupa4-Biblioteka\Biblioteka\Biblioteka\Views\Knjige\Details.cshtml"
                               WriteLiteral(Model.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "76972c6b1d18c2beb591c88ac2a7df11ba523a2c13695", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Biblioteka.Models.KnjigaPage> Html { get; private set; }
    }
}
#pragma warning restore 1591
