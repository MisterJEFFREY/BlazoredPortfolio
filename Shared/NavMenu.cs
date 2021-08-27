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
        async Task ToggleThemeSwitch(string tbColorThemeToggle) {
            //CHECK IF THE THEME TOGGLE IS ACTUALLY CHECKED
            if (tbColorThemeToggle == "True") {
                await ColorThemeChanged.InvokeAsync("Dark");
                return;
            } else {
                await ColorThemeChanged.InvokeAsync("Light");
                return;
            }
        }


        void ToggleNavMenu() {
            collapseNavMenu = !collapseNavMenu;
        }

        void CollapseNavMenu() {
            collapseNavMenu = true;
        }



        //public void ToggleThemeSwitch(){
        //    //if(_colorTheme == "Light") {
        //    //    color
        //    //    return;
        //    //}

        //    //if (_colorTheme == "Dark") {

        //    //    return;
        //    //}
        //}

        public void On_ColorThemeChanged(string tsValue) {
            colorTheme = tsValue;
        }
        #endregion (Methods)


        #region Properties
        bool collapseNavMenu = true;
        string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        [Parameter]
        public string ColorTheme { get => colorTheme; set => On_ColorThemeChanged(value); }/* colorTheme = value;*/ /*set => On_ColorThemeChanged(value); }*/

        public string ColorThemeDisplayText { get => colorTheme; set => colorTheme = value; }

        [Parameter]
        public EventCallback<string> ColorThemeChanged { get; set; }

        #endregion (Properties)

    }
}
