using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citi
{
    public class MyEntity
    {
        public string Asset_standard { set; get; }      //标准资产
        public string National_debt { set; get; }       //国债
        public string Enterprise_debt { set; get; }     //企业债
        public string Trust_rate { set; get; }          //收、受益权
        public string Trust_debt { set; get; }          //信托贷款
        public string Debt_foundation { set; get; }     //委托贷款
        public string Trust_debtRights { set; get; }    //交易所委托债权
        public string Trust_stock { set; get; }         //带回购条款的股权性融资
        public string Trust_transfer { set; get; }      //信贷资产转让
        public string Receive { set; get; }             //应收账款
        public string Self_debtRights { set; get; }     //私募债权
        public string Bill { set; get; }                //票据类
        public string Credit { set; get; }              //信用证
        public string Other { set; get; }               //其他非标准化债权类投资
        public string Cash { set; get; }                //现金及银行存款
        public string Currency_market_tool { set; get; }//货币市场工具
        public string Asset { set; get; }               //权益类资产
        public string Cost_deposit { set; get; }        //定期存款
        public string Cost_finance { set; get; }        //理财产品
        public string bank_deposit_rate { set; get; }   //定期存款利率
        public string Financial_products { get; set; }  //理财产品收益率
        public string Bond { get; set; }                //债券
        public string NonStandardAssets { get; set; }   //非标准化债权资产

      
        public string getAssetsTotal()
        {
            double assetsTotal = toDouble(Asset_standard) + toDouble(Bond) + toDouble(NonStandardAssets) + toDouble(Cash) + toDouble(Currency_market_tool) + toDouble(Asset) + toDouble(Other);
            return assetsTotal.ToString();
        }
        public string getLoanTotal()
        {
            double loanTotal = toDouble(Cost_deposit) + toDouble(Cost_finance);
            return loanTotal.ToString();
        }
        public string getTwoTotal()
        {
            double twoTotal = toDouble(getLoanTotal()) + toDouble(Trust_rate);
            return twoTotal.ToString();
        }
        private double toDouble(string value)
        {
            return value.Equals("") ? 0 : Convert.ToDouble(value);
        }
        public bool IsAllSetValue() {
            return Asset_standard.Equals("") || National_debt.Equals("") || Enterprise_debt.Equals("") || Trust_rate.Equals("") ||
                Trust_debt.Equals("") || Debt_foundation.Equals("") || Trust_debtRights.Equals("") || Trust_stock.Equals("") ||
                Trust_transfer.Equals("") || Receive.Equals("") || Self_debtRights.Equals("") || Bill.Equals("") ||
                Credit.Equals("") || Other.Equals("") || Cash.Equals("") || Currency_market_tool.Equals("") ||
                Asset.Equals("") || Cost_deposit.Equals("") || Cost_finance.Equals("") || bank_deposit_rate.Equals("") ||
                Financial_products.Equals("") || Bond.Equals("") || NonStandardAssets.Equals("");
        }

    }
}
