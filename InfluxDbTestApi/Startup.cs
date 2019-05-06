using Autofac;
using Autofac.Extensions.DependencyInjection;
using InfluxDb.Lib.Models;
using InfluxDbTestApi.SwaggerHelp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using NLog.Web;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InfluxDbTestApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        public Autofac.IContainer ApplicationContainer { get; private set; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                //配置tojson格式配置 DefaultContractResolver 为和后台属性名保持一致（即：后台属性名为OrderName，前端js获得属性名也为OrderName）
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //修改为CamelCasePropertyNamesContractResolver，为js的驼峰格式，即abp默认格式（即：后台属性名为OrderName，前端js获得属性名为orderName）
                //options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            #region Swagger
            services.AddSwaggerGen((obj) =>
            {
                obj.SwaggerDoc("v1", new Info()
                {
                    Version = "v1",
                    Title = "EFTest",
                    Description = "EFTestApi",
                });
                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();
                var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };
                obj.AddSecurityRequirement(security);//添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称要一致，这里是Bearer。

                obj.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",
                    Type = "apiKey",
                    In = "header",
                    Name = "Authorization"
                });
                //obj.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath,
                //   "Db.SqlServer.xml"));
                obj.DescribeStringEnumsInCamelCase();
                //添加对控制器的标签(描述)
                obj.DocumentFilter<SwaggerDocTag>();
            });
            #endregion

            #region 跨域请求配置
            services.AddCors(option =>
                {
                    option.AddPolicy("all", policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                        policy.AllowCredentials();
                        policy.AllowAnyOrigin();
                    });
                });
            #endregion
            
            #region InfluxDb
            services.Configure<InfluxDbModel>(Configuration.GetSection("InfluxDbModelStrings"));
            #endregion InfluxDb

            #region Autofac
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName() { Name = "InfluxDb.Lib" }))
                   .Where(w => w.Name.EndsWith("Service", StringComparison.CurrentCulture))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.Populate(services);

            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
            #endregion
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseCors("all");

            app.UseMvc();

            #region swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EntityFrameWork_Api");
            });
            #endregion
        }
    }
}
