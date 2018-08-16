using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Sample.DDD.Domin;
using Transfer.Sample.DDD.Domin.IRepository;

namespace Transfer.Sample.DDD.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccount(long ID)
        {
            //暂时不考虑数据库数据
            return new Account();
        }
    }
}
