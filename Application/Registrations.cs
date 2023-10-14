using Infrastructure.InterfaceRepositories;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class Registrations
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            
            return services;
        }
    }
}
