using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAutomation.Core
{
    class Page
    {
        private JArray controlsRegistry;
        public void Init()
        {
            string workingDirectory = Common.GetWorkingDirectory();
            string filePath = workingDirectory + @"\Pages\" + this.GetType().Name + ".json";
            string fileText = System.IO.File.ReadAllText(filePath);
            var json = (JObject)JsonConvert.DeserializeObject(fileText);
            this.controlsRegistry = (JArray)json["page"]["controls"];
        }

        public BaseControl InitControl(BaseControl control)
        {
            if(this.controlsRegistry == null)
            {
                this.Init();
            }
            foreach(var jControl in controlsRegistry)
            {
                if(jControl["name"].ToString() == control.ControlName)
                {
                    control.SelectorType = jControl["selectorType"].ToString();
                    control.Selector = jControl["selector"].ToString();
                }
            }
            return control;
        }
    }
}
