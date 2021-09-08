﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazoredPortfolio.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazoredPortfolio.Pages.blog {
    public partial class Blog {


        #region Fields

        #endregion (Fields)


        #region Methods
        //////IMPORTANT METHODS TO RECIEVE COLOR THEMES DYNAMICALLY
        protected override async Task OnInitialized() {
            OnParametersSet();
        }

        //THIS WILL RECIEVE THE LIGHT/DARK COLOR THEME VALUE
        //DYNAMICALLY AND WORKS W/OUT COOKIES.
        protected override void OnParametersSet() {
            Color_Theme_Recieved = Layout.MainColorTheme;
        }
        //////////////////////////////////////////////////////////////
        #endregion (Methods)


        #region Properties
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        public string Color_Theme_Recieved { get; set; }

        #endregion (Properties)
    }
}
