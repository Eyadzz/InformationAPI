namespace Application.Interfaces;

public interface IUnitOfWork
{
    public ICategoryRepository Categories { get; }
    public IInformationRepository Information { get;}
    Task Save();
}