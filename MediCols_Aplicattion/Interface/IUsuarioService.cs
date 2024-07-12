using MediCols_Domain.Entity;

namespace MediCols_Aplicattion.Interface
{
    public interface  IUsuarioService
    {
        public Task<int> GetUsuario(Usuario datosUsuario);
        public dynamic ValidateUsuario(Usuario datosUsuario);
    }
}
