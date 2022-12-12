using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;

namespace Customer_Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PhoneService : IPhoneService
    {
        public List<Phone> GetPhoneList()
        {
            return GetPhoneData();
        }

        public Phone GetPhoneById(string id)
        {
            int phone_id = int.Parse(id);
            return GetPhoneData().FirstOrDefault(x => x.PhoneID == phone_id);
        }

        private List<Phone> GetPhoneData()
        {
            List<Phone> lstPhone = new List<Phone>();
            Phone phone1 = new Phone();
            phone1.PhoneID = 1;
            phone1.Model = "M32";
            phone1.Maker = "Samsung";
            phone1.Price = 22000;
            lstPhone.Add(phone1);
            Phone phone2 = new Phone();
            phone2.PhoneID = 2;
            phone2.Model = "XS";
            phone2.Maker = "Apple";
            phone2.Price = 35000;
            lstPhone.Add(phone2);
            return lstPhone;
        }
    }
}
