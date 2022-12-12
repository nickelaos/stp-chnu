using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Customer_Service
{
    [DataContract(Namespace = "Customer_Service")]
    public class Customer
    {
        [DataMember]
        public Int32 CustomerID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public String Address { get; set; }
    }
}
