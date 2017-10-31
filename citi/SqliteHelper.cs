﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citi
{
    class SqliteHelper
    {
        private static readonly string m_DataSource =  "citihistory.db";


        private static readonly string m_ConnectionString;

        static SqliteHelper()
        {
            try
            {
                SQLiteConnectionStringBuilder connectionStringBuilder = new SQLiteConnectionStringBuilder
                {
                    Version = 3,
                    Pooling = true,
                    FailIfMissing = false,
                    DataSource = m_DataSource
                };
                m_ConnectionString = connectionStringBuilder.ConnectionString;
                using (SQLiteConnection conn = new SQLiteConnection(m_ConnectionString))
                {
                    conn.Open();
                }
            }
            catch
            {
                Console.WriteLine("can not open the database file");
            }
        }

        private static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(m_ConnectionString);
        }

        private static void PrepareCommand(SQLiteCommand cmd,SQLiteConnection conn,string cmdText,params object[] commandParameters)
        {
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandTimeout = 200;
            if (commandParameters != null)
            {
                foreach(object parm in commandParameters)
                {
                    cmd.Parameters.AddWithValue(string.Empty, parm);
                }
            }
        }


        public static DataSet ExecuteDataset(string cmdText,params object[] cmdParameters) {
            DataSet ds = new DataSet();
            SQLiteCommand sQLiteCommand = new SQLiteCommand();
            using(SQLiteConnection connection = GetConnection())
            {
                PrepareCommand(sQLiteCommand, connection, cmdText, cmdParameters);
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sQLiteCommand);
                dataAdapter.Fill(ds);
            }
            return ds;
        }
        public static void ExecuteSQLWithoutResult(string cmd) {
            SQLiteCommand sQLiteCommand = new SQLiteCommand();
            using (SQLiteConnection connection = GetConnection())
            {
                PrepareCommand(sQLiteCommand, connection, cmd, null);
                sQLiteCommand.ExecuteNonQuery();
            }
        }
        public static MyEntity GetEntity(String name)
        {
            MyEntity myEntity =null;
            String sql = "SELECT * from record where name = " + "'" + name + "';";
            DataSet ds = ExecuteDataset(sql, null);
            if (ds != null)
            {
                myEntity = new MyEntity();
                DataRowCollection drc = ds.Tables[0].Rows;
                if (drc.Count > 0)
                {
                    DataRow dataRow = drc[0];
                    myEntity.Asset_standard = dataRow[5] + "";
                    myEntity.National_debt = dataRow[6] + "";
                    myEntity.Enterprise_debt = dataRow[7] + "";
                    myEntity.Trust_rate = dataRow[8] + "";
                    myEntity.Trust_debt = dataRow[9] + "";
                    myEntity.Debt_foundation = dataRow[10] + "";
                    myEntity.Trust_debtRights = dataRow[11] + "";
                    myEntity.Trust_stock = dataRow[12] + "";
                    myEntity.Trust_transfer = dataRow[13] + "";
                    myEntity.Receive = dataRow[14] + "";
                    myEntity.Self_debtRights = dataRow[15] + "";
                    myEntity.Bill = dataRow[16] + "";
                    myEntity.Credit = dataRow[17] + "";
                    myEntity.Other = dataRow[18] + "";
                    myEntity.Cash = dataRow[19] + "";
                    myEntity.Currency_market_tool = dataRow[20] + "";
                    myEntity.Asset = dataRow[21] + "";
                    myEntity.Cost_deposit = dataRow[22] + "";
                    myEntity.Cost_finance = dataRow[23] + "";
                }
            }

            return myEntity;
        }

        //public static List<T> GetTableData<T>(string cmdText,params object[] parameters)where T : class
        //{
        //    List<T> dataList = new List<T>();
        //    try
        //    {
        //        using(SQLData context = new SQLiteContext(new SQLiteConnection(m_ConnectionString)))
        //        {

        //        }
        //    }
        //}
    }
}
