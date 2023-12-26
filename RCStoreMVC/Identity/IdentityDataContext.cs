


using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace RCStoreMVC.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        static IdentityDataContext()
        {
            Database.SetInitializer(new IdentityInitializer());
        }

        public IdentityDataContext() : base("dataConnection")
        {
        }
    }
}