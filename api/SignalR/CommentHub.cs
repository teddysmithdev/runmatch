using System;
using System.Threading.Tasks;
using api.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace api.SignalR
{
    public class CommentHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var clubId = httpContext.Request.Query["clubId"];
        await Groups.AddToGroupAsync(Context.ConnectionId, clubId);
        var result = await _unitOfWork.ClubCommentRepository.GetAllAsync(Int32.Parse(clubId));
        await Clients.Caller.SendAsync("LoadComments", result);
    }
    public async Task SendComment(ClubCommentDto clubCommentDto)
    {
        
    }


    
    }
}