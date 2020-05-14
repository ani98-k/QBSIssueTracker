using JWT;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QBSIssueTrackerAPI
{
    public  class TokenAPI
    {
        public static Boolean CheckTokenValidation(string token)
        {
            
            var tokenAccess = Convert.ToString(Xamarin.Forms.Application.Current.Properties["token"]);
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
            if (tokenAccess!=null)
            {
                var json = decoder.DecodeToObject(tokenAccess);
                if (json.TryGetValue("exp", out object expiryObj))
                {
                    var exp = Convert.ToInt32(expiryObj);
                    var date = DateTimeOffset.FromUnixTimeSeconds(exp).DateTime;
                    if (date <= DateTime.Now)
                    {
                        return false;
                    }
                    return true;

                }
                else
                {
                    throw new Exception("");
                }
            }
            throw new Exception();
        }
    }
}
