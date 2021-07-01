using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace spm_group
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //define o uso de controllers
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    // Ignora os loopings nas consultas
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    // Ignora valores nulos ao fazer jun��es nas consultas
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // CORS =========
            // Adiciona o CORS ao projeto
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:19006")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    }
                );
            });
            // ========= CORS


            // adiciona o serviço do swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "spm_group", Version = "v1"});


                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            }
                
                
                );

            services
                .AddAuthentication(options =>
                {

                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";

                })

                //define os parametros da validacao do token  
                .AddJwtBearer("JwtBearer", options =>
                {

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //quem esta emitindo
                        ValidateIssuer = true,

                        //quem esta recebendo esse token
                        ValidateAudience = true,

                        //se vai validar o tempo de expiração ou não
                        ValidateLifetime = true,

                        //como foi a forma de cliptografia e a chave de autenticação
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmg-seguranca-login")),

                        //tempo de expiração do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        //Nome do issuer, de onde esta vindo
                        ValidIssuer = "SPMG.WEBAPI",

                        //nome do audience, e para onde está indo
                        ValidAudience = "SPMG.WEBAPI"


                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "spm_group");
            });
            //Habilita a autenticação
            app.UseAuthentication();

            //Habilita a autorização
            app.UseAuthorization();

            // Define o uso de CORS
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {    
                   //define o mapeamento dos controllers
                    endpoints.MapControllers();
                });
            }
        }
    }

