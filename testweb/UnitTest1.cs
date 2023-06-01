using cicdweb.Models;
using System.Security.Principal;

namespace testweb
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            Account account = new Account("Test", 100);            

            // Act
            account.Deposit(100);

            // Assert
            Assert.Equal(200, account.Balance);
        }
    }
}