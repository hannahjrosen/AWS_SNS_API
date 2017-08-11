using AWS_SNS_API.EFramework;
using AWS_SNS_API.Models;
using System;
using System.Net.Mail;
using System.Web.UI;

namespace AWS_SNS_API
{
    public partial class _Default : Page
    {
        protected void Button1_Click1(object sender, EventArgs e)
        {
            SNSAlarm myAlarm;

            string JSONtext = alarmText.Text;

            myAlarm = parseAlarmJSON(JSONtext);

            createActions(myAlarm);
        }

        /*creates an alarm object from JSON*/
        public SNSAlarm parseAlarmJSON(string json)
        {
            int startIndex, stopIndex;
            string[] rawAttributes;
            string[] editedAttributes;

            SNSAlarm myAlarm;


            /* json = Regex.Replace(json, @"{", "");
             json = Regex.Replace(json, @"\s+", "");
             json = Regex.Replace(json, @"}", "");
             */

            //parse incoming json into usable alarm info
            rawAttributes = json.Split(',');
            editedAttributes = new string[rawAttributes.Length];

            for (int i = 0; i < rawAttributes.Length; i++)
            {
                startIndex = rawAttributes[i].LastIndexOf("\" : \"");
                stopIndex = rawAttributes[i].LastIndexOf("\"");
                editedAttributes[i] = rawAttributes[i].Substring(startIndex + 5, stopIndex - startIndex - 5);
            }

            myAlarm = new SNSAlarm(editedAttributes[0], editedAttributes[1], editedAttributes[2], editedAttributes[3], editedAttributes[4], editedAttributes[5]);

            return myAlarm;
        }

        /*creates alarm actions and logs info into database*/
        public void createActions(SNSAlarm myAlarm)
        {
            SNS_Alarm_Action myAlarmAction;
            SNS_Action mySNSAction;
            // Settings mySettings;



            //create a new alarm action
            myAlarmAction = new SNS_Alarm_Action(myAlarm.Name, myAlarm.Type, myAlarm.Subject);

            //figure out what to do for that action
            mySNSAction = new SNS_Action(myAlarmAction.name, myAlarmAction.subject, myAlarmAction.type);




            //set that action for SNS_Alarm_Action
            myAlarmAction.typeSNSAction = mySNSAction;

            //add alarm action to database


            //log alarm
            Event alarmEvent = new Event("source", myAlarm, myAlarmAction, mySNSAction);



            //add to database
            using (AWS_SNS_API_Context myDbContext = new AWS_SNS_API_Context())
            {
                myDbContext.Alarms.Add(myAlarm);
                myDbContext.SNSAlarmActions.Add(myAlarmAction);
                myDbContext.SNSActions.Add(mySNSAction);
                myDbContext.EventLog.Add(alarmEvent);
                myDbContext.SaveChanges();
            }

            performAction(myAlarmAction);

        }

        /*perform action requested from SNS alarm*/
        public void performAction(SNS_Alarm_Action action)
        {
            if(action.typeSNSAction.cName == className.EMAIL)
            {
                try
                {
                    MailMessage mail = new MailMessage("merklesnstest@gmail.com", "hrosen@merkleinc.com");
                    
                    mail.Subject = action.subject;
                    mail.Body = "This is an email from an SNS alarm";

                    SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com", 587);
                    SmtpClient.Credentials = new System.Net.NetworkCredential("merklesnstest@gmail.com", "merklesns");
                    SmtpClient.EnableSsl = true;
                    SmtpClient.Send(mail);
                    Console.WriteLine("Message sent");


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

    }
}