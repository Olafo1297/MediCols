using MediCols_Domain.Entity;

namespace MediCols_Infrastructure.Interface
{
    public interface IUsuarioRepository
    {
        public Task<int> GetUsuario(Usuario datosUsuario);

        public Task<int> CreateUsuario(Usuario datosUsuario);
    }
}
