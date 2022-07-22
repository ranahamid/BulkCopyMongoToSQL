using FXTF.Lib.RepositoryNoSQL.VM;

namespace FXTF.Lib.RepositoryNoSQL.UnitOfWork
{
    public interface IMDUnitOfWork
    {
        IMongoDbRepository<mt4_daily> Tblmt4_daily { get; }
        //IMongoDbRepository<mt4_users> Tblmt4_usersRepository { get; }
        //IMongoDbRepository<mt4_equity> Tblmt4_equityRepository { get; }
        //IMongoDbRepository<mt4_annualProfit> Tblmt4_annualProfitRepository { get; }
        //IMongoDbRepository<mt4_trade_users> Tblmt4_trade_usersRepository { get; }
    }
}
