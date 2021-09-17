using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazoredPortfolio.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazoredPortfolio.Pages.bounties.bounties_components {
    public partial class CmpBounty1 {


        #region Fields
        public int _slideShow_Index = 1;

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

        public void ReturnToBountyPage() {
            NavManager.NavigateTo("/bounties");
        }

        public void BountyContact() {
            NavManager.NavigateTo("/contact/bountynum1");
        }

        public void On_SlideShow_SRC(int tiSlideSrc) {
            //SINCE THIS BOUNTY ONLY HAS 8 IMAGES FOR ITS SLIDESHOW, CHECK AND REUSE THE INT VAR
            _slideShow_Index += tiSlideSrc;
            if (_slideShow_Index < 1) { _slideShow_Index = 1; }
            if (_slideShow_Index > 8) { _slideShow_Index = 8; }
            //if (tiSlideSrc == -1) {
            //    if (SlideShow_Index !< 2) {
            //        _slideShow_Index += tiSlideSrc;
                    
            //    }
            //} else {
            //    if (tiSlideSrc == 1) {
            //        if (SlideShow_Index !> 7) {
            //            _slideShow_Index += tiSlideSrc;
            //            if (_slideShow_Index > 8) { _slideShow_Index = 8; }
            //        }
            //    }
            //}
        }

        #endregion (Methods)


        #region Properties
        [CascadingParameter]
        public MainLayout Layout            { get; set; }
        public string Color_Theme_Recieved  { get; set; }
        
        //public string SlideShow_SRC         { get => _slideShow_SRC; set => On_SlideShow_SRC(value); }
        public int SlideShow_Index          { get => _slideShow_Index; set => On_SlideShow_SRC(value); }

        #endregion (Properties)

    }
}
