using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citi
{
    public class MyEntity
    {
        public string Asset_standard { set; get; }
        public string National_debt { set; get; }
        public string Enterprise_debt { set; get; }
        public string Trust_rate { set; get; }
        public string Trust_debt { set; get; }
        public string Debt_foundation { set; get; }
        public string Trust_debtRights { set; get; }
        public string Trust_stock { set; get; }
        public string Trust_transfer { set; get; }
        public string Receive { set; get; }
        public string Self_debtRights { set; get; }
        public string Bill { set; get; }
        public string Credit { set; get; }
        public string Other { set; get; }
        public string Cash { set; get; }
        public string Currency_market_tool { set; get; }
        public string Asset { set; get; }
        public string Cost_deposit { set; get; }
        public string Cost_finance { set; get; }
        public string bank_deposit_rate { set; get; }
        public string Financial_products { get; set; }
        public override string ToString()
        {
            return base.ToString()+Asset_standard+National_debt+Cost_deposit;
        }


    }
}
