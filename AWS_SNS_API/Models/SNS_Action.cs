using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AWS_SNS_API.Models
{
    //describes the 3 diff actions we can take from each SNS alarm
    public class SNS_Action
    {
        static int count = 0;

        [Key]
        public string typeNameId { get; set; }

        public string assemblyName { get; set; }

        public className cName { get; set; }

        public SNS_Action() { }

        public SNS_Action(string t, string a, className c)
        {
            count++;

            typeNameId = t;
            assemblyName = a;
            cName = c;
        }

        public SNS_Action(string name, string subject, string type)
        {
            count++;

            if (name.Contains("SCOM") || subject.Contains("SCOM"))  
            {
                cName = className.RAISE_SCOM_ALERT;
                typeNameId = "SCOM" + count;

            }
            else if (name.Contains("TICKET") || subject.Contains("TICKET"))
            {
                cName = className.TICKET;
                typeNameId = "TICKET" + count;

            }
            else if (name.Contains("EMAIL") || subject.Contains("EMAIL"))
            {
                cName = className.EMAIL;
                typeNameId = "EMAIL" + count;

            }
            else
            {
                cName = className.NONE;
                typeNameId = "NONE" + count;

            }


        }

    }

    public enum className { EMAIL, TICKET, RAISE_SCOM_ALERT, NONE }
}