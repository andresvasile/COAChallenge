using System.Collections.Generic;
using System.Threading.Tasks;
using COAChallenge.Entidades;

namespace COAChallenge.Datos.Repositorios
{
    public interface IRepositorioUsuario
    {
        Task<IEnumerable<Usuario>> GetAll();

        Task<Usuario> GetById(int id);

        Task<Usuario> Add(Usuario Usuario);

        Task<Usuario> Update(Usuario Usuario);

        Task<Usuario> Delete(int id);
    }
}