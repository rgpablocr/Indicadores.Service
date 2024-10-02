using Indicadores.Model;
using Indicadores.Model.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.DA.Interface
{
    public interface ITokenUsuarioDA
    {
        Task<Respuesta<TokenUsuario>> AutenticarUsuario(TokenUsuario tokenUsuario);
    }
}
