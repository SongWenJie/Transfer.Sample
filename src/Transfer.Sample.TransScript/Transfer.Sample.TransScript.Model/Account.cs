using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Sample.TransScript.Model
{
    /// <summary>
    /// 银行账号实体类
    /// </summary>
    public class Account
    {
        public Account()
        {
            this.TransferHistorys = new List<TransferHistory>();
        }

        /// <summary>
        /// 账户ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 账户金额
        /// </summary>
        public decimal MoneyAmount { get; set; }

        /// <summary>
        /// 转账历史记录
        /// </summary>
        public IList<TransferHistory> TransferHistorys { get; set; }
    }

}
