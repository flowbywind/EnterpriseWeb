using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
namespace DAL
{
   public class RepositotyFactory
    {
       public static InterfaceUserRepository UserRepository { get { return new UserRepository(); } }
    }

}
