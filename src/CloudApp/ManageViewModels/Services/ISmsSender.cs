using System.Threading.Tasks;

namespace CloudApp.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
