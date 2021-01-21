using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exchange
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DbConnection")
        { }
        public DbSet<User> Users { get; set; }
    }
}