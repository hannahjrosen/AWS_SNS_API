using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AWS_SNS_API.Models
{
    public class Event
    {
        public string source { get; set; }

        public string message { get; set; }

        [Key]
        public string eventDateTime { get; set; }

        public bool exceptionNFO { get; set; }

        public eventType eveType { get; set; }

        public Event(string s, string m, bool except, eventType eveTy)
        {
            source = s;
            message = m;
            eventDateTime = DateTime.Now.ToString("F");
            exceptionNFO = except;
            eveType = eveTy;
        }


        public Event(string s, SNSAlarm myAlarm, SNS_Alarm_Action myAlarmAction, SNS_Action mySNSAction)
        {
            eventDateTime = DateTime.Now.ToString("F");
            source = s;
            message = myAlarm.Message;

            //determine if alarm was turned into an action
            if (mySNSAction.cName == className.NONE)
            {
                exceptionNFO = true;
            }

            //figure out event type
            if (mySNSAction.cName == className.EMAIL)
            {
                eveType = eventType.INFO;
            }
            else if (mySNSAction.cName == className.RAISE_SCOM_ALERT)
            {
                eveType = eventType.WARNING;
            }
            else
            {
                eveType = eventType.ERROR;
            }

        }
    }

    public enum eventType { INFO, WARNING, ERROR }
}