using MediCols_Aplicattion.Interface;
using MediCols_Domain.Entity;
using MediCols_Infrastructure.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MediCols_Aplicattion.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration config)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = config;
        }
        public async Task<int> GetUsuario(Usuario datosUsuario)
        {
            int respuesta = await _usuarioRepository.GetUsuario(datosUsuario);
            return respuesta;
        }

        public  dynamic ValidateUsuario(Usuario datosUsuario)
        {
            if (datosUsuario.Usuari != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                string secretKey = _configuration.GetSection("SettingsToken")["SecretKey"];
                var byteKey = Encoding.UTF8.GetBytes(secretKey);
                var tokenDes = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                         new Claim(ClaimTypes.Name, datosUsuario.Usuari),

                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDes);
                return new 
                {
                    expirationDate = (DateTime)tokenDes.Expires,
                    message = "Token generado exitosamente.",
                    token = tokenHandler.WriteToken(token)
                };
            }
            else
            {
                return new
                {
                    expirationDate ="",
                    message = "Token generado no exitosamente.",
                    token = ""
                };
            }
        }

    }
}
