using BlazoredPortfolio.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazoredPortfolio {
    public partial class App {

        #region Methods
        ///////IMPORTANT METHODS TO RECIEVE COLOR THEMES DYNAMICALLY
        protected override void OnInitialized() {
            OnParametersSet();
        }

        //THIS WILL RECIEVE THE LIGHT/DARK COLOR THEME VALUE
        //DYNAMICALLY AND WORKS W/OUT COOKIES.
        protected override void OnParametersSet() {
            Color_Theme_Recieved = Layout.MainColorTheme;
        }
        #endregion (Methods)
        //////////////////////////////////////////////////////////////


        #region Fields

        #endregion (Fields)
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        public string Color_Theme_Recieved { get; set; }


    }
}
