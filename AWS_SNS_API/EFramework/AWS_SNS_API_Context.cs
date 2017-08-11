namespace AWS_SNS_API.EFramework
{
    using AWS_SNS_API.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AWS_SNS_API_Context : DbContext
    {
        // Your context has been configured to use a 'AWS_SNS_API_Context' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AWS_SNS_API.EFramework.AWS_SNS_API_Context' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AWS_SNS_API_Context' 
        // connection string in the application configuration file.
        public AWS_SNS_API_Context()
            : base("name=AWS_SNS_API_Context")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<SNSAlarm> Alarms { get; set; }
        public DbSet<Event> EventLog { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<SNS_Alarm_Action> SNSAlarmActions { get; set; }
        public DbSet<SNS_Action> SNSActions { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}


}