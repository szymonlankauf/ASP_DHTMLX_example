using System;
using System.Collections.Generic;
using System.Linq;
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
        }
        
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

            string connetionString = "Data Source=localhost;Initial Catalog=PersonalDB;User ID=SA;Password=qqqqqqQ1";
            string sql = "SELECT * FROM Inventory FOR XML RAW";

            try
            {
                string response = this.ConnectAndGetResponse(connetionString, sql);

                app.Run(async (context) => { await context.Response.WriteAsync(response); });
            }
            catch (Exception ex)
            {
//        Console.WriteLine("Can not open connection! ");
                app.Run(async (context) => { await context.Response.WriteAsync("Can not open connection! "); });
            }
            
        }
    }
}