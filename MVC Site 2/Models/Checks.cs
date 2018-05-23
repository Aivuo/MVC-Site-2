using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Site_2.Models
{
    public class Checks
    {
        public static string HaveFeverCheck(string scale, float temperature)
        {
            //Skapar en string sätter den till ett värde beroende på vilken temperatur användaren skriver in. Sen skickar den tillbaka den.
            string haveFever;

            if (scale == "celsius")
            {
                if (temperature > 38)
                {
                    haveFever = "Yes you have a fever.";
                }
                else if (temperature > 35)
                {
                    haveFever = "No, you are perfectly fine.";
                }
                else if (temperature > 32)
                {
                    haveFever = "No but you have a mild case of Hypothermia. Drink something warm and contact a doctor.";
                }
                else if (temperature > 28)
                {
                    haveFever = "You have severe Hypothermia. Get to a doctor now!";
                }
                else
                {
                    haveFever = "How did you even write this? You should be unconcious!";
                }
            }
            else
            {
                if (temperature > 100)
                {
                    haveFever = "Yes you have a fever.";
                }
                else if (temperature > 95)
                {
                    haveFever = "No, you are perfectly fine.";
                }
                else if (temperature > 89)
                {
                    haveFever = "No but you have a mild case of Hypothermia. Drink something warm and contact a doctor.";
                }
                else if (temperature > 82)
                {
                    haveFever = "You have severe Hypothermia. Get to a doctor now!";
                }
                else
                {
                    haveFever = "How did you even write this? You should be unconcious!";
                }
            }

            return haveFever;
        }
    }
}