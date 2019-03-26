using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Novovita.by.Services
{
    public class Statics
    {
        public static IConfiguration Configuration { get; set; }

        public static IHostingEnvironment Environment { get; set; }

        public static string WebRootPath { get; set; }
    }
}
