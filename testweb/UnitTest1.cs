using cicdweb.Models;
using System.Security.Principal;

namespace testweb
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Account account = new Account("Test", 100);
            
            account.Deposit(100);

            Assert.Equal(200, account.Balance);
        }
    }
}