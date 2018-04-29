using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
        }
        
        // Appdend "Content-Type: application/xml" header
        private void addHeader(IApplicationBuilder app)
        {
            app.Use(async (context, nextMiddleware) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("Content-Type", "application/xml");
//                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    return Task.FromResult(0);
                });
                await nextMiddleware();
            });
        }
        
        // create string with response from data readere
        private static string WriteResponse(SqlDataReader dataReader)
        {
            string response = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><root>";

            while (dataReader.Read())
            {
                response += dataReader.GetValue(0);
            }

            response += "</root>";

            return response;
        }
        
        // establish connection and get result of execution of sql with additional xml tags 
        private string ConnectAndGetResponse(string connetionString, string sql)
        {
            SqlConnection connection = new SqlConnection(connetionString);

            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            string response = WriteResponse(dataReader);

            connection.Close();

            return response;
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(builder =>
                builder.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                );

            string connetionString = "Data Source=localhost;Initial Catalog=PersonalDB;User ID=SA;Password=qqqqqqQ1";
            string sql = "SELECT id AS cell, firstName AS cell, lastName AS cell, pesel AS cell FROM Inventory AS row FOR XML AUTO, ROOT('rows'), ELEMENTS";

            try
            {
                this.addHeader(app);
                string response = this.ConnectAndGetResponse(connetionString, sql);

                
                app.MapWhen(context => context.Request.Method == "PUT", mapApp =>
                {
                    mapApp.Run(async context =>
                    {
                        await context.Response.WriteAsync("Hello World!");
                    });
                });
                
                app.Run(async (context) => { await context.Response.WriteAsync(response); });
            }
            catch (Exception ex)
            {
                app.Run(async (context) => { await context.Response.WriteAsync("Can not open connection! "); });
            }
            
        }
    }
}