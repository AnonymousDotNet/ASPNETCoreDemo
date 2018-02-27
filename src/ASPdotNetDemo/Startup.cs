using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASPdotNetDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                //下面这行代码用来响应该应用程序发出的每个HTTP请求，这里它仅响应“Helle world!”
                //await context.Response.WriteAsync("Hello World!");
                
                await context.Response.WriteAsync(DateTime.Now.ToString());

                //ASP.NET可以监视文件系统，能做到部署之后可以直接在文件代码中修改后，然后直接刷新浏览器就可以做到更新，修改可以用txt代开文件然后修改，也可以直接用VS Core 打开项目修改
                //这种算是热更新吧？这个概念也还没确定是不是，大概就是这样吧！

            });

            //UseMvc目测是dotNetCoreApp version = v1.0版本才有的，添加之后才可以
            //这个还不行，不理解
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
