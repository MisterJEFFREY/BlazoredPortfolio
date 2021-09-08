using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
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
                return;
            } else {
                await ColorThemeChanged.InvokeAsync("Light");
                return;
            }
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
        ////////////////////////////////////////////////////

        #endregion (Methods)


        #region Properties
        //INTENDED FOR NAVBAR/////////////////////////////////////////
        bool collapseNavMenu = true;
        string NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        //////////////////////////////////////////////////////////////
        [Parameter] public string ColorTheme { get => colorTheme; set => On_ColorThemeChanged(value); }/* colorTheme = value;*/ /*set => On_ColorThemeChanged(value); }*/
        [Parameter] public EventCallback<string> ColorThemeChanged { get; set; }
        public string ColorThemeDisplayText { get => colorTheme; set => colorTheme = value; }
        public bool ColorThemeInitiallyChecked { get; set; }
        #endregion (Properties)

    }
}
