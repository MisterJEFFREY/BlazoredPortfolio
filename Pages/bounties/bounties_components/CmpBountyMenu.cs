using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

namespace BlazoredPortfolio.Pages.bounties.bounties_components {
    public partial class CmpBountyMenu {

        #region Fields

        #endregion (Fields)


        #region Methods
        ////////////////////////////////////////////////////////////
        public void ActiveBountyInfo(string tsRouteData) {
            if (!string.IsNullOrEmpty(tsRouteData)){
                NavManager.NavigateTo("/bounties/" + tsRouteData);
            }
            //Bounty_Selection_Recieved = "CmpBounty1";
        }
        ////////////////////////////////////////////////////////////
        public void InActiveBountyInfo(string tsRouteData) {
            if (!string.IsNullOrEmpty(tsRouteData)) {
                NavManager.NavigateTo("/bounties/" + tsRouteData);
            }
            //Bounty_Selection_Recieved = "CmpBounty1";
        }
        ////////////////////////////////////////////////////////////
        #endregion (Methods)


        #region Properties
        [Parameter]
        public string Color_Theme_Recieved { get; set; }
        [Parameter]
        public EventCallback<string> Color_Theme_RecievedChanged { get; set; }
        //[Parameter]
        //public string Bounty_Selection_Recieved { get; set; }
        //[Parameter]
        //public EventCallback<string> Bounty_Selection_RecievedChanged { get; set; }
        #endregion (Properties)


    }
}
