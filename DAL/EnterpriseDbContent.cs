using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
namespace DAL
{
    public class EnterpriseDbContent:DbContext
    {
       
             public DbSet<User> Users{get;set;}
             public EnterpriseDbContent()
                   : base("DefaultConnection"){
               }

    }
}
