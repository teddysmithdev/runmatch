using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using API.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public UnitOfWork(DataContext context, IMapper mapper, IPhotoService photoService)
        {
            _photoService = photoService;
            _context = context;
            _mapper = mapper;
        }

        public IUserRepository UserRepository => new UserRepository(_context, _mapper);
        public IMessageRepository MessageRepository => new MessageRepository(_context, _mapper);
        public IPhotoRepository PhotoRepository => new PhotoRepository(_context, _photoService);
        public IInviteRepository InviteRepository => new InviteRepository(_context);
        public IClubRepository ClubRepository => new ClubRepository(_context, _mapper);
        public IEventRepository EventRepository => new EventRepository(_context, _mapper);
        public IBlogRepository BlogRepository => new BlogRepository(_context, _mapper);
        public IBlogCommentRepository BlogCommentRepository => new BlogCommentRepository(_context, _mapper);
        public IFollowRepository FollowRepository => new FollowerRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}