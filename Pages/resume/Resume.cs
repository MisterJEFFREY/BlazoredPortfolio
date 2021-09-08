using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazoredPortfolio.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazoredPortfolio.Pages.resume {
    public partial class Resume {


        #region Fields

        #endregion (Fields)


        #region Methods
        protected override async Task OnInitializedAsync() {
            OnParametersSet();
        }
        //THIS WILL RECIEVE THE LIGHT/DARK COLOR THEME VALUE
        //DYNAMICALLY AND WORKS W/OUT COOKIES.
        protected override void OnParametersSet() {
            Color_Theme_Recieved = Layout.MainColorTheme;
        }

        public void PasswordResumeAccess() {
            if (!AttemptResumeAccess) { 
                AttemptResumeAccess = true;
            }
        }

        public void ResumeContact() {
            //TODO: SET BLAZOR COOKIE HERE 
            //AND IF USER HAS COOKIES DISABLED, USER CAN STILL
            //ACCESS THE CONTACT PAGE
            NavManager.NavigateTo("/contact");
        }
        #endregion (Methods)


        #region Properties
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        public string Color_Theme_Recieved { get; set; }

        public bool AttemptResumeAccess { get; set; } = false;
        #endregion (Properties)

    }
}
