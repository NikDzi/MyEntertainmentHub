using System.Threading.Tasks;
using ClassLibrary1.Model;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.ViewModels;
using ClassLibrary1.Model;

namespace WebApplication1.Hubs
{
    public class MyHub : Hub
    {
        public Task SendMessage(Comments message)
        {
            AddCommentVM cmnt = new AddCommentVM()
            {
                CommentContent = message.CommentContent,
                CommentID = message.CommentID,
                DateOfCreation = message.DateOfCreation,
                MediaID = message.MediaID,
                Reports = 0,
                RUIDS = null,
                UserID = message.UserID,
                User = message.User,

            };
            
            return Clients.All.SendAsync("recievemessage", cmnt); 
        }
    }
}