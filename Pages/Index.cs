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
        ///////IMPORTANT METHODS TO RECIEVE COLOR THEMES DYNAMICALLY
        protected override async Task OnInitializedAsync() {
            OnParametersSet();
        }

        //THIS WILL RECIEVE THE LIGHT/DARK COLOR THEME VALUE
        //DYNAMICALLY AND WORKS W/OUT COOKIES.
        protected override void OnParametersSet() {
            Color_Theme_Recieved = Layout.MainColorTheme;
        }
        //////////////////////////////////////////////////////////////
        public void NavToContact() {
            NavManager.NavigateTo("/contact");
        }

        public void ChangeAcademicSection() {
            if (IndexAcademicButtonText != "Show Academic Info") {
                IndexAcademicButtonText = "Show Academic Info";
                return;
            } else if (IndexAcademicButtonText == "Show Academic Info") {
                IndexAcademicButtonText = "Hide Academic Info";
                return;
            }
        }

        public void ChangeVolitionalSection() {
            if (IndexVolitionalButtonText != "Show Volitional Info") {
                IndexVolitionalButtonText = "Show Volitional Info";
                return;
            } else if (IndexVolitionalButtonText == "Show Volitional Info") {
                IndexVolitionalButtonText = "Hide Volitional Info";
                return;
            }
        }

        public void ChangeDonationSection() {
            if(DonationButtonText != "Show Donation Links") {
                DonationButtonText = "Show Donation Links";
                return;
            } else if (DonationButtonText == "Show Donation Links") {
                DonationButtonText = "Hide Donation Links";
                return;
            }
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

        public string IndexAcademicButtonText { get; set; }     = "Show Academic Info";
        public string IndexResumeButtonText { get; set; }       = "Show Resume Link";
        public string DonationButtonText { get; set; }          = "Show Donation Links";
        public string SiteAlterationLogButtonText { get; set; } = "Show Site Logs";
        public string IndexVolitionalButtonText { get; set; }   = "Show Volitional Info";

        #endregion (Properties)
    }
}
