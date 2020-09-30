using System.Collections.Generic;
using System.Linq;
using UserAPI.Context;
using UserAPI.Model;

namespace UserAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _usuarioDbContext;

        public UsuarioRepository(UsuarioDbContext usuarioDbContext)
        {
            this._usuarioDbContext = usuarioDbContext;
        }
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioDbContext.Usuarios.ToList();
        }
    }
}
