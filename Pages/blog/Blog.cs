using System;
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
        protected override async Task OnInitializedAsync() {
            OnParametersSet();
        }

        //THIS WILL RECIEVE THE LIGHT/DARK COLOR THEME VALUE
        //DYNAMICALLY AND WORKS W/OUT COOKIES.
        protected override void OnParametersSet() {
            Color_Theme_Recieved = Layout.MainColorTheme;
        }
        //////////////////////////////////////////////////////////////
        public void ChangeBlog2021ButtonText() {
            if (Blog2021ButtonText != "Show 2021 Blog Entries") {
                Blog2021ButtonText = "Show 2021 Blog Entries";
                return;
            } else if (Blog2021ButtonText == "Show 2021 Blog Entries") {
                Blog2021ButtonText = "Hide 2021 Blog Entries";
                return;
            }
        }

        public void ChangeBlog2022ButtonText() {
            if (Blog2022ButtonText != "Show 2022 Blog Entries") {
                Blog2022ButtonText = "Show 2022 Blog Entries";
                return;
            } else if (Blog2022ButtonText == "Show 2022 Blog Entries") {
                Blog2022ButtonText = "Hide 2022 Blog Entries";
                return;
            }
        }
        #endregion (Methods)


        #region Properties
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        public string Color_Theme_Recieved { get; set; }

        public string Blog2021ButtonText { get; set; } = "Show 2021 Blog Entries";
        public string Blog2022ButtonText { get; set; } = "Show 2022 Blog Entries";
        #endregion (Properties)
    }
}
