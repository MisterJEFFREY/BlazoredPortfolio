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

        public bool _autoCheckCC = false;
        public bool _autoCheckEM = false;
        public bool _autoCheckBS = false;
        public bool _autoCheckFB = false;
        public bool _autoCheckD = false;

        public bool _urlDataValid = true;
        #endregion (Fields)


        #region Methods
        ///////IMPORTANT METHODS TO RECIEVE COLOR THEMES DYNAMICALLY
        protected override async Task OnInitializedAsync() {
            //TODO: IF TESTING SUCESSFUL, CHANGE COMMENTS
            if (!string.IsNullOrEmpty(UrlData)) {
                UrlData = UrlData.ToLower() ?? "";
                //////
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

        //public async override Task SetParametersAsync(ParameterView parameters) {
        //    await base.SetParametersAsync(parameters);
        //    //TODO: IF TESTING SUCESSFUL, CHANGE COMMENTS
        //    if (!string.IsNullOrEmpty(UrlData)) {
        //        UrlData = UrlData.ToLower() ?? "";
        //        //////
        //        CheckUrlDataContext(UrlData);
        //    }
        //}
        //////////////////////////////////////////////////////////////

        public void CheckUrlDataContext(string tsUrlData) {
            ///CHECK THE CONTEXT OF URL DATA AS LONG AS IT'S NOT EMPTY...
            if (!string.IsNullOrEmpty(tsUrlData)) {
                //////////////////////////////////////
                //CASUAL CONVERSATION RELATED SUBJECTS
                //////////////////////////////////////
                //IF USER CAME FROM YOUTUBE...
                if (tsUrlData.Contains("youtube")) {
                    var final_tsUrlData = tsUrlData.Substring(tsUrlData.IndexOf('e') + 1);
                    //FIRST CHECK IF TRIMMED STRING ACTUALLY CONTAINS SOMETHING...
                    if (final_tsUrlData.Length > 0) {
                        //CHECK IF REMAINING CHARACTERS IN RECIEVED STRING ARE ACTUALLY MERELY #'S!
                        bool RemainingCharsAreNums = final_tsUrlData.All(char.IsDigit);
                        if (RemainingCharsAreNums) {
                            _autoCheckCC = true;
                            _contactSubject = "Casual Conversation(s)";
                            _contactMessage = "Hello there!\nI've came across your YouTube Video #" + final_tsUrlData + "\nand [INSERT YOUR MESSAGE HERE]";
                            return;
                        } else {
                            //NOTIFY USER OF INVALID REMAINING URL DATA WHICH AREN'T NUMBERS...
                            _urlDataValid = false;
                            return;
                        }
                    }
                    //NOTIFY USER OF INVALID REMAINING URL DATA, WHICH WAS EMPTY AFTER BEING TRIMMED!
                    else {_urlDataValid = false; return; }
                }
                ///////////////////////////////////////////////////////
                //IF USER WAS ON WEB APP AND REQUESTED RESUME PASSWORD...
                if (tsUrlData.Contains("rsmpwdreq")) {
                    _autoCheckEM = true;
                    _contactSubject = "Employment Material(s)";
                    _contactMessage = "Hello there!\nI would like to converse about your resume\nand [INSERT YOUR MESSAGE HERE]";
                    return;
                }
                ///////////////////////////////////////////////////////
                //IF USER HAS SOMETHING BOUNTY RELATED...
                if (tsUrlData.Contains("bounty")) {
                    var final_tsUrlData = tsUrlData.Substring(tsUrlData.IndexOf('y') + 1);
                    //FIRST CHECK IF TRIMMED STRING ACTUALLY CONTAINS SOMETHING...
                    if (final_tsUrlData.Length > 0) {
                        //CHECK IF REMAINING CHARACTERS IN RECIEVED STRING ARE ACTUALLY MERELY #'S!
                        bool RemainingCharsAreNums = final_tsUrlData.All(char.IsDigit);
                        if (RemainingCharsAreNums) {
                            _autoCheckBS = true;
                            _contactSubject = "Bounty Submission(s)";
                            //TODO: SHOULD I CHECK WHICH BOUNTIES IT RELATES TO OR RESORT TO A NUMBER?
                            _contactMessage = "Hey, Jeffrey.\nI have a bounty submission for\nbounty #" + final_tsUrlData;
                            return;
                        } else {
                            //NOTIFY USER OF INVALID REMAINING URL DATA WHICH AREN'T NUMBERS...
                            _urlDataValid = false;
                            return;
                        }
                    }                        
                    //NOTIFY USER OF INVALID REMAINING URL DATA, WHICH WAS EMPTY AFTER BEING TRIMMED!
                    else { _urlDataValid = false; return; }
                }
                ///////////////////////////////////////////////////////
                //IF USER HAS SOME FEEDBACKS...
                if (tsUrlData.Contains("feedback")) {
                    _autoCheckFB = true;
                    _contactSubject = "Feedback(s)";
                    _contactMessage = "Hey, Jeff!\nI had some thoughts and want to give you some feedback.\n[INSERT YOUR MESSAGE HERE]";
                }
                ///////////////////////////////////////////////////////
                //IF USER HAS SOMETHING DONATION RELATED...
                if (tsUrlData.Contains("donation")) {
                    _autoCheckD = true;
                    _contactSubject = "Donations(s)";
                    _contactMessage = "Aye, Jeffrey.\n I had some thoughts about donating to you.\n[INSERT YOUR MESSAG HERE]";
                    return;
                }
                ///////////////////////////////////////////////////////
                //IF USER ...
                //if (tsUrlData.Contains("")) {
                //}

                /////////////////////////////////////////////////////////////////
                ///USER CLICKED ON URL THAT HAS NO INTENDED CONTEXT OR MISTYPED URL...
                //TODO: COMPLETE THIS SECTION BY WARNING USER THAT THE LINK GIVEN TO THEM WAS INCORRECT.
                Console.Write("\nUSER CLICKED ON INCORRECT LINK THAT HAD WRONG DATA AND/OR IS FORMATTED WRONG!\n");
                _urlDataValid = false;
                return;
            } else {
                Console.Write("\nUSER CLICKED ON A LINK WITH NO URL DATA AND CONTACT FORM EXPECTED IT!\n");
                _urlDataValid = false;
                return;
            }
        }

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
                ContactFormSubmitText = "Loading";
                ContactFormSubmitting = true;
                var random_delay = new Random();
                int random_delay_amount = random_delay.Next(3000, 6000); // Between 3-6 seconds to allow for slower connections
                //It feels like the form data is sent a lil slower than anticipated...
                await Task.Delay(random_delay_amount);
                //Will this allow the data to be sent before changing components?
                ContactFormSubmitted = true;
                //await test_numChanged.InvokeAsync(tiValue);
            }
        }

        //TODO: CURRENTLY INACCESSABLE FOR NOW
        public void NavToContact() {
            _contactName = "";
            _contactEmail = "";
            _contactSubject = "";
            _contactMessage = "";
            ContactFormSubmitting = false;
            ContactFormSubmitted = false;
            //uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
            //StateHasChanged();
            //NavManager.NavigateTo("/contact", true);
        }

        public void InvalidUrlDataAck(){
            if (!UrlDataValid) {
                _urlDataValid = true;
            }
        }      
        #endregion (Methods)


        #region Properties
        //VARIABLES MEANT FOR COLOR THEME SWITCHING
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        public string Color_Theme_Recieved { get; set; }
        //VARS MEANT FOR CONTACT FORM
        public bool ContactFormSubmitted { get; set; } = false;
        public bool ContactFormSubmitting { get; set; } = false;
        public string ContactFormSubmitText { get; set; } = "Submit";
        public string ContactName { get => _contactName; set => On_ContactNameChanged(value); }
        public string ContactEmail { get => _contactEmail; set => On_ContactEmailChanged(value); }
        public string ContactSubject { get => _contactSubject; set => _contactSubject = value; }
        public string ContactMessage { get => _contactMessage; set => On_ContactMessageChanged(value); }
        //Testing for auto filling data on contact Form based on URL
        [Parameter]
        public string? UrlData { get; set; }
        public bool AutoCheckCC { get => _autoCheckCC; set => _autoCheckCC = value; }
        public bool AutoCheckEM { get => _autoCheckEM; set => _autoCheckEM = value; }
        public bool AutoCheckBS { get => _autoCheckBS; set => _autoCheckBS = value; }
        public bool AutoCheckFB { get => _autoCheckFB; set => _autoCheckFB = value; }
        public bool AutoCheckD  { get => _autoCheckD;  set => _autoCheckD = value; }

        public bool UrlDataValid{ get => _urlDataValid;set => _urlDataValid = value; }
        
        #endregion (Properties)

    }
}
