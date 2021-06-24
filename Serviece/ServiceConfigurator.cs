using Microsoft.Extensions.DependencyInjection;
using Serviece.CartServices;

namespace Servieces
{
    public  static  class ProductConfigurator
    {
        public static void ConfigureServices(this ServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();
        }
    }
}
