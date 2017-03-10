using RozetkaAutomation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAutomation.Pages
{
    class ResultsPage :BasePage 
    {
        public BaseControl ResultsItem(string itemName)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string> { { "${itemName}", itemName } };
            return this.GetControl("ResultsItem", parameters);
        }
    }
}
