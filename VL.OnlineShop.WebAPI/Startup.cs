using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.Infrastructure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VL.OnlineShop.WebAPI.Authorization;

namespace VL.OnlineShop.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var xmlPath = Path.Combine(basePath, "VL.OnlineShop.WebAPI.xml");
                c.IncludeXmlComments(xmlPath);
            });

            //Auth2.0 
            services.AddIdentity<ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>();
            services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(schema =>
                {
                    schema.LoginPath = new Microsoft.AspNetCore.Http.PathString("/login");
                    schema.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/logout");
                    schema.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/denied");
                    schema.SlidingExpiration = false;
                    schema.CookieManager = new Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager();
                    schema.Cookie.Name = "vl_access_token";
                    schema.Cookie.HttpOnly = false;
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Over16", policy => policy.Requirements.Add(new MinimumAgeRequirement(21)));
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //尚未解析具体的机制
            app.UseAuthentication();
            app.Map("/login", builder =>
            {
                builder.Run(async context =>
                {
                    //测试快捷地址
                    //https://localhost:44360/login?name=vlong638&password=701616
                    var name = context.Request.Query["name"];
                    var password = context.Request.Query["password"];
                    if (name == "vlong638" && password == "701616")
                    {
                        var claims = new List<System.Security.Claims.Claim>() {
                            new System.Security.Claims.Claim(ClaimTypes.Name,name),
                            new System.Security.Claims.Claim(ClaimTypes.Role,"Admin"),
                        };
                        var identity = new System.Security.Claims.ClaimsIdentity(claims, "password");
                        var principal = new System.Security.Claims.ClaimsPrincipal(identity);
                        await context.SignInAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    }
                    else
                    {
                        await context.SignOutAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
                    }
                });
            });

            app.UseHttpsRedirection();
            app.UseMvc();

            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }

    //过时弃用
    //public class CookieAuthMiddleware
    //{
    //    public static Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions GetOptions()
    //    {
    //        var option = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions
    //        {
    //            //AutomaticAuthenticate = true,
    //            //AutomaticChallenge = true,
    //            LoginPath = new Microsoft.AspNetCore.Http.PathString("/login"),
    //            LogoutPath = new Microsoft.AspNetCore.Http.PathString("/logout"),
    //            AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/denied"),
    //            SlidingExpiration = true,
    //            CookieManager = new Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager()
    //        };
    //        option.Cookie.Name = "wings_access_token";
    //        option.Cookie.HttpOnly = false;
    //        return option;
    //    }
    //}
    public static class IdentityExtension
    {
        public static string FullName(this System.Security.Principal.IIdentity identity)
        {
            var claim = ((System.Security.Claims.ClaimsIdentity)identity).FindFirst("name");
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string Role(this System.Security.Principal.IIdentity identity)
        {
            var claim = ((System.Security.Claims.ClaimsIdentity)identity).FindFirst("role");
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
