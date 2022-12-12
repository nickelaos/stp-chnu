using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Customer_Service
{
    [DataContract(Namespace = "Customer_Service")]
    public class Phone
    {
        [DataMember]
        public Int32 PhoneID { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Maker { get; set; }
        [DataMember]
        public Int32 Price { get; set; }
    }
}
