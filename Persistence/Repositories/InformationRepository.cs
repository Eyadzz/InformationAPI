using Application.DTOs;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class InformationRepository : BaseRepository<Information>, IInformationRepository
{
    public InformationRepository(ApplicationDbContext context) : base(context) {}

    public async Task<InfoDTO> GetInformationWithCategory(int informationId)
    {
        var result = await Context.Information.
            Join(Context.Categories,
                i => i.CategoryId, c => c.CategoryId,
                (i, c) => new InfoDTO { InformationId = i.InformationId, Text = i.Text, CategoryId = i.CategoryId, CategoryName = c.Name })
            .SingleOrDefaultAsync(x => x.InformationId == informationId);
        
        return result!;
    }
    
    public List<string?> GetByCategory(int categoryName)
    {
        return Context.Information.Where(x => x.CategoryId == categoryName)
            .Select(x => x.Text).ToList();
    }
}