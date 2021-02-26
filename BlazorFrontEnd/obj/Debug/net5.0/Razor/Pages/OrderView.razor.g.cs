#pragma checksum "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb2df8df3f4c1567211855221112adbf8d3e4d93"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorFrontEnd.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\_Imports.razor"
using BlazorFrontEnd;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\_Imports.razor"
using BlazorFrontEnd.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor"
using BlazorFrontEnd.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/OrdersView")]
    public partial class OrderView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2 class=\"title\">View Bought items</h2>\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddMarkupContent(2, "\r\n    Filter By Name: ");
            __builder.OpenElement(3, "input");
            __builder.AddAttribute(4, "type", "text");
            __builder.AddAttribute(5, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 8 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor"
                                                   (arg)=>FilterByName(arg)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "style", "width: 150px");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 11 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor"
 if (orderToShow == null || orderToShow.Count != orders.Count)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(7, "<p><em>Loading....</em></p>");
#nullable restore
#line 16 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "row");
            __builder.AddMarkupContent(10, "<div class=\"col-3\"><h5>Buyer</h5></div>\r\n        ");
            __builder.AddMarkupContent(11, "<div class=\"col-3\"><h5>Item</h5></div>\r\n        ");
            __builder.AddMarkupContent(12, "<div class=\"col-3\"><h5>Date</h5></div>");
#nullable restore
#line 29 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor"
         foreach (var order in orderToShow)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "col-12");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "card");
            __builder.AddAttribute(17, "style", "width: 100%;");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "row");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "col-3");
            __builder.OpenElement(22, "p");
            __builder.AddAttribute(23, "class", "card-text");
            __builder.AddContent(24, 
#nullable restore
#line 35 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor"
                                                  order.nameOfBuyer

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n                        ");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "col-3");
            __builder.OpenElement(28, "p");
            __builder.AddContent(29, 
#nullable restore
#line 38 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor"
                                order.boughtItem.nameOfItem

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                        ");
            __builder.OpenElement(31, "div");
            __builder.AddAttribute(32, "class", "col-6");
            __builder.OpenElement(33, "p");
            __builder.AddContent(34, 
#nullable restore
#line 41 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor"
                                order.timeOfOrder

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 47 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 49 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 52 "A:\Rider\Projects\InternApplication\BlazorFrontEnd\Pages\OrderView.razor"
 
    public List<Order> orders;
    public List<Order> orderToShow;

    protected override async Task OnInitializedAsync()
    {
        orders = await OrderService.getAllOrdersAsync();
        orderToShow = orders;
        foreach (var order in orderToShow)
        {
            Console.WriteLine(order.nameOfBuyer + " " + order.boughtItem + " " + order.orderId + " " + order.timeOfOrder);
        }
        base.OnInitialized();
    }

    private void FilterByName(ChangeEventArgs changeEventArgs)
    {
        string? filterByName = null;
        try{
            filterByName = changeEventArgs.Value.ToString();
        }catch(Exception e){}
        if (!string.IsNullOrEmpty(filterByName))
        {
            orderToShow = orders.Where(o => o.nameOfBuyer.Equals(filterByName)).ToList();
        }
        else
        {
            orderToShow = orders;
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IOrderService OrderService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IItemService ItemService { get; set; }
    }
}
#pragma warning restore 1591
