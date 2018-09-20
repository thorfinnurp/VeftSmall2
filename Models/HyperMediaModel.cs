using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;

namespace template.Models
{
    public class HyperMediaModel
    {
        //Við þurfum að gera eitthvað hér held eg
        public HyperMediaModel() { Links = new ExpandoObject(); }
        [JsonProperty(PropertyName = "_links")]
        public ExpandoObject Links { get; set; }
    }
}