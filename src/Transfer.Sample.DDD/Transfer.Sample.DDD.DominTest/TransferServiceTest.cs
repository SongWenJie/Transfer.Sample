using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Sample.DDD.Domin;
using Transfer.Sample.DDD.Domin.IRepository;

namespace Transfer.Sample.DDD.DominTest
{
    [TestFixture]
    public class TransferServiceTest
    {
        private Mock<IAccountRepository> MockAccountRepository { get; set; }
        private TransferService TransferService { get; set; }
        [SetUp]
        public void SetUp()
        {
            MockAccountRepository = new Mock<IAccountRepository>();
            TransferService = new TransferService(MockAccountRepository.Object);
        }


        [Test]
        public void Test_TransferMoney_MoneyIsNotEnough()
        {
            MockAccountRepository.Setup(m => m.GetAccount(123))
                .Returns(new Account(123, 100, new List<TransferHistory>()));
            MockAccountRepository.Setup(m => m.GetAccount(456))
                .Returns(new Account(456, 500, new List<TransferHistory>()));

            Assert.Throws<NotSupportedException>(()
               =>
            { TransferService.TransferMoney(456, 123, 200); });
        }

        [Test]
        public void Test_TransferMoney_MoneyIsEnough()
        {
            var s = MockAccountRepository.Setup(m => m.GetAccount(123))
                .Returns(new Account(123, 100, new List<TransferHistory>()));
            MockAccountRepository.Setup(m => m.GetAccount(456))
                .Returns(new Account(456, 500, new List<TransferHistory>()));

            Assert.DoesNotThrow(()
                =>
            { TransferService.TransferMoney(456, 123, 50); });
        }
    }
}
