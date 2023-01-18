
using Microsoft.EntityFrameworkCore;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CustomerCreateAsync(CustomerCreate model)
    {
        var entity = new CustomerEntity()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            FullName = model.FirstName + " " + model.LastName,
        };

        await _context.Customers.AddAsync(entity);
        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;

    }

    public async Task<CustomerDetail> GetCustomerByIdAsync(int customerId)
    {
        var customer = await _context.Customers.FindAsync(customerId);
        if (customer is null)
            return null;

        var CustomerDetail = new CustomerDetail
        {
            Id = customer.Id,
            FullName = customer.FullName
        };

        return CustomerDetail;
    }
    public async Task<List<CustomerListItem>> GetCustomersAsync()
    {
        return await _context.Customers.Select(c => new CustomerListItem
        {
            Id = c.Id,
            FullName = c.FullName
        }).ToListAsync();

    }
    public async Task<bool> DeleteCustomerAsync(int customerId)
    {
        var customerEntity = await _context.Customers.FindAsync(customerId);

        if (customerEntity == null)
            return false;

        _context.Customers.Remove(customerEntity);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> UpdateCustomerAsync(int customerId, CustomerEdit model)
    {
        var customer = await _context.Customers.FindAsync(customerId);
        if (customer == null)
            return default;

        customer.FullName = model.FullName;

        await _context.SaveChangesAsync();
        return true;
    }
}


