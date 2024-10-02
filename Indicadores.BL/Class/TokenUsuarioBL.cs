using Indicadores.DA.Interface;
using Indicadores.Model.Auth;
using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.BL.Class
{
    public class TokenUsuarioBL
    {
        public ITokenUsuarioDA tokenUsuarioDA;

        public TokenUsuarioBL(ITokenUsuarioDA tokenUsuarioDA)
        {
            this.tokenUsuarioDA = tokenUsuarioDA;
        }

        public async Task<Respuesta<TokenUsuario>> AutenticarUsuario(TokenUsuario tokenUsuario)
        {
            return await tokenUsuarioDA.AutenticarUsuario(tokenUsuario);
        }

    }
}
