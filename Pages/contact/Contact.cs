
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazoredPortfolio.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazoredPortfolio.Pages.contact {
    public partial class Contact {

        #region Fields
        public string _contactName;
        public string _contactEmail;
        public string _contactSubject;
        public string _contactMessage;
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

        public void On_ContactNameChanged(string tsInput) {
            _contactName = tsInput;
        }

        public void On_ContactEmailChanged(string tsInput) {
            _contactEmail = tsInput;
        }

        public void On_ContactSubjectChanged(ChangeEventArgs tsInput) {
            _contactSubject = tsInput.Value.ToString();
        }

        public void On_ContactMessageChanged(string tsInput) {
            _contactMessage = tsInput;
        }


        async Task BlazorFormCheck() {
            //string Log; 
            //Log = System.Text.Json.JsonSerializer.Serialize(testformref) + "\r\n";
            //Check if all input fields are not empty
            if (!String.IsNullOrEmpty(ContactName) && !String.IsNullOrEmpty(ContactEmail)
                && !String.IsNullOrEmpty(ContactSubject) && !String.IsNullOrEmpty(ContactMessage)) {
                ContactFormSubmitText           = "Loading";
                ContactFormSubmitting           = true;
                var random_delay                = new Random();
                int random_delay_amount         = random_delay.Next(3000, 6000); // Between 3-6 seconds to allow for slower connections
                //It feels like the form data is sent a lil slower than anticipated...
                await Task.Delay(random_delay_amount); 
                //Will this allow the data to be sent before changing components?
                ContactFormSubmitted            = true;
                //await test_numChanged.InvokeAsync(tiValue);
            }
        }

        public void NavToContact() {
            _contactName            = "";
            _contactEmail           = "";
            _contactSubject         = "";
            _contactMessage         = "";
            ContactFormSubmitting   = false;
            ContactFormSubmitted    = false;
            //uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
            //StateHasChanged();
            //NavManager.NavigateTo("/contact", true);
        }
        #endregion (Methods)


        #region Properties
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        public string Color_Theme_Recieved { get; set; }


        public bool ContactFormSubmitted { get; set; } = false;
        public bool ContactFormSubmitting { get; set; } = false;
        public string ContactFormSubmitText { get; set; } = "Submit";
        //See if this grabs values from the contact form and if we can do validations before sending data...
        public string ContactName { get => _contactName; set => On_ContactNameChanged(value); }
        public string ContactEmail { get => _contactEmail; set => On_ContactEmailChanged(value); }
        public string ContactSubject { get => _contactSubject; set => _contactSubject = value; }
        public string ContactMessage { get => _contactMessage; set => On_ContactMessageChanged(value); }
        #endregion (Properties)

    }
}
