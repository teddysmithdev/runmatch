using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get;}
        IMessageRepository MessageRepository {get;}
        IInviteRepository InviteRepository {get;}
        IClubRepository ClubRepository {get;}
        IEventRepository EventRepository {get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}