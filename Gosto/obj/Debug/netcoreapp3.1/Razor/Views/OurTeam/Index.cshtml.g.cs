#pragma checksum "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c77329a2fb40d3b31916e418c3d9f47546b1188"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OurTeam_Index), @"mvc.1.0.view", @"/Views/OurTeam/Index.cshtml")]
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
#line 2 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\_ViewImports.cshtml"
using Gosto.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\_ViewImports.cshtml"
using Gosto.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\_ViewImports.cshtml"
using Gosto.DAL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\_ViewImports.cshtml"
using Gosto.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\_ViewImports.cshtml"
using Gosto.ViewModels.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c77329a2fb40d3b31916e418c3d9f47546b1188", @"/Views/OurTeam/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b611db0d3a6cb81a1bff47c8287cb14f1636e552", @"/Views/_ViewImports.cshtml")]
    public class Views_OurTeam_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OurTeamVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("testimonial"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/Our-team/our-team-testimonial.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<section>
    <div class=""head text-center"" style=""background-image: url('/assets/img/Our-team/bg-ourteam.jpg')"">
        <div class=""container"">
            <div class=""row"">
                <div class=""inffo"">
                    <h4>Perfect Target</h4>
                    <h1 class=""team-title"">");
#nullable restore
#line 14 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
                                      Write(Model.OurTeam.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                    <p class=\"team-description\">\r\n                       ");
#nullable restore
#line 16 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
                  Write(Model.OurTeam.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>
            </div>
        </div>
    </div>
</section>

<section>
    <div class=""team-head mt-2"">
        <div class=""container"">
            <div class=""col-lg-12"">
                <div class=""all text-center"">
                    <h5 class=""fw-bold"">OUR PERFECT TEAM</h5>
                    <h3 class=""fw-bold"">AWESOMENESS PEOPLE</h3>
                    <p>Commodo sociosqu venenatis cras dolor sagittis integer luctus maecenas.</p>
                </div>
            </div>
        </div>
    </div>
</section>

<section>
    <div class=""our-team mt-3"">
        <div class=""containerr"">
            <div class=""row"">
");
#nullable restore
#line 42 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
                 foreach (var team in Model.Teams)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-4\">\r\n                    <div class=\"card\">\r\n                        <div class=\"img text-center\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3c77329a2fb40d3b31916e418c3d9f47546b11887192", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1441, "~/assets/img/Our-team/", 1441, 22, true);
#nullable restore
#line 47 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
AddHtmlAttributeValue("", 1463, team.Image, 1463, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"card-body text-center\">\r\n                            <h4 class=\"team-name\">");
#nullable restore
#line 50 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
                                             Write(team.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                            <h5 class=\"team-position\">");
#nullable restore
#line 51 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
                                                 Write(team.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <p class=\"team-description\">\r\n                                ");
#nullable restore
#line 53 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
                           Write(team.Info);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 58 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n              \r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n<section class=\"overflow-hidden\">\r\n    <div class=\"teamwork \">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 70 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
             foreach (var ourTeamBackImage in Model.OurTeamBackImages)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-4\">\r\n                <div class=\"card \">\r\n                    <div class=\"img\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3c77329a2fb40d3b31916e418c3d9f47546b118810812", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2394, "~/assets/img/Our-team/", 2394, 22, true);
#nullable restore
#line 76 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
AddHtmlAttributeValue("", 2416, ourTeamBackImage.Image, 2416, 23, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 80 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

        </div>
    </div>
</section>

<section>
    <div class=""creater "">
        <div class=""containerr"">
            <div class=""row align-items-center"">

                <div class=""col-lg-6"">
                    <div class=""card"">
                        <div class=""img"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3c77329a2fb40d3b31916e418c3d9f47546b118812992", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2871, "~/assets/img/Our-team/", 2871, 22, true);
#nullable restore
#line 95 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
AddHtmlAttributeValue("", 2893, Model.CreateTrend.BackImage, 2893, 28, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""col-lg-6"">
                    <div class=""card "">
                        <div class=""title"">
                            <h5 class=""fw-bold"">ENDLESS PASSION</h5>
                            <h3 class=""fw-bold pb-2"">");
#nullable restore
#line 103 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
                                                Write(Model.CreateTrend.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <p>\r\n                   ");
#nullable restore
#line 105 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
              Write(Html.Raw(Model.CreateTrend.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</section>

<section>
    <div class=""team-testimonial"">
        <div class=""containerr "">
            <div class=""testimonial-slider overflow-hidden"">

");
#nullable restore
#line 121 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
                 foreach (var item in Model.Teams)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card\">\r\n                    <div class=\"info\">\r\n                        <div class=\"img\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3c77329a2fb40d3b31916e418c3d9f47546b118816222", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3948, "~/assets/img/Our-team/", 3948, 22, true);
#nullable restore
#line 126 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
AddHtmlAttributeValue("", 3970, item.Image, 3970, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"content mt-5\">\r\n                            <p>\r\n                             ");
#nullable restore
#line 130 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
                        Write(Html.Raw(item.Reply));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"author mt-5\">\r\n                            <h4>");
#nullable restore
#line 134 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
                           Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        </div>\r\n                        <div class=\"position mt-5`\">\r\n                            <h5>");
#nullable restore
#line 137 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"
                           Write(item.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n");
#nullable restore
#line 142 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\OurTeam\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n               \r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n<section>\r\n    <div class=\"clip\">\r\n        <div class=\"img\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3c77329a2fb40d3b31916e418c3d9f47546b118819407", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OurTeamVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
