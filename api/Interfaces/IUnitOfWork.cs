using System.Threading.Tasks;
using api.Interfaces;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get;}
        IMessageRepository MessageRepository {get;}
        IPhotoRepository PhotoRepository {get;}
        IInviteRepository InviteRepository {get;}
        IClubRepository ClubRepository {get;}
        IEventRepository EventRepository {get; }
        IBlogRepository BlogRepository {get; }
        IBlogCommentRepository BlogCommentRepository {get;}
        IFollowRepository FollowRepository {get; }
        IClubCommentRepository ClubCommentRepository {get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}