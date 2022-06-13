using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;


namespace CMS_Training {
    /// <summary>
    /// 入口類別
    /// </summary>
    public class Program {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Args"></param>
        public static void Main(string[] _Args) {
            CreateHostBuilder(_Args).Build().Run();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] _Args) =>
            // 可以定義Kestrel Server (IP與Port)
            // 預設為localhost:5000
            Host.CreateDefaultBuilder(_Args)
                // Lamda語法與ArrorFunction
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel((Context, ServerOptions) => {
                        ServerOptions.Listen(IPAddress.Any, 5000);
                        ServerOptions.Limits.MaxConcurrentConnections = 10 * 10 * 1024;
                        ServerOptions.Limits.MaxConcurrentUpgradedConnections = 10 * 1024;
                        ServerOptions.Limits.MaxRequestBodySize = 100 * 1024 * 1024; // 100MB，系統預設30MB
                        ServerOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
                        ServerOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(10);
                    });
                });
    }
}