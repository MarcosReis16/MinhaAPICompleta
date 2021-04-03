using AutoMapper;
using DevIO.Api.Controllers;
using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevIO.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{versioin:apiVersion}/teste")]
    public class TesteController : MainController
    {

        private readonly ILogger _logger;

        public TesteController(IMapper mapper, INotificador notificador, IUser appUser,
                               ILogger<TesteController> logger) : base(mapper, notificador, appUser)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Valor()
        {
            _logger.LogTrace("Log de Trace"); //Marcar início e finalização de um processo - Desabilitado por default no ASP Net Core
            _logger.LogDebug("Log de Debug");//Parar debug
            _logger.LogInformation("Log de Informação"); //Marca qualquer informação que não seja importante mas quer registrar
            _logger.LogWarning("Log de Aviso"); //Marca um aviso, algo que não é um erro mas não deveria acontecer
            _logger.LogError("Log de Erro"); // Marca um erro
            _logger.LogCritical("Log de Problema Crítico"); //Marca um erro com um nível mais importante que um erro comum, algo que não deveria acontecer

            return "Sou a V2";
        }

    }
}
