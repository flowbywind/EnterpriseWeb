using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
namespace DAL
{
   public  class ContextFactory
    {
       public static EnterpriseDbContent GetCurrentContext()
       {
           EnterpriseDbContent context = CallContext.GetData("EnterpriseDbContent") as EnterpriseDbContent;
           if (context == null)
           {
               context = new EnterpriseDbContent();
               CallContext.SetData("EnterpriseDbContent",context);
           }
           return context;
       }
    }
}
