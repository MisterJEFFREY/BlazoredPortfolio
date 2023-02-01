using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using BlazoredPortfolio.Shared;
using BlazoredPortfolio.Pages.contact;
using Microsoft.JSInterop;

namespace BlazoredPortfolio.Shared {
    public partial class NavMenu {

        #region Fields
        public string colorTheme;
        public string _colorThemeDisplayText;

        #endregion (Fields)


        #region Methods

        //IF COOKIE WAS FOUND AND IT IS DARK, PLEASE AUTO CHECK THE CHECKBOX UPON PAGE LOAD...
        protected override async Task OnInitializedAsync() {
            var CheckSessionCookie = await localStore.GetItemAsync<string>("SAVED_COLOR_THEME");
            if (!string.IsNullOrEmpty(CheckSessionCookie)) {
                Console.WriteLine("\nCHECKED FOR SESSION SESSION COOKIE AND IT IS: " + CheckSessionCookie);
                if (CheckSessionCookie == "Dark") {
                    Console.WriteLine("\nRETURNING TRUE FOR DARK!");
                    ColorThemeInitiallyChecked = true;
                } else {
                    Console.WriteLine("\nRETURNING FALSE FOR DARK!");
                    ColorThemeInitiallyChecked = false;
                }
            }
        }

        protected override void OnParametersSet() {
            CurrentURL = NavManager.Uri.ToString();
            //IF DEPLOYING LOCALLY...
            if (CurrentURL.Contains("44346")) {
                var TrimmedURL = CurrentURL.Substring(CurrentURL.IndexOf("44346") + 1);
                if (TrimmedURL.Contains("/contact")) {
                    DisabledContact = true;
                } else {
                    DisabledContact = false;
                }
                return;
            }

            //IF DEPLOYING ONLINE...
            if (CurrentURL.Contains(".site")) {
                var TrimmedURL = CurrentURL.Substring(CurrentURL.IndexOf(".site") + 1);
                if (TrimmedURL.Contains("/contact")) {
                    DisabledContact = true;
                } else {
                    DisabledContact = false;
                }
                return;
            } else {
                DisabledContact = false;
                return;
            }


            //if (CurrentURL.Contains("/contact")) {
            //    DisabledContact = true;
            //} else {
            //    DisabledContact = false;
            //}
        }
        //protected override void OnParametersSet() {
        //    CurrentURL = NavManager.Uri.ToString();
        //    if (CurrentURL.Contains("contact")) {
        //        DisabledContact = true;
        //    } else {
        //        DisabledContact = false;
        //    }
        //}
        //public async Task<bool> CheckForDarkThemeCookie() {

        //    var CheckSessionCookie = await localStore.GetItemAsync<string>("SAVED_COLOR_THEME");
        //    if (!string.IsNullOrEmpty(CheckSessionCookie)) {
        //        Console.WriteLine("\nCHECKED FOR SESSION SESSION COOKIE AND IT IS: " + CheckSessionCookie);
        //        if (CheckSessionCookie == "Dark") {
        //            Console.WriteLine("\nRETURNING TRUE FOR DARK!");
        //            return true;
        //        } else {
        //            Console.WriteLine("\nRETURNING FALSE FOR DARK!");
        //            return false;
        //        }
        //    }
        //    Console.WriteLine("\nAM I SUPPOSED TO BE RETURNING?");
        //    return false ;
        //}

        async Task ToggleThemeSwitch(string tbColorThemeToggle) {
            ColorThemeInitiallyChecked = Convert.ToBoolean(tbColorThemeToggle);
            //CHECK IF THE THEME TOGGLE IS ACTUALLY CHECKED
            if (tbColorThemeToggle == "True") {
                await ColorThemeChanged.InvokeAsync("Dark");
                //await JSRuntime.InvokeAsync<object>("methods.print", tbColorThemeToggle);
                await JS.InvokeAsync<bool>("JSColorCookie", "Dark");
                //return;
            } else {
                await ColorThemeChanged.InvokeAsync("Light");
                await JS.InvokeAsync<bool>("JSColorCookie", "Light");
                //return;
            }
            
            return;
        }
        public void On_ColorThemeChanged(string tsValue) {
            colorTheme = tsValue;
        }
        ////////////////////////////////////////////////////
        void ToggleNavMenu() {
            collapseNavMenu = !collapseNavMenu;
        }

        void CollapseNavMenu() {
            collapseNavMenu = true;
        }

        //IF USER CLICKS ON URL DATA THAT DIRECTS TO CONTACT PAGE AND THEN CLICKS ON CONTACT PAGE
        //EITHER CLEAR DATA OR DON'T REDIRECT
        //public void ClearContactData() {
        //    Contact CallContactFunc = new Contact();
        //    //UNFORTUNATELY THIS DOESN'T WORK AS THERE'S A RENDER ERROR WITH JS
        //    //CallContactFunc.NavToContactAsync();
        //    //CallContactFunc
        //    //JS.InvokeAsync<bool>("ClearAllContactSubjects");
        //    CallContactFunc._contactName = "";
        //    CallContactFunc._contactEmail = "";
        //    CallContactFunc._contactSubject = "";
        //    CallContactFunc._contactMessage = "";
        //    //CallContactFunc.ContactMessage = "";
        //    //CallContactFunc._contactMessage = String.Empty;
        //    //CallContactFunc.ContactMessage = String.Empty;
        //    CallContactFunc._autoCheckCC = false;
        //    CallContactFunc._autoCheckEM = false;
        //    CallContactFunc._autoCheckBS = false;
        //    CallContactFunc._autoCheckFB = false;
        //    CallContactFunc._autoCheckD = false;

        //    CallContactFunc.ContactFormSubmitting = false;
        //    CallContactFunc.ContactFormSubmitted = false;
        //    //uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);

        //    //THIS 'RETURN' NAVIGATION WILL OCCUR IF USER CLICKED ON LINK W/ URLDATA
        //    JS.InvokeAsync<bool>("ClearAllContactSubjects");
        //    //JS.InvokeAsync<bool>("ClearAllTextAreas");
        //    //NavManager.NavigateTo("/contact");
        //    //JS.InvokeAsync<bool>("ClearAllContactSubjects");
        //    //StateHasChanged();
        //}
        ////////////////////////////////////////////////////

        #endregion (Methods)


        #region Properties
        //VARIABLES MEANT FOR COLOR THEME SWITCHING
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        //INTENDED FOR NAVBAR/////////////////////////////////////////
        bool collapseNavMenu = true;
        string NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        //////////////////////////////////////////////////////////////
        [Parameter] public string ColorTheme { get => colorTheme; set => On_ColorThemeChanged(value); }/* colorTheme = value;*/ /*set => On_ColorThemeChanged(value); }*/
        [Parameter] public EventCallback<string> ColorThemeChanged { get; set; }
        public string ColorThemeDisplayText { get => colorTheme; set => colorTheme = value; }
        public bool ColorThemeInitiallyChecked { get; set; }

        public string CurrentURL { get; set; }
        public bool DisabledContact { get; set; } = false;
        #endregion (Properties)

    }
}
