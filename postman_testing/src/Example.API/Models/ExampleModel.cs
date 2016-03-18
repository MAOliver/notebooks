using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Example.API.Models
{
    public class ExampleModel
    {
        public bool IsVal { get; set; }
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public LoanType LoanType { get; set; }
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public State State { get; set; }
        public int PolicyCount { get; set; }
    }

    public enum LoanType
    {
        Purchase,Refinance,LoanModification
    }

    public enum State
    {
        AZ
    }
}
