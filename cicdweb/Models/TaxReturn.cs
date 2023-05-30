namespace cicdweb.Models
{
    /// <summary>
    /// This class represents a tax return of a tax payer.
    /// Objects of this class have the taxpayer, the amount, the period and the duedate.
    /// A penalty fee is applied if the tax return is not paid until the duedate.
    /// </summary>
    public class TaxReturn
    {
        public TaxPayer TaxPayer { get; set; }
        public double Amount { get; set; }
        public int Period { get; set; }
        public DateTime DueDate { get; set; }
        public double Penalty { get; set; }

        public TaxReturn(TaxPayer taxPayer, double amount, int period, DateTime duedate)
        {
            TaxPayer = taxPayer;
            Amount = amount;
            Period = period;
            DueDate = duedate;
        }

        /// <summary>
        /// A penalty fee is applied if the tax return is not paid until the duedate.
        /// The penalty is calculated as 2 for each day passed after the duedate.
        /// </summary>
        public void CalculatePenalty()
        {
            if (DateTime.Now > DueDate)
            {
                Penalty = (DateTime.Now - DueDate).Days * 2;
            }
        }

        public void Pay()
        {
            if (Penalty > 0)
            {
                Amount += Penalty;
            }
        }
    }
 }
