using Microsoft.EntityFrameworkCore;

public class ItemService : IItemService
    {
        private readonly AppDbContext _context;
        public ItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateItemAsync(ProductCreate model)
        {
            var entity = new ProductEntity
            {
                Name = model.Name,
                Description = model.Description,
                Cost = model.Cost,
                ProductTypeId = model.ProductTypeId
                
            };
            
            _context.Products.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<ProductListItem>> GetAllItemsAsync()
        {
            return await _context.Products.Select(i => new ProductListItem
            {
                Id = i.Id,
                Name = i.Name
            }).ToListAsync();
        }

        public async Task<ProductDetails> GetItemByIdAsync(int itemId)
        {
            ProductEntity item = await _context.Products.Include(i => i.ProductType).FirstOrDefaultAsync(i => i.Id == itemId);
            if (item is null)
            {
                return null;
            }
            // manuly mapping a GameEntity Object to a GameDetails Object
            return new ProductDetails
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Cost = item.Cost,
                ProductType = new ProductTypeListItem
                {
                    Id = item.ProductType.Id,
                    Name = item.ProductType.Name
                }
            };
        }

        public async Task<bool> EditItemAsync(ProductEdit request)
        {
            var itemEntity = await _context.Products.FindAsync(request.Id);
            
            if (itemEntity == null)
                return false;

            itemEntity.Name = request.Name;
            itemEntity.Description = request.Description;
            itemEntity.Cost = request.Cost;
            itemEntity.ProductTypeId = request.ProductTypeId;

            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteItemAsync(int itemId)
        {
            // Find the note by the given Id
            var itemEntity = await _context.Products.FindAsync(itemId);

            // Validate the note exists and is owned by the user
            if (itemEntity == null)
                return false;

            // Remove the note from the DbContext and assert that the one change was saved
            _context.Products.Remove(itemEntity);
            return await _context.SaveChangesAsync() == 1;

        }
    }