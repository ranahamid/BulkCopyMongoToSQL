using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Net;
using FXTF.Lib.RepositoryNoSQL.VM;

using FXTF.Lib.RepositorySQL.UnitOfWork;

namespace BulkCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            FTPReadWrite();

            Console.WriteLine("Finsihed");
            Console.ReadKey();
        }

        public static void FTPReadWrite()
        {
            WebClient request = new WebClient();
            string url = "ftp://13.78.119.83/" + "META_TRADER_USER.csv";
            request.Credentials = new NetworkCredential("BTFTP", "BT@123456");

            try
            {
                byte[] newFileData = request.DownloadData(url);
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);

                CSVReadWriteFTP(fileString);
                //   Console.WriteLine(fileString);
            }
            catch (WebException e)
            {
                // Do something such as log error, but this is based on OP's original code
                // so for now we do nothing.
                Console.WriteLine("Error!");
            }
        }


        public static void CSVReadWriteFTP(string fileString)
        {

            List<CSVData> VMs = new List<CSVData>();
            CSVData VM;
            string[,] values = LoadCsvFtp(fileString);

            Console.WriteLine("Read Finished.");


            //for SQL
            Console.WriteLine("Write in Database...");
            SqlConnection SQLconn = new SqlConnection();
            SQLconn.ConnectionString = @"Data Source=ATOMWS2012;Initial Catalog=FXTFPlusDev;User ID=devfxtf;Password=dev123456;Persist Security Info=false;";
            SQLconn.Open();

            for (int r = 0; r < num_rows; r++)
            {
                VM = new CSVData();

                string[] temp = new string[num_cols];
                for (int c = 0; c < num_cols; c++)
                {
                    temp[c] = values[r, c].ToString();
                }

                try
                {
                    VM.META_TRADER_USER_ID = Int32.Parse(temp[0].Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.META_TRADER_USER_ID = 0;
                }

             

              
                try
                {
                    VM.CUSTOMER_ID = Int32.Parse((temp[1]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.CUSTOMER_ID = 0;
                }

            
                try
                {
                    VM.ACTFOREX_USER_ID = Int32.Parse((temp[2]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.ACTFOREX_USER_ID = 0;
                }
              
                try
                {
                    VM.META_TRADER_USER_NAME = Int32.Parse((temp[3]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.META_TRADER_USER_NAME = 0;
                }
                VM.META_TRADER_PASSWORD = temp[4].Replace("\"", "");
                VM.META_TRADER_INVESTOR_PASSWORD = temp[5].Replace("\"", "");
             
                try
                {
                    VM.META_TRADER_PLAYER_ID = Int32.Parse((temp[6]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.META_TRADER_PLAYER_ID = 0;
                }
            
                try
                {
                    VM.IS_DEMO_USER = Int32.Parse((temp[7]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.IS_DEMO_USER = 0;
                }
             
                try
                {
                    VM.META_TRADER_USER_CAME_FROM = Int32.Parse((temp[8]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.META_TRADER_USER_CAME_FROM = 0;
                }
               
                try
                {
                    VM.META_TRADER_USER_STATUS = Int32.Parse((temp[9]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.META_TRADER_USER_STATUS = 0;
                }
              
                try
                {
                    VM.META_TRADER_USER_NAME_COUNT_DOWN = Int32.Parse(temp[10].Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.META_TRADER_USER_NAME_COUNT_DOWN = 0;
                }
              
                try
                {
                    VM.ACCOUNT_TYPE = Int32.Parse((temp[11]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.ACCOUNT_TYPE = 0;
                }
              
                try
                {
                    VM.COUNT_DOWN_STATUS = Int32.Parse((temp[12]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.COUNT_DOWN_STATUS = 0;
                }
              
                try
                {
                    VM.STATUS_UPDATED_AT = DateTime.Parse((temp[13]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.STATUS_UPDATED_AT = DateTime.Parse("01/01/1900");
                }
           
                try
                {
                    VM.CREATED_AT = DateTime.Parse((temp[14]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.CREATED_AT = DateTime.Parse("01/01/1900");
                }
               
                try
                {
                    VM.UPDATED_AT = DateTime.Parse((temp[15]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.UPDATED_AT = DateTime.Parse("01/01/1900");
                }
              
                try
                {
                    VM.LIVE_DATE = DateTime.Parse((temp[16]).Replace("\"", ""));
                }
                catch (Exception e)
                {
                    VM.LIVE_DATE = DateTime.Parse("01/01/1900");
                }
                VMs.Add(VM);
                Console.WriteLine("Parse: "+r);

                /*
                VM.META_TRADER_USER_ID = temp[0].Replace("\"", "");
                VM.CUSTOMER_ID = (temp[1]).Replace("\"", "");
                VM.ACTFOREX_USER_ID = (temp[2]).Replace("\"", "");
                VM.META_TRADER_USER_NAME = (temp[3]).Replace("\"", "");
                VM.META_TRADER_PASSWORD = temp[4].Replace("\"", "");
                VM.META_TRADER_INVESTOR_PASSWORD = temp[5].Replace("\"", "");
                VM.META_TRADER_PLAYER_ID = (temp[6]).Replace("\"", "");
                VM.IS_DEMO_USER = (temp[7]).Replace("\"", "");
                VM.META_TRADER_USER_CAME_FROM = (temp[8]).Replace("\"", "");
                VM.META_TRADER_USER_STATUS = (temp[9]).Replace("\"", "");
                VM.META_TRADER_USER_NAME_COUNT_DOWN = temp[10].Replace("\"", "");
                VM.ACCOUNT_TYPE = (temp[11]).Replace("\"", "");
                VM.COUNT_DOWN_STATUS = (temp[12]).Replace("\"", "");
                VM.STATUS_UPDATED_AT = (temp[13]).Replace("\"", "");
                VM.CREATED_AT = (temp[14]).Replace("\"", "");
                VM.UPDATED_AT = (temp[15]).Replace("\"", "");
                VM.LIVE_DATE = (temp[16]).Replace("\"", "");*/
                /*    if (r == 100)
                        break;
                 */

                //for SQL

                SqlCommand cmd = new SqlCommand("[dbo].[sp_CSVData]", SQLconn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("META_TRADER_USER_ID", VM.META_TRADER_USER_ID);
                cmd.Parameters.AddWithValue("CUSTOMER_ID", VM.CUSTOMER_ID);
                cmd.Parameters.AddWithValue("ACTFOREX_USER_ID", VM.META_TRADER_USER_NAME);
                cmd.Parameters.AddWithValue("META_TRADER_PASSWORD", VM.META_TRADER_PASSWORD);
                cmd.Parameters.AddWithValue("META_TRADER_INVESTOR_PASSWORD", VM.META_TRADER_INVESTOR_PASSWORD);
                cmd.Parameters.AddWithValue("META_TRADER_PLAYER_ID", VM.META_TRADER_PLAYER_ID);
                cmd.Parameters.AddWithValue("IS_DEMO_USER", VM.IS_DEMO_USER);
                cmd.Parameters.AddWithValue("META_TRADER_USER_CAME_FROM", VM.META_TRADER_USER_CAME_FROM);
                cmd.Parameters.AddWithValue("META_TRADER_USER_STATUS", VM.META_TRADER_USER_STATUS);
                cmd.Parameters.AddWithValue("META_TRADER_USER_NAME_COUNT_DOWN", VM.META_TRADER_USER_NAME_COUNT_DOWN);
                cmd.Parameters.AddWithValue("ACCOUNT_TYPE", VM.ACCOUNT_TYPE);
                cmd.Parameters.AddWithValue("COUNT_DOWN_STATUS", VM.COUNT_DOWN_STATUS);
                cmd.Parameters.AddWithValue("STATUS_UPDATED_AT", VM.STATUS_UPDATED_AT);
                cmd.Parameters.AddWithValue("CREATED_AT", VM.CREATED_AT);
                cmd.Parameters.AddWithValue("UPDATED_AT", VM.UPDATED_AT);
                cmd.Parameters.AddWithValue("LIVE_DATE", VM.LIVE_DATE);
                cmd.ExecuteNonQuery();

            }
           

            //MOngoDB
            /* MDUnitOfWork oMDUnitOfWork = new MDUnitOfWork();
             oMDUnitOfWork.CSvRead.InsertMany(VMs, "FTPCsvReadTemp01");*/
        }

        public static string[,] LoadCsvFtp(string whole_file)
        {

            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
            StringSplitOptions.RemoveEmptyEntries);
            num_rows = lines.Length;
            num_cols = lines[0].Split(',').Length;


            string[,] values = new string[num_rows, num_cols];
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }
            return values;
        }



        private static int num_rows = 0;
        private static int num_cols = 0;
        public static void CSVReadWrite()
        {

            List<CSVData> VMs = new List<CSVData>();
            CSVData VM;
            string[,] values = LoadCsv();

            for (int r = 0; r < num_rows; r++)
            {
                VM = new CSVData();

                string[] temp = new string[num_cols];
                for (int c = 0; c < num_cols; c++)
                {
                    temp[c] = values[r, c].ToString();
                }
                /*VM.META_TRADER_USER_ID = (temp[0]);
                VM.CUSTOMER_ID = (temp[1]);
                VM.ACTFOREX_USER_ID = (temp[2]);
                VM.META_TRADER_USER_NAME = (temp[3]);
                VM.META_TRADER_PASSWORD = temp[4];
                VM.META_TRADER_INVESTOR_PASSWORD = temp[5];
                VM.META_TRADER_PLAYER_ID = (temp[6]);
                VM.IS_DEMO_USER = (temp[7]);
                VM.META_TRADER_USER_CAME_FROM = (temp[8]);
                VM.META_TRADER_USER_STATUS = (temp[9]);
                VM.META_TRADER_USER_NAME_COUNT_DOWN = temp[10];
                VM.ACCOUNT_TYPE = (temp[11]);
                VM.COUNT_DOWN_STATUS = (temp[12]);
                VM.STATUS_UPDATED_AT = (temp[13]);
                VM.CREATED_AT = (temp[14]);
                VM.UPDATED_AT = (temp[15]);
                VM.LIVE_DATE = (temp[16]);*/
                VMs.Add(VM);

            }

            MDUnitOfWork oMDUnitOfWork = new MDUnitOfWork();
            oMDUnitOfWork.CSvRead.InsertMany(VMs, "CsvReadTemp");
        }

        public static string[,] LoadCsv()
        {
            //string loc = @"C:\DevTeam\TestProject\BulkCopy\BulkCopy\META_TRADER_USER.csv";
            string loc = @"C:\Users\Rana Hamid\Desktop\BulkCopy\BulkCopy\BulkCopy\META_TRADER_USER.csv";

            string whole_file = System.IO.File.ReadAllText(loc);
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
            StringSplitOptions.RemoveEmptyEntries);
            num_rows = lines.Length;
            num_cols = lines[0].Split(',').Length;


            string[,] values = new string[num_rows, num_cols];
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }
            return values;
        }





        //await MDlUow.Tblmt4_usersRepository.InsertMany(users, NoSqlTables.mt4_users);





        public static void BulkDataCopy()
        {
            string strMySQLConnString ="";

            //string strTblMt4DateWise = "mt4_open_trades_by_date";           
            //string Query1 = "select * from mt4live.mt4_open_trades_by_date where ID between 0 and 2762077;";
            //string Query2= "select * from mt4live.mt4_open_trades_by_date where ID between 2762078 and 6062077;";


            string strTblmt4Daily = "mt4_daily";
            //string Query3 = "select * from mt4live.mt4_daily limit 0,20000000;";
            //string Query4 = "select * from mt4live.mt4_daily limit 20000001,10000000;";
            string Query5 = "select * from mt4live.mt4_daily limit 0,20000000;";
            //string Query6 = "select * from mt4live.mt4_daily limit 60000001,20000000;";


            //string Query = "select * from mt4live.mt4_daily;";
            string Query = "select count(*) from mt4live.mt4_daily;";

            MySqlConnection MySQLConn = new MySqlConnection(strMySQLConnString);
            MySqlCommand MySqlCmd = new MySqlCommand(Query, MySQLConn);
            MySqlCmd.CommandTimeout = 500000;

            MySQLConn.Open();
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = MySqlCmd;


            Int64 count = (Int64)MySqlCmd.ExecuteScalar();


            DataTable dTable = new DataTable();
            dTable.Clear();

            //MyAdapter.Fill(dTable);
            //string abc = dTable.Rows.Count.ToString();

            MySQLConn.Close();

            //CopyToSQLServer(dTable, strTblmt4Daily);
        }



        public static void MSSQLData()
        {
            List<mt4_daily> VMs = new List<mt4_daily>();
            mt4_daily VM;

            SqlConnection SQLconn = new SqlConnection();
            SQLconn.ConnectionString = "Data Source=13.78.52.130;Initial Catalog=MT4Live;User id=fxtf_mssql_root;Password=MsSQL2016RootFxTf;";
            // string strQueryOld = "select top 20 * from mt4_daily";

            string strQuery = "select * from mt4_daily";
            //  string strQuery = "select top 20 * from mt4_daily";
            SqlCommand SqlCmd = new SqlCommand(strQuery, SQLconn);
            //  SqlCmd.CommandTimeout = 500000;
            SqlCmd.CommandTimeout = 0;

            SQLconn.Open();
            SqlDataAdapter MyAdapter = new SqlDataAdapter();
            MyAdapter.SelectCommand = SqlCmd;

            using (SqlDataReader dr = SqlCmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    VM = new mt4_daily();

                    VM.Balance = Convert.ToDouble(dr["Login"]);
                    VM.Time = Convert.ToDateTime(dr["TIME"]);
                    VM.Group = dr["Group"].ToString();
                    VM.Bank = dr["BANK"].ToString();
                    VM.BalancePrev = Convert.ToDouble(dr["BALANCE_PREV"]);
                    VM.Balance = Convert.ToDouble(dr["Balance"]);
                    VM.Deposit = Convert.ToDouble(dr["DEPOSIT"]);
                    VM.Credit = Convert.ToDouble(dr["CREDIT"]);
                    VM.ProfitClosed = Convert.ToDouble(dr["PROFIT_CLOSED"]);
                    VM.Profit = Convert.ToDouble(dr["PROFIT"]);
                    VM.Equity = Convert.ToDouble(dr["EQUITY"]);
                    VM.Margin = Convert.ToDouble(dr["MARGIN"]);
                    VM.MarginFree = Convert.ToDouble(dr["MARGIN_FREE"]);
                    VM.ModifyTime = Convert.ToDateTime(dr["MODIFY_TIME"]);
                    VMs.Add(VM);
                }
            }

            MDUnitOfWork oMDUnitOfWork = new MDUnitOfWork();
            oMDUnitOfWork.Tblmt4_daily.InsertMany(VMs, "mt4_dailyTemp");

            //await MDlUow.Tblmt4_usersRepository.InsertMany(users, NoSqlTables.mt4_users);

            SQLconn.Close();

        }



        public static void MSSQLData2()
        {
            List<mt4_open_trades_by_date> VMs = new List<mt4_open_trades_by_date>();
            mt4_open_trades_by_date VM;

            SqlConnection SQLconn = new SqlConnection();
            SQLconn.ConnectionString = "";
            // string strQueryOld = "select top 20 * from mt4_daily";

            string strQuery = "select  * from mt4_open_trades_by_date";
            //  string strQuery = "select top 20 * from mt4_daily";
            SqlCommand SqlCmd = new SqlCommand(strQuery, SQLconn);
            //  SqlCmd.CommandTimeout = 500000;
            SqlCmd.CommandTimeout = 0;

            SQLconn.Open();
            SqlDataAdapter MyAdapter = new SqlDataAdapter();
            MyAdapter.SelectCommand = SqlCmd;

            using (SqlDataReader dr = SqlCmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    VM = new mt4_open_trades_by_date();


                    VM.ID = Convert.ToInt64(dr["ID"]);
                    VM.DATE = Convert.ToDateTime(dr["DATE"]);
                    VM.TICKET = Convert.ToInt32(dr["TICKET"]);
                    VM.LOGIN = Convert.ToInt32(dr["LOGIN"]);
                    VM.SYMBOL = dr["SYMBOL"].ToString();
                    VM.DIGITS = Convert.ToInt32(dr["DIGITS"]);
                    VM.CMD = Convert.ToInt32(dr["ID"]);
                    VM.VOLUME = Convert.ToInt32(dr["CMD"]);
                    VM.OPEN_TIME = Convert.ToDateTime(dr["OPEN_TIME"]);
                    VM.OPEN_PRICE = Convert.ToDouble(dr["OPEN_PRICE"]);
                    VM.SL = Convert.ToDouble(dr["SL"]);
                    VM.TP = Convert.ToDouble(dr["TP"]);
                    VM.CLOSE_TIME = Convert.ToDateTime(dr["CLOSE_TIME"]);
                    VM.EXPIRATION = Convert.ToDateTime(dr["EXPIRATION"]);
                    VM.REASON = Convert.ToInt32(dr["REASON"]);
                    VM.CONV_RATE1 = Convert.ToDouble(dr["CONV_RATE1"]);
                    VM.CONV_RATE2 = Convert.ToDouble(dr["CONV_RATE2"]);
                    VM.COMMISSION = Convert.ToDouble(dr["COMMISSION"]);
                    VM.COMMISSION_AGENT = Convert.ToDouble(dr["COMMISSION_AGENT"]);
                    VM.SWAPS = Convert.ToDouble(dr["SWAPS"]);
                    VM.CLOSE_PRICE = Convert.ToDouble(dr["CLOSE_PRICE"]);
                    VM.PROFIT = Convert.ToDouble(dr["PROFIT"]);
                    VM.TAXES = Convert.ToDouble(dr["TAXES"]);
                    VM.COMMENT = dr["COMMENT"].ToString();
                    VM.INTERNAL_ID = Convert.ToInt32(dr["INTERNAL_ID"]);
                    VM.MARGIN_RATE = Convert.ToDouble(dr["MARGIN_RATE"]);
                    VM.TIMESTAMP = Convert.ToInt32(dr["TIMESTAMP"]);
                    VM.GW_VOLUME = Convert.ToInt32(dr["GW_VOLUME"]);
                    VM.GW_OPEN_PRICE = Convert.ToInt32(dr["GW_OPEN_PRICE"]);
                    VM.GW_CLOSE_PRICE = Convert.ToInt32(dr["GW_CLOSE_PRICE"]);
                    VM.MODIFY_TIME = Convert.ToDateTime(dr["MODIFY_TIME"]);

                    //VM.Balance = Convert.ToDouble(dr["Login"]);
                    //VM.Time = Convert.ToDateTime(dr["TIME"]);
                    //VM.Group = dr["Group"].ToString();
                    //VM.Bank = dr["BANK"].ToString();
                    //VM.BalancePrev = Convert.ToDouble(dr["BALANCE_PREV"]);
                    //VM.Balance = Convert.ToDouble(dr["Balance"]);
                    //VM.Deposit = Convert.ToDouble(dr["DEPOSIT"]);
                    //VM.Credit = Convert.ToDouble(dr["CREDIT"]);
                    //VM.ProfitClosed = Convert.ToDouble(dr["PROFIT_CLOSED"]);
                    //VM.Profit = Convert.ToDouble(dr["PROFIT"]);
                    //VM.Equity = Convert.ToDouble(dr["EQUITY"]);
                    //VM.Margin = Convert.ToDouble(dr["MARGIN"]);
                    //VM.MarginFree = Convert.ToDouble(dr["MARGIN_FREE"]);
                    //VM.ModifyTime = Convert.ToDateTime(dr["MODIFY_TIME"]);
                    VMs.Add(VM);
                }
            }

            MDUnitOfWork oMDUnitOfWork = new MDUnitOfWork();
            oMDUnitOfWork.Mt4OpenTradesByDate.InsertMany(VMs, "Mt4OpenTradesByDateTemp");

            //await MDlUow.Tblmt4_usersRepository.InsertMany(users, NoSqlTables.mt4_users);

            SQLconn.Close();

        }


        public static void CopyToSQLServer(DataTable dTable, string strTableName)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=13.78.52.130;Initial Catalog=MT4Live;User id=fxtf_mssql_root;Password=MsSQL2016RootFxTf;";
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conn))
            {
                sqlBulkCopy.BulkCopyTimeout = 50000;
                sqlBulkCopy.DestinationTableName = strTableName;
                conn.Open();
                sqlBulkCopy.WriteToServer(dTable);
                conn.Close();
            }
        }


    }
}
