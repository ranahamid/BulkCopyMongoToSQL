using FXTF.Lib.RepositoryNoSQL;
using System;

namespace FXTF.Lib.RepositoryNoSQL.VM
{
    public partial class mt4_open_trades_by_date : EntityBase
    {
        public Int64 ID { get; set; }
        public DateTime DATE { get; set; }
        public int TICKET { get; set; }
        public int LOGIN { get; set; }
        public string SYMBOL { get; set; }
        public int DIGITS { get; set; }
        public int CMD { get; set; }
        public int VOLUME { get; set; }
        public DateTime OPEN_TIME { get; set; }
        public double OPEN_PRICE { get; set; }
        public double SL { get; set; }
        public double TP { get; set; }
        public DateTime CLOSE_TIME { get; set; }
        public DateTime EXPIRATION { get; set; }
        public int REASON { get; set; }
        public double CONV_RATE1 { get; set; }
        public double CONV_RATE2 { get; set; }
        public double COMMISSION { get; set; }
        public double COMMISSION_AGENT { get; set; }
        public double SWAPS { get; set; }
        public double CLOSE_PRICE { get; set; }
        public double PROFIT { get; set; }
        public double TAXES { get; set; }
        public string COMMENT { get; set; }
        public int INTERNAL_ID { get; set; }
        public double MARGIN_RATE { get; set; }
        public int TIMESTAMP { get; set; }
        public int GW_VOLUME { get; set; }
        public int GW_OPEN_PRICE { get; set; }
        public int GW_CLOSE_PRICE { get; set; }
        public DateTime MODIFY_TIME { get; set; }
    }
}
