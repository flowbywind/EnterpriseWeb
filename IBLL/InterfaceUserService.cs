using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBLL
{
    public interface InterfaceUserService
    {
        bool Exist(string username);
        User Find(int userID);
        User Find(string username);
        IQueryable<User> FindPageList(int pageIndex,int pageSixe,out int totalCount,int order);
    }
}
