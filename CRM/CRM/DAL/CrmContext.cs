using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CRM.Models;

namespace CRM.DAL
{
    public class CrmContext : DbContext
    {
        public CrmContext() : base("DefaultConnection")
        { }

        public DbSet<Section> Sections { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}