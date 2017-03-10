using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAutomation.Core
{
    class Common
    {
        public static string GetWorkingDirectory()
        {
            string file = string.Empty;

            string result = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            int position;
            position = result.Contains(@"\RozetkaAutomation\") ? result.IndexOf(@"\RozetkaAutomation\") : -1;
            position = result.Contains(@"\bin\") ? result.IndexOf(@"\bin\") : -1;
            result = position > 0 ? result.Remove(position) : "";
            return result;
        }
    }
}
