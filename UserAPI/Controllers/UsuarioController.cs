using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserAPI.Model;
using UserAPI.Repository;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Produces(typeof(Usuario))]
        public IActionResult Get()
        {
            var usuarios = _usuarioRepository.GetAll();
            if (usuarios.Count() == 0)
                return NoContent();
            return Ok(usuarios);
        }

    }
}
