using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace ConvertServices
{
    [ServiceContract(Namespace = "ConvertServices")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WeightConverter
    {
        const double dollar = 35;
        [OperationContract]
        public double UahToDollars(double value)
        {

            return value / dollar;
        }
    }
}
