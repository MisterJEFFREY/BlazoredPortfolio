﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazoredPortfolio.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazoredPortfolio.Pages.blog.blog_components {
    public partial class CmpBlogYear2021Menu {

        #region Fields

        #endregion (Fields)

        #region Methods
        ///////IMPORTANT METHODS TO RECIEVE COLOR THEMES DYNAMICALLY
        protected override async Task OnInitializedAsync() {
            OnParametersSet();
        }

        //THIS WILL RECIEVE THE LIGHT/DARK COLOR THEME VALUE
        //DYNAMICALLY AND WORKS W/OUT COOKIES.
        protected override void OnParametersSet() {

            //LASTLY, UPDATE THE COLOR THEME ON THE FLY!
            Color_Theme_Recieved = Layout.MainColorTheme;
        }

        public void NavToBlogPage(string tsRouteData) {
            if (!string.IsNullOrEmpty(tsRouteData)) {
                NavManager.NavigateTo("/blog/" + tsRouteData);
            }
        }

        public async Task NavToBlogPageNTAsync(string tsRouteData) {
            if (!string.IsNullOrEmpty(tsRouteData)) {
                await JSRuntime.InvokeAsync<object>("open", "blog/" + tsRouteData, "_blank");
                //NavManager.NavigateTo("/blog/" + tsRouteData);
            }
        }

        #endregion (Methods)


        #region Properties
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        public string Color_Theme_Recieved { get; set; }
        #endregion (Properties)


    }
}
