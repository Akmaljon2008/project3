using Dapper;

namespace Infrastracture.Services;
using Infrastracture.DattaContext;
using Domain.Models;
public class TranzactionService
{
    private readonly DapperContext _db;

    public TranzactionService()
    {
        _db = new DapperContext();
    }

    public List<Tranzaction> HistorTranzactions()
    {
        var sql = "select * from Tranzaction order by Id";
        return _db.Connection().Query<Tranzaction>(sql).ToList();
    }

    public void MakeTranzaction(Tranzaction tranzaction)
    {
        var sql = "insert into Tranzaction(SenderId,TakerId,Sum)values (@SenderId,@TakerId,@Sum)";
        _db.Connection().Execute(sql, tranzaction);
        var sql1 = "select * from Customer where id = @id";
        var sen = _db.Connection().QuerySingle<Customer>(sql1, new { Id = tranzaction.SenderId });
        var tak = _db.Connection().QuerySingle<Customer>(sql1, new { Id = tranzaction.TakerId });
        decimal minamount = sen.Balance - tranzaction.Sum;
        decimal plamount = tak.Balance + tranzaction.Sum;
        var sql2 = "update customer set Balance = @balance where id = @id";
        _db.Connection().Execute(sql2, new { Balance = minamount, Id = tranzaction.SenderId });
        _db.Connection().Execute(sql2, new { Balance = plamount, Id = tranzaction.TakerId });
    }
}