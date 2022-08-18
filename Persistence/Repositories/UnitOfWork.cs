using Application.Interfaces;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Categories = new CategoryRepository(context);
        Information = new InformationRepository(context);
    }
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
    public ICategoryRepository Categories { get; }
    public IInformationRepository Information { get; }
   
}