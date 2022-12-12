using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CalcInterfaces
{
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        float Sum(float firstNumber, float secondNumber);

        [OperationContract]
        float Substraction(float firstNumber, float secondNumber);

        [OperationContract]
        float Multiplication(float firstNumber, float secondNumber);

        [OperationContract]
        string Divizion(float firstNumber, float secondNumber);

        [OperationContract]
        float Mod(float firstNumber, float secondNumber);

        [OperationContract]
        float Power(float firstNumber, float secondNumber);


    }
}
