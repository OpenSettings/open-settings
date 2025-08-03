using System.IdentityModel.Tokens.Jwt;

namespace OpenSettings.Services
{
    internal abstract class TokenServiceBase
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        protected TokenServiceBase(JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }

        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            return _jwtSecurityTokenHandler.ReadJwtToken(accessToken);
        }

        public string WriteJwtToken(JwtSecurityToken jwtSecurityToken)
        {
            return _jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}