using System.Collections.Generic;
using UserAPI.Model;

namespace UserAPI.Repository
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
    }
}
