using System.Threading.Tasks;
using api.Interfaces;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get;}
        IMessageRepository MessageRepository {get;}
        IInviteRepository InviteRepository {get;}
        IClubRepository ClubRepository {get;}
        IEventRepository EventRepository {get; }
        IBlogRepository BlogRepository {get; }
        IBlogCommentRepository BlogCommentRepository {get;}
        Task<bool> Complete();
        bool HasChanges();
    }
}