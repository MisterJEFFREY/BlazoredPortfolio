using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazoredPortfolio.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
//using System.Threading;

namespace BlazoredPortfolio.Pages.blog.blog_components.blog_pages {
    public partial class CmpBlog01 {


        #region Fields
        public bool _urlDataValid = true;
        public string _urlDataErrorMsg;
        #endregion (Fields)

        #region Methods
        ///////IMPORTANT METHODS TO RECIEVE COLOR THEMES DYNAMICALLY
        protected override async Task OnInitializedAsync() {
            if (!string.IsNullOrEmpty(UrlData)) {
                UrlData = UrlData.ToLower() ?? "";
                ////
                CheckUrlDataContext(UrlData);
            }

            OnParametersSet();
        }

        //THIS WILL RECIEVE THE LIGHT/DARK COLOR THEME VALUE
        //DYNAMICALLY AND WORKS W/OUT COOKIES.
        protected override void OnParametersSet() {

            //LASTLY, UPDATE THE COLOR THEME ON THE FLY!
            Color_Theme_Recieved = Layout.MainColorTheme;
        }


        public void CheckUrlDataContext(string tsUrlData) {
            if (tsUrlData.Contains("nt")) {
                IsNewTab = true;
            }

        }
        //IF USER OPENED THIS BLOG IN NEW PAGE...
        public void CloseTab() {
            if (IsNewTab == true) {
                JSRuntime.InvokeVoidAsync($"window.close");
            }
        }
        public void NavToBlogs() {
            if (IsNewTab == false) {
                NavManager.NavigateTo("/blog");
            }
        }
        //CONTACT THE JEFF ABOUT THIS BLOG IN PARTICULAR
        public void NavToContact(string tsRouteData) {
            if (!string.IsNullOrEmpty(tsRouteData)) {
                NavManager.NavigateTo(tsRouteData);
            }
        }

        //COPY URL TO CLIPBOARD TEST
        private async Task CopyUrlToClipboard() {
            string temp_url             = NavManager.Uri.ToString();
            var JSCopyResult            = await JSRuntime.InvokeAsync<object>("CopyURLToClipboard", temp_url);
            bool JSCopyResultBool       = Convert.ToBoolean(JSCopyResult.ToString());
            if (JSCopyResultBool == true) {
                URLCopyButtonText       = "Copied Blog URL! ";
                JustCopied2Clipboard    = true;
            } else {
                URLCopyButtonText       = "Copy URL Failed! ";
            }
            StateHasChanged();
            //NOTE TO SELF: USING VAR INSTEAD OF INT FOR TASK.DELAY WILL 
            //NOT DELAY THE TASK AS INTENDED! IN OTHER WORDS, IT WOULD BE IGNORED
            //& DELAYED UNTIL 2ND CLICK.
            var rand                    = new Random();
            int random_delay_amount     = rand.Next(1500, 2500);
            await Task.Delay(random_delay_amount);
            //ResetCopyURLButton();
            //Thread.Sleep(random_delay_amount);

            URLCopyButtonText = "Copy Blog URL ";
            JustCopied2Clipboard = false;
            //await JSRuntime.InvokeVoidAsync("CopyToClipboard");
        }

        public void Copy2ClipBoardResult(string tsJSResult) {

        }

        public void ResetCopyURLButton() {
            URLCopyButtonText = "Copy Blog URL ";
            JustCopied2Clipboard = false;
        }

        #endregion (Methods)


        #region Properties
        [CascadingParameter]
        public MainLayout Layout            { get; set; }
        public string Color_Theme_Recieved  { get; set; }

        [Parameter]
        public string? UrlData              { get; set; }
        public bool UrlDataValid            { get => _urlDataValid; set => _urlDataValid = value; }
        public bool IsNewTab                { get; set; } = false;

        public bool JustCopied2Clipboard    { get; set; } = false;
        public string URLCopyButtonText     { get; set; } = "Copy Blog URL ";
        #endregion (Properties)
    }
}
