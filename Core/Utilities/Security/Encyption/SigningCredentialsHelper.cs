using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey secutiryKey)
        {
            return new SigningCredentials(secutiryKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
