using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazoredPortfolio.Shared {
    public partial class MainLayout {
        #region Fields
        public string _mainColorTheme = "Light";
        #endregion (Fields)


        #region Methods
        public void On_MainColorThemeChanged(string tsValue) {
            if (!String.IsNullOrEmpty(tsValue)) {
                _mainColorTheme = tsValue;
                MyMethod();
            }
        }
        //See if this works to change html background color
        async Task MyMethod() {
          await JSRuntime.InvokeAsync<string>("applyStyleForHtml",
              new { attrib = "background-color", value = "var(--light-body-color)" });
        }
        #endregion (Methods)


            #region Properties
            [Parameter]
        public string MainColorTheme { get => _mainColorTheme; set => On_MainColorThemeChanged(value); }

        #endregion (Properties)
    }
}
