using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using IBLL;
namespace BLL
{
    public   class UserService:BaseService<User>,InterfaceUserService
    {
        public UserService() : base(RepositotyFactory.UserRepository) { 
          
        }

        //public bool Exist(string userName) {
        //   return CurrentRepository.(u=>u.UserName==userName);
        //}
        public User Find(int userID)
        {
            return CurrentRepository.Find(u => u.UserID == userID);
        }
        public User Find(string userName)
        {
            return CurrentRepository.Find(u=>u.UserName==userName);
        }
        public IQueryable<User> FindPageList(int pageIndex,int pageSize,out int total)
        {
            return CurrentRepository.FindPageList(pageIndex, pageSize, out total, u => true, true, u => u.UserID);
        }

    }
}
