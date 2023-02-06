using LocacaoImoveisAPI.Application;
using LocacaoImoveisAPI.Domain.Dtos;
using LocacaoImoveisAPI.Domain.Repository;
using LocacaoImoveisAPI.Domain.Service;
using LocacaoImoveisAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace LocacaoImoveisAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Registro do pacote Swagger

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "LocacaoImoveisAPI", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            // Classe de conexão
            // Acesse os valores do arquivo por meio de AppConnections.ConnectionsReader

            string cnn = this.Configuration.GetConnectionString("SqlConnectionString");
            services.AddDbContext<Context>(options => options.UseSqlServer(cnn));

            services.AddSingleton<IImovelRepository, ImovelRepository>();
            services.AddSingleton<IEnderecoRepository, EnderecoRepository>();
            services.AddSingleton<IHttpFactory, HttpFactory>();
            services.AddSingleton<IService, Service>();

            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

            //Adicionado campo para se evitar que campos nulos sejam retornado como resposa na API
            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.IgnoreNullValues = true);

            services.Configure<ConnStrings>(Configuration.GetSection("ConnectionStrings"));
            ConnStrings connStrings = Configuration.GetSection("ConnectionStrings").Get<ConnStrings>();
            services.AddSingleton<ConnStrings>(connStrings);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Swagger
            app.UseSwagger();

            // Indica o endpoint do swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiCadastraDados v1");
                c.RoutePrefix = "swagger";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
