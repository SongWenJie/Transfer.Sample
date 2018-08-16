using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Sample.TransScript.Model
{
    /// <summary>
    /// 转账历史记录实体类
    /// </summary>
    public class TransferHistory
    {
        /// <summary>
        /// 转入账户
        /// </summary>
        public long ToAccountID { get; set; }

        /// <summary>
        /// 转出账户
        /// </summary>
        public long FromAccountID { get; set; }

        /// <summary>
        /// 转账金额
        /// </summary>
        public decimal TransferAmount { get; set; }

        /// <summary>
        /// 转账日期
        /// </summary>
        public DateTime TransferDate { get; set; }
    }
}
