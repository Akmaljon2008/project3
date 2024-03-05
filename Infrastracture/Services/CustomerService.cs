namespace Infrastracture.Services;
using Dapper;
using Infrastracture.DattaContext;
using Domain.Models;

public class CustomerService
{
    private readonly DapperContext _db;

    public CustomerService()
    {
        _db = new DapperContext();
    }

    public List<Customer> GetCustomers()
    {
        var sql = "select * from Customer order by id";
        return _db.Connection().Query<Customer>(sql).ToList();
    }

    public void AddCustomer(Customer customer)
    {
        var sql = "insert into Customer(Fullname,Balance)values (@FullName,@Balance)";
        _db.Connection().Execute(sql, customer);
    }

    public void UpdateCusomer(Customer customer)
    {
        var sql = "update Customer set FullName = @FullName,Balance = @Balance where id = @id";
        _db.Connection().Execute(sql, customer);
    }
    
    public void DeleteCustomer(int id)
    {
        var sql = "delete from Customer where Id = @id";
        _db.Connection().Execute(sql, new { Id = id });
    }
}