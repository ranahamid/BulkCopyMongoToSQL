using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXTF.Lib.RepositoryNoSQL.VM
{
    public partial class CSVData : EntityBase
    {
        public int META_TRADER_USER_ID { get; set; }
        public int CUSTOMER_ID { get; set; }
        public int ACTFOREX_USER_ID { get; set; }
        public int META_TRADER_USER_NAME { get; set; }
        public string META_TRADER_PASSWORD { get; set; }
        public string META_TRADER_INVESTOR_PASSWORD { get; set; }
        public int META_TRADER_PLAYER_ID { get; set; }
        public int IS_DEMO_USER { get; set; }

        public int META_TRADER_USER_CAME_FROM { get; set; }
        public int META_TRADER_USER_STATUS { get; set; }

        public int META_TRADER_USER_NAME_COUNT_DOWN { get; set; }
        public int ACCOUNT_TYPE { get; set; }
        public int COUNT_DOWN_STATUS { get; set; }
        public DateTime STATUS_UPDATED_AT { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }
        public DateTime LIVE_DATE { get; set; }

        /* public string META_TRADER_USER_ID { get; set; }
         public string CUSTOMER_ID { get; set; }
         public string ACTFOREX_USER_ID { get; set; }
         public string META_TRADER_USER_NAME { get; set; }
         public   string META_TRADER_PASSWORD { get; set; }
         public   string META_TRADER_INVESTOR_PASSWORD { get; set; }
         public string META_TRADER_PLAYER_ID { get; set; }
         public string IS_DEMO_USER { get; set; }

         public string META_TRADER_USER_CAME_FROM  { get; set; }
         public string META_TRADER_USER_STATUS { get; set; }

         public   string META_TRADER_USER_NAME_COUNT_DOWN  { get; set; }
         public string ACCOUNT_TYPE  { get; set; }
         public string COUNT_DOWN_STATUS  { get; set; }
         public string STATUS_UPDATED_AT { get; set; }
         public string CREATED_AT { get; set; }
         public string UPDATED_AT { get; set; }
         public string LIVE_DATE  { get; set; }*/
    }
}
