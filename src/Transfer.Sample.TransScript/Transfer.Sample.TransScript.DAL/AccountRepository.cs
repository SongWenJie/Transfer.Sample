using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Sample.TransScript.IDAL;
using Transfer.Sample.TransScript.Model;

namespace Transfer.Sample.TransScript.DAL
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccountByID(long ID)
        {
            //返回账户信息 暂不考虑数据库实现
            return new Account();
        }
    }
}
