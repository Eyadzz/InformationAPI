using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class InformationRepository : BaseRepository<Information>, IInformationRepository
{
    public InformationRepository(ApplicationDbContext context) : base(context) {}

    public async Task<Information> GetInformationWithCategory(int informationId)
    {
        var result = await Context.Information.Include(c => c.Category)
            .SingleOrDefaultAsync(x => x.InformationId == informationId);
        
        return result!;
    }

    public async Task<Information> Add(Information information)
    {
        await Context.Information.AddAsync(information);
        return information;
    }

    public List<string?> GetByCategory(int categoryName)
    {
        return Context.Information.Where(x => x.CategoryId == categoryName)
            .Select(x => x.Text).ToList();
    }
}