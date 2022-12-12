using System;
using System.ServiceModel;
using CalcInterfaces;

namespace CalcClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            void Menu(bool need_to_try, ICalcService _proxy)
            {
                string str = "Which operation you wanna to do ? \n" +
                   "Operations: sum, pow, substraction, diviziion, mod, multiplication or exit\n" +
                   "Operation: ";

                if (need_to_try) str = "Please check and write correct your operation\n" + str;

                Console.WriteLine(str);
                OperationChoice(Console.ReadLine(), _proxy);
            }

            void OperationChoice(string input_operation, ICalcService _proxy) 
            {
                switch (input_operation)
                {
                    case "sum":
                        float res = _proxy.Sum(float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()));
                        Console.WriteLine($"Result of operation is {res}");
                        Menu(false, _proxy);
                        break;
                    case "pow":
                        res = _proxy.Power(float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()));
                        Console.WriteLine($"Result of operation is {res}");
                        Menu(false, _proxy);
                        break;
                    case "substraction":
                        res = _proxy.Substraction(float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()));
                        Console.WriteLine($"Result of operation is {res}");
                        Menu(false, _proxy);
                        break;
                    case "divizion":
                        string result = _proxy.Divizion(float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()));
                        Console.WriteLine($"Result of operation is {result}");
                        Menu(false, _proxy);
                        break;
                    case "mod":
                        res = _proxy.Mod(float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()));
                        Console.WriteLine($"Result of operation is {res}");
                        Menu(false, _proxy);
                        break;
                    case "multiplication":
                        res = _proxy.Multiplication(float.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()));
                        Console.WriteLine($"Result of operation is {res}");
                        Menu(false, _proxy);
                        break;
                    case "exit":
                        Exit();
                        break;
                    default:
                        Menu(true, _proxy);
                        break;
                }
            }

            void Exit() 
            {
                Environment.Exit(0);
            }


            ChannelFactory<ICalcService> channel = new ChannelFactory<ICalcService>("CalcServiceEndpoint");

            ICalcService proxy = channel.CreateChannel();

            Menu(false, proxy);

            Console.ReadLine();
        }
    }
}
