using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RulesEngine;
using System.Threading.Tasks;

namespace BRE
{
    class RuleEngine
    {
        public class BRE<T, R> where T : class,new()
        {
            public BRE()
            { }

            public static R GetRule(string RuleKey, T value)
            {
                Engine eng= new Engine();
                T GenProperty;
                R ReturnType =default(R);
                switch(RuleKey){
                    case "ServiceArea" :
                                    eng.For<ServiceArea>()
                                                .Setup(S => S.Pin)
                                                .MustNotBeNullOrEmpty();
                                    dynamic dynVar = value;
                                    ServiceAreaController SAC = new ServiceAreaController();
                                    return eng.Validate(dynVar) ? SAC.GetServiceableArea(dynVar.Pin) : ReturnType; 
                                    break;
                  

                    case "CustomerExists":
                                    eng.For<Customer>()
                                                .Setup(S => S.Mobile)
                                                .MustNotBeNullOrEmpty();
                                    return ReturnType;
                                    break;

                    case "Registration":
                                    eng.For<Customer>()
                                                .Setup(S => S.Mobile)
                                                .MustNotBeNullOrEmpty()
                                                .Setup(S => S.FirstName)
                                                .MustNotBeNullOrEmpty()
                                                .Setup(S => S.LastName)
                                                .MustNotBeNullOrEmpty()
                                                .Setup(S => S.Age)
                                                .MustNotBeNullOrEmpty();
                                                
                                               (chkServicablity())? chkAvailability()

                                    return ReturnType;
                                    break;

                                    default:
                                    return ReturnType;
                                    break;                            
                  }
          

    }


        }

        public class CustomRule : IRule<string>
        {
            string _strRule = "";

            public CustomRule() { }

            public CustomRule(string strRule)
            {
                _strRule = strRule;
            }

            ValidationResult IRule<string>.Validate(string value)
            {
                bool vResult = false;
                switch (_strRule)
                {
                    case "Pin":
                        vResult = (value.Trim().Replace(" ", "").Length == 6) ? true : false;
                        break;
                    default:
                        vResult = true;
                        break;
                }
                return (vResult) ? ValidationResult.Success : ValidationResult.Fail();
            }

            string IRule.RuleKind
            {
                get { throw new NotImplementedException(); }
            }
        }


    }
}
