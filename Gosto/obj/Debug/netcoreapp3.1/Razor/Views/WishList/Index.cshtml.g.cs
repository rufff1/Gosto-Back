#pragma checksum "C:\Users\ROG\source\repos\Gosto\Gosto\Views\WishList\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80f138ad41c4056d282b08fd2bce2fe695bf203e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WishList_Index), @"mvc.1.0.view", @"/Views/WishList/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80f138ad41c4056d282b08fd2bce2fe695bf203e", @"/Views/WishList/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"383323114719f8cb590d7dc7cc259758cbb41db5", @"/Views/_ViewImports.cshtml")]
    public class Views_WishList_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\ROG\source\repos\Gosto\Gosto\Views\WishList\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section id=""head-wish"">
    <div class=""container"">

        <div class=""col-lg-12 pop"">
            <h2>Product</h2>
            <h2 class=""bb"">Name</h2>
            <h2 class=""aa"">Count</h2>
            <h2>Price</h2>
        </div>
    </div>
</section>
<section id=""wish"">
    <div class=""container"">
        <div class=""row"">
            <div id=""wish-list"">

            </div>
        </div>
    </div>
</section>

<section>
    <div class=""container"">
        <div");
            BeginWriteAttribute("class", " class=\"", 541, "\"", 549, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"calcu\">\r\n\r\n        </div>\r\n\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
