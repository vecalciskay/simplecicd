namespace cicdweb.Models
{
    /// <summary>
    /// This is a simple account class. It is possible to deposit
    /// and to withdraw. These operations shall add and subtract
    /// the amount to the balance.
    /// </summary>
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
    }
}
