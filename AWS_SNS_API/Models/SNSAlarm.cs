using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AWS_SNS_API.Models
{
    public class SNSAlarm
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string TopicArn { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }


        public SNSAlarm(string id, string name, string type, string topicaArn, string subject, string message)
        {
            Id = id;
            Name = name;
            Type = type;
            TopicArn = topicaArn;
            Subject = subject;
            Message = message;
        }

    }
}