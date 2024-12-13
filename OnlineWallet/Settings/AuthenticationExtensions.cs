using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace OnlineWallet.Settings
{
    public static class AuthenticationExtensions
    {
        public static void ConfigureAuthentication(this IServiceCollection services, string secretKey)
        {
            var key = Encoding.UTF8.GetBytes(secretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var cookie = context.Request.Cookies["auth_token"];
                        if(!string.IsNullOrEmpty(cookie))
                        {
                            context.Token = cookie;
                        }

                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}