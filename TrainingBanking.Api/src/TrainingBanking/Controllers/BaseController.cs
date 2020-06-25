using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingBanking.Domain.Context;
using TrainingBanking.Shared.Commands.Contracts;
using TrainingBanking.Shared.Notifications.Contracts;

namespace TrainingBanking.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/[controller]")]
    public class BaseController : Controller
    {
        private readonly INotifications _notifications;
        private readonly IUnitOfWork _unitOfWork;
        public BaseController(INotifications notifications, IUnitOfWork unitOfWork)
        {
            _notifications = notifications;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult<TResponse>> Execute<TRequest, TResponse>(ICommand<TRequest, TResponse> command, TRequest request) where TRequest : class where TResponse : class
        {
            try
            {
                var result = (dynamic)await command.Execute(request);
                if (result.Errors != null && result.Errors.Count > 0)
                {
                    return StatusCode(400, result);
                }
                await _unitOfWork.Commit();
                return result;
            }
            catch (Exception e)
            {
                
                //todo: rotina de log
                Console.WriteLine(e);

                await _unitOfWork.Rollback();

                _notifications.Add("Ocorreu um erro inesperado");

                return StatusCode(500, (dynamic)new
                {
                    Errors = _notifications.Notifications
                });
            }
        }

        public async Task<ActionResult<TResponse>> Query<TRequest, TResponse>(ICommand<TRequest, TResponse> command, TRequest request) where TRequest : class where TResponse : class
        {
            try
            {
                var result = (dynamic)await command.Execute(request);
                if (result.Errors != null && result.Errors.Count > 0)
                {
                    return StatusCode(400, result);
                }
                return result;
            }
            catch (Exception e)
            {

                //todo: rotina de log
                Console.WriteLine(e);

                _notifications.Add("Ocorreu um erro inesperado");

                return StatusCode(500, (dynamic)new
                {
                    Errors = _notifications.Notifications
                });
            }
        }
    }
}
