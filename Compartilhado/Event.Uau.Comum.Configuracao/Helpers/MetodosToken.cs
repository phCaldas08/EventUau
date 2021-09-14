using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Event.Uau.Comum.Configuracao.Helpers
{
    public static class MetodosToken
    {

        public static int? ConsultarId(this string token)
        {
            int? id = null;

            if (!string.IsNullOrWhiteSpace(token))
            {
                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken tokenS = handler.ReadToken(token) as JwtSecurityToken;

                if (int.TryParse(tokenS.Claims.FirstOrDefault(claim => claim.Type == "Sid").Value, out int _id))
                    id = _id;
            }

            return id;
        }

    }
}
