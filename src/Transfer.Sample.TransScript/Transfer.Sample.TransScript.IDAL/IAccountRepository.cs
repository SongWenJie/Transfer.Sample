using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Sample.TransScript.Model;

namespace Transfer.Sample.TransScript.IDAL
{
    public interface IAccountRepository
    {
        Account GetAccountByID(long ID);
    }
}
