#pragma checksum "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89f61c54b44c96f652b95035202c3b5ed75ef622"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_About_Index), @"mvc.1.0.view", @"/Views/About/Index.cshtml")]
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
using Gosto.ComponentViewModels.Header;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\_ViewImports.cshtml"
using Gosto.ViewComponents;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89f61c54b44c96f652b95035202c3b5ed75ef622", @"/Views/About/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2138b3aba4b0a0ac261de5053b7f8111c097da55", @"/Views/_ViewImports.cshtml")]
    public class Views_About_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AboutVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"overflow-hidden\">\r\n    <div class=\"headd text-center\"");
            BeginWriteAttribute("style", " style=\"", 128, "\"", 206, 4);
            WriteAttributeValue("", 136, "background-image:", 136, 17, true);
            WriteAttributeValue(" ", 153, "url(\'/assets/img/Our-team/", 154, 27, true);
#nullable restore
#line 7 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
WriteAttributeValue("", 180, Model.HiGosto.BackImage, 180, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 204, "\')", 204, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"inffo\">\r\n                    <h4 data-aos=\"fade-down\">Hi, Gosto Store</h4>\r\n                    <h1 class=\"team-title\" data-aos=\"fade-left\">");
#nullable restore
#line 12 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                                                           Write(Model.HiGosto.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                    <p class=\"team-description\" data-aos=\"fade-right\">\r\n                        ");
#nullable restore
#line 14 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                   Write(Model.HiGosto.Description);

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

<section class=""overflow-hidden"">
    <div class=""welcome"" style=""background-image:url('/assets/img/About/bg_about.jpg') ;"">
        <div class=""container"" data-aos=""fade-left"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""modern pt-4"">
                        <h5 class=""fw-bold"">WELCOME TO GOSTO STORE</h5>
                        <h3 class=""fw-bold"">");
#nullable restore
#line 29 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                                       Write(Model.WelcomeGosto.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <p>\r\n                          ");
#nullable restore
#line 31 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                     Write(Model.WelcomeGosto.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                        <div class=\"founder\"> <h5 class=\"creater-name d-inline fw-bold\">Algistino</h5> <span");
            BeginWriteAttribute("class", " class=\"", 1380, "\"", 1388, 0);
            EndWriteAttribute();
            WriteLiteral(@">-   Founder Of Gosto Store</span>  </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>


<section class=""overflow-hidden"">
    <div class=""services"" data-aos=""fade-right"">
        <div class=""container"">
            <div class=""col-lg-12"">
                <div class=""all text-center"">
                    <h5 class=""fw-bold"">WHAT WE OFFER SERVICES</h5>
                    <h3 class=""fw-bold"">AMAZING PERFORMANCE</h3>
                    <p>Commodo sociosqu venenatis cras dolor sagittis integer luctus maecenas.</p>
                </div>
            </div>
        </div>
    </div>
</section>

<section class=""overflow-hidden"">
    <div class=""performance"" data-aos=""fade-up"">

        <div class=""containerr"">
            <div class=""row"">


");
#nullable restore
#line 63 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                 foreach (var service in Model.Services)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-lg-4\">\r\n                        <div class=\"card\">\r\n                            <div class=\"img\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "89f61c54b44c96f652b95035202c3b5ed75ef6229158", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2482, "~/assets/img/About/", 2482, 19, true);
#nullable restore
#line 68 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
AddHtmlAttributeValue("", 2501, service.Image, 2501, 14, false);

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
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-body\">\r\n                                <h5 class=\"card-title\">");
#nullable restore
#line 71 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                                                  Write(service.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <p class=\"card-text\">\r\n                                    ");
#nullable restore
#line 73 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                               Write(service.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 79 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"




            </div>
        </div>
    </div>
</section>

<section class=""overflow-hidden"">
    <div class=""texnology"" data-aos=""fade-right"">
        <div class=""container"">
            <div class=""col-lg-12"">
                <div class=""all text-center"">
                    <h5 class=""fw-bold"">TECHNOLOGY INDEX</h5>
                    <h3 class=""fw-bold"">LET’S GET CREATIVE</h3>
                    <p>Commodo sociosqu venenatis cras dolor sagittis integer luctus maecenas.</p>
                </div>
            </div>
        </div>
        </div>
</section>

<section class=""overflow-hidden"">
    <div class=""creative"" data-aos=""fade-up"">
        <div class=""containerr"">
            <div class=""row"">
