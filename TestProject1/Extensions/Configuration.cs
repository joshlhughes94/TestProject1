using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Extensions
{
    public static class Configuration
    {
        public static string ShadyMeadowsBedBreakfastUrl(this IConfiguration config)
        {
            return config.GetValue<string>("ShadyMeadowsBedBreakfastUrl");
        }
    }
}
