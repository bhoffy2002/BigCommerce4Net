using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BigCommerce4Net.Domain {
    public class FormField {
        [JsonProperty("name")]
        public virtual string Name { get; set; }
        [JsonProperty("value")]
        public virtual string Value { get; set; }
    }
}
