using System.Threading.Tasks;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}