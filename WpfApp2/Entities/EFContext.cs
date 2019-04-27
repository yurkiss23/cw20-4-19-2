using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Entities
{
    public class EFContext : DbContext
    {
        public EFContext() : base("conStr")
        {

        }
        public DbSet<EFUser> Users { get; set; }
    }
}
