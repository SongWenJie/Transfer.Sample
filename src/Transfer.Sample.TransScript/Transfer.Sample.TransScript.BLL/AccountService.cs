using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Sample.TransScript.IBLL;
using Transfer.Sample.TransScript.IDAL;
using Transfer.Sample.TransScript.Model;

namespace Transfer.Sample.TransScript.BLL
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        /// <summary>
        /// 转账操作
        /// </summary>
        /// <param name="toAccountID">转入账户</param>
        /// <param name="fromAccountID">转出账户</param>
        /// <param name="transferMoney">转账金额</param>
        public void TransferMoney(long toAccountID, long fromAccountID,decimal transferMoney)
        {
            Account toAccount = accountRepository.GetAccountByID(toAccountID);
            Account fromAcconut = accountRepository.GetAccountByID(fromAccountID);

            if(fromAcconut.MoneyAmount < transferMoney)
            {
                throw new NotSupportedException("账户余额不足");
            }
            fromAcconut.MoneyAmount -= transferMoney;
            toAccount.MoneyAmount += transferMoney;

            DateTime transferDate = DateTime.Now;
            toAccount.TransferHistorys.Add(new TransferHistory
            {
                FromAccountID = fromAccountID,
                ToAccountID = toAccountID,
                TransferAmount = transferMoney,
                TransferDate = transferDate
            });
            fromAcconut.TransferHistorys.Add(new TransferHistory
            {
                FromAccountID = fromAccountID,
                ToAccountID = toAccountID,
                TransferAmount = transferMoney,
                TransferDate = transferDate
            });
        }
    }
}
