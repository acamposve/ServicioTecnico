using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
namespace WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddMyGraphQLServer(this IServiceCollection services) {
            services.AddGraphQLServer().AddQueryType(q=>q.Name("TecnicService"))
                .AddTypeExtension<QueryTypes.CustomerQueryType>()
                .AddProjections()
                .AddFiltering();
        }
    }
}
