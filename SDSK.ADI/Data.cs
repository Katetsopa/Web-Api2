using System.Collections.Generic;
using SDSK.API.Model;

namespace SDSK.API
{
    public class Data
    {
        public static List<Mail> Mails = new List<Mail>()
                {
                    new Mail() {Id = 1, Body = "mail1", AttachementId = 1, Priority = Priority.High},
                    new Mail() {Id = 2, Priority = Priority.Critical, Body = "mail2"},
                    new Mail() {Id = 3, Priority = Priority.Critical, Body = "mail3"}
                };


        public static List<Attachement> AttList =
             new List<Attachement>()
                {
                    new Attachement()
                    {
                        Id = 1,
                        MailId = 1,
                        FileName = "name1",
                        Path = "path1",
                        StatusId = 1,
                        FileExtention = "file"
                    },
                    new Attachement()
                    {
                        Id = 2,
                        MailId = 1,
                        FileName = "name2",
                        Path = "path2",
                        StatusId = 1,
                        FileExtention = "file"
                    },
                    new Attachement()
                    {
                        Id = 3,
                        MailId = 2,
                        FileName = "name3",
                        Path = "path3",
                        StatusId = 1,
                        FileExtention = "file"
                    },
                    new Attachement()
                    {
                        Id = 4,
                        MailId = 5,
                        FileName = "name5",
                        Path = "path5",
                        StatusId = 1,
                        FileExtention = "file"
                    }
                };

        public static List<JiraItem> JiraItems = new List<JiraItem>()
        {
            new JiraItem() {JiraItemId = 1, JiraNumber = 1, JiraSourceId = 1, RequestIdType = 1},
            new JiraItem() {JiraItemId = 2, JiraNumber = 2, RequestIdType = 2, JiraSourceId = 2},
            new JiraItem() {JiraItemId = 3, JiraNumber = 3, RequestIdType = 3, JiraSourceId = 3},
        };

    }
}