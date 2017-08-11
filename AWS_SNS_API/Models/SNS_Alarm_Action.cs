using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AWS_SNS_API.Models
{
    //the indiv. actions created from the SNS alarm
    public class SNS_Alarm_Action
    {

        [Key]
        public string name { get; set; }

        public string type { get; set; }

        public string subject { get; set; }

        public SNS_Action typeSNSAction { get; set; }

        public int priorityOrder { get; set; }

        public SNS_Alarm_Action(string n, string t, string s)
        {
           // id = i;
            name = n + "_action";
            type = t;
            subject = s;
        }

    }
}