");
#nullable restore
#line 108 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                 foreach (var texnology in Model.Texnologies)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-lg-6\">\r\n                        <div class=\"card\">\r\n                            <div class=\"img\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "89f61c54b44c96f652b95035202c3b5ed75ef62213088", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3982, "~/assets/img/About/", 3982, 19, true);
#nullable restore
#line 113 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
AddHtmlAttributeValue("", 4001, texnology.Image, 4001, 16, false);

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
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-body d-flex\">\r\n                                <div class=\"left\">\r\n                                    <h5 class=\"card-title\">");
#nullable restore
#line 117 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                                                      Write(texnology.Title1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                    <p class=\"card-text\">");
#nullable restore
#line 118 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                                                    Write(texnology.Description1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </div>\r\n                                <div class=\"right\">\r\n                                    <h5 class=\"card-title\">");
#nullable restore
#line 121 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                                                      Write(texnology.Title2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                    <p class=\"card-text\">");
#nullable restore
#line 122 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                                                    Write(texnology.Description2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 127 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


            </div>
        </div>
    </div>
</section>

<section class=""overflow-hidden"">
    <div class=""brand"" data-aos=""fade-left"">
        <div class=""container"">
            <div class=""col-lg-12"">
                <div class=""all text-center"">
                    <h5 class=""fw-bold"">WHO OUR CLIENTS</h5>
                    <h3 class=""fw-bold"">OUR IMPORTANT PARTNERS</h3>
                    <p>Commodo sociosqu venenatis cras dolor sagittis integer luctus maecenas.</p>
                </div>
            </div>
        </div>
    </div>
</section>


<section class=""overflow-hidden"">
    <div class=""brand-list py-5 pb-5"" data-aos=""fade-up"">
        <div class=""containerr"">
            <div class=""d-flex flex-wrap"">
");
#nullable restore
#line 155 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                 foreach (var brand in Model.Brands)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-lg-4 col-4\">\r\n\r\n                        <div class=\"img\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "89f61c54b44c96f652b95035202c3b5ed75ef62217803", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5749, "~/assets/img/Brand/", 5749, 19, true);
#nullable restore
#line 160 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
AddHtmlAttributeValue("", 5768, brand.Image, 5768, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n\r\n                    </div>\r\n");
#nullable restore
#line 164 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"



            </div>
        </div>
    </div>
</section>

<section class=""overflow-hidden"">
    <div class=""location"" data-aos=""fade-right"">
        <div class=""container"">
            <div class=""col-lg-12"">
                <div class=""all text-center"">
                    <h5 class=""fw-bold"">LOCATION STORE</h5>
                    <h3 class=""fw-bold"">LOOKING FOR GOSTO</h3>
                    <p>Commodo sociosqu venenatis cras dolor sagittis integer luctus maecenas.</p>
                </div>
            </div>
        </div>
    </div>
</section>

<section class=""overflow-hidden"">
    <div class=""gosto-location"" data-aos=""fade-up"">

        <div class=""containerr"">
            <div class=""row"">
");
#nullable restore
#line 193 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                 foreach (var location in Model.Locations)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-lg-4\">\r\n                        <div class=\"card\">\r\n                            <div class=\"img\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "89f61c54b44c96f652b95035202c3b5ed75ef62220908", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6887, "~/assets/img/About/", 6887, 19, true);
#nullable restore
#line 198 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
AddHtmlAttributeValue("", 6906, location.Image, 6906, 15, false);

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
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"card-body\">\r\n                                <h5 class=\"card-title city-name\">");
#nullable restore
#line 201 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                                                            Write(location.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <p class=\"card-text gosto-adress\"><span>Add: </span>");
#nullable restore
#line 202 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                                                                               Write(location.Adress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p class=\"card-text gosto-phone\"><span>Phone: </span>");
#nullable restore
#line 203 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                                                                                Write(location.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p class=\"card-text gosto-email\"><span>Email: </span>");
#nullable restore
#line 204 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"
                                                                                Write(location.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 208 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\About\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"




            </div>
        </div>
    </div>
</section>

<section class=""overflow-hidden"">
    <div class=""gosto-info"" data-aos=""fade-up"">
        <div class=""containerr"">
            <div class=""row"">

                <div class=""col-lg-4"">
                    <div class=""pro"">
                        <h4><i class=""fa-regular fa-circle""></i></h4>
                        <h5>ORIGINAL PRODUCTS</h5>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""pro"">
                        <h4><i class=""fa-regular fa-circle""></i></h4>
                        <h5>ORIGINAL PRODUCTS</h5>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                    </div>
   ");
            WriteLiteral(@"             </div>
                <div class=""col-lg-4"">
                    <div class=""pro"">
                        <h4><i class=""fa-regular fa-circle""></i></h4>
                        <h5>FREE SHIPPING</h5>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AboutVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
