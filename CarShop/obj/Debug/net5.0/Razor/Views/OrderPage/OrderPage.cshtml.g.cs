#pragma checksum "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f2a6be3721816718e57d7382a9054341a5b9252"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OrderPage_OrderPage), @"mvc.1.0.view", @"/Views/OrderPage/OrderPage.cshtml")]
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
#line 1 "C:\Projects\CarShop\CarShop\Views\_ViewImports.cshtml"
using CarShop.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f2a6be3721816718e57d7382a9054341a5b9252", @"/Views/OrderPage/OrderPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59be5c10ddd30bb590049d453c15e717ae9b64e2", @"/Views/_ViewImports.cshtml")]
    public class Views_OrderPage_OrderPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CarShop.Domain.Layer.Car>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("needs-validation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/OrderPage/Order"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/sale-tag.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("30"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("padding: 0px 10px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-4"">
        <div class=""panel"" style=""background-color: black; color: lightgray; height: 700px"">
            <div class=""panel-heading"">Заповніть будь ласка свої дані:</div>
            <div class=""panel-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f2a6be3721816718e57d7382a9054341a5b92525021", async() => {
                WriteLiteral("\r\n                    <label for=\"firstName\" class=\"form-label\">Ім\'я</label><br />\r\n                    <input type=\"text\" class=\"form-control\" id=\"firstName\" name=\"FirstName\"");
                BeginWriteAttribute("required", " required=\"", 556, "\"", 567, 0);
                EndWriteAttribute();
                WriteLiteral("><br />\r\n\r\n                    <label for=\"lastName\" class=\"form-label\">Прізвище</label><br />\r\n                    <input type=\"text\" class=\"form-control\" id=\"lastName\" name=\"LastName\"");
                BeginWriteAttribute("required", " required=\"", 753, "\"", 764, 0);
                EndWriteAttribute();
                WriteLiteral("><br />\r\n\r\n                    <label for=\"phone\" class=\"form-label\">Телефон<span class=\"text-muted\"></span></label><br />\r\n                    <input type=\"text\" class=\"form-control\" id=\"email\" placeholder=\"В форматі (099)888-99-99\" name=\"Phone\"");
                BeginWriteAttribute("required", " required=\"", 1011, "\"", 1022, 0);
                EndWriteAttribute();
                WriteLiteral("><br />\r\n\r\n                    <label for=\"address\" class=\"form-label\">Поштова адреса</label><br />\r\n                    <input type=\"email\" class=\"form-control\" id=\"email\" placeholder=\"order@gmail.com\"");
                BeginWriteAttribute("required", " required=\"", 1225, "\"", 1236, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"Email\"><br />\r\n\r\n                    <label for=\"city\" class=\"form-label\">Місто</label><br />\r\n                    <input type=\"text\" class=\"form-control\" id=\"address\" placeholder=\"Київ\"");
                BeginWriteAttribute("required", " required=\"", 1430, "\"", 1441, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"City\"><br />\r\n\r\n                    <label for=\"country\" class=\"form-label\">Код автомобіля</label><br />\r\n");
#nullable restore
#line 26 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                       
                        bool on_off = false;
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                    \r\n");
#nullable restore
#line 30 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                    foreach (var item in Model)
                    {
                        on_off = true;

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input type=\"text\" class=\"form-control\" id=\"address\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1859, "\"", 1881, 1);
#nullable restore
#line 33 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
WriteAttributeValue("", 1873, item.Id, 1873, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("required", " required=\"", 1882, "\"", 1893, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"CarId\"><br />\r\n");
#nullable restore
#line 34 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                    if (!on_off)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input type=\"text\" class=\"form-control\" id=\"address\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 2072, "\"", 2086, 0);
                EndWriteAttribute();
                BeginWriteAttribute("required", " required=\"", 2087, "\"", 2098, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"CarId\"><br />\r\n");
#nullable restore
#line 38 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    <button class=\"btn btn-success btn-md\" type=\"submit\">Залишити заявку</button>\r\n                    <br />\r\n                    <br />\r\n");
#nullable restore
#line 43 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                    if (ViewBag.OperationOK != null)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <abbr>");
#nullable restore
#line 45 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                         Write(ViewBag.OperationOK);

#line default
#line hidden
#nullable disable
                WriteLiteral("</abbr>\r\n");
#nullable restore
#line 46 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 53 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
    foreach (var car in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-md-4"">
            <div class=""panel"" style=""background-color: black; color: lightgray; height: 550px"">
             
                   <div class=""panel-body"">
                       <div class=""photo"">
                          <img");
            BeginWriteAttribute("src", " src=\"", 2840, "\"", 2858, 1);
#nullable restore
#line 60 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
WriteAttributeValue("", 2846, car.Picture, 2846, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"position:center\" class=\"img-responsive cars_photo\"/><br />\r\n                       </div>\r\n\r\n                       <abbr>\r\n                           Марка авто: ");
#nullable restore
#line 64 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                                  Write(car.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                           Модель: ");
#nullable restore
#line 65 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                              Write(car.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                           Рік випуску: ");
#nullable restore
#line 66 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                                   Write(car.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                           Колір: ");
#nullable restore
#line 67 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                             Write(car.Color);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                           Тип двигуна: ");
#nullable restore
#line 68 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                                   Write(car.Engine);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                           Короба : ");
#nullable restore
#line 69 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                               Write(car.Transmission);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                           Тип кузова : ");
#nullable restore
#line 70 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                                   Write(car.TypeofCar);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                           Пробіг: ");
#nullable restore
#line 71 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                              Write(car.Mileage);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                           Наявність: ");
#nullable restore
#line 72 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                                 Write(car.CarInStock);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                           Участь в ДТП : ");
#nullable restore
#line 73 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                                     Write(car.CarAccident);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                           <a style=\"color:royalblue\">Код автомобіля: </a>");
#nullable restore
#line 74 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                                                                     Write(car.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 75 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                           if (car.Price == ViewBag.PriceWithSale)
                           {

#line default
#line hidden
#nullable disable
            WriteLiteral("                               <a style=\"color:green\">Ціна: ");
#nullable restore
#line 77 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                                                       Write(car.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $ </a><br />\r\n");
#nullable restore
#line 78 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                           }
                           else
                           {

#line default
#line hidden
#nullable disable
            WriteLiteral("                               <s style=\"color:red\">Ціна: ");
#nullable restore
#line 81 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                                                     Write(car.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $ </s><br /><a style=\"color:green\">Ціна зі знижкою: ");
#nullable restore
#line 81 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                                                                                                                    Write(ViewBag.PriceWithSale);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $</a>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5f2a6be3721816718e57d7382a9054341a5b925216964", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
#line 82 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("                       </abbr>\r\n\r\n                   </div>\r\n            </div>\r\n    \r\n        </div>\r\n");
#nullable restore
#line 89 "C:\Projects\CarShop\CarShop\Views\OrderPage\OrderPage.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CarShop.Domain.Layer.Car>> Html { get; private set; }
    }
}
#pragma warning restore 1591
