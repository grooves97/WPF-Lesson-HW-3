using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SecurityApp.Services;

namespace SecurityApp.DataAcces
{
    public class DataInitializer : CreateDatabaseIfNotExists<SecurityContext>
    {
        protected override void Seed(SecurityContext context)
        {
            context.Users.Add(new Models.User
            {
                Login = "admin",
                Password = CryptoService.HashPassword("123")
            });
            context.Users.Add(new Models.User
            {
                Login = "Aslan",
                Password = CryptoService.HashPassword("wasd")
            });
            base.Seed(context);
        }
    }
}
