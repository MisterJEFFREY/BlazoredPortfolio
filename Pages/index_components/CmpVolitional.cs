using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

namespace BlazoredPortfolio.Pages.index_components {
    public partial class CmpVolitional {
        #region Fields

        #endregion (Fields)


        #region Methods

        #endregion (Methods)

        #region Properties
        [Parameter]
        public string Color_Theme_Recieved { get; set; }
        [Parameter]
        public EventCallback<string> Color_Theme_RecievedChanged { get; set; }
        #endregion (Properties)
    }
}
