using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COAChallenge.Entidades;
using Microsoft.EntityFrameworkCore;

namespace COAChallenge.Datos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private AppDbContext _contexto { get; set; }

        public RepositorioUsuario(AppDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _contexto.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetById(int id)
        {
            var usuario = await _contexto.Usuarios.SingleOrDefaultAsync(x => x.Id == id);

            if (usuario == null) return null;

            return usuario;
        }

        public async Task<Usuario> Add(Usuario usuario)
        {
            var usuarioValidar = await GetById(usuario.Id);

            if (usuarioValidar == null)
            {
                var usuarioValido  = await _contexto.Usuarios.AddAsync(usuario);

                await Guardar();

                return usuarioValido.Entity;

            }
            return null;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {

            var validarUsuario = _contexto.Usuarios.Any(x => x.Nombre == usuario.Nombre 
                                                             || x.Email == usuario.Email 
                                                             || x.Telefono == usuario.Telefono);

            if (validarUsuario) return null;

            var usuarioExistente = await GetById(usuario.Id);

            usuarioExistente.Email = usuario.Email ?? usuarioExistente.Email;
            usuarioExistente.Nombre = usuario.Nombre ?? usuarioExistente.Nombre;
            usuarioExistente.Telefono = usuario.Telefono ?? usuarioExistente.Telefono;

            var usuarioActualizado =  _contexto.Usuarios.Update(usuarioExistente);

            await Guardar();

            return usuarioActualizado.Entity;

        }

        public async Task<Usuario> Delete(int id)
        {
            var usuarioExistente = await GetById(id);

            if (usuarioExistente == null) return null;

            _contexto.Usuarios.Remove(usuarioExistente);

            await Guardar();

            return usuarioExistente;

        }

        public async Task Guardar()
        {
            await _contexto.SaveChangesAsync();
        }
    }
}