#pragma checksum "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6ceace0a06f59faf2f7d9ea68df4826a1d6ce88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Services_Services), @"mvc.1.0.view", @"/Views/Services/Services.cshtml")]
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
#line 1 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\_ViewImports.cshtml"
using CarShop.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6ceace0a06f59faf2f7d9ea68df4826a1d6ce88", @"/Views/Services/Services.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59be5c10ddd30bb590049d453c15e717ae9b64e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Services_Services : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h3>Наші послуги, які входять у вартість нашої комісіі:</h3>\r\n<div class=\"row\">\r\n    <div class=\"p-5 rounded\" style=\"background-color:black; color:lightgray\">\r\n        <abbr style=\"color:cornflowerblue\">1. Участь у аукцiонi</abbr><br />\r\n");
#nullable restore
#line 5 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <abbr>");
#nullable restore
#line 7 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
             Write(item.Auction);

#line default
#line hidden
#nullable disable
            WriteLiteral("</abbr>\r\n");
#nullable restore
#line 8 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <hr />\r\n\r\n    <div class=\"p-5 rounded\" style=\"background-color:black; color:lightgray\">\r\n        <abbr style=\"color:cornflowerblue\">2. Доставка авто по терiторii США</abbr><br />\r\n");
#nullable restore
#line 14 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <abbr>");
#nullable restore
#line 16 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
             Write(item.DeliveryUSA);

#line default
#line hidden
#nullable disable
            WriteLiteral("</abbr>\r\n");
#nullable restore
#line 17 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <hr />\r\n\r\n    <div class=\"p-5 rounded\" style=\"background-color:black; color:lightgray\">\r\n        <abbr style=\"color:cornflowerblue\">3. Доставка авто з США в Україну</abbr><br />\r\n");
#nullable restore
#line 24 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <abbr>");
#nullable restore
#line 26 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
             Write(item.DeliveryUSA_Ukraine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</abbr>\r\n");
#nullable restore
#line 27 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <hr />\r\n\r\n    <div class=\" p-5 rounded\" style=\"background-color:black; color:lightgray\">\r\n        <abbr style=\"color:cornflowerblue\">4. Розмитнення</abbr><br />\r\n");
#nullable restore
#line 34 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <abbr>");
#nullable restore
#line 36 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
             Write(item.Customs_Clearance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</abbr>\r\n");
#nullable restore
#line 37 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <hr />\r\n\r\n    <div class=\"p-5 rounded\" style=\"background-color:black; color:lightgray\">\r\n        <abbr style=\"color:cornflowerblue\">5. Доставка авто до вашого місця проживання</abbr><br />\r\n");
#nullable restore
#line 44 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <abbr>");
#nullable restore
#line 46 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
             Write(item.Delivery_InCity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</abbr>\r\n");
#nullable restore
#line 47 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <hr />\r\n\r\n    <div class=\"p-5 rounded\" style=\"background-color:black; color:lightgray\">\r\n        <abbr style=\"color:cornflowerblue\">6. Ремонт</abbr><br />\r\n");
#nullable restore
#line 54 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <abbr>");
#nullable restore
#line 56 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
             Write(item.Repairy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</abbr>\r\n");
#nullable restore
#line 57 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <hr />\r\n\r\n    <div class=\"p-5 rounded\" style=\"background-color:black; color:lightgray\">\r\n        <abbr style=\"color:cornflowerblue\">7. Постановка на облік</abbr><br />\r\n");
#nullable restore
#line 64 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <abbr>");
#nullable restore
#line 66 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
             Write(item.Registration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</abbr>\r\n");
#nullable restore
#line 67 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <hr />\r\n\r\n    <div class=\"p-5 rounded\" style=\"background-color:black; color:lightgray\">\r\n        <abbr style=\"color:cornflowerblue\">8. Детейлінг сервіс</abbr><br />\r\n");
#nullable restore
#line 74 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <abbr>");
#nullable restore
#line 76 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
             Write(item.Detailing);

#line default
#line hidden
#nullable disable
            WriteLiteral("</abbr>\r\n");
#nullable restore
#line 77 "C:\Users\PortRed\source\repos\CarShop\CarShop\Views\Services\Services.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <hr />\r\n\r\n</div>");
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