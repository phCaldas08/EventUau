using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Evento.Commands.CriarEvento;
using Event.Uau.Evento.Core.Evento.Queries.BuscaEventoPorId;
using Event.Uau.Evento.Core.Evento.Queries.ListarEventos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Evento.API.Controllers
{
    [Route("api/eventos/{idEvento}/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class FuncionariosController : BaseController
    {
    }
}
