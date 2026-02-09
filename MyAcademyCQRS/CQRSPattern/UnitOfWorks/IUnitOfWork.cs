namespace MyAcademyCQRS.CQRSPattern.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
