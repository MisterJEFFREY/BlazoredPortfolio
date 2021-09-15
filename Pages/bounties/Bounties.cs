using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazoredPortfolio.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazoredPortfolio.Pages.bounties {
    public partial class Bounties {


        #region Fields
        public bool _urlDataValid = true;

        public string _urlDataErrorMsg;

        public string _bountySelection;

        #endregion (Fields)


        #region Methods
        ///////IMPORTANT METHODS TO RECIEVE COLOR THEMES DYNAMICALLY
        protected override async Task OnInitializedAsync() {
            //THIS MUST BE HERE INSTEAD OF PARAMETERSASYNC METHOD TO PREVENT MULTI-CHECKING
            if (!string.IsNullOrEmpty(UrlData)) {
                UrlData = UrlData.ToLower() ?? "";
                ////
                CheckUrlDataContext(UrlData);
            }
            OnParametersSet();
        }
        //////////////////////////////////////////////////////////////

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
        //THIS WILL RECIEVE THE LIGHT/DARK COLOR THEME VALUE
        //DYNAMICALLY AND WORKS W/OUT COOKIES.
        protected override void OnParametersSet() {
            Color_Theme_Recieved = Layout.MainColorTheme;
        }
        //////////////////////////////////////////////////////////////
        public void CheckUrlDataContext(string tsUrlData) {
            ///CHECK THE CONTEXT OF URL DATA AS LONG AS IT'S NOT EMPTY...
            if (!string.IsNullOrEmpty(tsUrlData)) {
                /////////////////////////////////////////////////////////////////////////
                //CHECK IF URLDATA ACTUALLY CONTAINS BOUNTY + # + NUMBER
                if (tsUrlData.Contains("bountynum")) {
                    var final_tsUrlData = tsUrlData.Substring(tsUrlData.IndexOf('m') + 1);
                    //FIRST MAKE SURE THAT THE REMAINING URL DATA ACTUALLY HAS A NUMBER AFTER TRIMMING...
                    if (final_tsUrlData.Length > 0) {
                        //CHECK IF REMAINING CHARACTERS IN RECIEVED STRING ARE ACTUALLY MERELY #'S!
                        bool RemainingCharsAreNums = final_tsUrlData.All(char.IsDigit);
                        if (RemainingCharsAreNums) {
                            //CHECK IF BOUNTY NUMBER IS LEGIT...
                            var final_tsUrlData_int = Int32.Parse(final_tsUrlData);
                            if (final_tsUrlData_int! < BountyAmount && final_tsUrlData_int! > BountyAmount) {
                                //TODO: SWITCH COMPONENT THAT CORRESPONDS TO BOUNTY NUMBER!
                                //
                                //
                                return;
                            } else {
                                /////////////////////////////////////////////////////////////////////////
                                //BOUNTY NNUMBER IS NOT LEGIT, GIVE ERROR MESSAGE TO USER.
                                _urlDataErrorMsg = "Url Data contains a number that is currently outside of the legimitate range, which is currently " + BountyAmount + " documented bounties." +
                                    "\nPlease check the url and try again.";
                                _urlDataValid = false;
                                return;
                            }

                        } else {
                            /////////////////////////////////////////////////////////////////////////
                            //NOTIFY USER OF INVALID REMAINING URL DATA WHICH AREN'T NUMBERS...
                            _urlDataErrorMsg = "Url Data contains incorrect data that aren't numbers.\nPlease check the url and try again.";
                            _urlDataValid = false;
                            return;
                        }
                    } else {
                        /////////////////////////////////////////////////////////////////////////
                        ///NOTIFY USER THAT THE URL DATA DIDN'T HAVE A NUMBER AFTERWARDS
                        _urlDataErrorMsg = "You have clicked on a url with incomplete data.\nPlease check the url and try again.";
                        _urlDataValid = false;
                        return;
                    }

                } else {
                    /////////////////////////////////////////////////////////////////////////
                    //NOTIFY USER OF INVALID URLDATA THAT DIDN'T MATCH UP WITH "BOUNTYNUM"
                    _urlDataErrorMsg = "Url Data contains incorrect data and/or is formatted incorrectly.\nPlease check the url and try again.";
                    _urlDataValid = false;
                    return;


                }
            } else {
                /////////////////////////////////////////////////////////////////////////
                /////NOTIFY USER THAT THE URL DATA DIDN'T HAVE ANY DATA. IS THIS A RARE CASE?
                _urlDataErrorMsg = "You may have clicked on a url with no data and this page expected it.\nPlease check the url and try again.";
                _urlDataValid = false;
                return;
            }
        }
        //////////////////////////////////////////////////////////////
        public void InvalidUrlDataAck() {
            if (!UrlDataValid) {
                _urlDataValid = true;
            }
        }
        //////////////////////////////////////////////////////////////
        public void On_BountySelectionChanged(string tsUrlData) { 

        }
        //////////////////////////////////////////////////////////////
        #endregion (Methods)


        #region Properties
        [CascadingParameter]
        public MainLayout Layout            { get; set; }
        public string Color_Theme_Recieved  { get; set; }

        [Parameter]
        public string? UrlData              { get; set; }
        public bool UrlDataValid            { get => _urlDataValid; set => _urlDataValid = value; }

        public int BountyAmount             { get; set; } = 1;  //# of Bounties so far
        public string UrlDataErrorMsg       { get => _urlDataErrorMsg; set => _urlDataErrorMsg = value; }

        public string BountySelection       { get => _bountySelection; set => On_BountySelectionChanged(value); }
        #endregion (Properties)

    }
}
