using CustomerOrderManagement.Models.APIModels.Order;
using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Repository.Abstractions;
using EFCoreSamples.Database;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderManagement.Repository
{
    public class OrderRepository:Repository<Order>,IOrderRepository
    {
        DbContext _dbContext;
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = new CustomerOrderDbContext();
        }

        public async Task<bool> PayNow(OrderCreateDTO orderCreateDTO)
        {
            var customerAccount = _dbContext.Set<CustomerAccountBalance>();
            var productStock = _dbContext.Set<ProductStock>();
            var companyAccount = _dbContext.Set<CompanyAccountBalance>();
            using (var transaction =_dbContext.Database.BeginTransaction())
            {
                try
                {
                    var order = new Order
                    {
                        OrderedOn = DateTime.Now,
                        CustomerId = orderCreateDTO.CustomerId,
                        ProductId = orderCreateDTO.ProductId,
                        TotalAmount = orderCreateDTO.TotalAmount
                    };
                    await _dbContext.AddAsync(order);
                    await _dbContext.SaveChangesAsync();

                    var customerAc = await customerAccount.FirstOrDefaultAsync(ca => ca.CustomerId == orderCreateDTO.CustomerId);
                    if(customerAc.Balance<orderCreateDTO.TotalAmount)
                    {
                        throw new Exception("Sorry You Do not have enough balance in account");
                    }
                    customerAc.Balance -= orderCreateDTO.TotalAmount;
                    await _dbContext.SaveChangesAsync();

                    var companyAc = await companyAccount.FindAsync(1);
                    companyAc.Amount += orderCreateDTO.TotalAmount;
                    await _dbContext.SaveChangesAsync();

                    var productSt = await productStock.FirstOrDefaultAsync(ps => ps.ProductId == orderCreateDTO.ProductId);
                    if (productSt != null)
                    {
                        if (productSt.Quantity > 0)
                        {
                            productSt.Quantity -= 1;
                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            throw new Exception("Product not available");
                        }
                    }
                    else
                    {
                        throw new Exception("Product Not found");
                    }
                    await transaction.CommitAsync();
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
            return true;
        }
    }
}
