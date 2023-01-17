
public interface ICustomerService
{
    public Task<bool> CustomerCreateAsync(CustomerCreate model);
    public Task<CustomerDetail> GetCustomerByIdAsync(int customerId);
    public Task<bool> UpdateCustomerAsync(int customerId, CustomerEdit model);

    public Task<bool> DeleteCustomerAsync(int customerId);

    public Task<List<CustomerListItem>> GetCustomersAsync();

}



