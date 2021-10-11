using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazoredPortfolio.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazoredPortfolio.Shared {
    public partial class Cmp404 {
        #region Methods
        //////IMPORTANT METHODS TO RECIEVE COLOR THEMES DYNAMICALLY
        //protected override async Task OnInitializedAsync() {
        //    OnParametersSet();
        //}

        ////THIS WILL RECIEVE THE LIGHT/DARK COLOR THEME VALUE
        ////DYNAMICALLY AND WORKS W/OUT COOKIES.
        protected override void OnParametersSet() {
            Color_Theme_Recieved = Layout.MainColorTheme;
            InvalidURL = NavManager.Uri.ToString();
        }
        //////////////////////////////////////////////////////////////
        #endregion (Methods)


        #region Properties
        [CascadingParameter]
        public MainLayout Layout { get; set; } 
        public string Color_Theme_Recieved { get; set; }
        public string InvalidURL { get; set; }

        #endregion (Properties)
    }
}
