using cicdweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testweb
{
    public class TaxReturnTest
    {
        [Fact]
        public void TestCalculation()
        {
            DateTime tenDaysAgo = DateTime.Now.AddDays(-10);
            TaxPayer taxPayer = new TaxPayer("Vladimir", "HU23425");
            TaxReturn taxReturn = new TaxReturn(taxPayer, 100, 2018, tenDaysAgo);

            taxReturn.CalculatePenalty();

            Assert.Equal(20, taxReturn.Penalty);
        }
    }
}
