using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Sample.DDD.Domin;

namespace Transfer.Sample.DDD.Domin.IRepository
{
    public interface IAccountRepository
    {
        Account GetAccount(long ID);
    }
}
