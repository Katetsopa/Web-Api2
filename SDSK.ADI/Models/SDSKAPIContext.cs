using System.Data.Entity;
using SDSK.API.Model;

namespace SDSK.API.Models
{
    public class SDSKAPIContext : DbContext
    {
        public SDSKAPIContext() : base("name=SDSKAPIContext")
        {
            Database.SetInitializer(new SDSKAPIInitializer());
        }

        public System.Data.Entity.DbSet<SDSK.API.Model.Mail> Mails { get; set; }

    }

    public class SDSKAPIInitializer : DropCreateDatabaseAlways<SDSKAPIContext>
    {
        protected override void Seed(SDSKAPIContext context)
        {
            context.Mails.Add(new Mail() { Id = 1, Body = "mail1", Priority = Priority.Low, AttachementId = 1 });
            context.Mails.Add(new Mail() { Id = 2, Body = "mail2", Priority = Priority.High, AttachementId = 2 });
        }
    }
}
