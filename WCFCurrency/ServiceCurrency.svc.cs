using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFCurrency
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceCurrency.svc or ServiceCurrency.svc.cs at the Solution Explorer and start debugging.
    public class ServiceCurrency : IServiceCurrency
    {
        public string GetCurrencyString(int value)
        {
            if (value == 0)
                return "ZERO ";
            if (value < 0)
                return "minus " + GetCurrencyString(Math.Abs(value));
            string words = "";

            //if ((value / 10000000) > 0)
            //{
            //    words += GetCurrencyString(value / 10000000) + " Crore ";
            //    value %= 10000000;
            //}

            if ((value / 1000000) > 0)
            {
                words += GetCurrencyString(value / 1000000) + " MILLION ";
                value %= 1000000;
            }
            if ((value / 1000) > 0)
            {
                words += GetCurrencyString(value / 1000) + " THOUSAND ";
                value %= 1000;
            }
            if ((value / 100) > 0)
            {
                words += GetCurrencyString(value / 100) + " HUNDRED ";
                value %= 100;
            }
            if (value > 0)
            {
                if (words != "")
                    words += " ";
                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (value < 20)
                    words += unitsMap[value];
                else
                {
                    words += tensMap[value / 10];
                    if ((value % 10) > 0)
                        words += "-" + unitsMap[value % 10];
                }
            }
            return words ;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.Boolvalue)
            {
                composite.Stringvalue += "Suffix";
            }
            return composite;
        }
    }
}
