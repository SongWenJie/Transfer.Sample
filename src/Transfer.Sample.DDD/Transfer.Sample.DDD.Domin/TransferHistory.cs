using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Sample.DDD.Domin
{
    /// <summary>
    /// 转账历史记录值对象
    /// </summary>
    public class TransferHistory
    {
        public TransferHistory(long fromAccountId,
                                long toAccountId,
                                decimal moneyAmount,
                                DateTime transferDate)
        {
            this.FromAccountId = fromAccountId;
            this.ToAccountId = toAccountId;
            this.MoneyAmount = moneyAmount;
            this.TransferDate = transferDate;
        }

        /// <summary>
        /// 转出账户
        /// </summary>
        public long FromAccountId { get; private set; }
        /// <summary>
        /// 转入账户
        /// </summary>
        public long ToAccountId { get; private set; }
        /// <summary>
        /// 转账金额
        /// </summary>
        public decimal MoneyAmount { get; private set; }
        /// <summary>
        /// 转账时间
        /// </summary>
        public DateTime TransferDate { get; private set; }
    }
}
