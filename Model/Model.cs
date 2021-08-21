using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRouteeAPI.Model
{
    public class Model
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Root
        {
            public string Code { get; set; }
            public string DeveloperMessage { get; set; }
        }


    }
}
