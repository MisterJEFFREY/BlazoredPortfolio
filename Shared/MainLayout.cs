using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Blazored.LocalStorage;

namespace BlazoredPortfolio.Shared {
    public partial class MainLayout {
        #region Fields
        public string _mainColorTheme; /*= "Light"*/
        public bool _showCookieNotification;
        #endregion (Fields)


        #region Methods
        ///SESSION COOKIES TO AUTOMATICALLY SET COLOR THEME UPON APP INITILIAZING... 
        ///HLP SRC: https://www.syncfusion.com/faq/blazor/web-api/how-do-i-store-session-data-in-blazor-webassembly
        protected override async Task OnInitializedAsync() {
            var CheckSessionCookie = await localStore.GetItemAsync<string>("SAVED_COLOR_THEME");
            //await localStore.GetItemAsync
            if (!string.IsNullOrEmpty(CheckSessionCookie)) {
                Console.WriteLine("FOUND SESSION COOKIE!\nRECIEVED VALUE IS: " + CheckSessionCookie);
                _mainColorTheme = CheckSessionCookie;
                //IF CheckSessionCookie IS DARK, UPDATE CHECKBOX IN NAVMENU!
            } else {
                Console.WriteLine("COULD NOT FIND SPECIFED SESSION COOKIE!\nFLUSHING OUT SESSION STORAGE\nAND SETTING NEW SESSION COOKIE AS LIGHT THEME. ");
                await localStore.ClearAsync(); //JUST IN CASE
                await localStore.SetItemAsync("SAVED_COLOR_THEME", "Light");
                _mainColorTheme = "Light";
                _showCookieNotification = true;
            }
         }

        //UPDATE COLOR THEME ON THE FLY & CALLING COOKIE METHOD
        public void On_MainColorThemeChanged(string tsValue) {
            if (!String.IsNullOrEmpty(tsValue)) {
                _mainColorTheme = tsValue;
                UpdateSessionCookie(tsValue);
                //MyMethod();
            }
        }
        //CLEARING OUT SESSION STORAGE & UPDATING SESSION COOKIE
        public async Task UpdateSessionCookie(string tsValue) {
            Console.WriteLine("SETTING SAVED_COLOR_THEME COOKIE WITH VALUE OF: " + tsValue);
            await localStore.ClearAsync(); //JUST IN CASE
            await localStore.SetItemAsync("SAVED_COLOR_THEME", tsValue);
        }

        public void On_ShowCookieNotificationChanged(bool tbValue) {
            if (_showCookieNotification != tbValue) {
                    _showCookieNotification = tbValue;
            }
        }

        //See if this works to change html background color
        //async Task MyMethod() {
        //  await JSRuntime.InvokeAsync<string>("applyStyleForHtml",
        //      new { attrib = "background-color", value = "var(--light-body-color)" });
        //}
        #endregion (Methods)


        #region Properties
        [Parameter]
        public string MainColorTheme { get => _mainColorTheme; set => On_MainColorThemeChanged(value); }
        public bool ShowCookieNotification { get => _showCookieNotification; set => On_ShowCookieNotificationChanged(value); }

        #endregion (Properties)
    }
}
