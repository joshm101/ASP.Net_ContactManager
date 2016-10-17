namespace ContactManager.Migrations
{
   using System;
   using System.Data.Entity;
   using System.Data.Entity.Migrations;
   using System.Linq;
   using ContactManager.Models;
   using Microsoft.AspNet.Identity;
   using Microsoft.AspNet.Identity.EntityFramework;
   

   internal sealed class Configuration : DbMigrationsConfiguration<ContactManager.Models.ApplicationDbContext>
   {
      public Configuration()
      {
         AutomaticMigrationsEnabled = false;
      }

      bool AddUserAndRole(ContactManager.Models.ApplicationDbContext context)
      {
         IdentityResult ir;

         // rm will allow us to manage
         // our web application's account roles
         var rm = new RoleManager<IdentityRole>
             (new RoleStore<IdentityRole>(context));

         // create a canEdit role that allows
         // users with that role to modify contacts.
         ir = rm.Create(new IdentityRole("canEdit"));

         // um allows us to manage our web application's
         // user accounts.
         var um = new UserManager<ApplicationUser>(
             new UserStore<ApplicationUser>(context));

         var user = new ApplicationUser()
         {
            UserName = "user1@contoso.com"
         };
         ir = um.Create(user, "P@55word_!");
         if (ir.Succeeded == false)
         {
            Console.WriteLine("not succeeded");
            return ir.Succeeded;
         }
         Console.WriteLine("succeeded");
         ir = um.AddToRole(user.Id, "canEdit");
         return ir.Succeeded;
      }

      protected override void Seed(ContactManager.Models.ApplicationDbContext context)
      {
         //  This method will be called after migrating to the latest version.

         //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
         //  to avoid creating duplicate seed data. E.g.
         //
         //    context.People.AddOrUpdate(
         //      p => p.FullName,
         //      new Person { FullName = "Andrew Peters" },
         //      new Person { FullName = "Brice Lambson" },
         //      new Person { FullName = "Rowan Miller" }
         //    );
         //
         Console.WriteLine("seeeeed");
         AddUserAndRole(context);
         context.Contacts.AddOrUpdate(p => p.Name,
            new Contact
            {
               Name = "Debra Garcia",
               Address = "1234 Main St",
               City = "Redmond",
               State = "WA",
               Zip = "10999",
               Email = "debra@example.com",
            },
            new Contact
            {
               Name = "Thorsten Weinrich",
               Address = "5678 1st Ave W",
               City = "Redmond",
               State = "WA",
               Zip = "10999",
               Email = "thorsten@example.com",
            },
            new Contact
            {
               Name = "Yuhong Li",
               Address = "9012 State st",
               City = "Redmond",
               State = "WA",
               Zip = "10999",
               Email = "yuhong@example.com",
            },
            new Contact
            {
               Name = "Jon Orton",
               Address = "3456 Maple St",
               City = "Redmond",
               State = "WA",
               Zip = "10999",
               Email = "jon@example.com",
            },
            new Contact
            {
               Name = "Diliana Alexieva-Bosseva",
               Address = "7890 2nd Ave E",
               City = "Redmond",
               State = "WA",
               Zip = "10999",
               Email = "diliana@example.com",
            }
         );
      }
   }
}
