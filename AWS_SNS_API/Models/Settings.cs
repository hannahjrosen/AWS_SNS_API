using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AWS_SNS_API.Models
{
    public class Settings
    {
        [Key]
        public string name { get; set; }
        public dataType dType { get; set; }
        public string value { get; set; }
    }

    public enum dataType { STRING, INT, BOOL }
}