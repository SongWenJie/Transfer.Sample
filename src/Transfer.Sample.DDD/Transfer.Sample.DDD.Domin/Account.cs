using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Transfer.Sample.DDD.Domin
{
    /// <summary>
    /// 账户领域实体
    /// </summary>
    public class Account
    {
        public Account()
        {
        }
        public Account(long ID,decimal moneyAmount, IList<TransferHistory> transferHistories)
        {
            this.ID = ID;
            this.MoneyAmount = moneyAmount;
            this.TransferHistories = transferHistories;
        }

        /// <summary>
        /// 账户ID
        /// </summary>
        public long ID { get;  set; }
        /// <summary>
        /// 账户金额
        /// </summary>
        public decimal MoneyAmount { get; set; }
        /// <summary>
        /// 转账历史记录
        /// </summary>
        public IList<TransferHistory> TransferHistories { get; set; }

        /// <summary>
        /// 转出操作
        /// </summary>
        /// <param name="toAccountID">转入账户ID（目标账户ID）</param>
        /// <param name="transferMoney">转账金额</param>
        /// <param name="transferDate">转账日期</param>
        public void TransferTo(long toAccountID,decimal transferMoney,DateTime transferDate)
        {
            if(this.MoneyAmount < transferMoney)
            {
                throw new NotSupportedException("账户余额不足！！！");
            }

            this.MoneyAmount -= transferMoney;
            this.TransferHistories.Add(
                new TransferHistory(this.ID, toAccountID, transferMoney, transferDate));
        }

        /// <summary>
        /// 转入操作
        /// </summary>
        /// <param name="fromAccountID">转出账户ID（源账户ID）</param>
        /// <param name="transferMoney">转账金额</param>
        /// <param name="transferDate">转账日期</param>
        public void TransferFrom(long fromAccountID, decimal transferMoney, DateTime transferDate)
        {
            this.MoneyAmount += transferMoney;
            this.TransferHistories.Add(
                new TransferHistory(fromAccountID,this.ID, transferMoney, transferDate));
        }
    }
}
