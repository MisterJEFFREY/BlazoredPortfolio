using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazoredPortfolio.Shared;
using Microsoft.AspNetCore.Components;
using Blazored.Video;
using Blazored.Video.Support;

namespace BlazoredPortfolio.Pages.coding.coding_components.games_components {
    public partial class CmpGame1 {

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

        public void ReturnToCodePage() {
            NavManager.NavigateTo("/coding");
        }

        public void GameContact() {
            NavManager.NavigateTo("/contact/game1");
        }

        public void On_SlideShow_SRC(int tiSlideSrc) {
            //SINCE THIS GAME ONLY HAS 4 IMAGES FOR ITS SLIDESHOW, CHECK AND REUSE THE INT VAR
            _slideShow_Index += tiSlideSrc;
            if (_slideShow_Index < 1) { _slideShow_Index = 1; }
            if (_slideShow_Index > 4) { _slideShow_Index = 4; }

        }

        public void VideoIsReady(VideoState state) {
            //toObject.
            VideoLoaded = true;
            //return toObject;
            //return;
        }

        public void VideoErrorEvent(VideoState state) {
            //var currentvideo = state.Error;
            VideoError = true;
        }
        #endregion (Methods)


        #region Properties
        [CascadingParameter]
        public MainLayout Layout            { get; set; }
        public string Color_Theme_Recieved  { get; set; }

        //public string SlideShow_SRC         { get => _slideShow_SRC; set => On_SlideShow_SRC(value); }
        public int SlideShow_Index          { get => _slideShow_Index; set => On_SlideShow_SRC(value); }

        public bool VideoLoaded             { get; set; } = false;
        public bool VideoError              { get; set; } = false;

        #endregion (Properties)

    }
}
