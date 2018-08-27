using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alpha.Repositories;
using alpha.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace alpha
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IMealService, MealService>();

            services.AddScoped(typeof(IRepository<>), typeof(CassandraRepository<>));


            //Cassandra config
            //create single instance of connection builder, then for each request, create a session, which feed the mapper
            //the mapper is configured with MappingConfiguration and customized ShoppingCartMappings
            services.AddSingleton<Cassandra.ICluster>((t) => Cassandra.Cluster.Builder().AddContactPoint("localhost").Build());
            services.AddScoped<Cassandra.ISession>((t) => t.GetService<Cassandra.ICluster>().Connect("shoppingcart"));
            services.AddScoped<Cassandra.Mapping.IMapper, Cassandra.Mapping.Mapper>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Alpha.ShoppingCart", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Cassandra.Mapping.MappingConfiguration.Global.Define<ShoppingCartMappings>();

            app.UseMvc(routes=>{
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}"
                );
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping Cart");
                c.RoutePrefix = string.Empty;
            });

      
        }
    }
}
