#pragma checksum "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a83c363ee4259b60444bf5f97d7be60a8c355393"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Account_Profile), @"mvc.1.0.view", @"/Areas/Manage/Views/Account/Profile.cshtml")]
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
#line 2 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\_ViewImports.cshtml"
using Gosto.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\_ViewImports.cshtml"
using Gosto.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\_ViewImports.cshtml"
using Gosto.DAL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\_ViewImports.cshtml"
using Gosto.Areas.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\_ViewImports.cshtml"
using Gosto.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83c363ee4259b60444bf5f97d7be60a8c355393", @"/Areas/Manage/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a50b4107d4549ceff6851451623ad432a69621f1", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProfileVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Profile"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/manage/img/user/nulluser.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
  
    ViewData["Title"] = "Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n    <main id=\"main\" class=\"main\">\r\n\r\n        <div class=\"pagetitle\">\r\n            <h1>Profile</h1>\r\n            <nav>\r\n                <ol class=\"breadcrumb\">\r\n                    <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a83c363ee4259b60444bf5f97d7be60a8c3553936459", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                    <li class=""breadcrumb-item"">Users</li>
                    <li class=""breadcrumb-item active"">Profile</li>
                </ol>
            </nav>
        </div><!-- End Page Title -->

        <section class=""section profile"">
            <div class=""row"">
                <div class=""col-xl-4"">

                    <div class=""card"">
                        <div class=""card-body profile-card pt-4 d-flex flex-column align-items-center"">
");
#nullable restore
#line 28 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
                             if (Model.UserImage != null)
                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a83c363ee4259b60444bf5f97d7be60a8c3553938826", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 967, "~/manage/img/user/", 967, 18, true);
#nullable restore
#line 31 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
AddHtmlAttributeValue("", 985, Model.UserImage, 985, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 32 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a83c363ee4259b60444bf5f97d7be60a8c35539310803", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 36 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h2>");
#nullable restore
#line 38 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
                           Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                            <h3>");
#nullable restore
#line 39 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
                           Write(Model.Job);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                        </div>
                    </div>

                </div>

                <div class=""col-xl-8"">

                    <div class=""card"">
                        <div class=""card-body pt-3"">
                      
                            <div class=""tab-content pt-2"">

                                <div class=""tab-pane fade show active profile-overview"" >


                                    <h5 class=""card-title"">Profile Details</h5>

                                    <div class=""row"">
                                        <div class=""col-lg-3 col-md-4 label "">Name</div>
                                        <div class=""col-lg-9 col-md-8"">");
#nullable restore
#line 60 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
                                                                  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-lg-3 col-md-4 label "">User Name</div>
                                        <div class=""col-lg-9 col-md-8"">");
#nullable restore
#line 64 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
                                                                  Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-lg-3 col-md-4 label"">Job</div>
                                        <div class=""col-lg-9 col-md-8"">");
#nullable restore
#line 69 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
                                                                  Write(Model.Job);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-lg-3 col-md-4 label"">Country</div>
                                        <div class=""col-lg-9 col-md-8"">");
#nullable restore
#line 74 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
                                                                  Write(Model.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-lg-3 col-md-4 label"">Address</div>
                                        <div class=""col-lg-9 col-md-8"">");
#nullable restore
#line 79 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
                                                                  Write(Model.Adress);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-lg-3 col-md-4 label"">Phone</div>
                                        <div class=""col-lg-9 col-md-8"">");
#nullable restore
#line 84 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
                                                                  Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-lg-3 col-md-4 label"">Email</div>
                                        <div class=""col-lg-9 col-md-8"">");
#nullable restore
#line 89 "C:\Users\ROG\source\repos\Gosto\Gosto\Areas\Manage\Views\Account\Profile.cshtml"
                                                                  Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>

                                </div>

                         


                         

                            </div><!-- End Bordered Tabs -->

                        </div>
                    </div>

                </div>
            </div>
        </section>

    </main><!-- End #main -->



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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProfileVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
