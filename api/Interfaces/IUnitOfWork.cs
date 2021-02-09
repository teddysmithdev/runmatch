using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get;}
        IMessageRepository MessageRepository {get;}
        IInviteRepository InviteRepository {get;}
        Task<bool> Complete();
        bool HasChanges();
    }
}