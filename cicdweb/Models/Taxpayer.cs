using System.Security.Cryptography;

namespace cicdweb.Models
{
    /// <summary>
    /// This class represents a tax payer.
    /// The taxpayer has a name and a tax id, and a list of tax returns.
    /// 
    /// </summary>
    public class TaxPayer
    {
        public string Name { get; set; }
        public string TaxId { get; set; }
        public List<TaxReturn> TaxReturns { get; set; }

        public TaxPayer(string name, string taxId)
        {
            Name = name;
            TaxId = taxId;
            TaxReturns = new List<TaxReturn>();
        }

        public void AddTaxReturn(TaxReturn taxReturn)
        {
            TaxReturns.Add(taxReturn);
        }

        public void RemoveTaxReturn(TaxReturn taxReturn)
        {
            TaxReturns.Remove(taxReturn);
        }

        public void PayTaxReturn(TaxReturn taxReturn)
        {
            taxReturn.CalculatePenalty();
            taxReturn.Pay();
        }

        public void PayAllTaxReturns()
        {
            foreach (TaxReturn taxReturn in TaxReturns)
            {
                taxReturn.CalculatePenalty();
                taxReturn.Pay();
            }
        }
        public void PayOnlyTaxReturnThatAreDue()
        {
            foreach (TaxReturn taxReturn in TaxReturns)
            {
                if (taxReturn.DueDate < DateTime.Now)
                {
                    taxReturn.CalculatePenalty();
                    taxReturn.Pay();
                }
            }
        }
    }
}
