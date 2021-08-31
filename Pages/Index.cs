using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazoredPortfolio.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazoredPortfolio.Pages {
    public partial class Index {

        #region Fields

        #endregion (Fields)


        #region Methods
        //protected override void OnInitialized() {
        //    test_recieved_string = Layout.MainColorTheme;
        //}

        protected override async Task OnInitializedAsync() {
            OnParametersSet();
        }


        protected override void OnParametersSet() {
            Color_Theme_Recieved = Layout.MainColorTheme;
        }

        public void ChangeIndexResumeSection() {
            if(IndexResumeButtonText != "Show Resume Link") {
                IndexResumeButtonText = "Show Resume Link";
                return;
            }else if (IndexResumeButtonText == "Show Resume Link") {
                IndexResumeButtonText = "Hide Resume Link";
                return;
            }
        }

        public void ChangeSiteLogSection() {
            if(SiteAlterationLogButtonText != "Show Site Logs") {
                SiteAlterationLogButtonText = "Show Site Logs";
                return;
            } else if(SiteAlterationLogButtonText == "Show Site Logs") {
                SiteAlterationLogButtonText = "Hide Site Logs";
                return;
            }
        }
        #endregion (Methods)


        #region Properties
        //TODO: CAN THIS RECEIVE VALUE FROM MAINLAYOUT?
        //UPDATE: YES IT CAN
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        public string Color_Theme_Recieved { get; set; }


        public string SiteAlterationLogButtonText { get; set; } = "Show Site Logs";
        public string IndexResumeButtonText { get; set; } = "Show Resume Link";

        #endregion (Properties)
    }
}
