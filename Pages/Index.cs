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
        protected override void OnInitialized() {
            test_recieved_string = Layout.MainColorTheme;
        }
        #endregion (Methods)


        #region Properties
        //TODO: CAN THIS RECEIVE VALUE FROM MAINLAYOUT?
        [CascadingParameter]
        public MainLayout Layout { get; set; }

        public string test_recieved_string { get; set; }


        #endregion (Properties)
    }
}
