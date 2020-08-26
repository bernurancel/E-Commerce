using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace E_Commerce.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "Admin Rolü" };
                manager.Create(role);         
            }
            if (context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "User Rolü" };
                manager.Create(role);
            }
            if (context.Roles.Any(i => i.Name == "supplier"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "supplier", Description = "Satıcı Rolü" };
                manager.Create(role);
            }
            if (context.Users.Any(i => i.Name == "bernurancel"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Bernur", Surname = "Ançel", UserName = "bernurancel", Email = "bernur@gmail.com" };
                manager.Create(user, "123");
                manager.AddToRole(user.Id , "admin");
                manager.AddToRole(user.Id, "user");
                manager.AddToRole(user.Id, "supplier");
            }
            if (context.Users.Any(i => i.Name == "selinayancel"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Selinay", Surname = "Ançel", UserName = "selinayancel", Email = "selinay@gmail.com" };
                manager.Create(user, "1234");
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context); 
        }
    }
}