using System.Collections.Generic;
using System.Text;

namespace TranslateHelperWpf
{
    internal static class THdefinitions
    {
        private static Dictionary<string, string> _history = new Dictionary<string, string>
        {
            { "1.1" , "???" },
            { "1.0" , "First edition: Basic layout and interaction as well as read write json file format. 2018-06-03. Anders W." }
        };
        public static string VersionString { get { return "1.0"; } }
        public static string History
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (string key in _history.Keys)
                {
                    sb.AppendLine ($"{key} : { _history[key]}" );
                }
                return sb.ToString();
            }
        }
    }
}
