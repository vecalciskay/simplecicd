using System.Security.Cryptography;

namespace cicdweb.Models
{
    /// <summary>
    /// This is a TaxPayer class.
    /// Attributes here are the tax id and the name of the taxpayer.
    /// </summary>
    public class TaxPayer
    {
        public string TaxId { get; set; }
        public string Name { get; set; }
        public List<TaxReturn> TaxReturns { get; set; }

        public TaxPayer(string taxId, string name)
        {
            TaxId = taxId;
            Name = name;
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

        public double CalculateTotalTaxReturns()
        {
            double total = 0;
            foreach (TaxReturn taxReturn in TaxReturns)
            {
                total += taxReturn.Amount;
            }
            return total;
        }

        public void PayTaxReturns()
        {
            foreach (TaxReturn taxReturn in TaxReturns)
            {
                taxReturn.Pay();
            }
        }

        public void PayOnlyTheTaxesThatAreBeforeTheDueDate()
        {

            foreach (TaxReturn taxReturn in TaxReturns)
            {
                if (taxReturn.DueDate > DateTime.Now)
                {
                    taxReturn.Pay();
                }
            }
        }
    }
}

