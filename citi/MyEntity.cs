using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citi
{
    public class MyEntity
    {
        public string asset_standard { set; get; }      //标准资产
        public string national_debt { set; get; }       //国债
        public string enterprise_debt { set; get; }     //企业债
        public string trust_rate { set; get; }          //收、受益权
        public string trust_debt { set; get; }          //信托贷款
        public string debt_foundation { set; get; }     //委托贷款
        public string trust_debtRights { set; get; }    //交易所委托债权
        public string trust_stock { set; get; }         //带回购条款的股权性融资
        public string trust_transfer { set; get; }      //信贷资产转让
        public string receive { set; get; }             //应收账款
        public string self_debtRights { set; get; }     //私募债权
        public string bill { set; get; }                //票据类
        public string credit { set; get; }              //信用证
        public string other { set; get; }               //其他非标准化债权类投资
        public string cash { set; get; }                //现金及银行存款
        public string currency_market_tool { set; get; }//货币市场工具
        public string asset { set; get; }               //权益类资产
        public string cost_deposit { set; get; }        //定期存款
        public string cost_finance { set; get; }        //理财产品
        public string bank_deposit_rate { set; get; }   //定期存款利率
        public string financial_products { get; set; }  //理财产品收益率
        public string bond { get; set; }                //债券
        public string nonStandardAssets { get; set; }   //非标准化债权资产


      
        public string getAssetsTotal()
        {
            double assetsTotal = toDouble(asset_standard) + toDouble(bond) + toDouble(nonStandardAssets) + toDouble(cash) + toDouble(currency_market_tool) + toDouble(asset) + toDouble(other);
            return assetsTotal.ToString();
        }
        public string getLoanTotal()
        {
            double loanTotal = toDouble(cost_deposit) + toDouble(cost_finance);
            return loanTotal.ToString();
        }
        public string getTwoTotal()
        {
            //double twoTotal = toDouble(getLoanTotal()) + toDouble(Trust_rate);
            //return twoTotal.ToString();
            return getAssetsTotal();
        }
        private double toDouble(string value)
        {
            return value.Equals("") ? 0 : Convert.ToDouble(value);
        }
        public bool IsAllSetValue() {
            return asset_standard.Equals("") || national_debt.Equals("") || enterprise_debt.Equals("") || trust_rate.Equals("") ||
                trust_debt.Equals("") || debt_foundation.Equals("") || trust_debtRights.Equals("") || trust_stock.Equals("") ||
                trust_transfer.Equals("") || receive.Equals("") || self_debtRights.Equals("") || bill.Equals("") ||
                credit.Equals("") || other.Equals("") || cash.Equals("") || currency_market_tool.Equals("") ||
                asset.Equals("") || cost_deposit.Equals("") || cost_finance.Equals("") || bank_deposit_rate.Equals("") ||
                financial_products.Equals("") || bond.Equals("") || nonStandardAssets.Equals("");
        }
        public string ToJson() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{");
            stringBuilder.Append("\"asset_standard\" :" + asset_standard + ","
                + "\"national_debt\" :" + national_debt + ","
                + "\"enterprise_debt\" :" + enterprise_debt + ","
                + "\"trust_rate\" :" + trust_rate + ","
                + "\"trust_debt\" :" + trust_debt + ","
                + "\"debt_foundation\" :" + debt_foundation + ","
                + "\"trust_debtRights\" :" + trust_debtRights + ","
                + "\"trust_stock\" :" + trust_stock + ","
                + "\"trust_transfer\" :" + trust_transfer + ","
                + "\"receive\" :" + receive + ","
                + "\"self_debtRights\" :" + self_debtRights + ","
                + "\"bill\" :" + bill + ","
                + "\"credit\" :" + credit + ","
                + "\"cash\" :" + cash + ","
                + "\"currency_market_tool\" :" + currency_market_tool + ","
                + "\"asset\" :" + asset + ","
                + "\"cost_deposit\" :" + cost_deposit + ","
                + "\"cost_finance\" :" + cost_finance + ","
                + "\"bank_deposit_rate\" :" + bank_deposit_rate + ","
                + "\"financial_products\" :" + financial_products);
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
       
    }
}
