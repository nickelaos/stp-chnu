using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Customer_Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CustomerService : ICustomerService
    {
        public List<Customer> GetCustomerList()
        {
            return PopulateCustomerData();
        }
        private List<Customer> PopulateCustomerData()
        {
            List<Customer> lstCustomer = new List<Customer>();
            Customer customer1 = new Customer();
            customer1.CustomerID = 1;
            customer1.FirstName = "John";
            customer1.LastName = "Meaney";
            customer1.Address = "Chicago";
            lstCustomer.Add(customer1);
            Customer customer2 = new Customer();
            customer2.CustomerID = 1;
            customer2.FirstName = "Peter";
            customer2.LastName = "Shaw";
            customer2.Address = "New York";
            lstCustomer.Add(customer2);
            return lstCustomer;
        }
    }
}
