using NS.Clientes.API.Data;

namespace NS.Cliente.API.Configuration
{
    public static class ExistingDb
    {
        public static void DbIsExisting(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ClientsContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}
