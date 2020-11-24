using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Templating
{
    public static class HelperFunctions
    {
        public static string Format(long? value, bool enforceSign = false)
        { 
            if (value.HasValue)
            { 
                if (enforceSign && value.Value > 0)
                {
                    return String.Format("+{0:n0}", value);
                }
                return String.Format("{0:n0}", value); 
            }
            else
            {
                return "Not updated yet";
            } 
        }

        public static string Format(double? value, bool enforceSign = false)
        {
            if (value.HasValue)
            {
                if (enforceSign && value.Value > 0)
                {
                    return String.Format("+{0:0.00}", value);
                }
                return String.Format("{0:0.00}", value);
            }
            else
            {
                return "Not updated yet";
            }
        } 

        public static string SimpleFormat(long? value)
        {
            if (value.HasValue)
            { 
                return value.Value.ToString();
            }
            else
            {
                return "???";
            }

        }
        public static string SimpleFormat(double? value)
        {
            if (value.HasValue)
            {
                return String.Format("{0:0.0}%", value.Value);
            }
            else
            {
                return "???%";
            } 
        }

        public static string Emphasise(bool emphasise, string value)
        {
            if (emphasise)
            {
                return $"*{value.Trim()}*";
            } else
            {
                return value;
            }
        }

    }
}
