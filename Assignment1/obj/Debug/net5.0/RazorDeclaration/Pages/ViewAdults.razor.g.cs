// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Assignment1.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\C#Projetcs\Assignment1\Assignment1\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\C#Projetcs\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\C#Projetcs\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\C#Projetcs\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\C#Projetcs\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\C#Projetcs\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\C#Projetcs\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\C#Projetcs\Assignment1\Assignment1\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\C#Projetcs\Assignment1\Assignment1\_Imports.razor"
using Assignment1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\C#Projetcs\Assignment1\Assignment1\_Imports.razor"
using Assignment1.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\C#Projetcs\Assignment1\Assignment1\Pages\ViewAdults.razor"
using Assignment1.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\C#Projetcs\Assignment1\Assignment1\Pages\ViewAdults.razor"
using Assignment1.Model;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/ViewAdults")]
    public partial class ViewAdults : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 73 "F:\C#Projetcs\Assignment1\Assignment1\Pages\ViewAdults.razor"
      
    private IList<Adult> allAduts;
    private IList<Adult> adultsToShow;

    private string? searchByName;
    private string? filterByGender;

    private void SearchByName(ChangeEventArgs changeEventArgs)
    {
        searchByName = null;
        try
        {
            searchByName = changeEventArgs.Value.ToString();
        }
        catch (Exception e)
        {}
        if (searchByName != null)
        {
            adultsToShow = allAduts.Where(adult => adult.FirstName.Equals(searchByName)).ToList();
            
        }
        else
        {
            adultsToShow = allAduts;
        }
    }

    private void FilterByGender(ChangeEventArgs changeeventArgs)
    {
        filterByGender = null;
        try
        {
            filterByGender = changeeventArgs.Value.ToString();
        }
        catch (Exception e)
        {}
        if (filterByGender != null)
        {
            adultsToShow = allAduts.Where(adult => adult.Sex.Equals(filterByGender, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        else
        {
            adultsToShow = allAduts;
        }
    }
    private void RemoveAdult(int itemId)
    {
        Adult adultToremove = allAduts.First(adult => adult.Id == itemId);
        AdultsData.RemoveAdult(itemId);
        allAduts.Remove(adultToremove);
        adultsToShow.Remove(adultToremove);

    }
    

   


    protected override async Task OnInitializedAsync()
    {
        allAduts = AdultsData.GetAdults();
        adultsToShow = allAduts;
    }
    
    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAdultsData AdultsData { get; set; }
    }
}
#pragma warning restore 1591
