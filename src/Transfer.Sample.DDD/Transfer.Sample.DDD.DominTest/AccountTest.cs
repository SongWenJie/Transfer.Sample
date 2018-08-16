using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Transfer.Sample.DDD.Domin;

namespace Transfer.Sample.DDD.DominTest
{
    [TestFixture]
    public class AccountTest
    {
       
        [Test]
        public void Test_TransferTo_MoneyIsNotEnough()
        {
            Account account = new Account(123,100,new List<TransferHistory>());

            Assert.Throws<NotSupportedException>(()
                =>
            { account.TransferTo(456, 200, DateTime.Now); });
        }

        [Test]
        public void Test_TransferTo_MoneyIsEnough()
        {
            Account account = new Account(123, 100, new List<TransferHistory>());

           account.TransferTo(456, 50, DateTime.Now);

            Assert.AreEqual(100 - 50, account.MoneyAmount);
            Assert.AreEqual(1, account.TransferHistories.Count);
            Assert.AreEqual(123, account.TransferHistories.FirstOrDefault().FromAccountId);
            Assert.AreEqual(456, account.TransferHistories.FirstOrDefault().ToAccountId);
            Assert.AreEqual(50, account.TransferHistories.FirstOrDefault().MoneyAmount);
        }

        [Test]
        public void Test_TransferFrom()
        {
            Account account = new Account(456, 100, new List<TransferHistory>());

            account.TransferFrom(123, 50, DateTime.Now);

            Assert.AreEqual(100 + 50, account.MoneyAmount);
            Assert.AreEqual(1, account.TransferHistories.Count);
            Assert.AreEqual(123, account.TransferHistories.FirstOrDefault().FromAccountId);
            Assert.AreEqual(456, account.TransferHistories.FirstOrDefault().ToAccountId);
            Assert.AreEqual(50, account.TransferHistories.FirstOrDefault().MoneyAmount);
        }
    }
}
