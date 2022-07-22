

using DevIO.Business.Interfaces;

namespace DevIO.Api.Controllers
{
    public class AuthController : MainController
    {
        public AuthController(INotificador notificador) : base(notificador)
        {
        }
    }
}
