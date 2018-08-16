using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Sample.TransScript.IBLL
{
    public interface IAccountService
    {
        void TransferMoney(long toAccountID, long fromAccountID, decimal transferMoney);
    }
}
