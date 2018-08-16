using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Sample.DDD.Domin;
using Transfer.Sample.DDD.Domin.IRepository;

namespace Transfer.Sample.DDD.Application
{
    public class TransferApp
    {
        private TransferService transferService;
        public TransferApp(IAccountRepository accountRepository)
        {
            transferService = new TransferService(accountRepository);
        }

        /// <summary>
        /// 转账操作
        /// </summary>
        /// <param name="toAccountID">目标账户ID</param>
        /// <param name="fromAccountID">源账户ID</param>
        /// <param name="transferMoney">转账金额</param>
        public void TransferMoney(long toAccountID, long fromAccountID, decimal transferMoney)
        {
            transferService.TransferMoney(toAccountID, fromAccountID, transferMoney);
        }
    }
}
