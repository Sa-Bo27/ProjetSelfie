using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Repository;

namespace SelfieAWookie.ExtensionMethods
{
    public static class DIMethods
    {
        /// <summary>
        /// prepare la customisation de la dependency Injection
        /// </summary>
        /// 
         
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();

        }
    }
}
