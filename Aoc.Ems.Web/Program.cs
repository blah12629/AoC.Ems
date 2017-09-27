using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Aoc.Ems.Web
{
    public class Program
    {
        public static void Main(String[] args) => BuildWebHost(args).Run();
        public static IWebHost BuildWebHost(String[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
