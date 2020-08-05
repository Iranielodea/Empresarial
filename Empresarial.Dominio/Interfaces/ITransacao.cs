namespace Empresarial.Dominio.Interfaces
{
    public interface ITransacao
    {
        void BeginTransaction();
        void Commit();
        void RoolBack();
        void SaveChanges();
    }
}
