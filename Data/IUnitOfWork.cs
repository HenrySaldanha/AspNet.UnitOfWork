namespace AspNet.UnitOfWork.Data;

public interface IUnitOfWork
{
    public void Commit();
    public void Rollback();
}
