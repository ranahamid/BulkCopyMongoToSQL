using FXTF.Lib.RepositoryNoSQL;
using FXTF.Lib.RepositoryNoSQL.VM;
using FXTF.Lib.RepositoryNoSQL.UnitOfWork;


namespace FXTF.Lib.RepositorySQL.UnitOfWork
{
    public class MDUnitOfWork : IMDUnitOfWork
    {
        public MDUnitOfWork()
        {
        }


        private IMongoDbRepository<CSVData> cSvRead;
        public IMongoDbRepository<CSVData> CSvRead
        {
            get
            {
                if (this.cSvRead == null)
                    this.cSvRead = new MongoDbRepository<CSVData>();
                return cSvRead;
            }
        }



        private IMongoDbRepository<mt4_open_trades_by_date> mt4OpenTradesByDate;
        public IMongoDbRepository<mt4_open_trades_by_date> Mt4OpenTradesByDate
        {
            get
            {
                if (this.mt4OpenTradesByDate == null)
                    this.mt4OpenTradesByDate = new MongoDbRepository<mt4_open_trades_by_date>();
                return mt4OpenTradesByDate;
            }
        }

        private IMongoDbRepository<mt4_daily> tblmt4_daily;
        public IMongoDbRepository<mt4_daily> Tblmt4_daily
        {
            get
            {
                if (this.tblmt4_daily == null)
                    this.tblmt4_daily = new MongoDbRepository<mt4_daily>();
                return tblmt4_daily;
            }
        }


        //private IMongoDbRepository<mt4_users> tblmt4_usersRepository;
        //public IMongoDbRepository<mt4_users> Tblmt4_usersRepository
        //{
        //    get
        //    {
        //        if (this.tblmt4_usersRepository == null)
        //            this.tblmt4_usersRepository = new MongoDbRepository<mt4_users>();
        //        return tblmt4_usersRepository;
        //    }
        //}
        //private IMongoDbRepository<mt4_equity> tblmt4_equityRepository;
        //public IMongoDbRepository<mt4_equity> Tblmt4_equityRepository
        //{
        //    get
        //    {
        //        if (this.tblmt4_equityRepository == null)
        //            this.tblmt4_equityRepository = new MongoDbRepository<mt4_equity>();
        //        return tblmt4_equityRepository;
        //    }
        //}
        //private IMongoDbRepository<mt4_annualProfit> tblmt4_annualProfitRepository;
        //public IMongoDbRepository<mt4_annualProfit> Tblmt4_annualProfitRepository
        //{
        //    get
        //    {
        //        if (this.tblmt4_annualProfitRepository == null)
        //            this.tblmt4_annualProfitRepository = new MongoDbRepository<mt4_annualProfit>();
        //        return tblmt4_annualProfitRepository;
        //    }
        //}
        //private IMongoDbRepository<mt4_trade_users> tblmt4_trade_usersRepository;
        //public IMongoDbRepository<mt4_trade_users> Tblmt4_trade_usersRepository
        //{
        //    get
        //    {
        //        if (this.tblmt4_trade_usersRepository == null)
        //            this.tblmt4_trade_usersRepository = new MongoDbRepository<mt4_trade_users>();
        //        return tblmt4_trade_usersRepository;
        //    }
        //}
    }
}
