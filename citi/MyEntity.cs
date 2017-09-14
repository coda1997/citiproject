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

        public override string ToString()
        {
            return base.ToString()+Asset_standard+National_debt+Cost_deposit;
        }
        public string getAssetsTotal()
        {
            double assetsTotal = Convert.ToDouble(Asset_standard) + Convert.ToDouble(Bond) + Convert.ToDouble(NonStandardAssets) + Convert.ToDouble(Cash) + Convert.ToDouble(Currency_market_tool) + Convert.ToDouble(Asset) + Convert.ToDouble(Other);
            return assetsTotal.ToString();
        }
        public string getLoanTotal()
        {
            double loanTotal = Convert.ToDouble(Cost_deposit) + Convert.ToDouble(Cost_finance);
            return loanTotal.ToString();
        }
        public string getTwoTotal()
        {
            double twoTotal = Convert.ToDouble(getLoanTotal()) + Convert.ToDouble(Trust_rate);
            return twoTotal.ToString();
        }


    }
}
