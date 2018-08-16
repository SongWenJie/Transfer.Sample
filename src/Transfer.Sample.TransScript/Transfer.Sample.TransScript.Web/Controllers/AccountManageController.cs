using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Transfer.Sample.TransScript.IBLL;

namespace Transfer.Sample.TransScript.Web.Controllers
{
    public class AccountManageController : ApiController
    {
        public IAccountService AccountService { get; set; }

        [HttpPost]
        public string TransferMoney([FromBody]long toAccountID,
            [FromBody]long fromAccountID,
            [FromBody]decimal transferMoney)
        {
            AccountService.TransferMoney(toAccountID, fromAccountID, transferMoney);
            return "转账成功！！！";
        }
    }
}
