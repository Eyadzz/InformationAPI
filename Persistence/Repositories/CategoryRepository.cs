using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository 
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    /*public async Task<ICollection<Information>> GetAllInfo(string categoryName)
    {
        var result = await Context.Categories.Where(c => c.Name == categoryName).SingleOrDefaultAsync();
        return result!.Information;
    }*/

    public async Task<Category> GetByName(string? categoryName)
    {
        var result = await Context.Categories.SingleOrDefaultAsync(c => c.Name == categoryName);
        return result!;
    }

    public void Update(Category category)
    {
        var model = Context.Categories.Attach(category);
        model.State = EntityState.Modified;
    }
}