namespace Customerize.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        void Commit();
    }
}
