using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Sample.DDD.Domin.IRepository;

namespace Transfer.Sample.DDD.Domin
{
    /// <summary>
    /// 转账领域服务
    /// </summary>
    public class TransferService
    {
        private IAccountRepository accountRepository;
        public TransferService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        /// <summary>
        /// 转账操作
        /// </summary>
        /// <param name="toAccountID">目标账户ID</param>
        /// <param name="fromAccountID">源账户ID</param>
        /// <param name="transferMoney">转账金额</param>
        public void TransferMoney(long toAccountID,long fromAccountID,decimal transferMoney)
        {
            var toAccount = accountRepository.GetAccount(toAccountID);
            var fromAccount = accountRepository.GetAccount(fromAccountID);

            DateTime transDate = DateTime.Now;
            fromAccount.TransferTo(toAccount.ID, transferMoney, transDate);
            toAccount.TransferFrom(fromAccount.ID, transferMoney, transDate);
        }
    }
}
