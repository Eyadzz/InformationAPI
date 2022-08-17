using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext Context;

    public BaseRepository(ApplicationDbContext context)
    {
        Context = context;
    }
    public async Task<T> Create(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<T> Get(int id)
    {
        var result = await Context.Set<T>().FindAsync(id);
        return result!;
    }
}