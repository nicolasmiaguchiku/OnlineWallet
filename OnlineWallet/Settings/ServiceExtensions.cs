using Microsoft.EntityFrameworkCore;
using OnlineWallet.Context;
using OnlineWallet.Interfaces;
using OnlineWallet.Services;

namespace OnlineWallet.Settings
{
    public static class ServiceExtensions
    {
        public static void ConfigureDataBase(this IServiceCollection services, IConfiguration confguration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(confguration.GetConnectionString("StringPadrao"));
            });
        }

        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddScoped<SecuritySevices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ITransactionServices, TransactionsServices>();
        }
    }
}
