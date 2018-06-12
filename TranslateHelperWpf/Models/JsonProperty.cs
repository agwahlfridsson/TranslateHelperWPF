using System.Collections.Generic;

namespace TranslateHelperWpf.Models
{
    class JsonProperty
    {
        public bool IsRoot { get; set; }
        public JsonProperty Parent { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public List<JsonProperty> Values { get; set; }
        public string Path
        {
            get
            {
                if (Parent == null)
                    return "";
                string path = this.Name;
                JsonProperty parent = Parent;
                while (parent != null)
                {
                    path = parent.Name + "." + path;
                    parent = parent.Parent;
                }
                if (path.Length > 0 && path[0] == '.')
                    path = path.Remove(0, 1);
                return path;
            }
        }
        public JsonProperty()
        {
            IsRoot = false;
            Name = string.Empty;
            Value = string.Empty;
            Values = new List<JsonProperty>();
            Parent = null;
        }
        public override string ToString()
        {
            return $"{Name} : {Value}";
        }
    }
}
